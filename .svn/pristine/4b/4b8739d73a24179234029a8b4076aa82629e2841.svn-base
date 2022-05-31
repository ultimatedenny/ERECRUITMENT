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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace ERECRUITMENT_WEB.Controllers
{
    public class InterviewBoardController : Controller
    {
        InterviewScoreboard IB = new InterviewScoreboard();
        public ActionResult Index()
        {
            if (Sessions.GetUseID() != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult Detail(string BATCHNO)
        {
            if (Sessions.GetUseID() != null)
            {
                if (!string.IsNullOrEmpty(BATCHNO))
                {
                    ViewBag.BATCHNO = BATCHNO;
                    Session["BATCHNO"] = BATCHNO;
                    return View();
                }
                else
                {
                    TempData["ERROR"] = "NO BATCH NUMBER SELECTED !";
                    return RedirectToAction("Index", "InterviewBoard");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult CandidateDetails(string BATCH_EMP)
        {
            if (Sessions.GetUseID() != null)
            {
                if (!string.IsNullOrEmpty(BATCH_EMP))
                {
                    ViewBag.BATCH_EMP = BATCH_EMP;
                    Session["BATCH_EMP"] = BATCH_EMP;
                    return View();
                }
                else
                {
                    TempData["ERROR"] = "NO BATCH EMP SELECTED !";
                    return RedirectToAction("Index", "InterviewBoard");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult ScoreBoard(string BATCH_EMP)
        {
            if (Sessions.GetUseID() != null)
            {
                if (!string.IsNullOrEmpty(BATCH_EMP))
                {
                    ViewBag.BATCH_EMP = BATCH_EMP;
                    return View();
                }
                else
                {
                    TempData["ERROR"] = "NO BATCH CANDIDATE SELECTED !";
                    return RedirectToAction("Index", "InterviewBoard");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public JsonResult WEB_GETSCOREBOARD(string BATCH_EMP)
        {
            return Json(IB.WEB_GETSCOREBOARD(BATCH_EMP), JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_GETTABLE_INTERVIEWSCOREBOARD(string BATCHNO, string BATCHCATEGORY, string BATCHSTATUS, string FROM, string TO)
        {
            return Json(new { data = IB.WEB_GETTABLE_INTERVIEWSCOREBOARD(BATCHNO, BATCHCATEGORY, BATCHSTATUS, FROM, TO) }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_GETTABLE_INTERVIEWSCOREBOARD_DETAIL(string BATCHNO, string KEYWORD, string STATUS)
        {
            return Json(new { data = IB.WEB_GETTABLE_INTERVIEWSCOREBOARD_DETAIL(BATCHNO, KEYWORD, STATUS) }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult WEB_GET_CANDIDATE_DETAIL(string BATCH_EMP)
        {
            return Json(IB.WEB_GET_CANDIDATE_DETAIL(BATCH_EMP), JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_GET_STATUS_DETAIL(string BATCH_EMP)
        {
            return Json(IB.WEB_GET_STATUS_DETAIL(BATCH_EMP), JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_GETBATCH_DROPDOWN()
        {
            return Json(IB.WEB_GETBATCH_DROPDOWN(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_GETCATEGORY_DROPDOWN()
        {
            return Json(IB.WEB_GETCATEGORY_DROPDOWN(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_GETBATSTAT_DROPDOWN()
        {
            return Json(IB.WEB_GETBATSTAT_DROPDOWN(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_GETEMPSTAT_DROPDOWN()
        {
            return Json(IB.WEB_GETEMPSTAT_DROPDOWN(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_SETDIGIT(string BATCH_EMP)
        {
            return Json(IB.WEB_SETDIGIT(BATCH_EMP), JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_SHOWDIGIT(string BATCH_EMP)
        {
            return Json(IB.WEB_SHOWDIGIT(BATCH_EMP), JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_INTERVIEWBOARD_SAVE(INTERVIEWSCOREBOARD_COMPLETED MODEL, int TYPE)
        {
            if(TYPE == 1)
            {
                var res = IB.WEB_INTERVIEWBOARD_SAVE_PERSONAL(MODEL);
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            else if (TYPE == 2)
            {
                var res = IB.WEB_INTERVIEWBOARD_SAVE_EDICATION(MODEL);
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            else if (TYPE == 3)
            {
                string USERID = Sessions.GetUseID().ToString();
                var res = IB.WEB_INTERVIEWBOARD_SAVE_WRITTEN(MODEL, USERID);
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            else if (TYPE == 4)
            {
                string USERID = Sessions.GetUseID().ToString();
                var res = IB.WEB_INTERVIEWBOARD_SAVE_PRACTICAL(MODEL, USERID);
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            else if (TYPE == 5)
            {
                string USERID = Sessions.GetUseID().ToString();
                var res = IB.WEB_INTERVIEWBOARD_SAVE_MEMORY(MODEL, USERID);
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            else if (TYPE == 6)
            {
                string USERID = Sessions.GetUseID().ToString();
                var res = IB.WEB_INTERVIEWBOARD_SAVE_OTHER(MODEL, USERID);
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            else if (TYPE == 7)
            {
                string USERID = Sessions.GetUseID().ToString();
                var res = IB.WEB_INTERVIEWBOARD_SAVE_FINAL(MODEL, USERID);
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(("ERROR", HttpStatusCode.InternalServerError), JsonRequestBehavior.AllowGet);
            }
        }
        public FileResult DownloadSampleMedical(string BatchNo, string Category)
        {
            try
            {
                DataTable table = new DataTable("EXPORT1");
                table = IB.EXPORTPERSONALITYANDMEDICAL(BatchNo, Category);
                table.TableName = "EXPORT1";
                string Key = RandomString(5);
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(table);
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "SAMPLE1-" + BatchNo + "-" + Key.ToUpper() + ".xlsx");
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public FileResult Download(string type, string BatchNo)
        {
            try
            {
                if (type == "0")
                {

                    DataTable table = new DataTable("EXPORT1");
                    table = IB.EXPORT1(BatchNo);
                    table.TableName = "EXPORT1";
                    string Key = RandomString(5);
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(table);
                        using (MemoryStream stream = new MemoryStream())
                        {
                            wb.SaveAs(stream);
                            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                            "SAMPLE1-" + BatchNo + "-" + Key.ToUpper() + ".xlsx");
                        }
                    }
                }
                else if (type == "1")
                {
                    DataTable table = new DataTable("EXPORT2");
                    table = IB.EXPORT2(BatchNo);
                    table.TableName = "EXPORT2";
                    string Key = RandomString(5);
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(table);
                        using (MemoryStream stream = new MemoryStream())
                        {
                            wb.SaveAs(stream);
                            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                               "GL-" + BatchNo + "-" + Key.ToUpper() + ".xlsx");
                        }
                    }
                }
                else
                {
                    return null;
                }
            }
            catch(Exception msg)
            {
                return null;
            }
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    string BATCHNO = Session["BATCHNO"].ToString();
                    ViewBag.BATCHNO = BATCHNO;

                    Stream stream = upload.InputStream;
                    IExcelDataReader reader = null;
                    if (upload.FileName.EndsWith(".xls"))
                    {
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (upload.FileName.EndsWith(".xlsx"))
                    {
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }
                    else
                    {
                        ModelState.AddModelError("File", "This file format is not supported");
                        return View();
                    }
                    int fieldcount = reader.FieldCount;
                    int rowcount = reader.RowCount;
                    DataTable dt = new DataTable();
                    DataRow row;
                    DataTable dt_ = new DataTable();
                    try
                    {
                        dt_ = reader.AsDataSet().Tables[0];
                        for (int i = 0; i < dt_.Columns.Count; i++)
                        {
                            dt.Columns.Add(dt_.Rows[0][i].ToString());
                        }
                        int rowcounter = 0;
                        for (int row_ = 1; row_ < dt_.Rows.Count; row_++)
                        {
                            row = dt.NewRow();
                            for (int col = 0; col < dt_.Columns.Count; col++)
                            {
                                row[col] = dt_.Rows[row_][col].ToString();
                                rowcounter++;
                            }
                            dt.Rows.Add(row);
                        }
                        IB.WEB_UPDATE_PTM(dt, Sessions.GetUseID().ToString());
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("File", "Unable to Upload file!");
                        return View("Detail");
                    }
                    ViewBag.BATCHNO = BATCHNO;
                    return View("Detail");
                }
                else
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
            }
            return View();
        }
        public JsonResult UPLOAD_DMR(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FILENAME = "[DMR]_" + RandomString(10).ToUpper() + "_" + (DateTime.Now.ToString("dd_MMM_yyyy__HH_mm_ss_tt")).ToUpper();
                    string _EXT = Path.GetExtension(file.FileName);
                    string _FINALNAME = _FILENAME + _EXT;

                    string _PATH = ConfigurationManager.AppSettings["ERECRUITMENT_UPLOAD_DMR"].ToString() + "\\" + _FINALNAME;
                    if (System.IO.File.Exists(_PATH))
                    {
                        System.IO.File.Delete(_PATH);
                    }
                    file.SaveAs(_PATH);
                    ViewBag.TEMP_DMR_FILE = _PATH;
                    ViewBag.TEMP_DMR_FILENAME = _FILENAME;

                    string HTML = System.IO.File.ReadAllText(_PATH);
                    HTML = HTML.Replace("<table", "<table id="+ _FILENAME +"");

                    return Json(new { Result = 1, DMRID = _FILENAME, Message = HTML });
                }
                else
                {
                    return Json(new { Result = 0, DMRID = "", Message = "NO DATA" });
                }
            }
            catch (Exception msg)
            {
                return Json(new { Result = 0, Message = msg.Message.ToString() });
            }
        }
        public JsonResult WEB_INTERVIEWBOARD_SAVE_WRITTEN_DMR(List<FILE_DMR> MODEL)
        {
            var Result = IB.WEB_INTERVIEWBOARD_SAVE_WRITTEN_DMR(MODEL, Sessions.GetUseID().ToString());
            return Json(Result, JsonRequestBehavior.AllowGet);
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
        public JsonResult WEB_GETTABLE_REPORT(string STATUS)
        {
            return Json(new { data = IB.WEB_GETTABLE_REPORT(STATUS) }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_GET_DETAIL_REPORT(string REPORTID)
        {
            return Json(IB.WEB_GET_DETAIL_REPORT(REPORTID), JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_SAVE_DETAIL_REPORT(USER_REPORT MODEL)
        {
            string USERID = Sessions.GetUseID().ToString();
            return Json(IB.WEB_SAVE_DETAIL_REPORT(MODEL, USERID), JsonRequestBehavior.AllowGet);
        }
        //WEB_GET_DETAIL_REPORT
        public JsonResult WEB_GETGRUPVIEW()
        {
            return Json(Sessions.GetBusFunc().ToString(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult WEB_CANDIDATE_DETAILS_SAVE(CANDIDATE_DETAILS2 MODEL)
        {
            try
            {
                var res = IB.WEB_CANDIDATE_DETAILS_SAVE(MODEL);
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch(Exception msg)
            {
                return Json(("ERROR: "+ msg.Message.ToString() + "", HttpStatusCode.InternalServerError), JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult WEB_CANDIDATE_DETAILS_SAVE_SIBLINGS(List<CANDIDATE_DETAILS_SIBLINGS> MODEL)
        {
            try
            {
                var Result = IB.WEB_CANDIDATE_DETAILS_SAVE_SIBLINGS(MODEL);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception msg)
            {
                return Json(("ERROR: " + msg.Message.ToString() + "", HttpStatusCode.InternalServerError), JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult WEB_CANDIDATE_DETAILS_SAVE_LANGUAGES(List<CANDIDATE_DETAILS_LANGUAGE> MODEL)
        {
            try
            {
                var Result = IB.WEB_CANDIDATE_DETAILS_SAVE_LANGUAGES(MODEL);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception msg)
            {
                return Json(("ERROR: " + msg.Message.ToString() + "", HttpStatusCode.InternalServerError), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public FileResult Export(string ExportData)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                StringReader reader = new StringReader(ExportData);
                Document PdfFile = new Document(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(PdfFile, stream);
                PdfFile.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, PdfFile, reader);
                PdfFile.Close();
                return File(stream.ToArray(), "application/pdf", "ExportData.pdf");
            }
        }
    }
}          