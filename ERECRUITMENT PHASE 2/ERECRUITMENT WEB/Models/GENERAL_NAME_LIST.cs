using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERECRUITMENT_WEB.Models
{
    public class GENERAL_NAME_LIST
    {
        public string BATCH_NO { get; set; }
        public string BATCH_EMP { get; set; }
        public string NAME_EMP { get; set; }
        public string GANDER { get; set; }
        public string NO_EMP { get; set; }
        public string FORM { get; set; }
        public string DOJ { get; set; }
        public string DOE { get; set; }
        public string TAX { get; set; }
        public string TIER { get; set; }
        public string DEPT { get; set; }
        public string STATUS { get; set; }
        public string COMPLETED_ON { get; set; }
        public string SEND_ON { get; set; }
        public string VERIFY_ON { get; set; }
    }

    public class REPORT_LIST
    {
        public string BATCH_NO { get; set; }
        public string BATCH_EMP { get; set; }
        public string NAME_EMP { get; set; }
        public string GANDER { get; set; }
        public string NIK { get; set; }
        public string DOJ { get; set; }
        public string DOE { get; set; }
        public string TAHUN { get; set; }
        public string BULAN { get; set; }
        public string HARI { get; set; }
        public string SERVICE_YEAR { get; set; }
        public string DEPT { get; set; }
        public string STATUS { get; set; }
    }



    public class REPORT_PARTICULAR_FORM
    {
        public string EMP_NAME { get; set; }
        public string EMP_GANDER { get; set; }
        public string EM_BIRTHPLACE { get; set; }
        public string EMP_BIRTHDATE { get; set; }
        public string EMP_ADDRESS { get; set; }
        public string EMP_RT { get; set; }
        public string EMP_RW { get; set; }
        public string EMP_KELURAHAN { get; set; }
        public string EMP_KECAMATAN { get; set; }
        public string EMP_RACE { get; set; }
        public string EMP_MARITAL { get; set; }
        public string EMP_HEIGHT { get; set; }
        public string EMP_WEIGHT { get; set; }
        public string EMP_EMAIL { get; set; }
        public string EMP_PHONE { get; set; }
        public string EMP_TELEGRAM { get; set; }
        public string EMP_WHATSAPP { get; set; }
        public string EMP_RELIGION { get; set; }


        public string EMP_LAST_EDU { get; set; }
        public string EMP_SCHOOL_NAME { get; set; }
        public string EMP_SCHOOL_MAJOR { get; set; }
        public string EMP_CERT_NO { get; set; }
        public string EMP_GRAD_YEAR { get; set; }
        public string EMP_GRAD_COUN { get; set; }
        public string EMP_WORK_EXP { get; set; }

        public string EMP_REF_NAME { get; set; }
        public string EMP_REF_COMPANY { get; set; }
        public string EMP_REF_TITLE { get; set; }
        public string EMP_REF_MOBILE { get; set; }
        public string EMP_REF_EMAIL { get; set; }

        public string EMP_EYECHECK { get; set; }
        public string EMP_EYEVALUE { get; set; }
        public string EMP_SMOKIN { get; set; }
        public string EMP_CRIME { get; set; }
        public string EMP_MENTAL_DISEASE { get; set; }

        public string EMP_DEPARTMENT { get; set; }
        public string EMP_POSITION { get; set; }
        public string EMP_PERIOD { get; set; }
        public string EMP_TIER { get; set; }
        public string EMP_DOJ { get; set; }
        public string EMP_SALARY { get; set; }
        public string EMP_ACKNOWLEDGE { get; set; }

        public List<REPORT_PARTICULAR_FORM_FAMILY> FAMILY { get; set; }
        public List<REPORT_PARTICULAR_FORM_WORK_EXP> WORK_EXP { get; set; }
    }
    public class REPORT_PARTICULAR_FORM_FAMILY
    {
        public string NAMA_KELUARGA { get; set; }
        public string HUBUNGAN_KELUARGA { get; set; }
        public string UMUR_KELUARGA { get; set; }
        public string PEKERJAAN_KELUARGA { get; set; }
    }
    public class REPORT_PARTICULAR_FORM_WORK_EXP
    {
        public string COMPANY_NAME { get; set; }
        public string POSITION { get; set; }
        public string START_YEAR { get; set; }
        public string END_YEAR { get; set; }
        public string REASON_LEAVE { get; set; }
    }
}