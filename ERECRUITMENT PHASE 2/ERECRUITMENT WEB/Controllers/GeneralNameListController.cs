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

namespace ERECRUITMENT_WEB.Controllers
{
    public class GeneralNameListController : Controller
    {
        GeneralNameList GN = new GeneralNameList();
        public ActionResult Index()
        {
            if (Sessions.GetUseID() != null)
            {
                //SBM - IT
                //SYSTEM - HRD
                //SYSTEM - HRM
                //SYSTEM - USER
                //SYSTEM - MANAGER
                var BUSFUNC = Sessions.GetBusFunc().ToString();
                if (BUSFUNC == "SYSTEM-ADMIN" || BUSFUNC == "SYSTEM-HRM")
                {
                    return View();
                }
                else
                {
                    TempData["ERROR"] = "Unauthorized Access! - " + DateTime.Now.ToString() + "";
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public JsonResult WEB_GET_TABLE_GENERAL(string BATCHNO, string STATUS, string KEYWORD)
        {
            return Json(new { data = GN.WEB_GET_TABLE_GENERAL(BATCHNO, STATUS, KEYWORD) }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_SUBMIT_USER_GENERAL(string BATCHNO)
        {
            string USERID = Sessions.GetUseID().ToString();
            var Result = GN.WEB_SUBMIT_USER_GENERAL(BATCHNO, USERID);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_VERIFY_USER_GENERAL(string BATCHNO)
        {
            string USERID = Sessions.GetUseID().ToString();
            var Result = GN.WEB_VERIFY_USER_GENERAL(BATCHNO, USERID);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public FileResult DOWNLOAD(string BATCHNO)
        {
            try
            {
                DataTable table = new DataTable("SHEET");
                table = GN.EXPORT(BATCHNO);
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
                           "SAMPLE-" + BATCHNO + "-" + Key.ToUpper() + ".xlsx");
                    }
                }
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        [HttpPost]
        public ActionResult UPLOAD(HttpPostedFileBase file)
        {
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    Stream stream = file.InputStream;
                    IExcelDataReader reader = null;
                    if (file.FileName.EndsWith(".xls"))
                    {
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (file.FileName.EndsWith(".xlsx"))
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
                    var res = GN.WEB_UPDATE_USER_GENERAL(dt, Sessions.GetUseID().ToString());
                    return Json(res, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Result = 0, Message = "Unable to Upload file!" });
                }
            }
            catch(Exception msg)
            {
                return Json(new { Result = 0, Message = msg.Message.ToString() });
            }
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