using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERECRUITMENT_WEB.Models
{
    public class USER_WORKEXP
    {
        public string BATCH_EMP { get; set; }
        public bool ISEXPERIENCED { get; set; }
        public string COMPANY_NAME { get; set; }
        public string POSITION { get; set; }
        public string START_YEAR { get; set; }
        public string END_YEAR { get; set; }
        public string REASON_LEAVE { get; set; }
        public string CERT_PHOTO { get; set; }
    }
}