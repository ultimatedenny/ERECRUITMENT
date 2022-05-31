using BaseFormLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeleSharp.TL;
using TeleSharp.TL.Contacts;
using TLSharp.Core;
using ERECRUITMENT_BROADCASTER.Model;
using TLSharp.Core.Utils;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;
using ZXing.Rendering;
using System.Drawing.Imaging;
using iTextSharp.text.pdf;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;

namespace ERECRUITMENT_BROADCASTER
{
    public partial class WhatsappQontak : _BaseForm
    {
        string access_token = string.Empty;
        string HASH, _FILEPATH;
        List<MQ_WA_Temp_Datum> list_MQ_WA_Temp_Datum = new List<MQ_WA_Temp_Datum>();
        List<MQ_WA_Channel_Datum> list_MQ_WA_Channel_Datum = new List<MQ_WA_Channel_Datum>();
        IList<MQ_WA_Temp_Datum> list_MQ_WA_Temp_Datum2 = new List<MQ_WA_Temp_Datum>();

        List<MQ_WA_CONTACT_Datum> list_MQ_WA_CONTACT_Datum = new List<MQ_WA_CONTACT_Datum>();
        IList<MQ_WA_CONTACT_Datum> list_MQ_WA_CONTACT_Datum2 = new List<MQ_WA_CONTACT_Datum>();

        List<MQ_WA_CONDET_Datum> list_MQ_WA_CONDET_Datum = new List<MQ_WA_CONDET_Datum>();
        IList<MQ_WA_CONDET_Datum> list_MQ_WA_CONDET_Datum2 = new List<MQ_WA_CONDET_Datum>();

        MQ_WA_Temp_Datum model_MQ_WA_Temp_Datum = new MQ_WA_Temp_Datum();
        MQ_WA_Channel_Datum model_MQ_WA_Channel_Datum = new MQ_WA_Channel_Datum();
        int total = 0;
        int final = 0;
        public WhatsappQontak()
        {
            InitializeComponent();
            btn_upload_spreadsheet.Enabled = false;
            openFileDialog1.InitialDirectory = $"{Application.StartupPath}/SampleData";
            openFileDialog1.Title = $"{Application.StartupPath}/SampleData";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;
            checkBox1.Enabled = true;
            LoadMessageSetting();
        }

        public void WhatsappQontak_Load(object sender, EventArgs e)
        {
            
        }

        public void WAQ_btn_connect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        public void btn_single_broadcast_Click(object sender, EventArgs e)
        {
            SendOutBondDirect(access_token);
        }

        public void btn_show_template_Click(object sender, EventArgs e)
        {
            try
            {
                string TEMP_ID = ((KeyValuePair<string, string>)comboBox2.SelectedItem).Key.ToString();
                var LINQ = (from x in list_MQ_WA_Temp_Datum
                            where x.id == TEMP_ID
                            select x).ToList();
                if (LINQ[0].header != null)
                {
                    checkBox1.Checked = true;
                    checkBox1.Enabled = true;
                }
                foreach (MQ_WA_Temp_Datum data in LINQ)
                {
                    string str = data.body.ToString();
                    char ch = '{';
                    total = str.Count(f => (f == ch));
                    final = total / 2;
                    richTextBox2.Text = data.body.ToString() + Environment.NewLine;
                }
                List<ParamList> lists = new List<ParamList>();
                BindingSource Source = new BindingSource();
                for (int i = 0; i < final; i++)
                {
                    ParamList obj = new ParamList();
                    obj.value = "";
                    lists.Add(obj);
                }
                dataGridView_param.DataSource = lists;
            }
            catch (Exception ex)
            {
                ShowError(this.GetCurrentMethod(), ex.Message);
            }
        }

        public void btn_show_contact_Click(object sender, EventArgs e)
        {
            string BatchNo = comboBox6.SelectedItem.ToString();
            BatchNo = BatchNo.Substring(BatchNo.LastIndexOf(",") + 1);
            BatchNo = BatchNo.Replace(" ", "");
            BatchNo = BatchNo.Replace("]", "");
            
            SP_GET_CONTACT_LIST1(BatchNo);
        }

        public void btn_upload_spreadsheet_Click(object sender, EventArgs e)
        {
            PostWAContactList(access_token);
        }

        public void btn_browse_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txt_browse.Text = openFileDialog1.FileName;
                    btn_upload_spreadsheet.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                ShowError(this.GetCurrentMethod(), ex.Message);
            }
        }

        public void ShowError(string Func, string Msg)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[4];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            richTextBox1.AppendText("Error: "+ finalString + "\n" +
                                    "[" + finalString + "] " + Func + "\n" +
                                    "[" + finalString + "] " + Msg + "\n" +
                                    "[" + finalString + "] " + "Time: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +""+ Environment.NewLine);
        }

        public void ShowNotif(string Msg)
        {
            richTextBox1.AppendText(""+ Msg + " - " + "Time: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "" + Environment.NewLine);
        }

        public string GetCurrentMethod()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);
            return sf.GetMethod().Name;
        }

        public async void Connect()
        {
            try
            {
                ShowNotif("Connecting Qontak API");
                var USERNAME = txt_username.Text;
                var PASSWORD = txt_password.Text;
                var CLIENT_ID = txt_client_id.Text;
                var CLIENT_SECRET = txt_client_secret.Text;
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://chat-service.qontak.com/oauth/token"))
                    {
                        string Content = "{\n  \"username\": \"" + USERNAME + "\",\n  \"password\": \"" + PASSWORD + "\",\n  \"grant_type\": \"password\",\n  \"client_id\": \"" + CLIENT_ID + "\",\n  \"client_secret\": \"" + CLIENT_SECRET + "\"\n}";
                        request.Content = new StringContent(Content);
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                        var response = await httpClient.SendAsync(request);
                        response.EnsureSuccessStatusCode();
                        var content = await response.Content.ReadAsStringAsync();
                        MQ_Auth data = JsonConvert.DeserializeObject<MQ_Auth>(content);
                        access_token = data.access_token;
                        var token_type = data.token_type;
                        var expires_in = data.expires_in;
                        var refresh_token = data.refresh_token;
                        var created_at = data.created_at;
                        ShowNotif("Connected");
                        GetWAChannel(access_token);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(this.GetCurrentMethod(), ex.Message);
            }
        }

        public async void GetWAChannel(string access_token)
        {
            try
            {
                ShowNotif("Getting WA Channel");
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://chat-service.qontak.com/api/open/v1/integrations?target_channel=wa&limit=10"))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + access_token + "");
                        var response = await httpClient.SendAsync(request);
                        response.EnsureSuccessStatusCode();
                        var content = await response.Content.ReadAsStringAsync();
                        MQ_WA_Channel_Root datas = JsonConvert.DeserializeObject<MQ_WA_Channel_Root>(content);
                        var status = datas.status;
                        if(status == "success")
                        {
                            if (datas.data.Count > 0)
                            {
                                Dictionary<string, string> ds = new Dictionary<string, string>();
                                foreach (var data in datas.data)
                                {
                                    model_MQ_WA_Channel_Datum.id = data.id;
                                    model_MQ_WA_Channel_Datum.target_channel = data.target_channel;
                                    model_MQ_WA_Channel_Datum.organization_id = data.organization_id;
                                    model_MQ_WA_Channel_Datum.created_at = data.created_at;
                                    //model.settings.account_name  = data.settings.account_name;
                                    //model.settings.authorization = data.settings.authorization;
                                    //model.settings.domain_server = data.settings.domain_server;
                                    //model.settings.server_wa_id  = data.settings.server_wa_id;
                                    list_MQ_WA_Channel_Datum.Add(model_MQ_WA_Channel_Datum);
                                    ds.Add(data.id, data.target_channel);
                                }
                                comboBox1.DataSource = new BindingSource(ds, null);
                                comboBox1.DisplayMember = "Value";
                                comboBox1.ValueMember = "Key";
                                ShowNotif("WA Channel loaded");
                                GetWATemplate(access_token);
                            }
                        }
                        else
                        {
                            ShowError(this.GetCurrentMethod(), status);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ShowError(this.GetCurrentMethod(),ex.Message);
            }
        }

        public async void GetWATemplate(string access_token)
        {
            try
            {
                ShowNotif("Getting WA Template");
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://chat-service.qontak.com/api/open/v1/templates/whatsapp"))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + access_token + "");
                        var response = await httpClient.SendAsync(request);
                        response.EnsureSuccessStatusCode();
                        var content = await response.Content.ReadAsStringAsync();
                        MQ_WA_Temp_Root datas = JsonConvert.DeserializeObject<MQ_WA_Temp_Root>(content);
                        var status = datas.status;
                        if (status == "success")
                        {
                            if (datas.data.Count > 0)
                            {
                                Dictionary<string, string> ds = new Dictionary<string, string>();
                                var list = new List<MQ_WA_Temp_Datum>();
                                foreach (var data in datas.data)
                                {
                                    //model_MQ_WA_Temp_Datum.id = data.id;
                                    //model_MQ_WA_Temp_Datum.name = data.name;
                                    //model_MQ_WA_Temp_Datum.language = data.language;
                                    //model_MQ_WA_Temp_Datum.body = data.body;
                                    //model_MQ_WA_Temp_Datum.status = data.status;
                                    //model_MQ_WA_Temp_Datum.category = data.category;
                                    //list_MQ_WA_Temp_Datum.Add(model_MQ_WA_Temp_Datum);
                                    //list_MQ_WA_Temp_Datum2.Add(model_MQ_WA_Temp_Datum);

                                    var dt = new MQ_WA_Temp_Datum
                                    {
                                        id = data.id,
                                        name = data.name,
                                        language = data.language,
                                        header = data.header,
                                        body = data.body,
                                        status = data.status,
                                        category = data.category,
                                    };

                                    list_MQ_WA_Temp_Datum.Add(dt);
                                    list_MQ_WA_Temp_Datum2.Add(dt);
                                    ds.Add(data.id, data.name);
                                }
                                comboBox2.DataSource = new BindingSource(ds, null);
                                comboBox2.DisplayMember = "Value";
                                comboBox2.ValueMember = "Key";
                                ShowNotif("WA Template loaded");
                                GetWAContactList(access_token);
                            }
                        }
                        else
                        {
                            ShowError(this.GetCurrentMethod(), status);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ShowError(this.GetCurrentMethod(), ex.Message);
            }
        }

        public async void GetWAContactList(string access_token)
        {
            try
            {
                ShowNotif("Getting WA Contact List");
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://chat-service.qontak.com/api/open/v1/contacts/contact_lists"))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + access_token + "");
                        var response = await httpClient.SendAsync(request);
                        response.EnsureSuccessStatusCode();
                        var content = await response.Content.ReadAsStringAsync();
                        MQ_WA_CONTACT_Root datas = JsonConvert.DeserializeObject<MQ_WA_CONTACT_Root>(content);
                        var status = datas.status;
                        if (status == "success")
                        {
                            if (datas.data.Count > 0)
                            {
                                Dictionary<string, string> ds = new Dictionary<string, string>();
                                var list = new List<MQ_WA_CONTACT_Datum>();
                                foreach (var data in datas.data)
                                {
                                    var dt = new MQ_WA_CONTACT_Datum
                                    {
                                        id = data.id,
                                        organization_id = data.organization_id,
                                        name = data.name
                                    };
                                    list_MQ_WA_CONTACT_Datum.Add(dt);
                                    list_MQ_WA_CONTACT_Datum2.Add(dt);
                                    ds.Add(data.id, data.name);
                                }
                                comboBox6.DataSource = new BindingSource(ds, null);
                                comboBox6.DisplayMember = "Value";
                                comboBox6.ValueMember = "Key";
                                ShowNotif("WA Contact List loaded");
                            }
                        }
                        else
                        {
                            ShowError(this.GetCurrentMethod(), status);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(this.GetCurrentMethod(), ex.Message);
            }
        }

        public async void GetWAContactDetail(string access_token)
        {
            try
            {
                ShowNotif("Getting Contact Details");
                using (var httpClient = new HttpClient())
                {
                    var CONTACT_LIST_ID = ((KeyValuePair<string, string>)comboBox6.SelectedItem).Key;
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://chat-service.qontak.com/api/open/v1/contacts/contact_lists/contacts/" + CONTACT_LIST_ID + "?offset=0&limit=100"))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + access_token + "");
                        var response = await httpClient.SendAsync(request);
                        response.EnsureSuccessStatusCode();
                        var content = await response.Content.ReadAsStringAsync();
                        MQ_WA_CONDET_Root datas = JsonConvert.DeserializeObject<MQ_WA_CONDET_Root>(content);
                        var status = datas.status;
                        if (status == "success")
                        {
                            if (datas.data.Count > 0)
                            {
                                var list = new List<MQ_WA_CONDET_Datum>();
                                foreach (var data in datas.data)
                                {
                                    var dt = new MQ_WA_CONDET_Datum
                                    {
                                        id = data.id,
                                        phone_number = data.phone_number,
                                        full_name = data.full_name
                                    };
                                    list_MQ_WA_CONDET_Datum.Add(dt);
                                    list_MQ_WA_CONDET_Datum2.Add(dt);
                                }
                                ShowNotif("Contact Details loaded");
                                dataGridView1.DataSource = list_MQ_WA_CONDET_Datum;
                            }
                            else
                            {
                                ShowError(this.GetCurrentMethod(), "No Data");
                            }
                        }
                        else
                        {
                            ShowError(this.GetCurrentMethod(), status);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ShowError(this.GetCurrentMethod(), ex.Message);
            }
        }

        public async void PostWAContactList(string access_token)
        {
            try
            {
                ShowNotif("Uploading Contact List");
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://chat-service.qontak.com/api/open/v1/contacts/contact_lists/async"))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + access_token + "");
                        var FILE = openFileDialog1.FileName;
                        var stream = File.OpenRead(FILE);
                        var file_content = new ByteArrayContent(new StreamContent(stream).ReadAsByteArrayAsync().Result);
                        file_content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");
                        file_content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                        {
                            FileName = openFileDialog1.SafeFileName,
                            Name = "file",
                        };
                        var multipartContent = new MultipartFormDataContent
                        {
                            { new StringContent("LIST-" + cb_listcontact.SelectedText.ToString()), "name" },
                            { new StringContent("spreadsheet"), "source_type" },
                            { new StringContent("1"), "source_id" },
                            file_content
                        };
                        request.Content = multipartContent;
                        var response = await httpClient.SendAsync(request);
                        var final = await response.Content.ReadAsStringAsync();
                        response.EnsureSuccessStatusCode();
                        if (response.IsSuccessStatusCode)
                        {
                            ShowNotif("Contact List Uploaded");
                            GetWAContactList(access_token);
                        }
                        else
                        {
                            ShowError(this.GetCurrentMethod(), "[" + response.StatusCode.ToString() + "]--" + response.ReasonPhrase.ToString());
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ShowError(this.GetCurrentMethod(), ex.Message);
            }
        }

        public async void SendOutBondDirect(string access_token)
        {
            try
            {
                bool UseHeader = checkBox1.Checked;
                ShowNotif("Sending Message to "+ txt_phone.Text + "");
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://chat-service.qontak.com/api/open/v1/broadcasts/whatsapp/direct"))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + access_token + "");
                        string CHANNEL = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Key;
                        string TEMP_ID = ((KeyValuePair<string, string>)comboBox2.SelectedItem).Key;
                        string PHONE = txt_phone.Text;
                        var param = string.Empty;
                        var body = string.Empty;

                        if (final > 0)
                        {
                            for (int i = 0; i < final; i++)
                            {
                                if ((i + 1) == final)
                                {
                                    param += "{\n        \"key\": \"" + (i + 1) + "\",\n        \"value\": \"full_name" + (i + 1) + "\",\n        \"value_text\": \"" + dataGridView_param.Rows[i].Cells[0].Value.ToString() + "\"\n      }\n";
                                }
                                else
                                {
                                    param += "{\n        \"key\": \"" + (i + 1) + "\",\n        \"value\": \"full_name" + (i + 1) + "\",\n        \"value_text\": \"" + dataGridView_param.Rows[i].Cells[0].Value.ToString() + "\"\n      },\n";
                                }
                            }
                        }
                        else
                        {
                            param += "";
                        }

                        if (UseHeader)
                        {
                            body = "{\n  \"to_name\": \"USER_1\",\n  \"to_number\": \""+ PHONE + "\",\n  \"message_template_id\": \"" + TEMP_ID + "\",\n   \"channel_integration_id\": \"" + CHANNEL + "\",\n  \"language\": {\n    \"code\": \"id\"\n  },\n  \"parameters\": {\n    \"header\": {\n      \"format\": \"IMAGE\",\n      \"params\": [\n        {\n          \"key\": \"url\",\n          \"value\": \"https://www.shimano.com/en/100th/thanks/img/logo.jpg\"\n        },\n        {\n          \"key\": \"logo\",\n          \"value\": \"logo.jpg\"\n        }\n      ]\n    },\n     \"body\": [\n      " + param + "    ]\n  }\n}";
                        }
                        else
                        {
                            body = "{\n  \"to_number\": \"" + PHONE + "\",\n  \"to_name\": \"USER_1\",\n  \"message_template_id\": \"" + TEMP_ID + "\",\n  \"channel_integration_id\": \"" + CHANNEL + "\",\n  \"language\": {\n    \"code\": \"id\"\n  },\n  \"parameters\": {\n    \"body\": [\n      " + param + "    ]\n  }\n}";
                        }

                        request.Content = new StringContent(body);
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                        var response = await httpClient.SendAsync(request);
                        response.EnsureSuccessStatusCode();
                        var content = await response.Content.ReadAsStringAsync();
                        ShowNotif("Sending Message Success");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(this.GetCurrentMethod(), ex.Message);
            }
        }

        public async void SendOutBondBulk(string access_token, string BatchNo, string BatchEmp, string PARAM_1, string PARAM_2)
        {
            try
            {
                bool UseHeader = checkBox1.Checked;
                
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://chat-service.qontak.com/api/open/v1/broadcasts/whatsapp/direct"))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + access_token + "");
                        string CHANNEL = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Key;
                        string TEMP_ID = ((KeyValuePair<string, string>)comboBox2.SelectedItem).Key;
                        string PHONE = PARAM_2.Replace("+", "");
                        var BASEURL = "https://sbm-apps.shimano.id/ERECRUITMENT";
                        string URL_IMG = BASEURL + "/QR-INVITE/" + BatchNo + "/" + BatchEmp + ".png";
                        string URL_INV = BASEURL + "/Mobile/Dashboard/" + BatchEmp;
                        string URL_RPT = BASEURL + "/Mobile/Report/" + BatchEmp;
                        string BATCH_NO = BatchNo;
                        var param = string.Empty;
                        var body = string.Empty;
                        var PARAM_3 = URL_INV;
                        var PARAM_4 = URL_RPT;
                        param += "{\n\"key\": \"1\",\n\"value\": \"p_1\",\n\"value_text\": \"" + PARAM_1 + "\"\n      },\n";
                        param += "{\n\"key\": \"2\",\n\"value\": \"p_2\",\n\"value_text\": \"" + PARAM_2 + "\"\n      }\n";
                        if (UseHeader)
                        {
                            body = "{\n  \"to_name\": \""+ BatchEmp + "\",\n  \"to_number\": \"" + PHONE + "\",\n  \"message_template_id\": \"" + TEMP_ID + "\",\n   \"channel_integration_id\": \"" + CHANNEL + "\",\n  \"language\": {\n    \"code\": \"id\"\n  },\n  \"parameters\": {\n    \"header\": {\n      \"format\": \"IMAGE\",\n      \"params\": [\n        {\n          \"key\": \"url\",\n          \"value\": \""+ URL_IMG + "\"\n        },\n        {\n          \"key\": \"logo\",\n          \"value\": \"logo.jpg\"\n        }\n      ]\n    },\n     \"body\": [\n      " + param + "    ]\n  }\n}";
                        }
                        else
                        {
                            body = "{\n  \"to_number\": \"" + PHONE + "\",\n  \"to_name\": \""+ BatchEmp + "\",\n  \"message_template_id\": \"" + TEMP_ID + "\",\n  \"channel_integration_id\": \"" + CHANNEL + "\",\n  \"language\": {\n    \"code\": \"id\"\n  },\n  \"parameters\": {\n    \"body\": [\n      " + param + "    ]\n  }\n}";
                        }
                        request.Content = new StringContent(body);
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                        var response = await httpClient.SendAsync(request);
                        response.EnsureSuccessStatusCode();
                        var content = await response.Content.ReadAsStringAsync();
                        MQ_WA_DIRECT_Root datas = JsonConvert.DeserializeObject<MQ_WA_DIRECT_Root>(content);
                        var status = datas.status;
                        ShowNotif("Sending Message to "+ BatchEmp + "-[" + PARAM_2.Replace("+", "") + "] " + status.ToUpper());
                    }
                }
                
            }
            catch (Exception ex)
            {
                ShowError(this.GetCurrentMethod(), ex.Message);
            }
        }

        

        public void CREATEQR()
        {
            try
            {
                int STATUS = 0;
                int TOTALROW = dataGridView2.Rows.Count;
                string title = "Action Confirmation";
                string imgdir = textBox_imgdir.Text;
                for (int i = 0; i <= (TOTALROW - 1); i++)
                {
                    if (dataGridView2.Rows[i].Cells[3].Value.ToString() == "" || dataGridView2.Rows[i].Cells[3].Value.ToString() == null)
                    {
                        STATUS = STATUS + 1;
                    }
                }
                int LEFTROW = (TOTALROW) - (STATUS);
                if (STATUS != -1)
                {
                    DialogResult dialogResult = MessageBox.Show("This action will create QR for \n\n" +
                        "" + dataGridView2.Rows[LEFTROW].Cells[0].Value.ToString() + " until " + dataGridView2.Rows[TOTALROW - 1].Cells[0].Value.ToString() + ", \n\n" +
                        "Total QR: " + Convert.ToString(STATUS) + " QR Codes.\n\n" +
                        "are you sure to continue ?", title, MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        ShowNotif("CREATING QR CODE WAS STARTED");
                        string foldername = "\\QR IMAGES";
                        string BatchNo = comboBox6.Text.ToString();
                        string qrpth = imgdir + "\\" + BatchNo + "";
                        if (!Directory.Exists(qrpth))
                        {
                            Directory.CreateDirectory(qrpth);
                        }
                        string date = DateTime.Now.ToString("yyyyMMddHHmmss");
                        for (int i = LEFTROW; i <= TOTALROW - 1; i++)
                        {
                            BarcodeWriter barcodewriters = new BarcodeWriter();
                            EncodingOptions encodingoptions = new EncodingOptions()
                            {
                                Width = 350,
                                Height = 350,
                                Margin = 5,
                                PureBarcode = false
                            };
                            encodingoptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.M);
                            barcodewriters.Renderer = new BitmapRenderer();
                            barcodewriters.Options = encodingoptions;
                            barcodewriters.Format = BarcodeFormat.QR_CODE;
                            string guid = Guid.NewGuid().ToString().ToUpper().Substring(0, 7);

                            Bitmap A4 = new Bitmap(1240, 1240);
                            A4.SetResolution(150, 150);
                            Graphics Master = Graphics.FromImage(A4);
                            Master.Clear(Color.White);
                            Bitmap barcode = barcodewriters.Write("QR-" + dataGridView2.Rows[i].Cells[2].Value.ToString() + "-" + guid + "-" + date);
                            Master.DrawImage(barcode, new Point(670, -10));
                            Bitmap logo = new Bitmap($"{Application.StartupPath}\\" + textBox_logopath.Text);
                            Graphics Detail = Graphics.FromImage(barcode);

                            int PointX = (250 - (747 / 5)) / 2;
                            int PointY = (200 - (194 / 5)) / 2;

                            Master.DrawImage(logo, PointX, PointY, (747 / 5), (194 / 5));
                            string X = dataGridView2.Rows[i].Cells[2].Value.ToString() + "-" + guid + "-" + date;
                            string digits = dataGridView2.Rows[i].Cells[2].Value.ToString().Substring(12);
                            string name = dataGridView2.Rows[i].Cells[0].Value.ToString().ToUpper();
                            string phone = dataGridView2.Rows[i].Cells[1].Value.ToString().ToUpper();

                            string noktp = String.Empty;
                            string titlemsg = textBox_titlemsg.Text.ToUpper();
                            string datemsg = datepicker.Value.ToString("dd-MMMM-yyyy").ToUpper();
                            string datemsg2 = datepicker.Value.ToString("dddd", new CultureInfo("id-ID")).ToUpper();
                            string timemsg = timepicker.Text.ToString();
                            string locmsg = textBox_locmsg.Text.ToUpper();
                            string unimsg = textBox_unimsg.Text.ToUpper();
                            string nohrd = "NO. HRD";

                            string A = ($"{Application.StartupPath}\\" + textBox_logopath.Text).ToString();
                            Font font1 = new Font("JetBrains Mono", 9, FontStyle.Regular);
                            Font font2 = new Font("JetBrains Mono", 9, FontStyle.Bold);

                            var FINAL_STRING = richTextBox3.Text
                               .Replace("[TITLE]", titlemsg)
                               .Replace("[NAME]", "NAMA" + "\t\t" + ":" + name)
                               .Replace("[PHONE]", "NO. HP" + "\t\t" + ":" + phone)
                               .Replace("[DAY]", "HARI" + "\t\t" + ":" + datemsg2)
                               .Replace("[DATE]", "TANGGAL" + "\t" + ":" + datemsg)
                               .Replace("[TIME]", "WAKTU" + "\t\t" + ":" + timemsg)
                               .Replace("[LOCATION]", "LOKASI" + "\t\t" + ":" + locmsg)
                               .Replace("[UNIFORM]", "PAKAIAN" + "\t" + ":" + unimsg) + "\n" + "\n" + nohrd + "\n" + digits;

                            Master.DrawString(FINAL_STRING, font1, Brushes.Black, new Point(50, 150));
                            Master.DrawString("", font2, Brushes.Black, new Point(50, 1190));

                            pictureBox1.Image = A4;
                            string filename = dataGridView2.Rows[i].Cells[2].Value.ToString() + "-" + guid + "-" + date;
                            pictureBox1.Image.Save(qrpth + @"\" + filename + ".png", ImageFormat.Png);
                            _FILEPATH = (Application.StartupPath) + foldername;
                            dataGridView2.Rows[i].Cells[3].Value = filename;
                            SP_UPDATE_INV_CODE(dataGridView2.Rows[i].Cells[2].Value.ToString(), filename);
                            ShowNotif("GENERATING QR [" + (i + 1).ToString() + " OF " + (TOTALROW).ToString() + "], SUCCESS !");
                            Task.Delay(300);
                        }
                        ShowNotif(Convert.ToString(TOTALROW) + "QR CODES HAS BEEN GENERATED !");
                    }
                    else
                    {
                        ShowError(this.GetCurrentMethod(), "CREATING QR CODE WAS CANCELED");
                    }
                }
                else
                {
                    MessageBox.Show("All QR for Batch " + comboBox6.Text + " has been recorded and created, please check QR Image's folder", "Success");
                }
            }
            catch (Exception msg)
            {
                ShowError(this.GetCurrentMethod(), msg.Message);
            }
        }

        public string JustifyLines(string text, Font font, int ControlWidth)
        {
            string result = string.Empty;
            List<string> Paragraphs = new List<string>();
            Paragraphs.AddRange(text.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList());
            foreach (string Paragraph in Paragraphs)
            {
                result += Justify(Paragraph, font, ControlWidth) + "\r\n";
            }
            return result.TrimEnd(new[] { '\r', '\n' });
        }

        private string Justify(string text, Font font, int width)
        {
            char SpaceChar = (char)0x200A;
            List<string> WordsList = text.Split((char)32).ToList();
            if (WordsList.Capacity < 2)
                return text;
            int NumberOfWords = WordsList.Capacity - 1;
            int WordsWidth = TextRenderer.MeasureText(text.Replace(" ", ""), font).Width;
            int SpaceCharWidth = TextRenderer.MeasureText(WordsList[0] + SpaceChar, font).Width - TextRenderer.MeasureText(WordsList[0], font).Width; 
            int AverageSpace = ((width - WordsWidth) / NumberOfWords) / SpaceCharWidth;
            float AdjustSpace = (width - (WordsWidth + (AverageSpace * NumberOfWords * SpaceCharWidth)));
            return ((Func<string>)(() => {
                string Spaces = "";
                string AdjustedWords = "";
                for (int h = 0; h < AverageSpace; h++)
                    Spaces += SpaceChar;
                foreach (string Word in WordsList)
                {
                    AdjustedWords += Word + Spaces;
                    if (AdjustSpace > 0)
                    {
                        AdjustedWords += SpaceChar;
                        AdjustSpace -= SpaceCharWidth;
                    }
                }
                return AdjustedWords.TrimEnd();
            }))();
        }

        

        public void LoadMessageSetting()
        {
            numericUpDown1.Value = Properties.Settings.Default.APP_MSG_DEL;
            textbox_msgformat.Text = Properties.Settings.Default.APP_MSG_FRMT;
            textBox_rptdir.Text = Properties.Settings.Default.APP_RPT_DIR;
            textBox_rptpass.Text = Properties.Settings.Default.APP_RPT_PASS;
            textBox_imgdir.Text = Properties.Settings.Default.APP_IMG_DIR;
            textBox_titlemsg.Text = Properties.Settings.Default.APP_MSG_TTL;
            textBox_locmsg.Text = Properties.Settings.Default.APP_MSG_LOC;
            textBox_unimsg.Text = Properties.Settings.Default.APP_MSG_UNIFORM;
            richTextBox3.Text = Properties.Settings.Default.QR_MSG;
            ShowNotif("Setting Loaded");
        }

        public void SaveSetting()
        {
            Properties.Settings.Default.APP_MSG_DEL = numericUpDown1.Value;
            Properties.Settings.Default.APP_MSG_FRMT = textbox_msgformat.Text;
            Properties.Settings.Default.APP_RPT_DIR = textBox_rptdir.Text;
            Properties.Settings.Default.APP_RPT_PASS = textBox_rptpass.Text;
            Properties.Settings.Default.APP_IMG_DIR = textBox_imgdir.Text;
            Properties.Settings.Default.APP_MSG_TTL = textBox_titlemsg.Text;
            Properties.Settings.Default.APP_MSG_LOC = textBox_locmsg.Text;
            Properties.Settings.Default.APP_MSG_UNIFORM = textBox_unimsg.Text;
            Properties.Settings.Default.QR_MSG = richTextBox3.Text;
            Properties.Settings.Default.Save();
            ShowNotif("Setting Saved");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CREATEQR();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string BatchNo = dataGridView2.Rows[0].Cells[2].Value.ToString().Substring(0, 11); ;
                int x = dataGridView2.RowCount - 1;
                progressBar1.Maximum = dataGridView2.RowCount;
                string starttime = DateTime.Now.ToString("HH:mm:ss");
                for (int i = 0; i <= x; i++)
                {
                    string PARAM_1      = dataGridView2.Rows[i].Cells[0].Value.ToString();
                    string PARAM_2      = dataGridView2.Rows[i].Cells[1].Value.ToString();
                    string BATCH_NO     = dataGridView2.Rows[i].Cells[2].Value.ToString().Substring(0, 11);
                    string BATCH_EMP    = dataGridView2.Rows[i].Cells[3].Value.ToString();
                    int rowNum = -1;
                    DataGridViewRow row = dataGridView2.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["PHONEEMP"].Value.ToString().Equals(PARAM_2)).First();
                    rowNum = row.Index;
                    dataGridView2.Rows[rowNum].Cells[4].Value = "2100";
                    dataGridView2.Rows[rowNum].Cells[5].Value = "INVITED";
                    SendOutBondBulk(access_token, BATCH_NO, BATCH_EMP, PARAM_1, PARAM_2);
                    Thread.Sleep(Convert.ToInt32(numericUpDown1.Value));
                    progressBar1.Value = i+1;
                }
                for (int i = 0; i <= (dataGridView2.RowCount-1); i++)
                {
                    if (dataGridView2.Rows[i].Cells[4].Value.ToString().Equals("2000"))
                    {
                        dataGridView2.Rows[i].Cells[4].Value = "2700";
                        dataGridView2.Rows[i].Cells[5].Value = "WHATSAPP FAILED INVITED";
                        dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        SP_UPDATE_CANDIDATE_STATUS(dataGridView2.Rows[i].Cells[3].Value.ToString(), "2700", "WHATSAPP FAILED INVITED");
                    }
                    else
                    {
                        SP_UPDATE_CANDIDATE_STATUS(dataGridView2.Rows[i].Cells[3].Value.ToString(), dataGridView2.Rows[i].Cells[4].Value.ToString(), dataGridView2.Rows[i].Cells[5].Value.ToString());
                    }
                }
                SP_UPDATE_BATCHSTATUS(BatchNo, "0001");
                SAVELOG(starttime);
            }
            catch(Exception ex)
            {
                ShowError(this.GetCurrentMethod(), ex.Message.ToString());
            }
        }


        public async void SP_GET_CONTACT_LIST1(string BatchNo)
        {
            try
            {
                List<ModelDBContact> DBContactLst = new List<ModelDBContact>();
                var Sql = @"EXEC [SP_GET_CONTACT_LIST1] '" + BatchNo + "'";
                Sql = string.Format(Sql);
                DataTable tUsr = SysUtl.ExecuteDTQuery(Sql, null);
                DBContactLst.Clear();
                dataGridView2.DataSource = null;
                if (tUsr.Rows.Count > 0)
                {
                    for (int i = 0; i <= (tUsr.Rows.Count - 1); i++)
                    {
                        ModelDBContact DBContact = new ModelDBContact();
                        DBContact.NameEmp = tUsr.Rows[i]["NAMEEMP"].ToString();
                        DBContact.PhoneEmp = tUsr.Rows[i]["PHONEEMP"].ToString();
                        DBContact.BatchEmp = tUsr.Rows[i]["BATCHEMP"].ToString();
                        DBContact.InvitationEmp = tUsr.Rows[i]["INVITATIONEMP"].ToString();
                        DBContact.StatusEmp = tUsr.Rows[i]["STATUSEMP"].ToString();
                        DBContact.Remark = tUsr.Rows[i]["REMARK"].ToString();

                        DBContactLst.Add(DBContact);
                    }
                    dataGridView2.DataSource = DBContactLst;
                    dataGridView2.AllowUserToAddRows = false;
                    ShowNotif("Getting Contact Details");

                    using (var httpClient = new HttpClient())
                    {
                        var CONTACT_LIST_ID = ((KeyValuePair<string, string>)comboBox6.SelectedItem).Key;
                        using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://chat-service.qontak.com/api/open/v1/contacts/contact_lists/contacts/" + CONTACT_LIST_ID + "?offset=0&limit=500"))
                        {
                            request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + access_token + "");
                            var response = await httpClient.SendAsync(request);
                            response.EnsureSuccessStatusCode();
                            var content = await response.Content.ReadAsStringAsync();
                            MQ_WA_CONDET_Root datas = JsonConvert.DeserializeObject<MQ_WA_CONDET_Root>(content);
                            var status = datas.status;
                            if (status == "success")
                            {
                                if (datas.data.Count > 0)
                                {
                                    var list = new List<MQ_WA_CONDET_Datum>();
                                    foreach (var data in datas.data)
                                    {
                                        var dt = new MQ_WA_CONDET_Datum
                                        {
                                            id = data.id,
                                            phone_number = data.phone_number,
                                            full_name = data.full_name
                                        };
                                        list_MQ_WA_CONDET_Datum.Add(dt);
                                        list_MQ_WA_CONDET_Datum2.Add(dt);
                                    }
                                    ShowNotif("Contact Details loaded");
                                    dataGridView1.DataSource = list_MQ_WA_CONDET_Datum;
                                }
                                else
                                {
                                    ShowError(this.GetCurrentMethod(), "No Data");
                                }
                            }
                            else
                            {
                                ShowError(this.GetCurrentMethod(), status);
                            }
                        }
                    }
                }
                else
                {
                    ShowError(this.GetCurrentMethod(), "No candidate for selected Batch Number !");
                }

            }
            catch (Exception msg)
            {
                ShowError(this.GetCurrentMethod(), msg.Message.ToString());
            }
        }
        public void SP_UPDATE_BATCHSTATUS(string BatchNo, string Status)
        {
            var query = "";
            query = @"EXEC [SP_UPDATE_BATCHSTATUS] '" + BatchNo + "','" + Status + "'";
            query = string.Format(query);
            SysUtl.ExecuteDTQuery(query, null);
        }
        public void SP_UPDATE_CANDIDATE_STATUS(string InvitationEmp, string Status, string Remark)
        {
            var Sql = @"EXEC [SP_UPDATE_CANDIDATE_STATUS] '" + InvitationEmp + "','" + Status + "','" + Remark + "'";
            Sql = string.Format(Sql);
            DataTable data0 = SysUtl.ExecuteDTQuery(Sql, null);
        }
        public void SP_UPDATE_LOGFILE(string BatchNo, string FileName)
        {
            var query = "";
            query = @"EXEC [SP_UPDATE_LOGFILE_TELEGRAM] '" + BatchNo + "','" + FileName + "','WA'";
            query = string.Format(query);
            SysUtl.ExecuteDTQuery(query, null);
        }
        public void SP_UPDATE_INV_CODE(string BatchEmp, string InvitationEmp)
        {
            var query = @"EXEC [SP_UPDATE_INV_CODE] '" + BatchEmp + "','" + InvitationEmp + "'";
            query = string.Format(query);
            SysUtl.ExecuteDTQuery(query, null);
        }
        public void SAVELOG(string starttime)
        {
            if (richTextBox1.Text != "")
            {
                try
                {
                    string Author = gVar.getProperty("UseNam");
                    DateTime start = DateTime.ParseExact(starttime, "HH:mm:ss", CultureInfo.InvariantCulture);
                    DateTime end = DateTime.Now;
                    TimeSpan ts = (end - start);
                    string rptdir = textBox_rptdir.Text;
                    BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                    string filename = ("LOG-" + "DATE (" + DateTime.Now.ToString("ddMMMyyyy") + ") TIME (" + DateTime.Now.ToString("HHmmss tt" + ")")).ToUpper();
                    iTextSharp.text.Document doc = new iTextSharp.text.Document();
                    string InputFile = "" + rptdir + "" + "\\" + (filename + ".pdf");
                    string OutputFile = "" + rptdir + "" + "\\" + (filename + " - PROTECTED" + ".pdf");
                    PdfWriter.GetInstance(doc, new FileStream(InputFile, FileMode.Create));
                    doc.Open();
                    doc.Add(new iTextSharp.text.Paragraph("FILE NAME: " + filename + "\n" +
                                                          "REPROT TYPE: \t\tTELEGRAM REPORT\n" +
                                                          "AUTHOR: \t\t" + Author + "\n" +
                                                          "REPORT DATE: \t\t" + DateTime.Now.ToString("dd-MMM-yyyy") + "\n" +
                                                          "REPORT TIME: \t\t" + DateTime.Now.ToString("HH:mm:ss") + "\n" +
                                                          "START TIME: \t\t" + starttime + "\n" +
                                                          "END TIME: \t\t" + DateTime.Now.ToString("HH:mm:ss") + "\n" +
                                                          "DURATION: \t\t" + ts.Minutes.ToString() + " Minute and " + ts.Seconds.ToString() + " Second" + "\n" +
                                                          "\n" +
                                                          "\n" +
                                                          richTextBox1.Text));
                    doc.Close();
                    using (Stream input = new FileStream(InputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        using (Stream output = new FileStream(OutputFile, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            PdfReader reader = new PdfReader(input);
                            PdfEncryptor.Encrypt(reader, output, true, textBox_rptpass.Text, textBox_rptpass.Text, PdfWriter.ALLOW_SCREENREADERS);
                        }
                    }

                    File.Delete(InputFile);
                    SP_UPDATE_LOGFILE(dataGridView2.Rows[0].Cells[2].Value.ToString().Substring(0, 11), (filename + " - PROTECTED" + ".pdf"));
                    ShowNotif("Log has been saved on Databas");
                    MessageBox.Show("Log has been saved on Database", "Success");
                }
                catch (Exception x)
                {
                    ShowNotif(x.Message.ToString());
                }
            }
            else
            {
                ShowNotif("No log to save");
            }
        }


        private void button_save_setting_Click(object sender, EventArgs e)
        {
            SaveSetting();
        }
        public class ParamList
        {
            public string value;
        }
    }
}
