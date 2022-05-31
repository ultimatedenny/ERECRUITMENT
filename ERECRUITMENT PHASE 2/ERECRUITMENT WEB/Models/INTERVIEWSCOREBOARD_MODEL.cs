using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERECRUITMENT_WEB.Models
{
    public class INTERVIEWSCOREBOARD_MODEL
    {
        public string BATCHNO { get; set; }
        public string TOTALINVITATION { get; set; }
        public string TOTALATTENDANCE { get; set; }
        public string FROM { get; set; }
        public string STATUS { get; set; }
        public string UNTIL { get; set; }
        public string CATEGORY { get; set; }
        public string SUBCATEGORY { get; set; }
    }
    public class RESPONSE_INTERVIEWSCOREBOARD_MODEL
    {
        public bool RESULT { get; set; }
        public string MESSAGE { get; set; }
        public List<INTERVIEWSCOREBOARD_MODEL> DATAS { get; set; }
    }



    /////////////////////////////////////////////////////
    /////////////////////////////////////////////////////


    public class INTERVIEWSCOREBOARD_DETAIL_MODEL
    {
        public string NAME_EMP { get; set; }
        public string BATCH_EMP { get; set; }
        public string GANDER { get; set; }
        public string NIK { get; set; }
        public string PHONE { get; set; }
        public string JAFORM { get; set; }
        public string PREVYEAR { get; set; }
        public string ATTN_EMP { get; set; }
        public string WRTN_TST { get; set; }
        public string PRTC_TST { get; set; }
        public string INTR_TST { get; set; }
        public string MDCL_TST { get; set; }
        public string STATUSEMP { get; set; }
    }
    public class RESPONSE_INTERVIEWSCOREBOARD_DETAIL_MODEL
    {
        public bool RESULT { get; set; }
        public string MESSAGE { get; set; }
        public List<INTERVIEWSCOREBOARD_DETAIL_MODEL> DATAS { get; set; }
    }
}