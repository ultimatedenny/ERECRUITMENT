using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERECRUITMENT_WEB.Models
{
    public class USER_HEALTH
    {
        public string BATCH_EMP { get; set; }
        public bool LIQUID_TINNER { get; set; }
        public bool STOMACH_ACID { get; set; }
        public bool PNEUMONIA { get; set; }
        public bool LUNG_DISEASE { get; set; }
        public bool ASTHMA { get; set; }
        public bool FRACTURE { get; set; }
        public bool SURGERY { get; set; }
        public string SURGERY_DESC { get; set; }
    }
    public class USER_REPORT
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