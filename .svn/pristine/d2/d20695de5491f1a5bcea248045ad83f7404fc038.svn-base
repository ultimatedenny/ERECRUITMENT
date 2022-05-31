using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using eReqruitment;
using System.Diagnostics;

namespace eReqruitment
{
    public partial class FrmAuth : Form
    {
        SysUtl su = new SysUtl();
        int TagMove;
        int MValX;
        int MValY;
        public static string NAME;
        public FrmAuth()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if (string.IsNullOrEmpty(tbWindowsID.Text))
            {
                MessageBox.Show("Wondows ID can't empty");
            }
            else if (string.IsNullOrEmpty(tbWindowsPassword.Text))
            { 
                MessageBox.Show("Wondows Password can't empty"); 
            }
            else
            {
                string A = tbWindowsID.Text.ToLower();
                A.ToLower();
                if (A == "sbm_deni" || A == "splb0021" || A == "sbm_fin180093" || A == "sbm_bpr200969")
                {
                    bool rtn = su.WinAuth(tbWindowsID.Text, tbWindowsPassword.Text);
                    if (rtn)
                    {
                        NAME = tbWindowsID.Text;
                        this.Hide();
                        FrmMain Main = new FrmMain();
                        Main.ShowDialog();
                        button1.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Login failed");
                        button1.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("You don't have access for this");
                    button1.Enabled = true;
                }
            }
            button1.Enabled = true;
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

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAuth_Load(object sender, EventArgs e)
        {
            //Process[] pname = Process.GetProcessesByName("Logger");
            //if (pname.Length == 0)
            //{
            //    RunLogger();
            //}
            //else
            //{

            //}
        }
        private void RunLogger()
        {
            //Process.Start(@"C:\\expana\\Logger.exe");
        }
    }
}
