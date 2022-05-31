using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERECRUITMENT_WEB.Models
{
    public class USER_PROFILE
    {
        public string BATCH_EMP { get; set; }
        public string NAME_EMP { get; set; }
        public string NIK { get; set; }
        public bool EXPIRE_TYPE { get; set; }
        public string EXPIRE_DATE { get; set; }
        public string RACE { get; set; }
        public string RELIGION { get; set; }
        public string PHONE { get; set; }
        public string EMAIL { get; set; }
        public string WHATSAPP { get; set; }
        public string TELEGRAM { get; set; }
        public string GANDER { get; set; }
        public string MARITAL { get; set; }
        public string AGE { get; set; }
        public string ADDRESS { get; set; }
        public string BLOK { get; set; }
        public string NOMOR { get; set; }
        public string LEFT_HANDED { get; set; }
        public string HEIGHT { get; set; }
        public string WEIGHT { get; set; }
        public string LINKEDIN { get; set; }
        public string RT { get; set; }
        public string RW { get; set; }
        public string KELURAHAN { get; set; }
        public string KECAMATAN { get; set; }
        public string PHOTO { get; set; }
        public string KTP_PHOTO { get; set; }
        public string HOME_STATUS { get; set; }
        public string BIRTHDATE { get; set; }
        public string BIRTHPLACE{ get; set; }
    }
}