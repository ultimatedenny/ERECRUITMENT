using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERECRUITMENT_WEB.Models
{
    public class ResponseModel
    {
        public bool Result { get; set; }
        public string Message { get; set; }
    }

    public class USERINFO
    {
        public string USEID { get; set; }
        public string USENAM { get; set; }
        public bool ISWINDOWS { get; set; }
        public string BUSFUNC { get; set; }
        public string CREATEDBY { get; set; }
        public string CREATEDON { get; set; }
    }
    public class USERGROUP
    {
        public string GROUP { get; set; }
        public string DESCRIPTION { get; set; }
        public string CREATEDBY { get; set; }
        public string CREATEDON { get; set; }
        public string UPDATEDBY { get; set; }
        public string UPDATEDON { get; set; }
    }

    public class RESPONSE
    {
        public bool RESULT { get; set; }
        public string MESSAGE { get; set; }
        public List<USERINFO> DATAS { get; set; }
    }
    public class RESPONSE2
    {
        public bool RESULT { get; set; }
        public string MESSAGE { get; set; }
    }
    public class RESPONSE3
    {
        public bool RESULT { get; set; }
        public string MESSAGE { get; set; }
        public List<USER_FAMILY> DATAS { get; set; }
    }
    public class RESPONSE_LOGIN_MOBILE
    {
        public bool RESULT { get; set; }
        public string MESSAGE { get; set; }
        public List<LOGIN_INFO_MOBILE> LOGIN_INFO_MOBILE { get; set; }
    }
    public class LOGIN_INFO_MOBILE
    {
        public string TOKEN { get; set; }
        public DateTime EXPIRE { get; set; }
    }




    public class ROOT
    {
        public RESPONSE RESPONSE { get; set; }
    }
}