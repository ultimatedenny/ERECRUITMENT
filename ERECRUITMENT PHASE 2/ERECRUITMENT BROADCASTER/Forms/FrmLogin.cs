using System;
using System.Configuration;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Windows.Forms;
using ERECRUITMENT_BROADCASTER.Utilities;

namespace ERECRUITMENT_BROADCASTER.Forms
{
    public partial class FrmLogin : Form
    {
        WinAuthClass WAC = new WinAuthClass();
        int TagMove;
        int MValX;
        int MValY;
        public string ConnectionDB = ConfigurationManager.AppSettings["SQLCON"].ToString();
        public FrmLogin()
        {
            InitializeComponent();
            signin_btn.Enabled = true;
            retry_btn.Enabled = false;
            retry_btn.Visible = false;
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            machinename.Text = ": " + Environment.MachineName;
            Guid tokenid = Guid.NewGuid();
            token.Text = ": " + tokenid.ToString().ToUpper();
            time.Text = ": " + DateTime.Now.ToString("HH:mm dd-MM-yyyy");
            username.Text = "sbm_deni";
            password.Text = "juliasayang";
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                signin_btn.Enabled = false;
                retry_btn.Enabled = true;
                retry_btn.Visible = true;
            }
            else
            {
                signin_btn.Enabled = true;
                retry_btn.Enabled = false;
                retry_btn.Visible = false;
                GetLocalIPAddress();
            }
        }
        public void GetLocalIPAddress()
        {
            try
            {
                string localIP = string.Empty;
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                {
                    socket.Connect("8.8.8.8", 65530);
                    IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                    ip.Text = ": " + endPoint.Address.ToString();
                }
            }
            catch (Exception msg)
            {
                string message = msg.ToString();
                string title = "ERROR: Failed getting IP Address";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    this.Hide();
                }
            }
        }
        private void retry_btn_Click(object sender, EventArgs e)
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                signin_btn.Enabled = false;
                retry_btn.Enabled = true;
                retry_btn.Visible = true;
            }
            else
            {
                signin_btn.Enabled = true;
                retry_btn.Enabled = false;
                retry_btn.Visible = false;
                GetLocalIPAddress();
            }
        }
        private void signin_btn_Click(object sender, EventArgs e)
        {

            try
            {
                signin_btn.Enabled = false;
                if (string.IsNullOrEmpty(username.Text))
                {
                    MessageBox.Show("Please fill username", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    signin_btn.Enabled = true;
                }
                else if (string.IsNullOrEmpty(password.Text))
                {
                    MessageBox.Show("Please fill password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    signin_btn.Enabled = true;
                }
                else
                {
                    var ConStr = ConfigurationManager.AppSettings["SQLCON"].ToString();
                    var UseRole = false;
                    var RoleName = ConfigurationManager.AppSettings["RuleName"].ToString();
                    var RolePassword = ConfigurationManager.AppSettings["RulePassword"].ToString();
                    var DefaultCon = true;
                    SysUtl.ConnectionStatus = SysUtl.SQLCon(ConStr, UseRole, RoleName, RolePassword, DefaultCon);
                    if (SysUtl.ConnectionStatus == false)
                    {
                        MessageBox.Show("Connection Status Return False", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        signin_btn.Enabled = true;
                    }
                    else
                    {
                        var result = SysUtl.ExecuteDTQuery(string.Format("SELECT TOP 1 * FROM Usr WHERE UseId = '{0}'", username.Text), null);
                        if (result.Rows.Count <= 0)
                        {
                            MessageBox.Show("Unauthorized Access!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            signin_btn.Enabled = true;
                        }
                        else
                        {
                            string ID = username.Text.ToLower();
                            ID.ToLower();
                            bool loginwindows = true;//WAC.WinAuth(ID, password.Text);
                            if (loginwindows)
                            {
                                var Sql = @"SELECT TOP 1 * FROM usr WHERE UseID='{0}'";
                                Sql = string.Format(Sql, ID);
                                DataTable tUsr = SysUtl.ExecuteDTQuery(Sql, null);

                                if (Convert.ToBoolean(tUsr.Rows[0]["IsWindowsAuth"]) == true)
                                {
                                    var USEID = username.Text;
                                    var USEPASS = password.Text;
                                    bool WINSUCCESS = WAC.WinAuth(USEID, USEPASS);
                                    if (WINSUCCESS)
                                    {
                                        gVar.DestroyAllProperty();
                                        object item;
                                        if (!gVar.properties.TryGetValue("sys_usr", out item))
                                        {
                                            gVar.AddProperty("sys_usr", ID, "C");
                                        }
                                        gVar.setProperty("sys_usr", ID.Trim());
                                        gVar.AddProperty("Comcod", tUsr.Rows[0]["usecomcod"].ToString().Trim(), "C");
                                        if (!gVar.properties.TryGetValue("sys_BusFunc", out item))
                                        {
                                            gVar.AddProperty("sys_BusFunc", tUsr.Rows[0]["BusFunc"].ToString().Trim(), "C");
                                        }
                                        gVar.setProperty("sys_BusFunc", tUsr.Rows[0]["BusFunc"].ToString().Trim());
                                        gVar.AddProperty("UseNam", tUsr.Rows[0]["UseId"].ToString().Trim(), "C");
                                        gVar.AddProperty("DisNam", tUsr.Rows[0]["UseNam"].ToString().Trim(), "C");
                                        gVar.AddProperty("UseRoleId", tUsr.Rows[0]["UseRole"].ToString().Trim(), "C");
                                        gVar.AddProperty("UseRole", Utils.GetUserRole(tUsr.Rows[0]["UseRole"].ToString().Trim()).ToString(), "C");
                                        gVar.AddProperty("UseToken", "", "C");
                                        gVar.AddProperty("UseMac", Utils.GetMacAddress(), "C");
                                        gVar.AddProperty("SysNam", SysUtl.SysNam, "C");
                                        gVar.AddProperty("DefaultFormColor", ConfigurationManager.AppSettings["DefaultFormColor"].ToString(), "C");
                                        tUsr.Dispose();
                                        signin_btn.Enabled = true;
                                        MainForm mainForm = new MainForm();
                                        FrmLogin loginForm = new FrmLogin();
                                        Utils.MainForm = mainForm;
                                        mainForm.Show();
                                        this.Hide();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Wrong Windows Password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                else
                                {
                                    gVar.DestroyAllProperty();
                                    object item;
                                    if (!gVar.properties.TryGetValue("sys_usr", out item))
                                    {
                                        gVar.AddProperty("sys_usr", ID, "C");
                                    }
                                    gVar.setProperty("sys_usr", ID.Trim());
                                    gVar.AddProperty("Comcod", tUsr.Rows[0]["usecomcod"].ToString().Trim(), "C");
                                    if (!gVar.properties.TryGetValue("sys_BusFunc", out item))
                                    {
                                        gVar.AddProperty("sys_BusFunc", tUsr.Rows[0]["BusFunc"].ToString().Trim(), "C");
                                    }
                                    gVar.setProperty("sys_BusFunc", tUsr.Rows[0]["BusFunc"].ToString().Trim());
                                    gVar.AddProperty("UseNam", tUsr.Rows[0]["UseId"].ToString().Trim(), "C");
                                    gVar.AddProperty("DisNam", tUsr.Rows[0]["UseNam"].ToString().Trim(), "C");
                                    gVar.AddProperty("UseRoleId", tUsr.Rows[0]["UseRole"].ToString().Trim(), "C");
                                    gVar.AddProperty("UseRole", Utils.GetUserRole(tUsr.Rows[0]["UseRole"].ToString().Trim()).ToString(), "C");
                                    gVar.AddProperty("UseToken", "", "C");
                                    gVar.AddProperty("UseMac", Utils.GetMacAddress(), "C");
                                    gVar.AddProperty("SysNam", SysUtl.SysNam, "C");
                                    gVar.AddProperty("DefaultFormColor", ConfigurationManager.AppSettings["DefaultFormColor"].ToString(), "C");
                                    tUsr.Dispose();
                                    signin_btn.Enabled = true;
                                    MainForm mainForm = new MainForm();
                                    FrmLogin loginForm = new FrmLogin();
                                    Utils.MainForm = mainForm;
                                    mainForm.Show();
                                    this.Hide();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Wrong Windows Password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                signin_btn.Enabled = true;
                            }
                        }
                    }
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                signin_btn.Enabled = true;
            }
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void label9_MouseDown(object sender, MouseEventArgs e)
        {
            TagMove = 1;
            MValX = e.X;
            MValY = e.Y;
        }

        private void label9_MouseMove(object sender, MouseEventArgs e)
        {
            if (TagMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        private void label9_MouseUp(object sender, MouseEventArgs e)
        {
            TagMove = 0;
        }
    }
}
