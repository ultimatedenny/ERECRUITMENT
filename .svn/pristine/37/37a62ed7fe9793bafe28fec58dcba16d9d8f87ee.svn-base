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
    public class HomeController : Controller
    {
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
    }
}