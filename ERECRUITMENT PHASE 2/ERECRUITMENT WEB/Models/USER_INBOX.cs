using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERECRUITMENT_WEB.Models
{
    public class USER_INBOX
    {
        public string BATCH_NO { get; set; }
        public string BATCH_EMP { get; set; }
        public string NAME_EMP { get; set; }
        public string REPORT_ID { get; set; }
        public string REPORT_CATE { get; set; }

        public string REPORT_DESC { get; set; }
        public string REPORT_IMG { get; set; }
        public string REPORT_STATUS { get; set; }
        public string REPORT_ACTION { get; set; }
        public string UPDT_TIME { get; set; }
        public string UPDT_USER { get; set; }

    }
}