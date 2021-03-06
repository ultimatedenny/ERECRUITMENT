using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERECRUITMENT_WEB.Class
{
    public static class Cookies
    {
        public static string GetUseID()
        {
            return GetCookies("UseID");
        }
        public static string GetBusFunc()
        {
            return GetCookies("BusFunc");
        }
        public static string GetCookies(string Key)
        {
            var Value = HttpContext.Current.Request.Cookies[Key] != null
                ? HttpContext.Current.Request.Cookies[Key].Value.Decrypt()
                : null;
            return Value;
        }
        public static void PostCookies(string Key, string Value)
        {
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(Key, Value.Encrypt()));
        }
        public static string GetCookiesWithoutEnc(string Key)
        {
            var Value = HttpContext.Current.Request.Cookies[Key] != null
                ? HttpContext.Current.Request.Cookies[Key].Value
                : null;
            return Value;
        }
        public static void PostCookiesWithoutEnc(string Key, string Value)
        {
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(Key, Value));
        }
        public static void DeleteCookies(string Key)
        {
            HttpContext.Current.Response.Cookies[Key].Expires = DateTime.Now.AddDays(-1);
        }
    }
    public static class Sessions
    {
        public static string GetUseID()
        {
            return (HttpContext.Current.Session["USEID"] != null ? HttpContext.Current.Session["USEID"].ToString() : null);
        }
        public static string GetUserName()
        {
            return (HttpContext.Current.Session["USENAM"] != null ? HttpContext.Current.Session["USENAM"].ToString() : null);
        }
        public static string GetBusFunc()
        {
            return (HttpContext.Current.Session["BUSFUNC"] != null ? HttpContext.Current.Session["BUSFUNC"].ToString() : null);
        }
        public static string GetUseLev()
        {
            return (HttpContext.Current.Session["UseLev"] != null ? HttpContext.Current.Session["UseLev"].ToString() : null);
        }
        public static string GetApprovalGroup()
        {
            return (HttpContext.Current.Session["ApprovalGroup"] != null ? HttpContext.Current.Session["ApprovalGroup"].ToString() : null);
        }
        public static string GetUsePlant()
        {
            return (HttpContext.Current.Session["UsePlant"] != null ? HttpContext.Current.Session["UsePlant"].ToString() : null);
        }
    }
}