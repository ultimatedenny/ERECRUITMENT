using BaseFormLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERECRUITMENT_BROADCASTER
{
    public partial class BatchInfo : _BaseForm
    {
        public BatchInfo()
        {
            InitializeComponent();
            var ConStr = ConfigurationManager.AppSettings["SQLCON"].ToString();
            var RoleName = ConfigurationManager.AppSettings["RuleName"].ToString();
            var RolePassword = ConfigurationManager.AppSettings["RulePassword"].ToString();
            RequestDate.Checked = true;
            InvitationDate.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string val1 = "1";
                string val2 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string val3 = maskedTextBox1.Text.ToString();
                string val4 = "PENDING";
                var Sql = @"EXEC [spGetBatchInfo]'{0}','{1}','{2}','{3}'";
                Sql = string.Format(Sql, val1, val2, val3, val4);
                DataTable tUsr = SysUtl.ExecuteDTQuery(Sql, null);
                dataGridView1.DataSource = tUsr;
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string val1 = "1";
                string val2 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string val3 = comboBox1.SelectedValue.ToString();
                string val4 = "PENDING";
                var Sql = @"EXEC [spGetBatchInfo]'{0}','{1}','{2}','{3}'";
                Sql = string.Format(Sql, val1, val2, val3, val4);
                DataTable tUsr = SysUtl.ExecuteDTQuery(Sql, null);
                dataGridView1.DataSource = tUsr;
            }
            catch(Exception msg)
            {
                MessageBox.Show(msg.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void GetBatchList(string Date)
        {
            string val1 = "";
            string val2 = Date;
            if (RequestDate.Checked == true && InvitationDate.Checked == false)
            {
                val1 = "0";
            }
            else if (RequestDate.Checked == false && InvitationDate.Checked == true)
            {
                val1 = "1";
            }
            else
            {
                MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var Sql = @"EXEC [spGetBatchList]'{0}','{1}'";
            Sql = string.Format(Sql, val1, val2);
            DataTable tUsr = SysUtl.ExecuteDTQuery(Sql, null);
            if (tUsr.Rows.Count == 0)
            {
                comboBox1.Items.Clear();
            }
            else
            {
                comboBox1.DataSource = tUsr;
                comboBox1.DisplayMember = "BatchNo";
                comboBox1.ValueMember = "BatchNo";
            }
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetBatchList(dateTimePicker1.Value.ToString("yyyy-MM"));
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void dateTimePicker1_DropDown(object sender, EventArgs e)
        {
            IntPtr cal = SendMessage(dateTimePicker1.Handle, DTM_GETMONTHCAL, IntPtr.Zero, IntPtr.Zero);
            SendMessage(cal, MCM_SETCURRENTVIEW, IntPtr.Zero, (IntPtr)1);
        }
        private const int DTM_GETMONTHCAL = 0x1000 + 8;
        private const int MCM_SETCURRENTVIEW = 0x1000 + 32;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        
    }
}
