using ERECRUITMENT_WEB.Models;
using ERECRUITMENT_WEB.Class;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERECRUITMENT_WEB.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        Authentication AUTH = new Authentication();

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (Sessions.GetUseID() != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                else
                {
                    var USEID = "";
                    var USENAM = "";
                    var BUSFUNC = "";
                    bool ISWINDOWS;
                    var result = AUTH.SignIn(model.UseId, model.Password);
                    if (result.Result == true)
                    {
                        USEID = result.Data.USEID.ToString();
                        USENAM = result.Data.USENAM.ToString();
                        BUSFUNC = result.Data.BUSFUNC.ToString();
                        ISWINDOWS = result.Data.ISWINDOWS.ToBoolean();

                        TempData["SUCCESSLOGIN"] = "Success Access!- Login - " + DateTime.Now.ToString() + "";
                        Session["USEID"] = USEID;
                        Session["USENAM"] = USENAM;
                        Session["BUSFUNC"] = BUSFUNC;
                        Session["ISWINDOWS"] = ISWINDOWS;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["ERROR"] = result.Message.ToString() + " - " + DateTime.Now.ToString() + "";
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

        public JsonResult RemoveCookies(string Name)
        {
            try
            {
                Cookies.DeleteCookies(Name);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            string[] myCookies = Request.Cookies.AllKeys;
            foreach (string cookie in myCookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }
            return RedirectToAction("Login", "Account");
        }
    }
}





