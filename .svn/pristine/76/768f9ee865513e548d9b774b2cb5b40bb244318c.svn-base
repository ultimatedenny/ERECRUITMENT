using ERECRUITMENT_WEB.Class;
using ERECRUITMENT_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace ERECRUITMENT_WEB.Controllers
{
    public class MobileController : Controller
    {
        Authentication AUTH = new Authentication();
        Mobile MBL = new Mobile();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginMobileViewModel model, string returnUrl)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                else
                {
                    var result = AUTH.Mobile_SignIn(model.UniqueId);
                    if (result.Result == true)
                    {
                        string TOKEN = Guid.NewGuid().ToString().ToUpper();
                        TempData["SUCCESSLOGIN"] = "Login Success - " + DateTime.Now.ToString() + "";
                        Session["TOKEN_MOBILE"] = model.UniqueId.ToString().ToUpper();
                        return RedirectToAction("Dashboard", "Mobile", new { id = model.UniqueId.ToString() });
                    }
                    else
                    {
                        TempData["ERROR"] = "Login Failed - " + result.Message.ToString() + " - " + DateTime.Now.ToString() + "";
                        return View();
                    }
                }
            }
            catch (Exception msg)
            {
                TempData["ERROR"] = "" + msg.Message.ToString() + "";
                return View();
            }
        }
        public ActionResult Dashboard(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "Mobile");
            }
            else
            {
                var result = AUTH.Mobile_SignIn(id);
                if (result.Result == true)
                {
                    string TOKEN = Guid.NewGuid().ToString().ToUpper();
                    TempData["SUCCESSLOGIN"] = "Login Success - " + DateTime.Now.ToString() + "";
                    Session["TOKEN_MOBILE"] = id.ToString().ToUpper();
                    ViewBag.UNIQUEID = Session["TOKEN_MOBILE"].ToString();
                    return View();
                }
                else
                {
                    TempData["ERROR"] = "Login Failed - " + result.Message.ToString() + " - " + DateTime.Now.ToString() + "";
                    return RedirectToAction("Index", "Mobile");
                }
            }
        }
        public ActionResult PersonalDataForm()
        {
            if (Session["TOKEN_MOBILE"] == null)
            {
                return RedirectToAction("Index", "Mobile");
            }
            else
            {
                ViewBag.UNIQUEID = Session["TOKEN_MOBILE"].ToString();
                return View();
            }
        }
        public ActionResult FamilyDataForm()
        {
            if (Session["TOKEN_MOBILE"] == null)
            {
                return RedirectToAction("Index", "Mobile");
            }
            else
            {
                ViewBag.UNIQUEID = Session["TOKEN_MOBILE"].ToString();
                return View();
            }
        }
        public ActionResult EducationDataForm()
        {
            if (Session["TOKEN_MOBILE"] == null)
            {
                return RedirectToAction("Index", "Mobile");
            }
            else
            {
                ViewBag.UNIQUEID = Session["TOKEN_MOBILE"].ToString();
                return View();
            }
        }
        public ActionResult LanguageDataForm()
        {
            if (Session["TOKEN_MOBILE"] == null)
            {
                return RedirectToAction("Index", "Mobile");
            }
            else
            {
                ViewBag.UNIQUEID = Session["TOKEN_MOBILE"].ToString();
                return View();
            }
        }
        public ActionResult WorkExperienceDataForm()
        {
            if (Session["TOKEN_MOBILE"] == null)
            {
                return RedirectToAction("Index", "Mobile");
            }
            else
            {
                ViewBag.UNIQUEID = Session["TOKEN_MOBILE"].ToString();
                return View();
            }
        }
        public ActionResult AdditionalDataForm()
        {
            if (Session["TOKEN_MOBILE"] == null)
            {
                return RedirectToAction("Index", "Mobile");
            }
            else
            {
                ViewBag.UNIQUEID = Session["TOKEN_MOBILE"].ToString();
                return View();
            }
        }
        public ActionResult UniformDataForm()
        {
            if (Session["TOKEN_MOBILE"] == null)
            {
                return RedirectToAction("Index", "Mobile");
            }
            else
            {
                ViewBag.UNIQUEID = Session["TOKEN_MOBILE"].ToString();
                return View();
            }
        }
        public ActionResult EmergencyContactDataForm()
        {
            if (Session["TOKEN_MOBILE"] == null)
            {
                return RedirectToAction("Index", "Mobile");
            }
            else
            {
                ViewBag.UNIQUEID = Session["TOKEN_MOBILE"].ToString();
                return View();
            }
        }
        public ActionResult FamilyBackgroundDataForm()
        {
            if (Session["TOKEN_MOBILE"] == null)
            {
                return RedirectToAction("Index", "Mobile");
            }
            else
            {
                ViewBag.UNIQUEID = Session["TOKEN_MOBILE"].ToString();
                return View();
            }
        }
        public ActionResult SpouseDataForm()
        {
            if (Session["TOKEN_MOBILE"] == null)
            {
                return RedirectToAction("Index", "Mobile");
            }
            else
            {
                ViewBag.UNIQUEID = Session["TOKEN_MOBILE"].ToString();
                return View();
            }
        }
        public ActionResult ReferencePersonDataForm()
        {
            if (Session["TOKEN_MOBILE"] == null)
            {
                return RedirectToAction("Index", "Mobile");
            }
            else
            {
                ViewBag.UNIQUEID = Session["TOKEN_MOBILE"].ToString();
                return View();
            }
        }
        public ActionResult HealthDataForm()
        {
            if (Session["TOKEN_MOBILE"] == null)
            {
                return RedirectToAction("Index", "Mobile");
            }
            else
            {
                ViewBag.UNIQUEID = Session["TOKEN_MOBILE"].ToString();
                return View();
            }
        }
        public ActionResult DocumentDataForm()
        {
            if (Session["TOKEN_MOBILE"] == null)
            {
                return RedirectToAction("Index", "Mobile");
            }
            else
            {
                ViewBag.UNIQUEID = Session["TOKEN_MOBILE"].ToString();
                return View();
            }
        }
        public ActionResult SubmitReport()
        {
            if (Session["TOKEN_MOBILE"] == null)
            {
                return RedirectToAction("Index", "Mobile");
            }
            else
            {
                ViewBag.UNIQUEID = Session["TOKEN_MOBILE"].ToString();
                return View();
            }
        }







        public JsonResult GET_MOBILE_DASHBOARD(string INVITATION)
        {
            var Result = MBL.GET_MOBILE_DASHBOARD(INVITATION);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GET_MOBILE_CANEDIT_WORKEXPFORM(string INVITATION)
        {
            var Result = MBL.GET_MOBILE_CANEDIT_WORKEXPFORM(INVITATION);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GET_MOBILE_CANEDIT_PERSONALFORM(string INVITATION)
        {
            var Result = MBL.GET_MOBILE_CANEDIT_PERSONALFORM(INVITATION);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GET_MOBILE_CANEDIT_FAMILYFORM(string INVITATION)
        {
            var Result = MBL.GET_MOBILE_CANEDIT_FAMILYFORM(INVITATION);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GET_MOBILE_CANEDIT_EDUCATIONFORM(string INVITATION)
        {
            var Result = MBL.GET_MOBILE_CANEDIT_EDUCATIONFORM(INVITATION);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GET_MOBILE_CANEDIT_LANGUAGEFORM(string INVITATION)
        {
            var Result = MBL.GET_MOBILE_CANEDIT_LANGUAGEFORM(INVITATION);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GET_MOBILE_CANEDIT_ADDITIONALFORM(string INVITATION)
        {
            var Result = MBL.GET_MOBILE_CANEDIT_ADDITIONALFORM(INVITATION);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GET_MOBILE_GATENAME_UNIFORM(string INVITATION)
        {
            var Result = MBL.GET_MOBILE_GATENAME_UNIFORM(INVITATION);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MOBILE_GET_MOBILE_GOTOFORM(string INVITATION)
        {
            var Result = MBL.MOBILE_GET_MOBILE_GOTOFORM(INVITATION);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GET_MOBILE_GETPARENTS(string INVITATION)
        {
            var RESULT = MBL.GET_MOBILE_GETPARENTS(INVITATION);
            return Json(RESULT, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MOBILE_SAVE_PERSONALFORM(USER_PROFILE MODEL, string KTP_DIR, string PASFOTO_DIR)
        {
            KTP_DIR = Session["TEMP_KTP_FILE"].ToString();
            PASFOTO_DIR = Session["TEMP_PASFOTO_FILE"].ToString();
            var Result = MBL.MOBILE_SAVE_PERSONALFORM(MODEL, KTP_DIR, PASFOTO_DIR);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MOBILE_SAVE_FAMILYFORM(USER_FAMILY MODEL)
        {
            string KK_DIR = Session["TEMP_KK_FILE"].ToString();
            var Result = MBL.MOBILE_SAVE_FAMILYFORM(MODEL, KK_DIR);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MOBILE_SAVE_SIBLINGSFORM(List<USER_SIBLINGS> MODEL)
        {
            var Result = MBL.MOBILE_SAVE_SIBLINGSFORM(MODEL);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MOBILE_SAVE_EDUCATIONFORM(USER_EDUCATION MODEL)
        {
            string IJAZAH_DIR_F = Session["TEMP_IJAZAH_F_FILE"].ToString();
            string IJAZAH_DIR_B = Session["TEMP_IJAZAH_B_FILE"].ToString();
            MODEL.PHOTO_CERT_F = IJAZAH_DIR_F;
            MODEL.PHOTO_CERT_B = IJAZAH_DIR_B;
            var Result = MBL.MOBILE_SAVE_EDUCATIONFORM(MODEL, IJAZAH_DIR_F, IJAZAH_DIR_B);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MOBILE_SAVE_LANGUAGEFORM(List<USER_LANGUAGE> MODEL)
        {
            var Result = MBL.MOBILE_SAVE_LANGUAGEFORM(MODEL);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MOBILE_SAVE_WORKEXPFORM(List<USER_WORKEXP> MODEL)
        {
            var RESULT = MBL.MOBILE_SAVE_WORKEXPFORM(MODEL);
            return Json(RESULT, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MOBILE_SAVE_ADDITIONAL(USER_ADDITIONAL MODEL)
        {
            string CV = Session["TEMP_DOC_CV_FILE"].ToString();
            string CL = Session["TEMP_DOC_CL_FILE"].ToString();
            var RESULT = MBL.MOBILE_SAVE_ADDITIONALFORM(MODEL, CV, CL);
            return Json(RESULT, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MOBILE_SAVE_UNIFORMFORM(USER_UNIFORM MODEL)
        {
            var RESULT = MBL.MOBILE_SAVE_UNIFORMFORM(MODEL);
            return Json(RESULT, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MOBILE_SAVE_EMERGENCYCONTACT(USER_EMERGENCY MODEL)
        {
            var RESULT = MBL.MOBILE_SAVE_EMERGENCYCONTACT(MODEL);
            return Json(RESULT, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MOBILE_SAVE_FAMILYBACKGROUND(USER_FAMILY MODEL)
        {
            var RESULT = MBL.MOBILE_SAVE_FAMILYBACKGROUND(MODEL);
            return Json(RESULT, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MOBILE_SAVE_SPOUSE(USER_SPOUSE MODEL)
        {
            var RESULT = MBL.MOBILE_SAVE_SPOUSE(MODEL);
            return Json(RESULT, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MOBILE_SAVE_CHILD(List<USER_CHILD> MODEL)
        {
            var RESULT = MBL.MOBILE_SAVE_CHILD(MODEL);
            return Json(RESULT, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MOBILE_SAVE_REFERENCE_PERSON(USER_REFERENCE MODEL)
        {
            var RESULT = MBL.MOBILE_SAVE_REFERENCE_PERSON(MODEL);
            return Json(RESULT, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MOBILE_SAVE_HEALTH(USER_HEALTH MODEL)
        {
            var RESULT = MBL.MOBILE_SAVE_HEALTH(MODEL);
            return Json(RESULT, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MOBILE_SAVE_DOCUMENT(USER_DOCUMENT MODEL)
        {
            string IMG_BCA = Session["TEMP_DOC_BCA_FILE"].ToString();
            string IMG_NPWP = Session["TEMP_DOC_NPWP_FILE"].ToString();
            string IMG_EFIN = Session["TEMP_DOC_EFIN_FILE"].ToString();
            string IMG_BPJS_KES = Session["TEMP_DOC_BPJS_KS_FILE"].ToString();
            string IMG_BPJS_TKJ = Session["TEMP_DOC_BPJS_TJK_FILE"].ToString();
            string IMG_SIM_C = Session["TEMP_DOC_SIM_C_FILE"].ToString();
            string IMG_VAKSIN = Session["TEMP_DOC_VAKSIN_FILE"].ToString();
            string IMG_SKCK = Session["TEMP_DOC_SKCK_FILE"].ToString();
            string IMG_SERTIFIKAT_KOMPETENSI = Session["TEMP_DOC_SERTIFIKAT_FILE"].ToString();
            string IMG_PENGALAMAN = Session["TEMP_DOC_PENGALAMAN_FILE"].ToString();
            string IMG_SURAT_SEHAT = Session["TEMP_DOC_KESEHATAN_FILE"].ToString();
            string IMG_KARTU_KUNING = Session["TEMP_DOC_KARTU_KUNING_FILE"].ToString();
            string IMG_SIO = Session["TEMP_DOC_SIO_FILE"].ToString();

            var RESULT = MBL.MOBILE_SAVE_DOCUMENT(MODEL, 
                IMG_BCA, 
                IMG_NPWP, 
                IMG_EFIN, 
                IMG_BPJS_KES,
                IMG_BPJS_TKJ,
                IMG_SIM_C,
                IMG_VAKSIN,
                IMG_SKCK,
                IMG_SERTIFIKAT_KOMPETENSI,
                IMG_PENGALAMAN,
                IMG_SURAT_SEHAT,
                IMG_KARTU_KUNING,
                IMG_SIO);
            return Json(RESULT, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MOBILE_SAVE_REPORT(USER_REPORT MODEL)
        {
            string REPORT_DIR = Session["TEMP_DOC_REPORT_FILE"].ToString();
            var Result = MBL.MOBILE_SAVE_REPORT(MODEL, REPORT_DIR);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }




        public JsonResult UPLOAD_KTP(HttpPostedFileBase file, string UNIQUEID)
        {
            try
            {
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        string _FILENAME = "[KTP]_" + Session["TOKEN_MOBILE"].ToString();
                        string _EXT = Path.GetExtension(file.FileName);
                        string _FINALNAME = _FILENAME + _EXT;

                        string _PATH = System.Configuration.ConfigurationManager.AppSettings["ERECRUITMENT_UPLOAD_KTP"].ToString() + "\\" + _FINALNAME;
                        if (System.IO.File.Exists(_PATH))
                        {
                            System.IO.File.Delete(_PATH);
                        }
                        file.SaveAs(_PATH);
                        Session["TEMP_KTP_FILE"] = _PATH;
                        return Json(new { Result = 1, Message = "Success" });
                    }
                    else
                    {
                        return Json(new { Result = 0, Message = "Failed" });
                    }
                }
                else
                {
                    return Json(new { Result = 0, Message = "Failed" });
                }
            }
            catch (Exception msg)
            {
                return Json(new { Result = 0, Message = msg.Message.ToString() });
            }
        }
        public JsonResult UPLOAD_PASFOTO(HttpPostedFileBase file, string UNIQUEID)
        {
            try
            {
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        string _FILENAME = "[PASFOTO]_" + Session["TOKEN_MOBILE"].ToString();
                        string _EXT = Path.GetExtension(file.FileName);
                        string _FINALNAME = _FILENAME + _EXT;

                        string _PATH = System.Configuration.ConfigurationManager.AppSettings["ERECRUITMENT_UPLOAD_PASFOTO"].ToString() + "\\" + _FINALNAME;
                        if (System.IO.File.Exists(_PATH))
                        {
                            System.IO.File.Delete(_PATH);
                        }
                        file.SaveAs(_PATH);
                        Session["TEMP_PASFOTO_FILE"] = _PATH;
                        return Json(new { Result = 1, Message = "Success" });
                    }
                    else
                    {
                        return Json(new { Result = 0, Message = "Failed" });
                    }
                }
                else
                {
                    return Json(new { Result = 0, Message = "Failed" });
                }
            }
            catch (Exception msg)
            {
                return Json(new { Result = 0, Message = msg.Message.ToString() });
            }
        }
        public JsonResult UPLOAD_KK(HttpPostedFileBase file, string UNIQUEID)
        {
            try
            {
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        string _FILENAME = "[KK]_" + Session["TOKEN_MOBILE"].ToString();
                        string _EXT = Path.GetExtension(file.FileName);
                        string _FINALNAME = _FILENAME + _EXT;

                        string _PATH = System.Configuration.ConfigurationManager.AppSettings["ERECRUITMENT_UPLOAD_KK"].ToString() + "\\" + _FINALNAME;
                        if (System.IO.File.Exists(_PATH))
                        {
                            System.IO.File.Delete(_PATH);
                        }
                        file.SaveAs(_PATH);
                        Session["TEMP_KK_FILE"] = _PATH;
                        return Json(new { Result = 1, Message = "Success" });
                    }
                    else
                    {
                        return Json(new { Result = 0, Message = "Failed" });
                    }
                }
                else
                {
                    return Json(new { Result = 0, Message = "Failed" });
                }
            }
            catch (Exception msg)
            {
                return Json(new { Result = 0, Message = msg.Message.ToString() });
            }
        }
        public JsonResult UPLOAD_IJAZAH_F(HttpPostedFileBase file, string UNIQUEID)
        {
            try
            {
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        string _FILENAME = "[IJAZAH_F]_" + Session["TOKEN_MOBILE"].ToString();
                        string _EXT = Path.GetExtension(file.FileName);
                        string _FINALNAME = _FILENAME + _EXT;

                        string _PATH = System.Configuration.ConfigurationManager.AppSettings["ERECRUITMENT_UPLOAD_IJAZAH"].ToString() + "\\" + _FINALNAME;
                        if (System.IO.File.Exists(_PATH))
                        {
                            System.IO.File.Delete(_PATH);
                        }
                        file.SaveAs(_PATH);
                        Session["TEMP_IJAZAH_F_FILE"] = _PATH;
                        return Json(new { Result = 1, Message = "Success" });
                    }
                    else
                    {
                        return Json(new { Result = 0, Message = "Failed" });
                    }
                }
                else
                {
                    return Json(new { Result = 0, Message = "Failed" });
                }
            }
            catch (Exception msg)
            {
                return Json(new { Result = 0, Message = msg.Message.ToString() });
            }
        }
        public JsonResult UPLOAD_IJAZAH_B(HttpPostedFileBase file, string UNIQUEID)
        {
            try
            {
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        string _FILENAME = "[IJAZAH_B]_" + Session["TOKEN_MOBILE"].ToString();
                        string _EXT = Path.GetExtension(file.FileName);
                        string _FINALNAME = _FILENAME + _EXT;

                        string _PATH = System.Configuration.ConfigurationManager.AppSettings["ERECRUITMENT_UPLOAD_IJAZAH"].ToString() + "\\" + _FINALNAME;
                        if (System.IO.File.Exists(_PATH))
                        {
                            System.IO.File.Delete(_PATH);
                        }
                        file.SaveAs(_PATH);
                        Session["TEMP_IJAZAH_B_FILE"] = _PATH;
                        return Json(new { Result = 1, Message = "Success" });
                    }
                    else
                    {
                        return Json(new { Result = 0, Message = "Failed" });
                    }
                }
                else
                {
                    return Json(new { Result = 0, Message = "Failed" });
                }
            }
            catch (Exception msg)
            {
                return Json(new { Result = 0, Message = msg.Message.ToString() });
            }
        }
        public JsonResult UPLOAD_WORKEXPERIENCE(HttpPostedFileBase file, string UNIQUEID)
        {
            try
            {
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                        var stringChars = new char[4];
                        var random = new Random();
                        for (int i = 0; i < stringChars.Length; i++)
                        {
                            stringChars[i] = chars[random.Next(chars.Length)];
                        }
                        var randomkey = new String(stringChars);

                        string _FILENAME = "[WORK_EXP]_" + Session["TOKEN_MOBILE"].ToString();
                        string _EXT = Path.GetExtension(file.FileName);
                        string _FINALNAME = _FILENAME + "-" + randomkey + _EXT;
                        string _PATH = System.Configuration.ConfigurationManager.AppSettings["ERECRUITMENT_UPLOAD_WORKEXP"].ToString() + "\\" + _FINALNAME;
                        if (System.IO.File.Exists(_PATH))
                        {
                            System.IO.File.Delete(_PATH);
                        }
                        file.SaveAs(_PATH);
                        Session["TEMP_WORK_EXP_FILE"] = _PATH;
                        return Json(new { Result = true, Message = _PATH });
                    }
                    else
                    {
                        return Json(new { Result = false, Message = "-" });
                    }
                }
                else
                {
                    return Json(new { Result = false, Message = "-" });
                }
            }
            catch (Exception msg)
            {
                return Json(new { Result = false, Message = msg.Message.ToString() });
            }
        }
        public JsonResult UPLOAD_CL(HttpPostedFileBase file, string UNIQUEID)
        {
            try
            {
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        string _FILENAME = "[DOC_CL]_" + Session["TOKEN_MOBILE"].ToString();
                        string _EXT = Path.GetExtension(file.FileName);
                        string _FINALNAME = _FILENAME + _EXT;

                        string _PATH = System.Configuration.ConfigurationManager.AppSettings["ERECRUITMENT_UPLOAD_CL"].ToString() + "\\" + _FINALNAME;
                        if (System.IO.File.Exists(_PATH))
                        {
                            System.IO.File.Delete(_PATH);
                        }
                        file.SaveAs(_PATH);
                        Session["TEMP_DOC_CL_FILE"] = _PATH;
                        return Json(new { Result = 1, Message = "Success" });
                    }
                    else
                    {
                        return Json(new { Result = 0, Message = "Failed" });
                    }
                }
                else
                {
                    return Json(new { Result = 0, Message = "Failed" });
                }
            }
            catch (Exception msg)
            {
                return Json(new { Result = 0, Message = msg.Message.ToString() });
            }
        }
        public JsonResult UPLOAD_CV(HttpPostedFileBase file, string UNIQUEID)
        {
            try
            {
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        string _FILENAME = "[DOC_CV]_" + Session["TOKEN_MOBILE"].ToString();
                        string _EXT = Path.GetExtension(file.FileName);
                        string _FINALNAME = _FILENAME + _EXT;

                        string _PATH = System.Configuration.ConfigurationManager.AppSettings["ERECRUITMENT_UPLOAD_CV"].ToString() + "\\" + _FINALNAME;
                        if (System.IO.File.Exists(_PATH))
                        {
                            System.IO.File.Delete(_PATH);
                        }
                        file.SaveAs(_PATH);
                        Session["TEMP_DOC_CV_FILE"] = _PATH;
                        return Json(new { Result = 1, Message = "Success" });
                    }
                    else
                    {
                        return Json(new { Result = 0, Message = "Failed" });
                    }
                }
                else
                {
                    return Json(new { Result = 0, Message = "Failed" });
                }
            }
            catch (Exception msg)
            {
                return Json(new { Result = 0, Message = msg.Message.ToString() });
            }
        }
        public JsonResult UPLOAD_BCA(HttpPostedFileBase file, string UNIQUEID)
        {
            try
            {
                if (file != null)
                {
                    if (file.ContentLength > 0 || file != null)
                    {
                        string _FILENAME = "[DOC_BCA]_" + Session["TOKEN_MOBILE"].ToString();
                        string _EXT = Path.GetExtension(file.FileName);
                        string _FINALNAME = _FILENAME + _EXT;

                        string _PATH = System.Configuration.ConfigurationManager.AppSettings["ERECRUITMENT_UPLOAD_BCA"].ToString() + "\\" + _FINALNAME;
                        if (System.IO.File.Exists(_PATH))
                        {
                            System.IO.File.Delete(_PATH);
                        }
                        file.SaveAs(_PATH);
                        Session["TEMP_DOC_BCA_FILE"] = _PATH;
                        return Json(new { Result = 1, Message = "Success" });
                    }
                    else
                    {
                        return Json(new { Result = 0, Message = "Failed" });
                    }
                }
                else
                {
                    return Json(new { Result = 0, Message = "Failed" });
                }
            }
            catch (Exception msg)
            {
                return Json(new { Result = 0, Message = msg.Message.ToString() });
            }
        }
        public JsonResult UPLOAD_NPWP(HttpPostedFileBase file, string UNIQUEID)
        {
            try
            {
                if (file != null)
                {
                    if (file.ContentLength > 0 || file != null)
                    {
                        string _FILENAME = "[DOC_NPWP]_" + Session["TOKEN_MOBILE"].ToString();
                        string _EXT = Path.GetExtension(file.FileName);
                        string _FINALNAME = _FILENAME + _EXT;

                        string _PATH = System.Configuration.ConfigurationManager.AppSettings["ERECRUITMENT_UPLOAD_NPWP"].ToString() + "\\" + _FINALNAME;
                        if (System.IO.File.Exists(_PATH))
                        {
                            System.IO.File.Delete(_PATH);
                        }
                        file.SaveAs(_PATH);
                        Session["TEMP_DOC_NPWP_FILE"] = _PATH;
                        return Json(new { Result = 1, Message = "Success" });
                    }
                    else
                    {
                        return Json(new { Result = 0, Message = "Failed" });
                    }
                }
                else
                {
                    return Json(new { Result = 0, Message = "Failed" });
                }
            }
            catch (Exception msg)
            {
                return Json(new { Result = 0, Message = msg.Message.ToString() });
            }
        }
        public JsonResult UPLOAD_EFIN(HttpPostedFileBase file, string UNIQUEID)
        {
            try
            {
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        string _FILENAME = "[DOC_EFIN]_" + Session["TOKEN_MOBILE"].ToString();
                        string _EXT = Path.GetExtension(file.FileName);
                        string _FINALNAME = _FILENAME + _EXT;

                        string _PATH = System.Configuration.ConfigurationManager.AppSettings["ERECRUITMENT_UPLOAD_EFIN"].ToString() + "\\" + _FINALNAME;
                        if (System.IO.File.Exists(_PATH))
                        {
                            System.IO.File.Delete(_PATH);
                        }
                        file.SaveAs(_PATH);
                        Session["TEMP_DOC_EFIN_FILE"] = _PATH;
                        return Json(new { Result = 1, Message = "Success" });
                    }
                    else
                    {
                        Session["TEMP_DOC_EFIN_FILE"] = "";
                        return Json(new { Result = 0, Message = "Failed" });
                    }
                }
                else
                {
                    Session["TEMP_DOC_EFIN_FILE"] = "";
                    return Json(new { Result = 1, Message = "NO DOCUMENT ATTACHED" });
                }
            }
            catch (Exception msg)
            {
                return Json(new { Result = 0, Message = msg.Message.ToString() });
            }
        }
        public JsonResult UPLOAD_BPJS_KS(HttpPostedFileBase file, string UNIQUEID)
        {
            try
            {
                if(file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        string _FILENAME = "[DOC_BPJS_KS]_" + Session["TOKEN_MOBILE"].ToString();
                        string _EXT = Path.GetExtension(file.FileName);
                        string _FINALNAME = _FILENAME + _EXT;
                        string _PATH = System.Configuration.ConfigurationManager.AppSettings["ERECRUITMENT_UPLOAD_BPJS_KS"].ToString() + "\\" + _FINALNAME;
                        if (System.IO.File.Exists(_PATH))
                        {
                            System.IO.File.Delete(_PATH);
                        }
                        file.SaveAs(_PATH);
                        Session["TEMP_DOC_BPJS_KS_FILE"] = _PATH;
                        return Json(new { Result = 1, Message = "Success" });
                    }
                    else
                    {
                        Session["TEMP_DOC_BPJS_KS_FILE"] = "";
                        return Json(new { Result = 0, Message = "Failed" });
                    }
                }
                else
                {
                    Session["TEMP_DOC_BPJS_KS_FILE"] = "";
                    return Json(new { Result = 1, Message = "Failed" });
                }
            }
            catch (Exception msg)
            {
                return Json(new { Result = 0, Message = msg.Message.ToString() });
            }
        }
        public JsonResult UPLOAD_BPJS_TKJ(HttpPostedFileBase file, string UNIQUEID)
        {
            try
            {
                if(file!=null)
                {
                    if (file.ContentLength > 0)
                    {
                        string _FILENAME = "[DOC_BPJS_TKJ]_" + Session["TOKEN_MOBILE"].ToString();
                        string _EXT = Path.GetExtension(file.FileName);
                        string _FINALNAME = _FILENAME + _EXT;
                        string _PATH = System.Configuration.ConfigurationManager.AppSettings["ERECRUITMENT_UPLOAD_BPJS_TKJ"].ToString() + "\\" + _FINALNAME;
                        if (System.IO.File.Exists(_PATH))
                        {
                            System.IO.File.Delete(_PATH);
                        }
                        file.SaveAs(_PATH);
                        Session["TEMP_DOC_BPJS_TJK_FILE"] = _PATH;
                        return Json(new { Result = 1, Message = "Success" });
                    }
                    else
                    {
                        Session["TEMP_DOC_BPJS_TJK_FILE"] = "";
                        return Json(new { Result = 0, Message = "Failed" });
                    }
                }
                else
                {
                    Session["TEMP_DOC_BPJS_TJK_FILE"] = "";
                    return Json(new { Result = 1, Message = "Failed" });
                }
            }
            catch (Exception msg)
            {
                return Json(new { Result = 0, Message = msg.Message.ToString() });
            }
        }
        public JsonResult UPLOAD_SIM_C(HttpPostedFileBase file, string UNIQUEID)
        {
            try
            {
                if(file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        string _FILENAME = "[DOC_SIM_C]_" + Session["TOKEN_MOBILE"].ToString();
                        string _EXT = Path.GetExtension(file.FileName);
                        string _FINALNAME = _FILENAME + _EXT;
                        string _PATH = System.Configuration.ConfigurationManager.AppSettings["ERECRUITMENT_UPLOAD_SIM_C"].ToString() + "\\" + _FINALNAME;
                        if (System.IO.File.Exists(_PATH))
                        {
                            System.IO.File.Delete(_PATH);
                        }
                        file.SaveAs(_PATH);
                        Session["TEMP_DOC_SIM_C_FILE"] = _PATH;
                        return Json(new { Result = 1, Message = "Success" });
                    }
                    else
                    {
                        Session["TEMP_DOC_SIM_C_FILE"] = "";
                        return Json(new { Result = 0, Message = "Failed" });
                    }
                }
                else
                {
                    Session["TEMP_DOC_SIM_C_FILE"] = "";
                    return Json(new { Result = 1, Message = "Failed" });
                }
            }
            catch (Exception msg)
            {
                return Json(new { Result = 0, Message = msg.Message.ToString() });
            }
        }
        public JsonResult UPLOAD_VAKSIN(HttpPostedFileBase file, string UNIQUEID)
        {
            try
            {
                if(file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        string _FILENAME = "[DOC_VAKSIN]_" + Session["TOKEN_MOBILE"].ToString();
                        string _EXT = Path.GetExtension(file.FileName);
                        string _FINALNAME = _FILENAME + _EXT;

                        string _PATH = System.Configuration.ConfigurationManager.AppSettings["ERECRUITMENT_UPLOAD_VAKSIN"].ToString() + "\\" + _FINALNAME;
                        if (System.IO.File.Exists(_PATH))
                        {
                            System.IO.File.Delete(_PATH);
                        }
                        file.SaveAs(_PATH);
                        Session["TEMP_DOC_VAKSIN_FILE"] = _PATH;
                        return Json(new { Result = 1, Message = "Success" });
                    }
                    else
                    {
                        return Json(new { Result = 0, Message = "Failed" });
                    }
                }
                else
                {
                    return Json(new { Result = 0, Message = "Failed" });
                }
            }
            catch (Exception msg)
            {
                return Json(new { Result = 0, Message = msg.Message.ToString() });
            }
        }
        public JsonResult UPLOAD_SKCK(HttpPostedFileBase file, string UNIQUEID)
        {
            try
            {
                if (file != null)
                {
                    if (file.ContentLength > 0 || file != null)
                    {
                        string _FILENAME = "[DOC_SKCK]_" + Session["TOKEN_MOBILE"].ToString();
                        string _EXT = Path.GetExtension(file.FileName);
                        string _FINALNAME = _FILENAME + _EXT;
                        string _PATH = System.Configuration.ConfigurationManager.AppSettings["ERECRUITMENT_UPLOAD_SKCK"].ToString() + "\\" + _FINALNAME;
                        if (System.IO.File.Exists(_PATH))
                        {
                            System.IO.File.Delete(_PATH);
                        }
                        file.SaveAs(_PATH);
                        Session["TEMP_DOC_SKCK_FILE"] = _PATH;
                        return Json(new { Result = 1, Message = "Success" });
                    }
                    else
                    {
                        Session["TEMP_DOC_SKCK_FILE"] = "";
                        return Json(new { Result = 0, Message = "Failed" });
                    }
                }
                else
                {
                    Session["TEMP_DOC_SKCK_FILE"] = "";
                    return Json(new { Result = 1, Message = "Failed" });
                }
            }
            catch (Exception msg)
            {
                return Json(new { Result = 0, Message = msg.Message.ToString() });
            }
        }
        public JsonResult UPLOAD_SERTIFIKAT(HttpPostedFileBase file, string UNIQUEID)
        {
            try
            {
                if (file != null)
                {
                    if (file.ContentLength > 0 || file != null)
                    {
                        string _FILENAME = "[DOC_SKCK]_" + Session["TOKEN_MOBILE"].ToString();
                        string _EXT = Path.GetExtension(file.FileName);
                        string _FINALNAME = _FILENAME + _EXT;

                        string _PATH = System.Configuration.ConfigurationManager.AppSettings["ERECRUITMENT_UPLOAD_SERTIFIKAT"].ToString() + "\\" + _FINALNAME;
                        if (System.IO.File.Exists(_PATH))
                        {
                            System.IO.File.Delete(_PATH);
                        }
                        file.SaveAs(_PATH);
                        Session["TEMP_DOC_SERTIFIKAT_FILE"] = _PATH;
                        return Json(new { Result = 1, Message = "Success" });
                    }
                    else
                    {
                        Session["TEMP_DOC_SERTIFIKAT_FILE"] = "";
                        return Json(new { Result = 0, Message = "Failed" });
                    }
                }
                else
                {
                    Session["TEMP_DOC_SERTIFIKAT_FILE"] = "";
                    return Json(new { Result = 1, Message = "Failed" });
                }
            }
            catch (Exception msg)
            {
                return Json(new { Result = 0, Message = msg.Message.ToString() });
            }
        }
        public JsonResult UPLOAD_PENGALAMAN(HttpPostedFileBase file, string UNIQUEID)
        {
            try
            {
                if (file != null)
                {
                    if (file.ContentLength > 0 || file != null)
                    {
                        string _FILENAME = "[WORK_EXP]_" + Session["TOKEN_MOBILE"].ToString();
                        string _EXT = Path.GetExtension(file.FileName);
                        string _FINALNAME = _FILENAME + _EXT;
                        string _PATH = System.Configuration.ConfigurationManager.AppSettings["ERECRUITMENT_UPLOAD_WORKEXP"].ToString() + "\\" + _FINALNAME;
                        if (System.IO.File.Exists(_PATH))
                        {
                            System.IO.File.Delete(_PATH);
                        }
                        file.SaveAs(_PATH);
                        Session["TEMP_DOC_PENGALAMAN_FILE"] = _PATH;
                        return Json(new { Result = 1, Message = "Success" });
                    }
                    else
                    {
                        Session["TEMP_DOC_PENGALAMAN_FILE"] = "";
                        return Json(new { Result = 0, Message = "Failed" });
                    }
                }
                else
                {
                    Session["TEMP_DOC_PENGALAMAN_FILE"] = "";
                    return Json(new { Result = 1, Message = "Failed" });
                }
            }
            catch (Exception msg)
            {
                return Json(new { Result = 0, Message = msg.Message.ToString() });
            }
        }
        public JsonResult UPLOAD_KESEHATAN(HttpPostedFileBase file, string UNIQUEID)
        {
            try
            {
                if (file != null)
                {
                    if (file.ContentLength > 0 || file != null)
                    {
                        string _FILENAME = "[DOC_KESEHATAN]_" + Session["TOKEN_MOBILE"].ToString();
                        string _EXT = Path.GetExtension(file.FileName);
                        string _FINALNAME = _FILENAME + _EXT;
                        string _PATH = System.Configuration.ConfigurationManager.AppSettings["ERECRUITMENT_UPLOAD_KESEHATAN"].ToString() + "\\" + _FINALNAME;
                        if (System.IO.File.Exists(_PATH))
                        {
                            System.IO.File.Delete(_PATH);
                        }
                        file.SaveAs(_PATH);
                        Session["TEMP_DOC_KESEHATAN_FILE"] = _PATH;
                        return Json(new { Result = 1, Message = "Success" });
                    }
                    else
                    {
                        Session["TEMP_DOC_KESEHATAN_FILE"] = "";
                        return Json(new { Result = 0, Message = "Failed" });
                    }
                }
                else
                {
                    Session["TEMP_DOC_KESEHATAN_FILE"] = "";
                    return Json(new { Result = 1, Message = "Failed" });
                }
            }
            catch (Exception msg)
            {
                return Json(new { Result = 0, Message = msg.Message.ToString() });
            }
        }
        public JsonResult UPLOAD_KARTU_KUNING(HttpPostedFileBase file, string UNIQUEID)
        {
            try
            {
                if (file != null)
                {
                    if (file.ContentLength > 0 || file != null)
                    {
                        string _FILENAME = "[DOC_KARTU_KUNING]_" + Session["TOKEN_MOBILE"].ToString();
                        string _EXT = Path.GetExtension(file.FileName);
                        string _FINALNAME = _FILENAME + _EXT;
                        string _PATH = System.Configuration.ConfigurationManager.AppSettings["ERECRUITMENT_UPLOAD_KARTU_KUNING"].ToString() + "\\" + _FINALNAME;
                        if (System.IO.File.Exists(_PATH))
                        {
                            System.IO.File.Delete(_PATH);
                        }
                        file.SaveAs(_PATH);
                        Session["TEMP_DOC_KARTU_KUNING_FILE"] = _PATH;
                        return Json(new { Result = 1, Message = "Success" });
                    }
                    else
                    {
                        Session["TEMP_DOC_KARTU_KUNING_FILE"] = "";
                        return Json(new { Result = 0, Message = "Failed" });
                    }
                }
                else
                {
                    Session["TEMP_DOC_KARTU_KUNING_FILE"] = "";
                    return Json(new { Result = 1, Message = "Failed" });
                }
            }
            catch (Exception msg)
            {
                return Json(new { Result = 0, Message = msg.Message.ToString() });
            }
        }
        public JsonResult UPLOAD_SIO(HttpPostedFileBase file, string UNIQUEID)
        {
            try
            {
                if (file != null)
                {
                    if (file.ContentLength > 0 || file != null)
                    {
                        string _FILENAME = "[DOC_SIO]_" + Session["TOKEN_MOBILE"].ToString();
                        string _EXT = Path.GetExtension(file.FileName);
                        string _FINALNAME = _FILENAME + _EXT;
                        string _PATH = System.Configuration.ConfigurationManager.AppSettings["ERECRUITMENT_UPLOAD_SIO"].ToString() + "\\" + _FINALNAME;
                        if (System.IO.File.Exists(_PATH))
                        {
                            System.IO.File.Delete(_PATH);
                        }
                        file.SaveAs(_PATH);
                        Session["TEMP_DOC_SIO_FILE"] = _PATH;
                        return Json(new { Result = 1, Message = "Success" });
                    }
                    else
                    {
                        Session["TEMP_DOC_SIO_FILE"] = "";
                        return Json(new { Result = 0, Message = "NO DOCUMENT ATTACHED" });
                    }
                }
                else
                {
                    Session["TEMP_DOC_SIO_FILE"] = "";
                    return Json(new { Result = 1, Message = "Failed" });
                }
            }
            catch (Exception msg)
            {
                return Json(new { Result = 0, Message = msg.Message.ToString() });
            }
        }
        public JsonResult UPLOAD_REPORT(HttpPostedFileBase file, string UNIQUEID)
        {
            try
            {
                if (file != null)
                {
                    if (file.ContentLength > 0 || file != null)
                    {
                        string _FILENAME = "[DOC_REPORT]_" + Session["TOKEN_MOBILE"].ToString();
                        string _EXT = Path.GetExtension(file.FileName);
                        string _FINALNAME = _FILENAME + _EXT;
                        //string _PATH = Server.MapPath("~/ERECRUITMENT/ERECRUITMENT_UPLOAD_REPORT") + "\\" + _FINALNAME;
                        string _PATH = System.Configuration.ConfigurationManager.AppSettings["ERECRUITMENT_UPLOAD_REPORT"].ToString() + "\\" + _FINALNAME;
                        if (System.IO.File.Exists(_PATH))
                        {
                            System.IO.File.Delete(_PATH);
                        }
                        file.SaveAs(_PATH);
                        Session["TEMP_DOC_REPORT_FILE"] = _PATH;
                        return Json(new { Result = 1, Message = "Success" });
                    }
                    else
                    {
                        Session["TEMP_DOC_REPORT_FILE"] = "";
                        return Json(new { Result = 0, Message = "Failed" });
                    }
                }
                else
                {
                    Session["TEMP_DOC_REPORT_FILE"] = "";
                    return Json(new { Result = 1, Message = "Failed" });
                }
            }
            catch (Exception msg)
            {
                return Json(new { Result = 0, Message = msg.Message.ToString() });
            }
        }

        public JsonResult UPLOAD_BUKU_NIKAH(HttpPostedFileBase file)
        {
            try
            {
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        string _FILENAME = "[BNIKAH]_" + Session["TOKEN_MOBILE"].ToString();
                        string _EXT = Path.GetExtension(file.FileName);
                        string _FINALNAME = _FILENAME + _EXT;
                        string _PATH = System.Configuration.ConfigurationManager.AppSettings["ERECRUITMENT_UPLOAD_BUKUNIKAH"].ToString() + "\\" + _FINALNAME;
                        if (System.IO.File.Exists(_PATH))
                        {
                            System.IO.File.Delete(_PATH);
                        }
                        file.SaveAs(_PATH);
                        Session["TEMP_BKNIKAH_FILE"] = _PATH;
                        return Json(new { Result = 1, Message = _PATH });
                    }
                    else
                    {
                        return Json(new { Result = 0, Message = "Failed" });
                    }
                }
                else
                {
                    return Json(new { Result = 0, Message = "Failed" });
                }
            }
            catch (Exception msg)
            {
                return Json(new { Result = 0, Message = msg.Message.ToString() });
            }
        }
        public JsonResult UPLOAD_AKTA_ANAK(HttpPostedFileBase file)
        {
            try
            {
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                        var stringChars = new char[4];
                        var random = new Random();
                        for (int i = 0; i < stringChars.Length; i++)
                        {
                            stringChars[i] = chars[random.Next(chars.Length)];
                        }
                        var randomkey = new String(stringChars);

                        string _FILENAME = "[AKTA_ANAK]_" + Session["TOKEN_MOBILE"].ToString();
                        string _EXT = Path.GetExtension(file.FileName);
                        string _FINALNAME = _FILENAME + "-" + randomkey + _EXT;
                        string _PATH = System.Configuration.ConfigurationManager.AppSettings["ERECRUITMENT_UPLOAD_AKTALAHIR_ANAK"].ToString() + "\\" + _FINALNAME;
                        if (System.IO.File.Exists(_PATH))
                        {
                            System.IO.File.Delete(_PATH);
                        }
                        file.SaveAs(_PATH);
                        Session["TEMP_AKTA_ANAK_FILE"] = _PATH;
                        return Json(new { Result = true, Message = _PATH });
                    }
                    else
                    {
                        return Json(new { Result = false, Message = "-" });
                    }
                }
                else
                {
                    return Json(new { Result = false, Message = "-" });
                }
            }
            catch (Exception msg)
            {
                return Json(new { Result = false, Message = msg.Message.ToString() });
            }
        }
    }
}