using ClosedXML.Excel;
using ERECRUITMENT_WEB.Class;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Web.Mvc;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ERECRUITMENT_WEB.Models;
using ExcelDataReader;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace ERECRUITMENT_WEB.Controllers
{
    public class InboxController : Controller
    {
        InterviewScoreboard IB = new InterviewScoreboard();
        public ActionResult Index()
        {
            return View();
        }
        public FileResult SP_EXPORTEXCEL_INBOX(string BATCHNO, string STATUS)
        {
            try
            {
                DataTable table = new DataTable("SHEET");
                table = IB.SP_EXPORTEXCEL_INBOX(BATCHNO, STATUS);
                table.TableName = "SHEET";
                string Key = RandomString(5);
                Session["BATCHNO"] = BATCHNO;
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(table);
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                           "REPORT-" + BATCHNO + "-" + Key.ToUpper() + ".xlsx");
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public string EREC_CON = ConfigurationManager.ConnectionStrings["EREC_CON"].ToString();
        public FileContentResult CREATE_IMAGE(string REPORTID)
        {
            DataTable DATATABLE;
            string SQL = @"SELECT * FROM USER_REPORT WHERE REPORT_ID = '" + REPORTID + "'";
            using (ClassMSSQL s = new ClassMSSQL())
            {
                DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
            }
            var DATA0 = (from row in DATATABLE.AsEnumerable()
                         select new USER_INBOX()
                         {

                             BATCH_NO = (row["BATCH_NO"].ToString() == null) ? "" : row["BATCH_NO"].ToString(),
                             BATCH_EMP = (row["BATCH_EMP"].ToString() == null) ? "" : row["BATCH_EMP"].ToString(),
                             NAME_EMP = (row["NAME_EMP"].ToString() == null) ? "" : row["NAME_EMP"].ToString(),
                             REPORT_ID = (row["REPORT_ID"].ToString() == null) ? "" : row["REPORT_ID"].ToString(),
                             REPORT_CATE = (row["REPORT_CATE"].ToString() == null) ? "" : row["REPORT_CATE"].ToString(),
                             REPORT_DESC = (row["REPORT_DESC"].ToString() == null) ? "" : row["REPORT_DESC"].ToString(),
                             REPORT_IMG = (row["REPORT_IMG"].ToString() == null) ? "" : row["REPORT_IMG"].ToString(),
                             REPORT_STATUS = (row["REPORT_STATUS"].ToString() == null) ? "" : row["REPORT_STATUS"].ToString(),
                             REPORT_ACTION = (row["REPORT_ACTION"].ToString() == null) ? "" : row["REPORT_ACTION"].ToString(),
                             UPDT_TIME = (row["UPDT_TIME"].ToString() == null) ? "" : row["UPDT_TIME"].ToString(),
                             UPDT_USER = (row["UPDT_USER"].ToString() == null) ? "" : row["UPDT_USER"].ToString(),
                         }).ToList();

            Bitmap A4 = new Bitmap(720, 1200);
            A4.SetResolution(150, 150);
            Graphics Master = Graphics.FromImage(A4);
            Master.Clear(Color.White);
            Bitmap attachment       = new Bitmap(DATA0[0].REPORT_IMG.ToString());
            var BATCH_NO            = "BATCH NO: " + DATA0[0].BATCH_NO.ToString();
            var BATCH_EMP           = "BATCH EMP: " + DATA0[0].BATCH_EMP.ToString();
            var NAME_EMP            = "NAME EMP: " + DATA0[0].NAME_EMP.ToString();
            var REPORT_ID           = "REPORT ID: " + DATA0[0].REPORT_ID.ToString();
            var REPORT_CATEGORY     = "REPORT CATEGORY: " + DATA0[0].REPORT_CATE.ToString();
            var REPORT_STATUS       = "REPORT STATUS: " + DATA0[0].REPORT_STATUS.ToString();
            var REPORT_ACTION       = "ACTION: " + DATA0[0].REPORT_ACTION.ToString();
            var REPORT_DESC         = "DESC: " + DATA0[0].REPORT_DESC.ToString();

            var FINALSTRING =
                REPORT_ID + "\n" +
                REPORT_CATEGORY + "\n" +
                REPORT_STATUS + "\n" +
                REPORT_ACTION + "\n\n" +
                BATCH_NO + "\n" +
                BATCH_EMP + "\n" +
                NAME_EMP + "\n" +
                REPORT_DESC + "\n" +
                "ATTACHMENT: " + "\n";

            int PointX = 50;
            int PointY = 400;
            
            Font title = new Font("JetBrains Mono", 15, FontStyle.Regular);
            Font font1 = new Font("JetBrains Mono", 12, FontStyle.Regular);
            //Master.DrawString("E-RECRUITMENT", title, Brushes.Black, new Point(50, 100));
            Master.DrawString(FINALSTRING, font1, Brushes.Black, new Point(50, 75));
            Master.DrawImage(attachment, PointX, PointY, 480, 640);
            MemoryStream MS = new MemoryStream();
            A4.Save(MS, ImageFormat.Png);
            return File(MS.ToArray(), "image/png");
        }
        string RandomString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            return finalString;
        }
    }
}