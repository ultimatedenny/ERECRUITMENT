using BaseFormLibrary;
using System;
using System.Linq;
using System.Windows.Forms;
using WeeferCustomLibrary;
using ERECRUITMENT_BROADCASTER.Model;
using System.Net.NetworkInformation;
using ERECRUITMENT_BROADCASTER.Forms;


namespace ERECRUITMENT_BROADCASTER.Utilities
{
    public static class Utils
    {
        public static MainForm MainForm { get; set; }
        public static void OpenForm(object sender, Panel container = null)
        {
            _BaseForm frm = new _BaseForm();
            if (container == null)
                container = MainForm.SpBody;

            var senderName = "";
            if (sender is WeeferNavigationMenu)
            {
                senderName = (sender as WeeferNavigationMenu).Name;
                System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
                frm = (_BaseForm)asm.CreateInstance(senderName);
            }
            else if (sender is _BaseForm)
            {
                frm = (sender as _BaseForm);
            }
            try
            {
                frm.TopLevel = false;
                frm.WindowState = FormWindowState.Normal;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                container.Controls.Add(frm);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Form '{0}' not found!", ex.Message.ToString()), "Error found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public static Boolean IsUserExist(String Usename, String ConStr, bool UseRole, String RoleName, String RolePassword, bool DefaultCon = false, bool ThirdPartyDeveloperMode = false)
        {
            SysUtl.ConnectionStatus = SysUtl.SQLCon(ConStr, UseRole, RoleName, RolePassword, DefaultCon);
            if (SysUtl.ConnectionStatus == false)
            {
                return false;
            }
            var result = SysUtl.ExecuteDTQuery(string.Format("SELECT TOP 1 * FROM Usr WHERE UseId = '{0}'", Usename), null);
            if (result.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public static UserRole GetUserRole(int RoleId)
        {
            return (UserRole)RoleId;
        }
        public static UserRole GetUserRole(string RoleId)
        {
            return (UserRole)int.Parse(RoleId);
        }
        public static string GetMacAddress()
        {
            var macAddr =
                    (
                        from nic in NetworkInterface.GetAllNetworkInterfaces()
                        where nic.OperationalStatus == OperationalStatus.Up
                        select nic.GetPhysicalAddress().ToString()
                    ).FirstOrDefault();
            return macAddr;
        }
    }
}
