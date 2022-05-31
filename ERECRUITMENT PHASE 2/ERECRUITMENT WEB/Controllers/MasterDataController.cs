using ERECRUITMENT_WEB.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERECRUITMENT_WEB.Controllers
{
    public class MasterDataController : Controller
    {
        MasterData MD = new MasterData();
        public ActionResult User()
        {
            return View();
        }
        public ActionResult Group()
        {
            return View();
        }

        public JsonResult WEB_GET_RELIGION()
        {
            return Json(MD.WEB_GET_RELIGION(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_GET_RACE()
        {
            return Json(MD.WEB_GET_RACE(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_GET_EDU()
        {
            return Json(MD.WEB_GET_EDU(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_GET_PERSONALITY()
        {
            return Json(MD.WEB_GET_PERSONALITY(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_GET_THINKING_STY()
        {
            return Json(MD.WEB_GET_THINKING_STY(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_GET_WORKING_STY()
        {
            return Json(MD.WEB_GET_WORKING_STY(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult MOBILE_GET_GENDER()
        {
            return Json(MD.MOBILE_GET_GENDER(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult MOBILE_GET_MARITAL()
        {
            return Json(MD.MOBILE_GET_MARITAL(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult MOBILE_GET_DISTRICT()
        {
            return Json(MD.MOBILE_GET_DISTRICT(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult MOBILE_GET_VILLAGE(string DISTRICT)
        {
            return Json(MD.MOBILE_GET_VILLAGE(DISTRICT), JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_GET_USER_GROUP()
        {
            return Json(MD.WEB_GET_USER_GROUP(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_GET_GROUPTABLE()
        {
            var Result = MD.WEB_GET_GROUPTABLE();
            return Json(new { data = Result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_CREATE_GROUP(string GROUPNAME, string GROUPDESC)
        {
            var USERID = Sessions.GetUseID().ToString();
            return Json(MD.WEB_CREATE_GROUP(GROUPNAME, GROUPDESC, USERID), JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_DELETE_GROUP(string GROUP)
        {
            return Json(MD.WEB_DELETE_GROUP(GROUP), JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_GET_USERTABLE()
        {
            var Result = MD.WEB_GET_USERTABLE();
            return Json(new { data = Result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_CREATE_USER(string USER_ID, string USER_NAME, string USER_GROUP)
        {
            var USER_CREATOR = Sessions.GetUseID().ToString();
            return Json(MD.WEB_CREATE_USER(USER_ID, USER_NAME, USER_GROUP, USER_CREATOR), JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_DELETE_USER(string USER_ID)
        {
            return Json(MD.WEB_DELETE_USER(USER_ID), JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_GET_DASHBOARD_DETAIL(string BATCHNO)
        {
            return Json(MD.WEB_GET_DASHBOARD_DETAIL(BATCHNO), JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_GET_MD_PROVINCIES()
        {
            return Json(MD.WEB_GET_MD_PROVINCIES(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_GET_MD_REGENCIES(string ID_PROVINCIES)
        {
            return Json(MD.WEB_GET_MD_REGENCIES(ID_PROVINCIES), JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_GET_MD_DISTRICTS(string ID_REGENCIES)
        {
            return Json(MD.WEB_GET_MD_DISTRICTS(ID_REGENCIES), JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_GET_MD_VILLAGES(string ID_DISTRICTS)
        {
            return Json(MD.WEB_GET_MD_VILLAGES(ID_DISTRICTS), JsonRequestBehavior.AllowGet);
        }
        public JsonResult LOADCHART()
        {
            return Json(MD.LOADCHART(), JsonRequestBehavior.AllowGet);
        }
    }
}
