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

namespace ERECRUITMENT_BROADCASTER
{
    public partial class Telegram : _BaseForm
    {
        int TLSHARP_API_ID, MessageType;
        string TLSHARP_API_HASH, TLSHARP_API_SENDER, TLSHARP_API_AUTHCODE, TLSHARP_SESSION_ID, TLSHARP_SESSION_LASTMSGID;
        string TLSHARP_SESSION_SALT, TLSHARP_SESSION_SESSEXP, TLSHARP_SESSION_SEQ, TLSHARP_SESSION_SESSID, TLSHARP_SESSION_HASH;
        string HASH, _FILEPATH;
        TelegramClient client;
        TLContacts tLContact;
        List<ModelTelegramContact> TContactLst = new List<ModelTelegramContact>();
        List<ModelDBContact> DBContactLst = new List<ModelDBContact>();
        List<ModelTelegramContact> TContactLst2 = new List<ModelTelegramContact>();

        public Telegram()
        {
            InitializeComponent();
        }
        private void Telegram_Load(object sender, EventArgs e)
        {
            button_getbatchcontact.Enabled = false;
            button_gettelecontact.Enabled = false;
            button_synccontact.Enabled = false;
            button_generateqr.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button7.Enabled = true;
            SP_GET_BATCHLIST_2();
            LoadAppSetting();

            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            MessageType = 0;
            timepicker.Format = DateTimePickerFormat.Time;
            datepicker.Format = DateTimePickerFormat.Long;
            timepicker.ShowUpDown = true;
            LoadMessageSetting();
            button7.Enabled = false;

            string BusFunc = gVar.getProperty("sys_BusFunc");

            if (BusFunc != "SYSTEM-ADMIN")
            {
                textbox_msgformat.Enabled = false;
                textBox_rptdir.Enabled = false;
                textBox_rptpass.Enabled = false;
                textBox_imgdir.Enabled = false;
            }
        }
        private void button_getbatchcontact_Click(object sender, EventArgs e)
        {
            string BatchNo = comboBox1.SelectedValue.ToString();
            SP_GET_CONTACT_LIST1(BatchNo);
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                MessageType = 0;
                checkBox1.Checked = false;
                checkBox1.Enabled = true;
                richTextBox2.Enabled = true;
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                MessageType = 1;
                checkBox1.Checked = false;
                checkBox1.Enabled = false;
                richTextBox2.Enabled = false;
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                MessageType = 2;
                checkBox1.Checked = false;
                checkBox1.Enabled = false;
                richTextBox2.Enabled = false;
            }
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                MessageType = 3;
                checkBox1.Checked = false;
                checkBox1.Enabled = false;
                richTextBox2.Enabled = false;
            }
        }
        private async void button_gettelecontact_Click(object sender, EventArgs e)
        {
            try
            {
                tLContact = await client.GetContactsAsync();
                foreach (TLUser user in tLContact.Users)
                {
                    if (!string.IsNullOrEmpty(user.Phone))
                    {
                        ModelTelegramContact TelegramContact = new ModelTelegramContact();
                        TelegramContact.Id = user.Id;
                        TelegramContact.Username = user.Username;
                        TelegramContact.FullName = $"{user.FirstName} {user.LastName}";
                        TelegramContact.Phone = "+" + user.Phone;
                        TContactLst.Add(TelegramContact);
                    }
                }
                dataGridView1.DataSource = TContactLst;
                button_synccontact.Enabled = true;
                rtbLog.AppendText("GET TELEGRAM CONTACT SUCCESS ! " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "" + Environment.NewLine);
            }
            catch (Exception msg)
            {
                rtbLog.AppendText("ERROR : " + msg.Message.ToString() + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "" + Environment.NewLine);
                MessageBox.Show(msg.Message.ToString());
            }
        }
        private void button_synccontact_Click(object sender, EventArgs e)
        {
            try
            {
                int X = TContactLst.Count;
                int y = DBContactLst.Count;
                TContactLst2.Clear();
                dataGridView3.DataSource = null;
                for (int i = 0; i < y; i++)
                {
                    ModelTelegramContact TC = new ModelTelegramContact();
                    var data = (from T in TContactLst
                                where T.Phone == DBContactLst[i].PhoneEmp.ToString()
                                select new ModelTelegramContact()
                                {
                                    Id = T.Id,
                                    Username = T.Username,
                                    FullName = T.FullName,
                                    Phone = T.Phone
                                }
                                ).ToList();
                    if (data.Count > 0)
                    {
                        if (data[0].Id == 0)
                        {
                            TC.Id = 0;
                        }
                        else
                        {
                            TC.Id = data[0].Id;
                        }

                        if (data[0].Username == null)
                        {
                            TC.Username = "";
                        }
                        else
                        {
                            TC.Username = data[0].Username.ToString();
                        }

                        TC.FullName = data[0].FullName.ToString();
                        TC.Phone = data[0].Phone.ToString();
                        TContactLst2.Add(TC);
                    }
                }
                dataGridView3.DataSource = TContactLst2;
                rtbLog.AppendText("CONTACT SYNCED SUCCESS ! " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "" + Environment.NewLine);
                button7.Enabled = true;
            }
            catch (Exception msg)
            {
                rtbLog.AppendText("ERROR : " + msg.Message.ToString() + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "" + Environment.NewLine);
                MessageBox.Show(msg.Message.ToString());
            }
        }
        private void button_savesetting_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.APP_MSG_DEL = numericUpDown1.Value;
            Properties.Settings.Default.APP_MSG_FRMT = textbox_msgformat.Text;
            Properties.Settings.Default.APP_RPT_DIR = textBox_rptdir.Text;
            Properties.Settings.Default.APP_RPT_PASS = textBox_rptpass.Text;
            Properties.Settings.Default.APP_IMG_DIR = textBox_imgdir.Text;
            Properties.Settings.Default.APP_MSG_TTL = textBox_titlemsg.Text;
            Properties.Settings.Default.APP_MSG_LOC = textBox_locmsg.Text;
            Properties.Settings.Default.APP_MSG_UNIFORM = textBox_unimsg.Text;
            Properties.Settings.Default.QR_MSG = richTextBox1.Text;
            //QR_MSG
            Properties.Settings.Default.Save();
            MessageBox.Show("MESSAGE SETTING SAVED !");
        }
        private void button_generateqr_Click(object sender, EventArgs e)
        {
            CREATEQR();
        }
        private void button_loadsession_Click(object sender, EventArgs e)
        {
            LoadAppSetting();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.SelectedItem.ToString() == "Default")
                {
                    client = new TelegramClient(TLSHARP_API_ID, TLSHARP_API_HASH, null, TLSHARP_API_SENDER, dcIpVersion: DataCenterIPVersion.Default);
                    await client.ConnectAsync();
                    if (client.IsConnected == true)
                    {
                        button1.Enabled = false;
                        GetNewSession();
                        HASH = await client.SendCodeRequestAsync(TLSHARP_API_SENDER);
                        GetNewHash();
                    }
                    else
                    {
                        MessageBox.Show("Client Not Connected");
                    }
                }
                else if (comboBox2.SelectedItem.ToString() == "OnlyIPv4")
                {
                    client = new TelegramClient(TLSHARP_API_ID, TLSHARP_API_HASH, null, TLSHARP_API_SENDER, dcIpVersion: DataCenterIPVersion.OnlyIPv4);
                    await client.ConnectAsync();
                    if (client.IsConnected == true)
                    {
                        button1.Enabled = false;
                        GetNewSession();
                        HASH = await client.SendCodeRequestAsync(TLSHARP_API_SENDER);
                        GetNewHash();
                    }
                    else
                    {
                        MessageBox.Show("Client Not Connected");
                    }
                }
                else if (comboBox2.SelectedItem.ToString() == "OnlyIPv6")
                {
                    client = new TelegramClient(TLSHARP_API_ID, TLSHARP_API_HASH, null, TLSHARP_API_SENDER, dcIpVersion: DataCenterIPVersion.OnlyIPv6);
                    await client.ConnectAsync();
                    if (client.IsConnected == true)
                    {
                        button1.Enabled = false;
                        GetNewSession();
                        HASH = await client.SendCodeRequestAsync(TLSHARP_API_SENDER);
                        GetNewHash();
                    }
                    else
                    {
                        MessageBox.Show("Client Not Connected");
                    }
                }
                else if (comboBox2.SelectedItem.ToString() == "PreferIPv4")
                {
                    client = new TelegramClient(TLSHARP_API_ID, TLSHARP_API_HASH, null, TLSHARP_API_SENDER, dcIpVersion: DataCenterIPVersion.PreferIPv4);
                    await client.ConnectAsync();
                    if (client.IsConnected == true)
                    {
                        button1.Enabled = false;
                        GetNewSession();
                        HASH = await client.SendCodeRequestAsync(TLSHARP_API_SENDER);
                        GetNewHash();
                    }
                    else
                    {
                        MessageBox.Show("Client Not Connected");
                    }

                }
                else if (comboBox2.SelectedItem.ToString() == "PreferIPv6")
                {
                    client = new TelegramClient(TLSHARP_API_ID, TLSHARP_API_HASH, null, TLSHARP_API_SENDER, dcIpVersion: DataCenterIPVersion.PreferIPv6);
                    await client.ConnectAsync();
                    if (client.IsConnected == true)
                    {
                        button1.Enabled = false;
                        GetNewSession();
                        HASH = await client.SendCodeRequestAsync(TLSHARP_API_SENDER);
                        GetNewHash();
                    }
                    else
                    {
                        MessageBox.Show("Client Not Connected");
                    }
                }
                else
                {
                    MessageBox.Show("Please select DataCenterIPVersion !");
                }
            }
            catch (Exception msg)
            {
                button1.Enabled = true;
                MessageBox.Show(msg.Message.ToString());
            }
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (client.IsConnected == true)
                {
                    button2.Enabled = false;
                    TLSHARP_API_AUTHCODE = textBox_authcode.Text;
                    await client.MakeAuthAsync(TLSHARP_API_SENDER, HASH, TLSHARP_API_AUTHCODE);
                    Properties.Settings.Default.TLSHARP_API_AUTHCODE = TLSHARP_API_AUTHCODE;
                    Properties.Settings.Default.Save();
                    button_gettelecontact.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Client Not Connected");
                }
            }
            catch (Exception msg)
            {
                button2.Enabled = true;
                button_gettelecontact.Enabled = false;
                MessageBox.Show(msg.Message.ToString());
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectAsync();
            }
            catch (Exception msg)
            {
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
                MessageBox.Show(msg.Message.ToString());
            }
        }
        private async void button5_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView3.AllowUserToAddRows = false;
                int x = dataGridView3.RowCount - 1;
                for (int i = 0; i <= x; i++)
                {
                    int _id = Convert.ToInt32(dataGridView3.Rows[i].Cells[3].Value);
                    string _message = richTextBox1.Text;
                    await client.SendMessageAsync(new TLInputPeerUser() { UserId = _id }, _message);
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.Message.ToString());
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_api_id.Text))
            {
                MessageBox.Show("Please fill Telegram API ID first !", "Error");
            }
            else if (string.IsNullOrEmpty(textBox_api_hash.Text))
            {
                MessageBox.Show("Please set Telegram API HASH first !", "Error");
            }
            else if (string.IsNullOrEmpty(textBox_api_sender.Text))
            {
                MessageBox.Show("Please set Telegram API SENDER first !", "Error");
            }
            else
            {
                TLSHARP_API_ID = Convert.ToInt32(textBox_api_id.Text);
                TLSHARP_API_HASH = textBox_api_hash.Text;
                TLSHARP_API_SENDER = textBox_api_sender.Text;

                Properties.Settings.Default.TLSHARP_API_ID = TLSHARP_API_ID;
                Properties.Settings.Default.TLSHARP_API_HASH = TLSHARP_API_HASH;
                Properties.Settings.Default.TLSHARP_API_SENDER = TLSHARP_API_SENDER;
                Properties.Settings.Default.Save();

                MessageBox.Show("SUCCESSFULLY SAVING TELEGRAM API SETTING !");
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                button_getbatchcontact.Enabled = false;
                button_synccontact.Enabled = false;
                button_gettelecontact.Enabled = false;
                dataGridView3.AllowUserToAddRows = false;
                int TimeInverval = Convert.ToInt32(numericUpDown1.Value);
                string title = "Action Confirmation";
                if (MessageType == 0)
                {
                    string BusFunc = gVar.getProperty("sys_BusFunc");
                    
                    if (BusFunc == "SYSTEM-ADMIN")
                    {
                        string message = "Do you want to continue sending message to All Telegram Contact,\n with Delay: " + Convert.ToString(TimeInverval) + " ms ?";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result = MessageBox.Show(message, title, buttons);
                        if (result == DialogResult.Yes)
                        {
                            SendType0(TimeInverval);
                            rtbLog.AppendText("PROCEED ACTION : MessageType(0) - " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "" + Environment.NewLine);
                        }
                        else
                        {
                            rtbLog.AppendText("ABORTED ACTION : MessageType(0) - " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "" + Environment.NewLine);
                        }
                    }
                    else
                    {
                        rtbLog.AppendText("UNATHORIZED ACTION : MessageType(0) - " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "" + Environment.NewLine);
                        MessageBox.Show("You not allowed for this action !","Unauthorized Access");
                    }
                }
                else if (MessageType == 1)
                {
                    string message = "Do you want to continue sending message to All Synchronized Contact,\n with Delay: "+Convert.ToString(TimeInverval)+" ms ?";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        SendType1(TimeInverval);
                        rtbLog.AppendText("PROCEED ACTION : MessageType(1) - " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "" + Environment.NewLine);
                    }
                    else
                    {
                        rtbLog.AppendText("ABORTED ACTION : MessageType(1) - "+DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")+"" + Environment.NewLine);
                    }
                }
                else if (MessageType == 2)
                {

                }
                else if (MessageType == 3)
                {

                }
                else
                {

                }
            }
            catch (Exception msg)
            {
                button_getbatchcontact.Enabled = true;
                button_synccontact.Enabled = false;
                button_gettelecontact.Enabled = true;
                rtbLog.AppendText("ERROR : " + msg.Message.ToString() + " - " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "" + Environment.NewLine);
                MessageBox.Show(msg.Message.ToString());
            }
        }
        public void LoadAppSetting()
        {
            TLSHARP_API_ID = Properties.Settings.Default.TLSHARP_API_ID;
            TLSHARP_API_HASH = Properties.Settings.Default.TLSHARP_API_HASH;
            TLSHARP_API_SENDER = Properties.Settings.Default.TLSHARP_API_SENDER;
            TLSHARP_API_AUTHCODE = Properties.Settings.Default.TLSHARP_API_AUTHCODE;
            HASH = Properties.Settings.Default.TLSHARP_SESSION_HASH;

            textBox_api_id.Text = Convert.ToString(TLSHARP_API_ID);
            textBox_api_sender.Text = Convert.ToString(TLSHARP_API_SENDER);
            textBox_api_hash.Text = Convert.ToString(TLSHARP_API_HASH);

            var dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            string filepath = dir + "\\" + TLSHARP_API_SENDER + ".dat";
            CustomSessionStore data = new CustomSessionStore();
            var _session = data.Load(TLSHARP_API_SENDER);

            if (File.Exists(filepath))
            {
                Properties.Settings.Default.TLSHARP_SESSION_ID = Convert.ToString(_session.Id);
                Properties.Settings.Default.TLSHARP_SESSION_LASTMSGID = Convert.ToString(_session.LastMessageId);
                Properties.Settings.Default.TLSHARP_SESSION_SALT = Convert.ToString(_session.Salt);
                Properties.Settings.Default.TLSHARP_SESSION_SESSEXP = Convert.ToString(_session.SessionExpires);
                Properties.Settings.Default.TLSHARP_SESSION_SEQ = Convert.ToString(_session.Sequence);
                Properties.Settings.Default.TLSHARP_SESSION_SESSID = Convert.ToString(_session.SessionUserId);

                Properties.Settings.Default.Save();

                TLSHARP_SESSION_ID = Properties.Settings.Default.TLSHARP_SESSION_ID;
                TLSHARP_SESSION_LASTMSGID = Properties.Settings.Default.TLSHARP_SESSION_LASTMSGID;
                TLSHARP_SESSION_SALT = Properties.Settings.Default.TLSHARP_SESSION_SALT;
                TLSHARP_SESSION_SESSEXP = Properties.Settings.Default.TLSHARP_SESSION_SESSEXP;
                TLSHARP_SESSION_SEQ = Properties.Settings.Default.TLSHARP_SESSION_SEQ;
                TLSHARP_SESSION_SESSID = Properties.Settings.Default.TLSHARP_SESSION_SESSID;

                textbox_SessionId.Text = TLSHARP_SESSION_ID;
                textBox_LastMsgId.Text = TLSHARP_SESSION_LASTMSGID;
                textBox_Salt.Text = TLSHARP_SESSION_SALT;
                textBox_sessionExp.Text = TLSHARP_SESSION_SESSEXP;
                textBox_sequence.Text = TLSHARP_SESSION_SEQ;
                textBox_userid.Text = TLSHARP_SESSION_SESSID;
                textBox_hash.Text = HASH;
                textBox_authcode.Text = TLSHARP_API_AUTHCODE;
                button_loadsession.Enabled = true;

                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = true;
            }
            else
            {
                textbox_SessionId.Text = "";
                textBox_LastMsgId.Text = "";
                textBox_Salt.Text = "";
                textBox_sessionExp.Text = "";
                textBox_sequence.Text = "";
                textBox_userid.Text = "";
                textBox_hash.Text = "";
                textBox_authcode.Text = "";
                button_loadsession.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
            }
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
            richTextBox1.Text = Properties.Settings.Default.QR_MSG;
        }
        public async void ConnectAsync()
        {
            try
            {
                if (comboBox2.SelectedItem.ToString() == "Default")
                {
                    client = new TelegramClient(TLSHARP_API_ID, TLSHARP_API_HASH, null, TLSHARP_API_SENDER, dcIpVersion: DataCenterIPVersion.Default);
                    await client.ConnectAsync();
                    button_gettelecontact.Enabled = true;
                }
                else if (comboBox2.SelectedItem.ToString() == "OnlyIPv4")
                {
                    client = new TelegramClient(TLSHARP_API_ID, TLSHARP_API_HASH, null, TLSHARP_API_SENDER, dcIpVersion: DataCenterIPVersion.Default);
                    await client.ConnectAsync();
                    button_gettelecontact.Enabled = true;
                }
                else if (comboBox2.SelectedItem.ToString() == "OnlyIPv6")
                {
                    client = new TelegramClient(TLSHARP_API_ID, TLSHARP_API_HASH, null, TLSHARP_API_SENDER, dcIpVersion: DataCenterIPVersion.Default);
                    await client.ConnectAsync();
                    button_gettelecontact.Enabled = true;

                }
                else if (comboBox2.SelectedItem.ToString() == "PreferIPv4")
                {
                    client = new TelegramClient(TLSHARP_API_ID, TLSHARP_API_HASH, null, TLSHARP_API_SENDER, dcIpVersion: DataCenterIPVersion.Default);
                    await client.ConnectAsync();
                    button_gettelecontact.Enabled = true;

                }
                else if (comboBox2.SelectedItem.ToString() == "PreferIPv6")
                {
                    client = new TelegramClient(TLSHARP_API_ID, TLSHARP_API_HASH, null, TLSHARP_API_SENDER, dcIpVersion: DataCenterIPVersion.Default);
                    await client.ConnectAsync();
                    button_gettelecontact.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Please select DataCenterIPVersion !");
                }
            }
            catch(Exception msg)
            {
                MessageBox.Show(msg.Message.ToString(), "Error");
            }
        }
        public void GetNewSession()
        {
            TLSHARP_SESSION_ID = client.Session.Id.ToString();
            TLSHARP_SESSION_LASTMSGID = client.Session.LastMessageId.ToString();
            TLSHARP_SESSION_SALT = client.Session.Salt.ToString();
            TLSHARP_SESSION_SESSEXP = client.Session.SessionExpires.ToString();
            TLSHARP_SESSION_SEQ = client.Session.Sequence.ToString();
            TLSHARP_SESSION_SESSID = client.Session.SessionUserId.ToString();

            Properties.Settings.Default.TLSHARP_SESSION_ID = TLSHARP_SESSION_ID;
            Properties.Settings.Default.TLSHARP_SESSION_LASTMSGID = TLSHARP_SESSION_LASTMSGID;
            Properties.Settings.Default.TLSHARP_SESSION_SALT = TLSHARP_SESSION_SALT;
            Properties.Settings.Default.TLSHARP_SESSION_SESSEXP = TLSHARP_SESSION_SESSEXP;
            Properties.Settings.Default.TLSHARP_SESSION_SEQ = TLSHARP_SESSION_SEQ;
            Properties.Settings.Default.TLSHARP_SESSION_SESSID = TLSHARP_SESSION_SESSID;
            Properties.Settings.Default.Save();

            textbox_SessionId.Text = TLSHARP_SESSION_ID;
            textBox_LastMsgId.Text = TLSHARP_SESSION_LASTMSGID;
            textBox_Salt.Text = TLSHARP_SESSION_SALT;
            textBox_sessionExp.Text = TLSHARP_SESSION_SESSEXP;
            textBox_sequence.Text = TLSHARP_SESSION_SEQ;
            textBox_userid.Text = TLSHARP_SESSION_SESSID;
        }
        public void GetNewHash()
        {
            TLSHARP_SESSION_HASH = HASH.ToString();
            textBox_hash.Text = HASH;
            Properties.Settings.Default.TLSHARP_SESSION_HASH = HASH;
            Properties.Settings.Default.Save();
            button2.Enabled = true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string starttime = DateTime.Now.ToString("HH:mm:ss");
            SaveLog(starttime);
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                int x = dataGridView2.RowCount - 1;
                for (int i = 0; i <= x; i++)
                {
                    var contacts = new TLVector<TLInputPhoneContact>();
                    if (dataGridView2.Rows[i].DefaultCellStyle.BackColor != Color.Red)
                    {
                        var FIRSTNAME = dataGridView2.Rows[i].Cells[0].Value.ToString();
                        var LASTNAME = dataGridView2.Rows[i].Cells[2].Value.ToString();
                        var PHONE = dataGridView2.Rows[i].Cells[1].Value.ToString();
                        contacts.Add(new TLInputPhoneContact
                        {
                            FirstName = FIRSTNAME,
                            LastName = "[ " + LASTNAME + " ]",
                            Phone = PHONE
                        });
                        var req = new TLRequestImportContacts() { Contacts = contacts };
                        var contact = client.SendRequestAsync<TLImportedContacts>(req).GetAwaiter().GetResult();
                        Thread.Sleep(3000);
                        var counts = contact.Users.Count();
                        if (counts == 0)
                        {
                            contacts.Clear();
                            dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        }
                        else
                        {
                            contacts.Clear();
                            dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                        }
                    }
                    rtbLog.AppendText("PROGRESS "+(i+1).ToString()+" OF "+(x).ToString()+"" + Environment.NewLine);
                }
            }
            catch(Exception msg)
            {
                MessageBox.Show(msg.Message.ToString(), "Error");
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
                        "" + dataGridView2.Rows[LEFTROW].Cells[0].Value.ToString() + " until " + dataGridView2.Rows[TOTALROW-1].Cells[0].Value.ToString() + ", \n\n" +
                        "Total QR: " + Convert.ToString(STATUS) + " QR Codes.\n\n" +
                        "are you sure to continue ?", title, MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        rtbLog.AppendText("CREATING QR CODE WAS STARTED" + " - " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + Environment.NewLine);
                        string foldername = "\\QR IMAGES";
                        string BatchNo = comboBox1.Text.ToString();
                        string qrpth = imgdir + "\\" + BatchNo + "";
                        if (!Directory.Exists(qrpth))
                        {
                            Directory.CreateDirectory(qrpth);
                        }
                        string date = DateTime.Now.ToString("yyyyMMddHHmmss");
                        for (int i = LEFTROW; i <= TOTALROW-1; i++)
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
                            string timemsg = timepicker.Value.ToString("HH:mm tt").ToUpper();
                            string locmsg = textBox_locmsg.Text.ToUpper();
                            string unimsg = textBox_unimsg.Text.ToUpper();
                            string nohrd = "NO. HRD";

                            string A = ($"{Application.StartupPath}\\" + textBox_logopath.Text).ToString();
                            System.Drawing.Font font1 = new System.Drawing.Font("JetBrains Mono", 9);
                            System.Drawing.Font font2 = new System.Drawing.Font("JetBrains Mono", 9, FontStyle.Bold);

                            Master.DrawString(richTextBox1.Text
                                                           .Replace("[TITLE]", titlemsg)
                                                           .Replace("[NAME]", "NAMA" + "\t\t" + ":" + name)
                                                           .Replace("[PHONE]", "NO. HP" + "\t\t" + ":" + phone)
                                                           .Replace("[DATE]", "TANGGAL" + "\t\t" + ":" + datemsg)
                                                           .Replace("[TIME]", "WAKTU" + "\t\t\t" + ":" + timemsg)
                                                           .Replace("[LOCATION]", "LOKASI" + "\t\t\t" + ":" + locmsg)
                                                           .Replace("[UNIFORM]", "PAKAIAN" + "\t\t" + ":" + unimsg) + "\n" + "\n" + nohrd + "\n" + digits, font1, Brushes.Black, new Point(50, 150));

                            Master.DrawString("PEMALSUAN UNDANGAN, PENYALAHGUNAAN UNDANGAN ATAU KEJAHATAN LAINNYA MERUPAKAN TINDAKAN PIDANA, \n" +
                                              "PT SHIMANO BATAM AKAN MENYERAHKAN KEPADA PIHAK YANG BERWAJIB.", font2, Brushes.Black, new Point(50, 1190));

                            pictureBox1.Image = A4;
                            string filename = dataGridView2.Rows[i].Cells[2].Value.ToString() + "-" + guid + "-" + date;
                            pictureBox1.Image.Save(qrpth + @"\" + filename + ".png", ImageFormat.Png);
                            _FILEPATH = (Application.StartupPath) + foldername;
                            dataGridView2.Rows[i].Cells[3].Value = filename;
                            SP_UPDATE_INV_CODE(dataGridView2.Rows[i].Cells[2].Value.ToString(), filename);
                            rtbLog.AppendText("GENERATING QR ["+ (i + 1).ToString() + " OF " + (TOTALROW).ToString() + "], SUCCESS !" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + Environment.NewLine);
                            Task.Delay(300);
                        }
                        rtbLog.AppendText(Convert.ToString(TOTALROW) + "QR CODES HAS BEEN GENERATED !" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + Environment.NewLine);
                    }
                    else
                    {
                        rtbLog.AppendText("CREATING QR CODE WAS CANCELED" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + Environment.NewLine);
                    }
                }
                else
                {
                    MessageBox.Show("All QR for Batch " + comboBox1.Text + " has been recorded and created, please check QR Image's folder", "Success");
                }
            }
            catch(Exception msg)
            {
                rtbLog.AppendText("CREATING QR CODE HAS BEEN FAIL" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + Environment.NewLine);
                rtbLog.AppendText("ERROR: "+msg.Message.ToString() + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + Environment.NewLine);
                MessageBox.Show(msg.Message.ToString(), "ERROR: " + msg.GetType() + "");
            }
        }
        public async void SendType0(int TimeInterval)
        {
            try
            {
                int x = dataGridView1.RowCount - 1;
                for (int i = 0; i <= x; i++)
                {
                    int _id = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                    string _message = richTextBox1.Text;
                    await client.SendMessageAsync(new TLInputPeerUser() { UserId = _id }, _message);
                    if (checkBox1.Checked)
                    {
                        var fileResult = await client.UploadFile("", new StreamReader(textBox_incldimgpath.Text));
                        await client.SendUploadedPhoto(new TLInputPeerUser() { UserId = _id }, fileResult, _message);
                    }
                    Thread.Sleep(TimeInterval);
                }
                button_getbatchcontact.Enabled = true;
            }
            catch(Exception msg)
            {
                MessageBox.Show(msg.Message.ToString(), "Error");
            }
        }
        public async void SendType1(int TimeInterval)
        {
            try
            {
                button7.Enabled = false;
                string starttime = DateTime.Now.ToString("HH:mm:ss");
                int x = dataGridView3.RowCount - 1;
                int y = dataGridView2.RowCount - 1;
                string BatchNo = comboBox1.SelectedValue.ToString();
                for (int i = 0; i <= x; i++)
                {
                    int _id = Convert.ToInt32(dataGridView3.Rows[i].Cells[3].Value);
                    string Phone = Convert.ToString(dataGridView3.Rows[i].Cells[0].Value);
                    ModelDBContact DBC = new ModelDBContact();
                    var data0 = (from T in DBContactLst
                                 where T.PhoneEmp == TContactLst2[i].Phone.ToString()
                                 select new
                                 {
                                     Files = T.InvitationEmp
                                 }).ToList();
                    int rowNum = -1;
                    DataGridViewRow row = dataGridView2.Rows
                        .Cast<DataGridViewRow>()
                        .Where(r => r.Cells["PHONEEMP"].Value.ToString().Equals(Phone))
                        .First();
                    rowNum = row.Index;

                    dataGridView2.Rows[rowNum].Cells[4].Value = "2100";
                    dataGridView2.Rows[rowNum].Cells[5].Value = "INVITED";
                    string Name = dataGridView2.Rows[rowNum].Cells[0].Value.ToString();
                    string NoHP = dataGridView2.Rows[rowNum].Cells[1].Value.ToString();

                    await client.SendMessageAsync(new TLInputPeerUser() { UserId = _id },
                       richTextBox2.Text.Replace("#NAMA", Name).Replace("#NO_HP", NoHP).Replace("#URL", data0[0].Files.ToString()).Replace("#REPORT_ID", data0[0].Files.ToString()));
                    Thread.Sleep(500);

                    //await client.SendMessageAsync(new TLInputPeerUser() { UserId = _id }, 
                    //    "Kepada, " + "\n" + Name + " " + "(" + NoHP + ")" + "\n" +
                    //    "Anda telah diundangan untuk mengikuti tes tertulis PT SHIMANO BATAM.");
                    //Thread.Sleep(500);

                    string files = textBox_imgdir.Text + "\\" + BatchNo + "\\" + data0[0].Files + ".png";
                    var fileResult = await client.UploadFile("", new StreamReader(files));
                    await client.SendUploadedPhoto(new TLInputPeerUser() { UserId = _id }, fileResult, "");
                    Thread.Sleep(500);

                    //await client.SendMessageAsync(new TLInputPeerUser() { UserId = _id },
                    //   "Kepada peserta ujian,\n" +
                    //   "Dipersilahkan untuk masuk ke halaman dibawah ini,\n" +
                    //   "https://sbm-apps.dev/ERECRUITMENT2/Mobile/Dashboard/" + data0[0].Files.ToString() + "" + "\n\nJika anda mengalami logout otomatis, silakan masuk kembali dengan menekan link diatas.");
                    //Thread.Sleep(500);
                    
                   
                    //await client.SendMessageAsync(new TLInputPeerUser() { UserId = _id },
                    //   "MOHON WASPADA !!\n\n" +
                    //   "UNDANGAN TES INI TIDAK DIPUNGUT BIAYA (GRATIS), APABILA ANDA DIMINTA UNTUK MEMBAYAR DENGAN SEJUMLAH UANG TERHADAP UNDANGAN PT SHIMANO BATAM, \n\n\n" +
                    //   "HARAP MELAPOR PADA (https://sbm-apps.shimano.id/ERECRUITMENT2/SubmitReport?Id=" + data0[0].Files.ToString() + ") ");
                    //Thread.Sleep(500);

                    rtbLog.AppendText("SENDING [" + (i + 1).ToString() + " OF " + (x + 1).ToString() + "] " + "(" + Name.ToUpper() + " - " + NoHP.ToUpper() + ") SUCCESS" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + Environment.NewLine);
                    //SP_UPDATE_CANDIDATE_STATUS(dataGridView2.Rows[i].Cells[3].Value.ToString(), "2100", "INVITED");
                    //rtbLog.AppendText("UPDATING ["+ dataGridView2.Rows[i].Cells[3].Value.ToString() + "] TO [2100-INVITED], SUCCESS" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + Environment.NewLine);

                    Thread.Sleep(TimeInterval);
                }
                for (int i = 0; i <= y; i++)
                {
                    string A = dataGridView2.Rows[i].Cells[4].Value.ToString();
                    string B = dataGridView2.Rows[i].Cells[0].Value.ToString();
                    if (dataGridView2.Rows[i].Cells[4].Value.ToString().Equals("2000"))
                    {
                        dataGridView2.Rows[i].Cells[4].Value = "2600";
                        dataGridView2.Rows[i].Cells[5].Value = "TELEGRAM FAILED INVITED";
                        dataGridView2.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                        SP_UPDATE_CANDIDATE_STATUS(dataGridView2.Rows[i].Cells[3].Value.ToString(), "2600", "TELEGRAM FAILED INVITED");
                        //rtbLog.AppendText("UPDATING [" + dataGridView2.Rows[i].Cells[3].Value.ToString() + "] TO [2600-TELEGRAM FAILED INVITED], SUCCESS " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + Environment.NewLine);
                    }
                    else
                    {
                        SP_UPDATE_CANDIDATE_STATUS(dataGridView2.Rows[i].Cells[3].Value.ToString(), dataGridView2.Rows[i].Cells[4].Value.ToString(), dataGridView2.Rows[i].Cells[5].Value.ToString());
                    }
                }
                button_getbatchcontact.Enabled = true;
                rtbLog.AppendText("COMPLETED ! " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + Environment.NewLine);
                SaveLog(starttime);
                SP_UPDATE_BATCHSTATUS(BatchNo, "0001");
                //SP_UPDATE_ALL_USER_TABLE(BatchNo);
            }
            catch(Exception msg)
            {
                rtbLog.AppendText("SENDING TELEGRAM SendType1 WITH INTERVAL: "+ TimeInterval.ToString() + " HAS BEEN FAIL " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + Environment.NewLine);
                rtbLog.AppendText("ERROR: " + msg.Message.ToString() + "" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + Environment.NewLine);
                MessageBox.Show(msg.Message.ToString(), "ERROR");
                button7.Enabled = true;
            }
        }
        public void SaveLog(string starttime)
        {
            if (rtbLog.Text != "")
            {
                try
                {
                    string Author = gVar.getProperty("UseNam");
                    DateTime start = DateTime.ParseExact(starttime, "HH:mm:ss",CultureInfo.InvariantCulture);
                    DateTime end = DateTime.Now;
                    TimeSpan ts = (end - start);
                    string rptdir = textBox_rptdir.Text;
                    BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                    string filename = ("LOG-" + "DATE (" + DateTime.Now.ToString("ddMMMyyyy") + ") TIME (" + DateTime.Now.ToString("HHmmss tt" + ")")).ToUpper();
                    iTextSharp.text.Document doc = new iTextSharp.text.Document();
                    PdfWriter.GetInstance(doc, new FileStream(""+ rptdir + "" + "\\" +(filename + ".pdf"), FileMode.Create));
                    doc.Open();
                    doc.Add(new iTextSharp.text.Paragraph("FILE NAME: " + filename + "\n" +
                                                          "REPROT TYPE: \t\tTELEGRAM REPORT\n" +
                                                          "AUTHOR: \t\t" + Author + "\n" +
                                                          "REPORT DATE: \t\t" + DateTime.Now.ToString("dd-MMM-yyyy") + "\n" +
                                                          "REPORT TIME: \t\t" + DateTime.Now.ToString("HH:mm:ss") + "\n" +
                                                          "START TIME: \t\t" + starttime + "\n" +
                                                          "END TIME: \t\t" + DateTime.Now.ToString("HH:mm:ss") + "\n" +
                                                          "DURATION: \t\t" + ts.Minutes.ToString() + " Minute and " + ts.Seconds.ToString() + " Second" +"\n" +
                                                          "\n" +
                                                          "\n" +
                                                          rtbLog.Text));
                    doc.Close();
                    //rtbLog.Text = "";
                    string InputFile =  "" + rptdir + "" + "\\" + (filename + ".pdf");
                    string OutputFile = "" + rptdir + "" + "\\" + (filename + " - PROTECTED" + ".pdf");
                    
                    using (Stream input = new FileStream(InputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        using (Stream output = new FileStream(OutputFile, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            PdfReader reader = new PdfReader(input);
                            PdfEncryptor.Encrypt(reader, output, true, textBox_rptpass.Text, textBox_rptpass.Text, PdfWriter.ALLOW_SCREENREADERS);
                        }
                    }
                    File.Delete(InputFile);
                    SP_UPDATE_LOGFILE_TELEGRAM(comboBox1.Text.ToString(), filename + ".pdf");
                    MessageBox.Show("Log has been saved on Database", "Success");

                    button7.Enabled = true;
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.ToString(), "Saving Log Failed");
                }
            }
            else
            {
                MessageBox.Show("No log to save", "Saving Log Failed");
            }
        }
        //public void SP_UPDATE_ALL_USER_TABLE(string BatchNo)
        //{
        //    var Sql = @"EXEC [SP_UPDATE_ALL_USER_TABLE] '" + BatchNo + "'";
        //    Sql = string.Format(Sql);
        //    System.Data.DataTable data0 = SysUtl.ExecuteDTQuery(Sql, null);
        //}
        public void SP_UPDATE_CANDIDATE_STATUS(string InvitationEmp, string Status, string Remark)
        {
            var Sql = @"EXEC [SP_UPDATE_CANDIDATE_STATUS] '" + InvitationEmp + "','"+ Status + "','"+ Remark + "'";
            Sql = string.Format(Sql);
            DataTable data0 = SysUtl.ExecuteDTQuery(Sql, null);
        }
        public void SP_GET_CONTACT_LIST1(string BatchNo)
        {
            try
            {
                button_getbatchcontact.Enabled = false;
                var Sql = @"EXEC [SP_GET_CONTACT_LIST1] '" + BatchNo + "'";
                Sql = string.Format(Sql);
                System.Data.DataTable tUsr = SysUtl.ExecuteDTQuery(Sql, null);
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
                    button_getbatchcontact.Enabled = true;
                    button_generateqr.Enabled = true;
                }
                else
                {
                    button_getbatchcontact.Enabled = true;
                    MessageBox.Show("No candidate for selected Batch Number !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                rtbLog.AppendText("GET BATCH CONTACT SUCCESS ! " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "" + Environment.NewLine);
            }
            catch (Exception msg)
            {
                button_getbatchcontact.Enabled = true;
                rtbLog.AppendText("ERROR: " + msg.Message.ToString() + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "" + Environment.NewLine);
                MessageBox.Show(msg.Message.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void SP_GET_BATCHLIST_2()
        {
            try
            {
                var Sql = @"EXEC [SP_GET_BATCHLIST_2]";
                Sql = string.Format(Sql);
                System.Data.DataTable dt = SysUtl.ExecuteDTQuery(Sql, null);
                if (dt.Rows.Count == 0)
                {
                    comboBox1.Items.Clear();
                }
                else
                {
                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "BatchNo";
                    comboBox1.ValueMember = "BatchNo";
                    button_getbatchcontact.Enabled = true;
                }
                rtbLog.AppendText("GET BATCH LIST SUCCESS ! " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "" + Environment.NewLine);
            }
            catch (Exception msg)
            {
                rtbLog.AppendText("ERROR: " + msg.Message.ToString() + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "" + Environment.NewLine);
                MessageBox.Show(msg.Message.ToString());
                button_getbatchcontact.Enabled = false;
            }
        }
        public void SP_UPDATE_INV_CODE(string BatchEmp, string InvitationEmp)
        {
            var query = "";
            query = @"EXEC [SP_UPDATE_INV_CODE] '" + BatchEmp + "','" + InvitationEmp + "'";
            query = string.Format(query);
            SysUtl.ExecuteDTQuery(query, null);
        }
        public void SP_UPDATE_LOGFILE_TELEGRAM(string BatchNo, string FileName)
        {
            var query = "";
            query = @"EXEC [SP_UPDATE_LOGFILE_TELEGRAM] '" + BatchNo + "','" + FileName + "'";
            query = string.Format(query);
            SysUtl.ExecuteDTQuery(query, null);
        }
        public void SP_UPDATE_BATCHSTATUS(string BatchNo, string Status)
        {
            var query = "";
            query = @"EXEC [SP_UPDATE_BATCHSTATUS] '" + BatchNo + "','"+ Status + "'";
            query = string.Format(query);
            SysUtl.ExecuteDTQuery(query, null);
        }
    }
}
