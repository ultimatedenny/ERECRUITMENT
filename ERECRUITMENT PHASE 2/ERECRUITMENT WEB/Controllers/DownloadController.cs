using ERECRUITMENT_WEB.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERECRUITMENT_WEB.Controllers
{
    public class DownloadController : Controller
    {
        // GET: Download
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
        public JsonResult IsPermitted()
        {
            var BUSFUNC = Sessions.GetBusFunc().ToString();
            if (BUSFUNC == "SYSTEM-ADMIN" || BUSFUNC == "SYSTEM-HRM" || BUSFUNC == "SYSTEM-HRD")
            {
                var model = new Models.ResponseModel()
                {
                    Result = true,
                    Message = ""
                };
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var model = new Models.ResponseModel()
                {
                    Result = false,
                    Message = "You cannot download this file."
                };
                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }
    }
}