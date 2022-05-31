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
    public class ReportController : Controller
    {
        InterviewScoreboard IB = new InterviewScoreboard();
        Report RPT = new Report();
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
        public ActionResult PersonalParticularForm(string BATCH_EMP)
        {
            if(string.IsNullOrEmpty(BATCH_EMP))
            {
                return RedirectToAction("Index", "Report");
            }
            {
                ViewBag.BATCH_EMP = BATCH_EMP;
                return View();
            }
        }
        public JsonResult WEB_GET_TABLE_REPORT(string BATCHNO, string STATUS, string KEYWORD)
        {
            return Json(new { data = RPT.WEB_GET_TABLE_REPORT(BATCHNO, STATUS, KEYWORD) }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_GETREPORT_FORM1(string BATCH_EMP)
        {
            return Json(RPT.WEB_GETREPORT_FORM1(BATCH_EMP), JsonRequestBehavior.AllowGet);
        }
    }
}