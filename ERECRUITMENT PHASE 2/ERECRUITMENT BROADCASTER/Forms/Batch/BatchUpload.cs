using BaseFormLibrary;
using ExcelDataReader;
using Google.Apis.PeopleService.v1.Data;
using ERECRUITMENT_BROADCASTER.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ERECRUITMENT_BROADCASTER
{
    public partial class BatchUpload : _BaseForm
    {
        DataTableCollection tableCollection;
        string ConStr = ConfigurationManager.AppSettings["SQLCON"].ToString();
        public BatchUpload()
        {
            InitializeComponent();
            textBox3.Text = DateTime.Now.ToString("dd-MM-yyyy");
            textBox3.Enabled = false;
            radioButton1.Checked = true;
            radioButton3.Checked = true;
            radioOperator.Checked = true;
            GetBatchList();
        }
        public void GetBatchList()
        {
            var Sql = @"EXEC [spGetBatchList2]";
            Sql = string.Format(Sql);
            DataTable tUsr = SysUtl.ExecuteDTQuery(Sql, null);
            if (tUsr.Rows.Count == 0)
            {
                comboBox2.Items.Clear();
            }
            else
            {
                comboBox2.DataSource = tUsr;
                comboBox2.DisplayMember = "BatchNo";
                comboBox2.ValueMember = "BatchNo";
            }
        }

        public void GetExcelFile()
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls" })
            {
                btnUpload.Enabled = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtExcelPath.Text = ofd.FileName;
                    using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            });
                            tableCollection = result.Tables;
                            cboSheet.Items.Clear();
                            foreach (DataTable table in tableCollection)
                            {
                                cboSheet.Items.Add(table.TableName);
                            }
                        }
                    }
                }
            }
        }

        private void btnGetSample_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start($"{Application.StartupPath}/SampleData");
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString(), "Error");
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                if(comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select format !", "Error");
                }
                else
                {
                    GetExcelFile();
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString(), "Error");
            }
        }

        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()];
            if (dt != null)
            {
                if (maskedTextBox3.Text.Length > 3 || maskedTextBox3.Text == "" || maskedTextBox3.Text.Length < 3)
                {
                    MessageBox.Show("Please fill Sequence with format 001", "Error");
                    btnUpload.Enabled = false;
                    return;
                }
                else
                {
                    string A = dt.Rows[0]["Invitation Date"].ToString();
                    DateTime date = DateTime.ParseExact(A, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    string BatchCompTemp = comboBox1.SelectedItem.ToString() + "-" + date.ToString("yyMM-") + maskedTextBox3.Text;

                    var Sql = @"SELECT * FROM [DBERECRUITMENT].[dbo].[BatchDetail] where BatchNo = '" + BatchCompTemp + "'";
                    Sql = string.Format(Sql);
                    DataTable tUsr = SysUtl.ExecuteDTQuery(Sql, null);
                    if (tUsr.Rows.Count == 0)
                    {
                        List<BatchUploadExcel> list = new List<BatchUploadExcel>();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DateTime date2 = DateTime.ParseExact(dt.Rows[i]["Invitation Date"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                            DateTime date3 = DateTime.ParseExact(dt.Rows[i]["Request Date"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                            BatchUploadExcel obj = new BatchUploadExcel();

                            obj.BatchNo = BatchCompTemp;
                            obj.BatchEmp = BatchCompTemp + "-" + (1 + i).ToString("D3");
                            obj.InvitationDate = date2.ToString("dd-MM-yyyy");
                            obj.RequestDate = date3.ToString("dd-MM-yyyy");
                            obj.NameEmp = dt.Rows[i]["Name Emp"].ToString();
                            obj.PhoneNumber = dt.Rows[i]["Phone Number"].ToString();
                            obj.DateOfBirthEmp = dt.Rows[i]["Date Of Birth Emp"].ToString();
                            list.Add(obj);
                        }
                        dataGridView1.DataSource = list;
                    }
                    else
                    {
                        int TempSeq = tUsr.Rows.Count + 1;
                        List<BatchUploadExcel> list = new List<BatchUploadExcel>();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DateTime date2 = DateTime.ParseExact(dt.Rows[i]["Invitation Date"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                            DateTime date3 = DateTime.ParseExact(dt.Rows[i]["Request Date"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

                            BatchUploadExcel obj = new BatchUploadExcel();
                            obj.BatchNo = BatchCompTemp;
                            obj.BatchEmp = BatchCompTemp + "-" + (TempSeq + i).ToString("D3");
                            obj.InvitationDate = date2.ToString("dd-MM-yyyy");
                            obj.RequestDate = date3.ToString("dd-MM-yyyy");
                            obj.NameEmp = dt.Rows[i]["Name Emp"].ToString();
                            obj.PhoneNumber = dt.Rows[i]["Phone Number"].ToString();
                            obj.DateOfBirthEmp = dt.Rows[i]["Date Of Birth Emp"].ToString();
                            list.Add(obj);
                        }
                        
                        dataGridView1.DataSource = list;
                    }
                }
                btnUpload.Enabled = true;
            }
            else
            {
                MessageBox.Show("Excel file empty", "Error");
                btnUpload.Enabled = false;
                return;
            }
        }

        public async void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if(radioOperator.Checked != true && radioStaff.Checked != true)
                {
                    MessageBox.Show("Please select category STAFF or OPERATOR !", "Error");
                    return;
                }
                bool returnValue = CanUpload();
                if (returnValue == true)
                {
                    var createTempHeader = @"CREATE TABLE #createTempHeader
                                            (
	                                            [BatchNo] [nvarchar](20) NOT NULL,
                                                [BatchCategory] [nvarchar](20) NOT NULL,
	                                            [InvitationDate] [date] NOT NULL,
	                                            [RequestDate] [date] NOT NULL,
	                                            [StatusBatch] [nvarchar](20) NOT NULL,
	                                            [UpdateBy] [nvarchar](20) NOT NULL,
	                                            [UpdateDate] [date] NOT NULL
                                            )
                                            SELECT 'SUCCESS' as Message";

                    var createTempDetail = @"CREATE TABLE #createTempDetail
                                            (
	                                            [BatchNo] [nvarchar](20) NOT NULL,
	                                            [InvitationDate] [date] NULL,
	                                            [BatchEmp] [nvarchar](30) NOT NULL,
	                                            [NameEmp] [nvarchar](100) NOT NULL,
	                                            [PhoneEmp] [nvarchar](20) NOT NULL,
	                                            [DOBEmp] [date] NOT NULL,
	                                            [InvitationEmp] [nvarchar](max) NOT NULL,
	                                            [StatusEmp] [nvarchar](20) NOT NULL,
	                                            [UpdateBy] [nvarchar](20) NOT NULL,
	                                            [UpdateDate] [date] NOT NULL
                                            )
                                            SELECT 'SUCCESS' as Message";

                    createTempHeader = string.Format(createTempHeader);
                    DataTable TempHeader = SysUtl.ExecuteDTQuery(createTempHeader, null);

                    createTempDetail = string.Format(createTempDetail);
                    DataTable TempDetail = SysUtl.ExecuteDTQuery(createTempDetail, null);

                    if(TempHeader.Rows.Count > 0 && TempDetail.Rows.Count > 0)
                    {
                        string dataHeader0 = dataGridView1.Rows[0].Cells[0].Value.ToString();
                        string dataHeader1 = dataGridView1.Rows[0].Cells[1].Value.ToString();
                        string dataHeader2 = dataGridView1.Rows[0].Cells[2].Value.ToString();
                        string dataHeader3 = dataGridView1.Rows[0].Cells[3].Value.ToString();
                        string dataHeader4 = dataGridView1.Rows[0].Cells[4].Value.ToString();
                        string dataHeader5 = dataGridView1.Rows[0].Cells[5].Value.ToString();
                        string dataHeader6 = dataGridView1.Rows[0].Cells[6].Value.ToString();

                        DateTime oDate1 = DateTime.ParseExact(dataHeader2, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        DateTime oDate2 = DateTime.ParseExact(dataHeader3, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        

                        string BatchCategory = "";
                        
                        if(radioOperator.Checked == true)
                        {
                            BatchCategory = "OPERATOR";
                        }
                        if (radioStaff.Checked == true)
                        {
                            BatchCategory = "STAFF";
                        }

                        string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        string sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;

                        var query = @"insert into #createTempHeader (BatchNo, BatchCategory, InvitationDate, RequestDate, StatusBatch, UpdateBy, UpdateDate)
                                      VALUES('" + dataHeader0 + "','"+ BatchCategory + "','" + oDate1 + "','" + oDate2 + "','0000','DESKTOP',GETDATE())";
                        query = string.Format(query);
                        SysUtl.ExecuteDTQuery(query, null);
                        query = @"insert into [DBERECRUITMENT].[dbo].[BatchHeader] (BatchNo, BatchCategory, InvitationDate, RequestDate, StatusBatch, UpdateBy, UpdateDate)
                                  SELECT BatchNo, BatchCategory, InvitationDate, RequestDate, StatusBatch, UpdateBy, UpdateDate FROM  #createTempHeader";
                        query = string.Format(query);
                        SysUtl.ExecuteDTQuery(query, null);
                       
                        ////////////////////////////////////////////////////////////////////////
                        ///

                        for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                        {
                            string BatchNo = dataGridView1.Rows[i].Cells[0].Value.ToString();
                            string BatchEmp = dataGridView1.Rows[i].Cells[1].Value.ToString();
                            string InvDate = dataGridView1.Rows[i].Cells[2].Value.ToString();
                            string ReqeustDate = dataGridView1.Rows[i].Cells[3].Value.ToString();
                            string NameEmp = dataGridView1.Rows[i].Cells[4].Value.ToString();
                            string PhoneNumber = dataGridView1.Rows[i].Cells[5].Value.ToString();
                            string DOBEmp = dataGridView1.Rows[i].Cells[6].Value.ToString();


                            DateTime InvDate_ = DateTime.ParseExact(InvDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                            DateTime ReqeustDate_ = DateTime.ParseExact(ReqeustDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                            DateTime DOBEmp_ = DateTime.ParseExact(DOBEmp, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                            query = @"insert into #createTempDetail (BatchNo, InvitationDate, BatchEmp, NameEmp, PhoneEmp, DOBEmp, InvitationEmp, StatusEmp, UpdateBy, UpdateDate)
                                        VALUES('" + BatchNo + "','" + InvDate_ + "','" + BatchEmp + "','" + NameEmp + "','" + PhoneNumber + "','" + DOBEmp_ + "','','2000','DESKTOP',GETDATE())";

                            query = string.Format(query);
                            SysUtl.ExecuteDTQuery(query, null);
                        }
                        query = @"insert into [DBERECRUITMENT].[dbo].BatchDetail (BatchNo, InvitationDate, BatchEmp, NameEmp, PhoneEmp, DOBEmp, InvitationEmp, StatusEmp, UpdateBy, UpdateDate)
                                       SELECT BatchNo, InvitationDate, BatchEmp, NameEmp, PhoneEmp, DOBEmp, InvitationEmp, StatusEmp, UpdateBy, UpdateDate FROM  #createTempDetail";
                        query = string.Format(query);
                        SysUtl.ExecuteDTQuery(query, null);
                        query = @"drop table #createTempHeader
                                  drop table #createTempDetail";
                        query = string.Format(query);
                        SysUtl.ExecuteDTQuery(query, null);
                        query = @"EXEC [SP_UPDATE_ALL_USER_TABLE] '" + dataHeader0 + "'";
                        SysUtl.ExecuteDTQuery(query, null);
                        MessageBox.Show("Uploading Success !", "Success");
                        //dataGridView1.Rows.Clear();
                        dataGridView1.DataSource = null;

                        if(check_Qontak.Checked)
                        {
                            var access_token = string.Empty;
                            var USERNAME = "hendyhadiyanto@sbm.shimano.com.sg";
                            var PASSWORD = "Shimano123!";
                            var CLIENT_ID = "RRrn6uIxalR_QaHFlcKOqbjHMG63elEdPTair9B9YdY";
                            var CLIENT_SECRET = "Sa8IGIh_HpVK1ZLAF0iFf7jU760osaUNV659pBIZR00";
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
                                }
                            }
                            PostWAContactList(access_token, dataHeader0);
                        }
                    }
                    else
                    {
                        MessageBox.Show("createTempHeader and createTempDetail not found", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Empty cell on excel file", "Error");
                }
            }
            catch(Exception msg)
            {
                var query = @"drop table #createTempHeader drop table #createTempDetail";
                query = string.Format(query);
                SysUtl.ExecuteDTQuery(query, null);
                MessageBox.Show(msg.Message.ToString(), "Error");
            }
        }
        public async void PostWAContactList(string access_token, string dataHeader0)
        {
            try
            {
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
                            { new StringContent(dataHeader0), "name" },
                            { new StringContent("spreadsheet"), "source_type" },
                            { new StringContent("1"), "source_id" },
                            file_content
                        };
                        request.Content = multipartContent;
                        var response = await httpClient.SendAsync(request);
                        var final = await response.Content.ReadAsStringAsync();
                        response.EnsureSuccessStatusCode();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public bool CanUpload()
        {
            foreach (DataGridViewRow rw in this.dataGridView1.Rows)
            {
                for (int i = 0; i < rw.Cells.Count; i++)
                {
                    if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Enabled)
            {
                maskedTextBox1.Text = "";
                maskedTextBox1.Enabled = true;
                comboBox2.Enabled = false;
                textBox1.Enabled = false;
                textBox1.Text = "";
                textBox4.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Enabled)
            {
                maskedTextBox1.Text = "";
                maskedTextBox1.Enabled = false;
                comboBox2.Enabled = true;
                textBox1.Enabled = true;
                textBox4.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
        }

        private void buttonSingleUpload_Click(object sender, EventArgs e)
        {
            try
            {
                var query = "";
                if (radioButton1.Checked == true)
                {
                    string BatchNo = maskedTextBox1.Text;
                    string BatchCategory = "";
                    string InvitationDate = textBox4.Text;
                    string RequestDate = textBox3.Text;
                    string StatusBatch = "0000";
                    string UpdateBy = "DESKTOP";
                    string BatchEmp = BatchNo + "-001";
                    string NameEmp = textBox2.Text;
                    string DOBEmp = textBox5.Text;
                    string PhoneEmp = maskedTextBox2.Text;
                    string InvitationEmp = "";
                    string StatusEmp = "2000";

                    DateTime oDate1 = DateTime.ParseExact(DOBEmp, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    DateTime oDate2 = DateTime.ParseExact(InvitationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    DateTime oDate3 = DateTime.ParseExact(RequestDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                    if (radioButton3.Checked)
                    {
                        BatchCategory = "OPERATOR";
                    }
                    else if (radioButton4.Checked)
                    {
                        BatchCategory = "STAFF";
                    }
                    else
                    {
                        MessageBox.Show("Please select category", "Error");
                        return;
                    }

                    query = @"EXEC [SP_UPLOAD_SINGLE_BATCH] '" + BatchNo + "','" + BatchCategory + "','" + oDate2.ToString("yyyy-MM-dd") + "','" + oDate3.ToString("yyyy-MM-dd") + "','" + StatusBatch + "','" + UpdateBy + "'";
                    query = string.Format(query);
                    DataTable data0 = SysUtl.ExecuteDTQuery(query, null);

                    if(Convert.ToBoolean(data0.Rows[0]["RESULT"]) == true)
                    {
                        query = @"EXEC [SP_UPLOAD_SINGLE_BATCH_2] '" + BatchNo + "','" + oDate2.ToString("yyyy-MM-dd") + "','" + BatchEmp + "','" + NameEmp + "','" + PhoneEmp + "','" + oDate1.ToString("yyyy-MM-dd") + "','" + InvitationEmp + "','" + StatusEmp + "','" + UpdateBy + "'";
                        query = string.Format(query);
                        SysUtl.ExecuteDTQuery(query, null);
                    }
                    else
                    {
                        MessageBox.Show(data0.Rows[0]["MESSAGE"].ToString(), "Error");
                    }
                }
                else if (radioButton2.Checked == true)
                {
                    string BatchNo = comboBox2.SelectedValue.ToString();
                    string BatchCategory = "";
                    string InvitationDate = textBox4.Text;
                    string StatusBatch = "0000";
                    string UpdateBy = "DESKTOP";
                    string BatchEmp = BatchNo + "-"+ textBox1.Text;
                    string NameEmp = textBox2.Text;
                    string DOBEmp = textBox5.Text;
                    string PhoneEmp = maskedTextBox2.Text;
                    string InvitationEmp = "";
                    string StatusEmp = "2000";

                    DateTime oDate1 = DateTime.ParseExact(DOBEmp, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    DateTime oDate2 = DateTime.ParseExact(InvitationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                    query = @"EXEC [SP_UPLOAD_SINGLE_BATCH_2] '" + BatchNo + "','" + oDate2.ToString("yyyy-MM-dd") + "','" + BatchEmp + "','" + NameEmp + "','" + PhoneEmp + "','" + oDate1.ToString("yyyy-MM-dd") + "','" + InvitationEmp + "','" + StatusEmp + "','" + UpdateBy + "'";
                    query = string.Format(query);
                    DataTable data0 = SysUtl.ExecuteDTQuery(query, null);

                    MessageBox.Show(data0.Rows[0]["MESSAGE"].ToString(), "Error");

                    DataTable tUsr = SysUtl.ExecuteDTQuery(query, null);
                    query = @"EXEC [SP_GET_LAST_SEQ] '" + BatchNo + "'";
                    query = string.Format(query);
                    tUsr = SysUtl.ExecuteDTQuery(query, null);
                    int total = Convert.ToInt32(tUsr.Rows[0]["TOTAL"]) + 1;
                    textBox1.Text = total.ToString("D3");
                    textBox2.Text = "";
                    maskedTextBox2.Text = "";
                    textBox5.Text = "";
                }
                else
                {
                    MessageBox.Show("Error", "Error");
                }
            }
            catch(Exception msg)
            {
                MessageBox.Show(msg.Message.ToString(), "Error");
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if(dateTimePicker2.Value < DateTime.Now)
            {
                MessageBox.Show("Invalid invitation date", "Error");
            }
            else
            {
                textBox4.Text = dateTimePicker2.Value.ToString("dd-MM-yyyy");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox5.Text = dateTimePicker1.Value.ToString("dd-MM-yyyy");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedValue.ToString() != "")
            {
                var Batch = comboBox2.SelectedValue.ToString();
                var query = @"EXEC [GetBatchInvDate] '" + Batch + "'";
                query = string.Format(query);
                DataTable tUsr = SysUtl.ExecuteDTQuery(query, null);
                if(tUsr.Rows.Count != 0)
                {
                    textBox4.Text = Convert.ToDateTime(tUsr.Rows[0]["InvitationDate"].ToString()).ToString("dd-MM-yyyy");

                    query = @"EXEC [SP_GET_LAST_SEQ] '" + Batch + "'";
                    query = string.Format(query);
                    tUsr = SysUtl.ExecuteDTQuery(query, null);
                    int total = Convert.ToInt32(tUsr.Rows[0]["TOTAL"]) + 1;
                    textBox1.Text = total.ToString("D3");
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        public void check_Qontak_CheckedChanged(object sender, EventArgs e)
        {
            if(check_Qontak.Checked)
            {
                btnQontakFile.Enabled = true;
                txtQontak.Enabled = true;
            }
            else
            {
                btnQontakFile.Enabled = false;
                txtQontak.Enabled = false;
                txtQontak.Clear();
            }
        }

        public void btnQontakFile_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.CheckFileExists = true;
                openFileDialog1.CheckPathExists = true;
                openFileDialog1.ReadOnlyChecked = true;
                openFileDialog1.ShowReadOnly = true;
                openFileDialog1.Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtQontak.Text = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
    }
}
