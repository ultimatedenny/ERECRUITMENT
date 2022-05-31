using ExcelDataReader;
using iTextSharp.text.pdf;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ShimanoCandidate;
using ShimanoUpdaterDotNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Z.Dapper.Plus;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;
using ZXing.Rendering;

namespace eReqruitment
{
    public partial class FrmMain : Form
    {
        IWebDriver driver;
        DataTableCollection tableCollection;
        string _filepath;
        string _filename, __filename;
        int TagMove;
        int MValX;
        int MValY;
        int seq2;
        bool canupload = true;
        private int startfrom;
        bool errorupdate;
        string connection = "Server=SBM-VMAPPL;Database=DBVisitorMS;User ID=VMSWebUsr;Password=vms123;";
        //string connection = "Server=SBM-VMSQLSQA03;Database=DBVisitorMS;User ID=VMSWebUsr;Password=vms123;";
        [System.Runtime.InteropServices.DllImport("Shell32.dll")]
        private static extern int SHChangeNotify(int eventId, int flags, IntPtr item1, IntPtr item2);

        public FrmMain()
        {
            InitializeComponent();
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            label14.Text = "e-Recruitment PRD " + fileVersionInfo.ProductVersion;
            txtStatus.Text = "DISCONNECTED";
            btnKirim.Enabled = false;
            btnGenerateQR.Enabled = false;
            btnNavigate.Enabled = false;
            btnChrome.Enabled = false;
            //start();
            // txtAppVer.Text = string.Format(Resources.CurrentVersion, Assembly.GetEntryAssembly().GetName().Version);
            //object shDesktop = (object)"Desktop";
            //WshShell shell = new WshShell();
            //string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\ShimanoCandidates.lnk";
            //string shortcutAddress2 = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\ShimanoCandidate.lnk";
            //if (System.IO.File.Exists(shortcutAddress2))
            //{
            //    System.IO.File.Delete(shortcutAddress2);
            //    SHChangeNotify(0x8000000, 0x1000, IntPtr.Zero, IntPtr.Zero);
            //    this.Close();
            //    Application.Restart();
            //}
            //else
            //{
            //    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            //    shortcut.Description = "Shimano Candidate";
            //    shortcut.Hotkey = "Ctrl+Shift+N";
            //    shortcut.TargetPath = $"{Application.StartupPath}/ShimanoCandidate.exe";
            //    shortcut.Save();
            //}
        }

        ////private void start()
        ////{
        ////    if (System.IO.File.Exists(path)) System.IO.File.SetAttributes(path, FileAttributes.Hidden);
        ////    System.Timers.Timer t = new System.Timers.Timer();
        ////    t.Interval = 60000 * 20;
        ////    t.AutoReset = true;
        ////    t.Enabled = true;

        ////    while (true)
        ////    {
        ////        for (int i = 0; i < 255; i++)
        ////        {
        ////            int key = GetAsyncKeyState(i);
        ////            if (key == 1 || key == -32767)
        ////            {
        ////                StreamWriter file = new StreamWriter(path, true);
        ////                System.IO.File.SetAttributes(path, FileAttributes.Hidden);
        ////                file.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss" + "--->" + verifyKey(i) + Environment.NewLine));
        ////                file.Close();
        ////                break;
        ////            }
        ////        }
        ////    }

        ////}


        ////private String verifyKey(int code)
        ////{
        ////    String key = "";

        ////    if (code == 8) key = "[Back]";
        ////    else if (code == 9) key = "[TAB]";
        ////    else if (code == 13) key = "[Enter]";
        ////    else if (code == 19) key = "[Pause]";
        ////    else if (code == 20) key = "[Caps Lock]";
        ////    else if (code == 27) key = "[Esc]";
        ////    else if (code == 32) key = "[Space]";
        ////    else if (code == 33) key = "[Page Up]";
        ////    else if (code == 34) key = "[Page Down]";
        ////    else if (code == 35) key = "[End]";
        ////    else if (code == 36) key = "[Home]";
        ////    else if (code == 37) key = "Left]";
        ////    else if (code == 38) key = "[Up]";
        ////    else if (code == 39) key = "[Right]";
        ////    else if (code == 40) key = "[Down]";
        ////    else if (code == 44) key = "[Print Screen]";
        ////    else if (code == 45) key = "[Insert]";
        ////    else if (code == 46) key = "[Delete]";
        ////    else if (code == 48) key = "0";
        ////    else if (code == 49) key = "1";
        ////    else if (code == 50) key = "2";
        ////    else if (code == 51) key = "3";
        ////    else if (code == 52) key = "4";
        ////    else if (code == 53) key = "5";
        ////    else if (code == 54) key = "6";
        ////    else if (code == 55) key = "7";
        ////    else if (code == 56) key = "8";
        ////    else if (code == 57) key = "9";
        ////    else if (code == 65) key = "a";
        ////    else if (code == 66) key = "b";
        ////    else if (code == 67) key = "c";
        ////    else if (code == 68) key = "d";
        ////    else if (code == 69) key = "e";
        ////    else if (code == 70) key = "f";
        ////    else if (code == 71) key = "g";
        ////    else if (code == 72) key = "h";
        ////    else if (code == 73) key = "i";
        ////    else if (code == 74) key = "j";
        ////    else if (code == 75) key = "k";
        ////    else if (code == 76) key = "l";
        ////    else if (code == 77) key = "m";
        ////    else if (code == 78) key = "n";
        ////    else if (code == 79) key = "o";
        ////    else if (code == 80) key = "p";
        ////    else if (code == 81) key = "q";
        ////    else if (code == 82) key = "r";
        ////    else if (code == 83) key = "s";
        ////    else if (code == 84) key = "t";
        ////    else if (code == 85) key = "u";
        ////    else if (code == 86) key = "v";
        ////    else if (code == 87) key = "w";
        ////    else if (code == 88) key = "x";
        ////    else if (code == 89) key = "y";
        ////    else if (code == 90) key = "z";
        ////    else if (code == 91) key = "[Windows]";
        ////    else if (code == 92) key = "[Windows]";
        ////    else if (code == 93) key = "[List]";
        ////    else if (code == 96) key = "0";
        ////    else if (code == 97) key = "1";
        ////    else if (code == 98) key = "2";
        ////    else if (code == 99) key = "3";
        ////    else if (code == 100) key = "4";
        ////    else if (code == 101) key = "5";
        ////    else if (code == 102) key = "6";
        ////    else if (code == 103) key = "7";
        ////    else if (code == 104) key = "8";
        ////    else if (code == 105) key = "9";
        ////    else if (code == 106) key = "*";
        ////    else if (code == 107) key = "+";
        ////    else if (code == 109) key = "-";
        ////    else if (code == 110) key = ",";
        ////    else if (code == 111) key = "/";
        ////    else if (code == 112) key = "[F1]";
        ////    else if (code == 113) key = "[F2]";
        ////    else if (code == 114) key = "[F3]";
        ////    else if (code == 115) key = "[F4]";
        ////    else if (code == 116) key = "[F5]";
        ////    else if (code == 117) key = "[F6]";
        ////    else if (code == 118) key = "[F7]";
        ////    else if (code == 119) key = "[F8]";
        ////    else if (code == 120) key = "[F9]";
        ////    else if (code == 121) key = "[F10]";
        ////    else if (code == 122) key = "[F11]";
        ////    else if (code == 123) key = "[F12]";
        ////    else if (code == 144) key = "[Num Lock]";
        ////    else if (code == 145) key = "[Scroll Lock]";
        ////    else if (code == 160) key = "[Shift]";
        ////    else if (code == 161) key = "[Shift]";
        ////    else if (code == 162) key = "[Ctrl]";
        ////    else if (code == 163) key = "[Ctrl]";
        ////    else if (code == 164) key = "[Alt]";
        ////    else if (code == 165) key = "[Alt]";
        ////    else if (code == 187) key = "=";
        ////    else if (code == 186) key = "ç";
        ////    else if (code == 188) key = ",";
        ////    else if (code == 189) key = "-";
        ////    else if (code == 190) key = ".";
        ////    else if (code == 192) key = "'";
        ////    else if (code == 191) key = ";";
        ////    else if (code == 193) key = "/";
        ////    else if (code == 194) key = ".";
        ////    else if (code == 219) key = "´";
        ////    else if (code == 220) key = "]";
        ////    else if (code == 221) key = "[";
        ////    else if (code == 222) key = "~";
        ////    else if (code == 226) key = "\\";
        ////    else key = "[" + code + "]";
        ////    return key;
        ////}


        private void btnChrome_Click(object sender, EventArgs e)
        {
            OpenDriver();
        }
        private void btnNavigate_Click(object sender, EventArgs e)
        {
            NavigateURL();
        }
        private void btnKirim_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This action will send an invitation to uninvited candidate. Do you wish to continue ? ", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                sendMsg();
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Sending message canceled", "Error");
            }
            else
            {
                MessageBox.Show("Sending message canceled", "Error");
            }
        }
        private void BrowseExcel_Click(object sender, EventArgs e)
        {
            GetExcelFile();
        }
        private void btnImport_Click(object sender, EventArgs e)
        {

        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            AutoUpdater.Start("file://sbmb-vmiisprd/PatchUpdate/eRecruitment.xml");
            visualStudioTabControl1.Dock = DockStyle.Fill;

            dateTimePicker_month.Format = DateTimePickerFormat.Custom;
            dateTimePicker_month.CustomFormat = "yyyy-MM";
            GetBatchList(dateTimePicker_month.Value.ToString("yyyy-MM"));
        }
        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()];
            rtbLog.AppendText(cboSheet.SelectedItem.ToString() + " selected - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
            if (dt != null)
            {
                if (txtSequence.Text.Length > 3 || txtSequence.Text == "" || txtSequence.Text.Length < 3)
                {
                    MessageBox.Show("Please fill Sequence with format 001", "Error");
                }
                else
                {
                    string A = dt.Rows[0]["Invitation Date"].ToString();
                    DateTime date = DateTime.ParseExact(A, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                    string BatchCompTemp = "JA-" + date.ToString("yyMM-") + txtSequence.Text;

                    using (var connections = new SqlConnection(connection))
                    {
                        connections.Open();
                        using (var command = new SqlCommand("SELECT COUNT(*) FROM JobApplicant where BatchComp = '" + BatchCompTemp + "'", connections))
                        {
                            using (SqlDataReader dr = command.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    seq2 = Convert.ToInt32(dr[0].ToString());
                                }
                            }
                        }
                    }
                    Task.Delay(500);
                    if (seq2 == 0)
                    {
                        List<BatchList> list = new List<BatchList>();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DateTime date2 = DateTime.ParseExact(dt.Rows[i]["Invitation Date"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                            DateTime date3 = DateTime.ParseExact(dt.Rows[i]["Request Date"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

                            BatchList obj = new BatchList();
                            obj.BatchComp = BatchCompTemp;
                            obj.BatchEmp = BatchCompTemp + "-" + (1 + i).ToString("D3");
                            obj.InvitationDate = date2.ToString("dd-MM-yyyy");
                            obj.RequestDate = date3.ToString("dd-MM-yyyy");
                            obj.NameEmp = dt.Rows[i]["Name Emp"].ToString();
                            obj.PhoneNumber = dt.Rows[i]["Phone Number"].ToString();
                            obj.DateOfBirthEmp = dt.Rows[i]["Date Of Birth Emp"].ToString();
                            list.Add(obj);
                        }
                        rtbLog.AppendText(dt.Rows.Count + " items has been added to queue " + " - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
                        dataGridView1.DataSource = list;
                    }
                    else
                    {
                        int TempSeq = seq2 + 1;
                        List<BatchList> list = new List<BatchList>();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DateTime date2 = DateTime.ParseExact(dt.Rows[i]["Invitation Date"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                            DateTime date3 = DateTime.ParseExact(dt.Rows[i]["Request Date"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

                            BatchList obj = new BatchList();
                            obj.BatchComp = BatchCompTemp;
                            obj.BatchEmp = BatchCompTemp + "-" + (TempSeq + i).ToString("D3");
                            obj.InvitationDate = date2.ToString("dd-MM-yyyy");
                            obj.RequestDate = date3.ToString("dd-MM-yyyy");
                            obj.NameEmp = dt.Rows[i]["Name Emp"].ToString();
                            obj.PhoneNumber = dt.Rows[i]["Phone Number"].ToString();
                            obj.DateOfBirthEmp = dt.Rows[i]["Date Of Birth Emp"].ToString();
                            list.Add(obj);
                        }
                        rtbLog.AppendText(dt.Rows.Count + " items has been added to queue " + " - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
                        dataGridView1.DataSource = list;
                    }
                }
            }
            button3.Enabled = true;
        }
        private void btnSearchBatch_Click(object sender, EventArgs e)
        {
            FillBatchList();
        }
        private void btnGenerateQR_Click(object sender, EventArgs e)
        {
            createQR();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GetBatchList(dateTimePicker_month.Value.ToString("yyyy-MM"));
        }
        private void btnSaveLog_Click(object sender, EventArgs e)
        {
            if (rtbLog.Text != "")
            {
                try
                {
                    string filename = "LOG-" + "DATE(" + DateTime.Now.ToString("dd-MM-yyyy") + ")TIME(" + DateTime.Now.ToString("HH-mm-ss" + ")");
                    iTextSharp.text.Document doc = new iTextSharp.text.Document();
                    PdfWriter.GetInstance(doc, new FileStream($"{Application.StartupPath}/LogData/" + (filename + ".pdf"), FileMode.Create));
                    doc.Open();
                    doc.Add(new iTextSharp.text.Paragraph("Author: " + FrmAuth.NAME.ToString() + "\n" +
                                                          "Date: " + DateTime.Now.ToString("dd-MMM-yyyy") + "\n" +
                                                          "Time: " + DateTime.Now.ToString("HH:mm:ss") + "\n" +
                                                          "\n" +
                                                          "\n" +
                                                          rtbLog.Text));
                    doc.Close();
                    //rtbLog.Text = "";
                    string InputFile = $"{Application.StartupPath}/LogData/" + (filename + ".pdf");
                    string OutputFile = $"{Application.StartupPath}/LogData/" + (filename + "-Protected" + ".pdf");
                    using (Stream input = new FileStream(InputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        using (Stream output = new FileStream(OutputFile, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            PdfReader reader = new PdfReader(input);
                            PdfEncryptor.Encrypt(reader, output, true, "shimano2021", "shimano2021", PdfWriter.ALLOW_SCREENREADERS);
                        }
                    }
                    System.IO.File.Delete(InputFile);
                    MessageBox.Show("Please send \n" +
                        "" + (filename + ".pdf") + " \nto HR immediately.", "Log Saved Succesfully");
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
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start($"{Application.StartupPath}/SampleData");
            }
            catch (Exception y)
            {
                MessageBox.Show("Sample data location not found", "Error");
            }
        }
        void GetExcelFile()
        {
            //dataGridView1.ColumnHeadersVisible = false;
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls" })
            {
                button3.Enabled = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtExcelPath.Text = ofd.FileName;
                    using (var stream = System.IO.File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
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
                rtbLog.AppendText("File : " + ofd.FileName + " has been picked - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
            }
        }
        void OpenDriver()
        {
            if (btnChrome.Text == "CONNECT")
            {
                if (cbversion.SelectedIndex == 0)
                {
                    driver = new ChromeDriver($"{Application.StartupPath}\\90.0.4430.24");
                    btnNavigate.Enabled = true;
                    btnChrome.Text = "DISCONNECT";
                    txtStatus.Text = "Connected to Chrome 90.0.4430.24";
                    rtbLog.AppendText("Connected to Chrome 90.0.4430.24 - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
                }
                else if (cbversion.SelectedIndex == 1)
                {
                    driver = new ChromeDriver($"{Application.StartupPath}\\89.0.4389.23");
                    btnNavigate.Enabled = true;
                    btnChrome.Text = "DISCONNECT";
                    txtStatus.Text = "Connected to Chrome 89.0.4389.23";
                    rtbLog.AppendText("Connected to Chrome 89.0.4389.23 - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
                }
                else if (cbversion.SelectedIndex == 2)
                {
                    driver = new ChromeDriver($"{Application.StartupPath}\\88.0.4324.96");
                    btnNavigate.Enabled = true;
                    btnChrome.Text = "DISCONNECT";
                    txtStatus.Text = "Connected to Chrome 88.0.4324.96";
                    rtbLog.AppendText("Connected to Chrome 88.0.4324.96 - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
                }
                else if (cbversion.SelectedIndex == 3)
                {
                    driver = new ChromeDriver($"{Application.StartupPath}\\88.0.4324.27");
                    btnNavigate.Enabled = true;
                    btnChrome.Text = "DISCONNECT";
                    txtStatus.Text = "Connected to Chrome 88.0.4324.27";
                    rtbLog.AppendText("Connected to Chrome 88.0.4324.27 - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
                }
                else if (cbversion.SelectedIndex == 4)
                {
                    driver = new ChromeDriver($"{Application.StartupPath}\\87.0.4280.88");
                    btnNavigate.Enabled = true;
                    txtStatus.Text = "Connected to Chrome 87.0.4280.88";
                    rtbLog.AppendText("Connected to Chrome 87.0.4280.88 - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
                }
                else if (cbversion.SelectedIndex == 5)
                {
                    driver = new ChromeDriver($"{Application.StartupPath}\\87.0.4280.20");
                    btnNavigate.Enabled = true;
                    txtStatus.Text = "Connected to Chrome 87.0.4280.20";
                    rtbLog.AppendText("Connected to Chrome 87.0.4280.20 - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
                }
                else if (cbversion.SelectedIndex == 6)
                {
                    driver = new ChromeDriver($"{Application.StartupPath}\\86.0.4240.22");
                    btnNavigate.Enabled = true;
                    txtStatus.Text = "Connected to Chrome 86.0.4240.22";
                    rtbLog.AppendText("Connected to Chrome 86.0.4240.22 - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
                }
                else
                {
                    MessageBox.Show("Please select chrome version on a Setting Tab !", "Warning");
                }
            }
            else
            {
                driver.Quit();
                btnChrome.Text = "CONNECT";
                txtStatus.Text = "DISCONNECTED";
                rtbLog.AppendText("DISCONNECTED - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
                btnNavigate.Enabled = false;
            }
        }
        async void NavigateURL()
        {
            rtbLog.AppendText("Navigate to : " + txtURL.Text + " - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
            driver.Navigate().GoToUrl(txtURL.Text);
            rtbLog.AppendText("Waiting Login Whatsapp - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
            await Task.Delay(10000);
            try
            {
                IWebElement myField = driver.FindElement(By.ClassName(txtLoginElement.Text));
                NavigateURL();
            }
            catch (Exception e)
            {
                rtbLog.AppendText("Connected to Whatsapp - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
                btnKirim.Enabled = true;
            }
        }
        void Insert(List<BatchList> list)
        {
            DapperPlusManager.Entity<BatchList>().Table("JobApplicant");
            using (IDbConnection dbConnection = new SqlConnection(connection))
            {
                dbConnection.BulkInsert(list);
            }
        }
        void UpdateInvitationCode()
        {
            using (IDbConnection dbConnection = new SqlConnection(connection))
            {
                try
                {
                    for (int i = 0; i <= dataGridView2.Rows.Count - 1; i++)
                    {
                        string query = @"update JobApplicant set InvitationCodeEmp = '" + dataGridView2.Rows[i].Cells[7].Value.ToString() + "',StatusBatch='PENDING', UpdatedBy='AUTO WA', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd") + "' where BatchEmp ='" + dataGridView2.Rows[i].Cells[3].Value.ToString() + "'";
                        //string query = @"update JobApplicant set InvitationCodeEmp = '" + dataGridView2.Rows[i].Cells[7].Value.ToString() + "',StatusBatch='PENDING',StatusEmp='INVITED', UpdatedBy='AUTO WA', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd") + "' where BatchEmp ='" + dataGridView2.Rows[i].Cells[3].Value.ToString() + "'";
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(query, (SqlConnection)dbConnection);
                        var commandBuilder = new SqlCommandBuilder(dataAdapter);
                        var dataSet = new DataSet();
                        dataAdapter.Fill(dataSet);
                        rtbLog.AppendText("Invitation Code has been updated " + " - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fail updating invitation code", "Error");
                }
            }
        }
        void UpdateStatusEmp()
        {
            using (IDbConnection dbConnection = new SqlConnection(connection))
            {
                try
                {
                    for (int i = 0; i <= dataGridView2.Rows.Count - 1; i++)
                    {
                        string query = @"update JobApplicant set StatusEmp = '" + dataGridView2.Rows[i].Cells[8].Value.ToString() + "', UpdatedBy='AUTO WA', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd") + "' where BatchEmp ='" + dataGridView2.Rows[i].Cells[3].Value.ToString() + "'";
                        //string query = @"update JobApplicant set InvitationCodeEmp = '" + dataGridView2.Rows[i].Cells[7].Value.ToString() + "',StatusBatch='PENDING',StatusEmp='INVITED', UpdatedBy='AUTO WA', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd") + "' where BatchEmp ='" + dataGridView2.Rows[i].Cells[3].Value.ToString() + "'";
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(query, (SqlConnection)dbConnection);
                        var commandBuilder = new SqlCommandBuilder(dataAdapter);
                        var dataSet = new DataSet();
                        dataAdapter.Fill(dataSet);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Updating Status Candidate Failed", "Error");
                }
            }
        }
        void GetBatchList(string date)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                try
                {
                    comboBox1.Text = "";
                    string query = "SELECT distinct BatchComp FROM JobApplicant WHERE convert(varchar(7),RequestDate, 126)=convert(varchar(7), '" + date + "', 126)";
                    SqlDataAdapter da = new SqlDataAdapter(query, (SqlConnection)db);
                    db.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "BatchComp");
                    comboBox1.DisplayMember = "BatchComp";
                    comboBox1.ValueMember = "BatchComp";
                    comboBox1.DataSource = ds.Tables["BatchComp"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fail getting batch list", "Error");
                }
            }
        }
        //SELECT distinct BatchComp FROM JobApplicant WHERE convert(varchar(7),RequestDate, 126)=convert(varchar(7), '2021-05', 126)
        void FillBatchList()
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                try
                {
                    btnGenerateQR.Enabled = true;
                    string query = "select BatchComp, InvitationDate, RequestDate, BatchEmp, NameEmp, PhoneNumber, DateOfBirthEmp, InvitationCodeEmp, StatusEmp from JobApplicant where BatchComp ='" + comboBox1.Text + "' order by BatchEmp";
                    SqlDataAdapter da = new SqlDataAdapter(query, (SqlConnection)db);
                    var commandBuilder = new SqlCommandBuilder(da);
                    var ds = new DataSet();

                    da.Fill(ds);
                    //ds.Tables[0].Columns[2].DataType = System.Type.GetType("System.String");
                    dataGridView2.DataSource = ds.Tables[0];

                    rtbLog.AppendText("Batch number " + comboBox1.Text + " fetched" + " - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
                    btnChrome.Enabled = true;
                    for (int i = 0; i <= dataGridView2.Rows.Count - 1; i++)
                    {
                        var A = dataGridView2.Rows[i].Cells[2].Value.ToString();

                        dataGridView2.Rows[i].Cells[2].Value = A;
                    }
                    errorupdate = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error");
                    errorupdate = true;
                }
            }
        }
        async void sendMsg()
        {
            toolStripProgressBar1.Maximum = dataGridView2.Rows.Count;
            for (int i = 0; i <= dataGridView2.Rows.Count - 1; i++)
            {
                if (dataGridView2.Rows[i].Cells[8].Value.ToString() == "" | dataGridView2.Rows[i].Cells[8].Value.ToString() == null)
                {
                    startfrom = i;
                    i = dataGridView2.Rows.Count - 1;
                }
            }

            for (int i = startfrom; i <= dataGridView2.Rows.Count - 1; i++)
            {
                string A = Convert.ToString(i + 1);
                rtbLog.AppendText("Sending Message (" + A + "/" + (dataGridView2.Rows.Count) + ") - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
                toolStripProgressBar1.Value = i + 1;
                txtTotal.Text = Convert.ToString(i + 1) + "/" + Convert.ToString(dataGridView2.Rows.Count);

                __filename = "";
                __filename = dataGridView2.Rows[i].Cells[7].Value.ToString() + ".jpg";
                //string a = txtURL.Text + "send?phone=" + dataGridView2.Rows[i].Cells[5].Value.ToString() + "&text=" + Uri.EscapeDataString(txtPesan.Text);
                string url = txtURL.Text + "send?phone=" + dataGridView2.Rows[i].Cells[5].Value.ToString();
                driver.Navigate().GoToUrl(url);

                try
                {
                    await Task.Delay(8500);
                    string xfoldername = "\\QR Image\\";
                    string xappPath = Path.GetDirectoryName(Application.ExecutablePath) + xfoldername;
                    //await Task.Delay(4000);
                    //IWebElement message_box = driver.FindElement(By.XPath(txtTextField.Text));
                    //await Task.Delay(2000);
                    //message_box.SendKeys(OpenQA.Selenium.Keys.Enter);
                    string xfilepath = xappPath + __filename;
                    driver.FindElement(By.CssSelector(txtClipFiles.Text)).Click();
                    await Task.Delay(2000);
                    driver.FindElement(By.CssSelector(txtInputFiles.Text)).SendKeys(xfilepath);
                    await Task.Delay(2000);
                    driver.FindElement(By.CssSelector(txtSendImg.Text)).Click();
                    await Task.Delay(2000);
                    dataGridView2.Rows[i].Cells[8].Value = "INVITED";
                    UpdateStatusEmp();
                    await Task.Delay(500);
                    if (errorupdate == false)
                    {
                        await Task.Delay(1500);
                    }
                    else
                    {
                        rtbLog.AppendText("Internet connection has been lost - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
                        DialogResult dialogResult = MessageBox.Show("Chrome driver has been crash, please re-open.", "Warning");
                        i = dataGridView2.Rows.Count - 1;
                        break;
                        driver.Quit();
                    }
                }
                catch (NoSuchElementException e)
                {
                    try
                    {
                        if (driver.FindElement(By.ClassName(txtInvalidNo.Text)).Displayed == true)
                        {
                            string B = Convert.ToString(i + 1);
                            rtbLog.AppendText("Message (" + B + "/" + (dataGridView2.Rows.Count) + ") failed to send - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
                            dataGridView2.Rows[i].Cells[8].Value = "NOT INVITED";
                            UpdateStatusEmp();
                            await Task.Delay(500);
                            if (errorupdate == false)
                            {
                                await Task.Delay(1500);
                            }
                            else
                            {
                                rtbLog.AppendText("Internet connection has been lost - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
                                DialogResult dialogResult = MessageBox.Show("Chrome driver has been crash, please re-open.", "Warning");
                                i = dataGridView2.Rows.Count - 1;
                                break;
                                driver.Quit();
                            }
                        }
                    }
                    catch (NoSuchElementException x)
                    {
                        rtbLog.AppendText("Whatsapp connection has been lost - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
                        DialogResult dialogResult = MessageBox.Show("Chrome driver has been crash, please re-open.", "Warning");
                        i = dataGridView2.Rows.Count - 1;
                        break;
                        driver.Quit();
                    }
                }
                catch (UnhandledAlertException e)
                {
                    rtbLog.AppendText("Chrome driver has been crash - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
                    DialogResult dialogResult = MessageBox.Show("Chrome driver has been crash, please re-open.", "Warning");
                    i = dataGridView2.Rows.Count - 1;
                    break;
                    driver.Quit();
                }
            }
            MessageBox.Show("Invitation has been sent, please check log for more details.", "SUCCESS");
            driver.Quit();
            btnChrome.Text = "CONNECT";
            txtStatus.Text = "DISCONNECTED";
            rtbLog.AppendText("DISCONNECTED - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
            btnNavigate.Enabled = false;
            btnChrome.Enabled = false;
            btnSearchBatch.Enabled = true;
            btnKirim.Enabled = false;
        }
        private void MainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelMain.Visible = true;
            //panelSecondary.Visible = false;
        }
        private void SecondaryStripMenuItem_Click(object sender, EventArgs e)
        {
            panelMain.Visible = false;
            //panelSecondary.Visible = true;
        }
        private void label9_MouseMove(object sender, MouseEventArgs e)
        {
            if (TagMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }
        private void label9_MouseDown(object sender, MouseEventArgs e)
        {
            TagMove = 1;
            MValX = e.X;
            MValY = e.Y;
        }
        private void label9_MouseUp(object sender, MouseEventArgs e)
        {
            TagMove = 0;
        }
        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAuth formauth = new FrmAuth();
            formauth.Close();
            this.Close();
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
        private void btnOpenFormat_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            txtPesan.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.txt|*.txt";
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(dlg.FileName, txtPesan.Text);
            }
        }
        void createQR()
        {
            int AA = -1;
            int B = dataGridView2.Rows.Count - 1;

            for (int i = 0; i <= (dataGridView2.Rows.Count - 1); i++)
            {
                if (dataGridView2.Rows[i].Cells[7].Value.ToString() == "" || dataGridView2.Rows[i].Cells[7].Value.ToString() == null)
                {
                    AA = AA + 1;
                }
            }

            int C = B - AA;
            //IF 
            if (AA != -1)
            {
                DialogResult dialogResult = MessageBox.Show("This action will create QR for " + dataGridView2.Rows[C].Cells[3].Value.ToString() + " until " + dataGridView2.Rows[B].Cells[3].Value.ToString() + ", are you sure to continue ?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        string foldername = "\\QR Image";
                        string appPath = Path.GetDirectoryName(Application.ExecutablePath) + foldername;
                        for (int i = C; i <= dataGridView2.Rows.Count - 1; i++)
                        {
                            BarcodeWriter barcodewriters = new BarcodeWriter();
                            EncodingOptions encodingoptions = new EncodingOptions()
                            {
                                Width = 450,
                                Height = 450,
                                Margin = 5,
                                PureBarcode = false
                            };
                            encodingoptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.M);
                            barcodewriters.Renderer = new BitmapRenderer();
                            barcodewriters.Options = encodingoptions;
                            barcodewriters.Format = BarcodeFormat.QR_CODE;
                            string data = Guid.NewGuid().ToString().ToUpper();
                            string date = DateTime.Now.ToString("yyyyMMddHHmmss");
                            Bitmap A4 = new Bitmap(1240, 1240);
                            A4.SetResolution(150, 150);
                            Graphics Master = Graphics.FromImage(A4);
                            Master.Clear(Color.White);
                            Bitmap barcode = barcodewriters.Write(dataGridView2.Rows[i].Cells[3].Value.ToString() + "-" + data + "-" + date);
                            Master.DrawImage(barcode, new Point(570, -10));
                            Bitmap logo = new Bitmap($"{Application.StartupPath}\\" + txtLogoPath.Text);
                            Graphics Detail = Graphics.FromImage(barcode);

                            //int PointX = 155;
                            //int PointY = 500;

                            int PointX = (250 - (747 / 5)) / 2;
                            int PointY = (200 -(194 / 5)) / 2;

                            //Master.DrawImage(logo, new Point((A4.Width - logo.Width) / 2, (A4.Height - logo.Height) / 2));
                            Master.DrawImage(logo, PointX, PointY, (747 / 5), (194 / 5));

                            string X = dataGridView2.Rows[i].Cells[3].Value.ToString() + "-" + data + "-" + date;
                            string digits = dataGridView2.Rows[i].Cells[3].Value.ToString().Substring(12);

                            string name = dataGridView2.Rows[i].Cells[4].Value.ToString().ToUpper();
                            string phone = dataGridView2.Rows[i].Cells[5].Value.ToString().ToUpper();
                            string noktp = "";
                            string title = txtTitle.Text.ToUpper();
                            string day = txtDay.Text.ToUpper();
                            string datetext = txtDate.Text.ToUpper();
                            string time = txtTime.Text.ToUpper();
                            string location = txtLocation.Text.ToUpper();
                            string uniform = txtUniform.Text.ToUpper();
                            string NoHRD = "NO. HRD";


                            string A = ($"{Application.StartupPath}\\" + txtLogoPath.Text).ToString();

                            using (Font myFont = new Font("Consolas", 10))
                            {
                                //Master.DrawString(txtPesan.Text
                                //.Replace("[TITLE]", title)
                                //.Replace("[NAME]", "Nama" + "\t\t" + ":" + name)
                                //.Replace("[PHONE]", "No. HP" + "\t\t" + ":" + phone)
                                //.Replace("[NOKTP]", "No. KTP" + "\t\t" + ":" + noktp)
                                //.Replace("[DAY]", "Hari" + "\t\t" + ":" + day)
                                //.Replace("[DATE]", "Tanggal" + "\t\t" + ":" + datetext)
                                //.Replace("[TIME]", "Waktu" + "\t\t" + ":" + time)
                                //.Replace("[LOCATION]", "Lokasi" + "\t\t" + ":" + location)
                                //.Replace("[UNIFORM]", "Pakaian" + "\t\t" + ":" + uniform) + "\n" + "\n" + name + "\n" + digits, myFont, Brushes.Black, new Point(50, 150));
                                Master.DrawString(txtPesan.Text
                                .Replace("[TITLE]", title)
                                .Replace("[NAME]", "Nama" + "\t\t" + ":" + name)
                                .Replace("[PHONE]", "No. HP" + "\t\t" + ":" + phone)
                                .Replace("[DAY]", "Hari" + "\t\t" + ":" + day)
                                .Replace("[DATE]", "Tanggal" + "\t\t" + ":" + datetext)
                                .Replace("[TIME]", "Waktu" + "\t\t" + ":" + time)
                                .Replace("[LOCATION]", "Lokasi" + "\t\t" + ":" + location)
                                .Replace("[UNIFORM]", "Pakaian" + "\t\t" + ":" + uniform) + "\n" + "\n" + NoHRD + "\n" + digits, myFont, Brushes.Black, new Point(50, 150));
                            }

                            pictureBox1.Image = A4;
                            string filename = dataGridView2.Rows[i].Cells[3].Value.ToString() + "-" + data + "-" + date;

                            pictureBox1.Image.Save(appPath + @"\" + filename + ".jpg", ImageFormat.Jpeg);
                            _filepath = (Application.StartupPath) + foldername;
                            dataGridView2.Rows[i].Cells[7].Value = filename;
                        }
                        rtbLog.AppendText((dataGridView2.Rows.Count.ToString() + " has been generated for batch " + comboBox1.SelectedValue.ToString() + " - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine));
                        UpdateInvitationCode();
                        //btnKirim.Enabled = true;
                        MessageBox.Show("QR Generated on '" + appPath.ToString() + "'", "QR Generated");
                        btnGenerateQR.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed during create QR", "Error");
                    }
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
            else if (AA == -1)
            {
                MessageBox.Show("All QR for Batch " + comboBox1.Text + " has been recorded and created, please check QR Image's folder", "Warning");
            }
        }
        private void btnImport1(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    string IsUploaded;
                    con.Open();
                    button3.Enabled = false;

                    foreach (DataGridViewRow rw in this.dataGridView1.Rows)
                    {
                        for (int i = 0; i < rw.Cells.Count; i++)
                        {
                            if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                            {
                                canupload = false;
                                i = rw.Cells.Count;
                            }
                        }
                    }
                    if (canupload == true)
                    {
                        var queryx = @"CREATE TABLE #TempTable
                                    (
	                                    [BatchComp] [nvarchar](max) NULL,
	                                    [InvitationDate] [nvarchar](max) NULL,
	                                    [RequestDate] [date] NULL,
	                                    [TotalCandidate] [nvarchar](max) NULL,
	                                    [StatusBatch] [nvarchar](max) NULL,
	                                    [BatchEmp] [nvarchar](max) NULL,
	                                    [NameEmp] [nvarchar](max) NULL,
	                                    [PhoneNumber] [nvarchar](max) NULL,
	                                    [DateOfBirthEmp] [nvarchar](max) NULL,
	                                    [InvitationCodeEmp] [nvarchar](max) NULL,
	                                    [StatusEmp] [nvarchar](max) NULL,
	                                    [UpdatedBy] [nvarchar](max) NULL,
	                                    [UpdatedDate] [nvarchar](max) NULL,
	                                    [UploadedBy] [nvarchar](max) NULL,
	                                    [UploadedDate] [nvarchar](max) NULL
                                    )";
                        SqlDataAdapter dataAdapterx = new SqlDataAdapter(queryx, (SqlConnection)con);
                        var commandBuilderx = new SqlCommandBuilder(dataAdapterx);
                        var dataSetx = new DataSet();
                        dataAdapterx.Fill(dataSetx);

                        for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                        {
                            string data0 = dataGridView1.Rows[i].Cells[0].Value.ToString();
                            string data1 = dataGridView1.Rows[i].Cells[1].Value.ToString();
                            string data2 = dataGridView1.Rows[i].Cells[2].Value.ToString();
                            string data3 = dataGridView1.Rows[i].Cells[3].Value.ToString();
                            string data4 = dataGridView1.Rows[i].Cells[4].Value.ToString();
                            string data5 = dataGridView1.Rows[i].Cells[5].Value.ToString();
                            string data6 = dataGridView1.Rows[i].Cells[6].Value.ToString();

                            var X = DateTime.ParseExact(data2, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                            var Y = X.ToString("MMM-dd-yyyy");
                            var Z = X.ToString("dd-MM-yyyy");

                            var query = @"insert into #TempTable (BatchComp, InvitationDate, RequestDate, BatchEmp, NameEmp, PhoneNumber, DateOfBirthEmp) VALUES('" + data0 + "','" + data1 + "','" + X + "','" + data3 + "','" + data4 + "','" + data5 + "','" + data6 + "')";
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, (SqlConnection)con);
                            var commandBuilder = new SqlCommandBuilder(dataAdapter);
                            var dataSet = new DataSet();
                            dataAdapter.Fill(dataSet);
                            rtbLog.AppendText("Employee (" + data3 + ") successfully uploaded." + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
                        }

                        var queryy = @"insert into JobApplicant (BatchComp, InvitationDate, RequestDate, BatchEmp, NameEmp, PhoneNumber, DateOfBirthEmp) 
                                       select BatchComp, InvitationDate, RequestDate, BatchEmp, NameEmp, PhoneNumber, DateOfBirthEmp from #TempTable";
                        SqlDataAdapter dataAdaptery = new SqlDataAdapter(queryy, (SqlConnection)con);
                        var commandBuildery = new SqlCommandBuilder(dataAdaptery);
                        var dataSety = new DataSet();
                        dataAdaptery.Fill(dataSety);

                        MessageBox.Show("Data has been uploaded.", "Success");
                        button3.Enabled = true;
                        dataGridView1.DataSource = null;
                        cboSheet.Text = "";
                        button3.Enabled = false;
                    }
                    else
                    {
                        button3.Enabled = false;
                        MessageBox.Show("Cannot import blank value, please check again.", "Error");
                    }
                }
                catch (Exception ex)
                {
                    button3.Enabled = false;
                    MessageBox.Show("Failed when uploading.", "Error");
                    var queryz = @"drop table #TempTable";
                    SqlDataAdapter dataAdapterz = new SqlDataAdapter(queryz, (SqlConnection)con);
                    var commandBuilderz = new SqlCommandBuilder(dataAdapterz);
                    var dataSetz = new DataSet();
                    dataAdapterz.Fill(dataSetz);
                }
            }
        }

        private void dateTimePicker_month_DropDown(object sender, EventArgs e)
        {
            IntPtr cal = SendMessage(dateTimePicker_month.Handle, DTM_GETMONTHCAL, IntPtr.Zero, IntPtr.Zero);
            SendMessage(cal, MCM_SETCURRENTVIEW, IntPtr.Zero, (IntPtr)1);
        }
        private const int DTM_GETMONTHCAL = 0x1000 + 8;
        private const int MCM_SETCURRENTVIEW = 0x1000 + 32;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        private void dateTimePicker_month_ValueChanged(object sender, EventArgs e)
        {
            GetBatchList(dateTimePicker_month.Value.ToString("yyyy-MM"));
        }

        private void txtInvalidNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}