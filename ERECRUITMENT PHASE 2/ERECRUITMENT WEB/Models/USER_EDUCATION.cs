using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERECRUITMENT_WEB.Models
{
    public class USER_EDUCATION
    {
        public string BATCH_EMP { get; set; }
        public string LAST_EDU { get; set; }
        public string SCHOOL_NAME { get; set; }
        public string SCHOOL_MAJOR { get; set; }
        public string SCHOOL_FACULTY { get; set; }
        public string GRADUATE_YEAR { get; set; }
        public string GRADUATE_PLACE { get; set; }

        public string GRADUATE_COUNTRY { get; set; }
        public string GRADUATE_DISTRICT { get; set; }
        public string GRADUATE_CITY { get; set; }

        public string AVG_SCORE { get; set; }
        public string CERT_NO { get; set; }
        public string PHOTO_CERT_F { get; set; }
        public string PHOTO_CERT_B { get; set; }
        public bool HOLD_WILLINGLY { get; set; }
    }
}