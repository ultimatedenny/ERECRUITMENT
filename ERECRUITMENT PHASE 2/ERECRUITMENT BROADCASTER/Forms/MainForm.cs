using BaseFormLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WeeferCustomLibrary;
using ERECRUITMENT_BROADCASTER.Properties;
using ERECRUITMENT_BROADCASTER.Utilities;

namespace ERECRUITMENT_BROADCASTER.Forms
{
    public partial class MainForm : _BaseForm
    {
        int TagMove;
        int MValX;
        int MValY;
        int seq2;
        public MainForm()
        {
            InitializeComponent();
            RegisterEventHandler();
        }
        private void RegisterEventHandler()
        {
            this.Resize += Form1_Resize;
            this.weeferNavigationPanel1.NavigationMenuClicked += WeeferNavigationPanel1_NavigationMenuClicked;
            this.weeferNavigationPanel1.NavigationOptionClicked += WeeferNavigationPanel1_NavigationOptionClicked;
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            foreach (Control item in SpBody.Controls)
            {
                item.Dock = DockStyle.Fill;
                item.Size = SpBody.Size;
            }
        }
        private void WeeferNavigationPanel1_NavigationOptionClicked(object sender, EventArgs e)
        {
            Application.DoEvents();
            var senderName = "";
            if (sender is WeeferNavigationMenu)
            {
                senderName = (sender as WeeferNavigationMenu).Name;
            }
            if (senderName == "exit")
            {
                FrmLogin frm = new FrmLogin();
                frm.Show();
                this.Close();
            }
            else
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
                _BaseForm frm = (_BaseForm)asm.CreateInstance(senderName);
                frm.ShowDialog();
            }
        }
        private void WeeferNavigationPanel1_NavigationMenuClicked(object sender, EventArgs e)
        {
            Application.DoEvents();
            foreach (WeeferNavigationMenu menu in weeferNavigationPanel1.WeeferNavigationMenus)
            {
                menu.ActiveState = false;
            }
            (sender as WeeferNavigationMenu).ActiveState = true;
            SpBody.Controls.Clear();
            Utils.OpenForm(sender, SpBody);
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MainForm mainForm = new MainForm();
            //FrmLogin loginForm = new FrmLogin();
            //Utils.MainForm = mainForm;
            //loginForm.Show();
            //mainForm.Dispose();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            SeedData.Seed();
            weeferNavigationPanel1.UserText = gVar.getProperty("DisNam");
            weeferNavigationPanel1.SubUserText = gVar.getProperty("UseRole");

            var Sql = @"select a.BusFunc,b.* from levelmenu a
                        LEFT join menulist b on a.MnuCod=b.MnuCod and a.BusFunc='" + gVar.getProperty("sys_BusFunc") + @"'
                        where MnuLev<>0 and UPPER(isnull(FRMNAM,''))<>'HIDDEN' and b.[group]='ER'
                        order by MnuCod";
            var Menus = SysUtl.ExecuteDTQuery(Sql, null);
            Utils.MainForm = this;

            List<WeeferNavigationMenu> menus = new List<WeeferNavigationMenu>();
            List<WeeferNavigationMenu> options = new List<WeeferNavigationMenu>();

            foreach (var item in Menus.Rows)
            {
                if (item["MnuLev"].ToString() == "9")
                {
                    WeeferNavigationMenu option = new WeeferNavigationMenu()
                    {
                        Image = (Bitmap)Resources.ResourceManager.GetObject(item["Pic"]),
                        Text = item["MnuNam"].ToString(),
                        Name = item["FRMNAM"].ToString(),
                        BorderColor     = Color.FromArgb(31, 31, 31),
                        BorderWidth     = 0,
                        ActiveState     = false,
                        HoverColor      = Color.FromArgb(113, 96, 232),
                        InactiveColor   = Color.FromArgb(51, 51, 51),
                        ActiveColor     = Color.FromArgb(113, 96, 232)
                    };
                    options.Add(option);
                }
                else if (!string.IsNullOrWhiteSpace(item["FRMNAM"].ToString()))
                {
                    WeeferNavigationMenu menu = new WeeferNavigationMenu()
                    {
                        Image = (Bitmap)Resources.ResourceManager.GetObject(item["Pic"]),
                        Text = item["MnuNam"].ToString(),
                        Name = item["FRMNAM"].ToString(),
                        BorderColor = Color.FromArgb(31, 31, 31),
                        BorderWidth = 0,
                        ActiveState = false,
                        HoverColor = Color.FromArgb(113, 96, 232),
                        InactiveColor = Color.FromArgb(51, 51, 51),
                        ActiveColor = Color.FromArgb(113, 96, 232)
                    };
                    menus.Add(menu);
                }
            }
            weeferNavigationPanel1.WeeferNavigationMenus = menus;
            weeferNavigationPanel1.WeeferNavigationOptions = options;
            weeferNavigationPanel1.FooterHeight = options.Count * weeferNavigationPanel1.NavigationMenuHeight;
            weeferNavigationPanel1.NavigationHeight = this.Height - weeferNavigationPanel1.HeaderHeight - weeferNavigationPanel1.FooterHeight;
            //weeferNavigationPanel1.BackColor = Color.FromArgb(244, 245, 247);
            //weeferNavigationPanel1.DarkerBackColor = Color.FromArgb(221, 228, 236);
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
            Environment.Exit(0);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                try
                {
                    this.WindowState = FormWindowState.Normal;
                }
                catch
                {
                    this.WindowState = FormWindowState.Maximized;
                }
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void weeferNavigationPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
