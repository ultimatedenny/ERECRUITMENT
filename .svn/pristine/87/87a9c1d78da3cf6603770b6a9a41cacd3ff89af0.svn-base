using ERECRUITMENT_WEB.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ERECRUITMENT_WEB.Class
{
    public class Report
    {
        DataTable DATATABLE;
        string SQL = "";
        public string EREC_CON = ConfigurationManager.ConnectionStrings["EREC_CON"].ToString();

        public List<REPORT_LIST> WEB_GET_TABLE_REPORT(string BATCHNO, string STATUS, string KEYWORD)
        {
            try
            {
                SQL = @"EXEC [SP_WEB_REPORT_TABLE]'" + BATCHNO + "','" + STATUS + "','" + KEYWORD + "'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA = (from row in DATATABLE.AsEnumerable()
                            select new REPORT_LIST()
                            {

                                BATCH_NO = (row["BATCH_NO"].ToString() == null) ? "" : row["BATCH_NO"].ToString(),
                                BATCH_EMP = (row["BATCH_EMP"].ToString() == null) ? "" : row["BATCH_EMP"].ToString(),
                                NAME_EMP = (row["NAME_EMP"].ToString() == null) ? "" : row["NAME_EMP"].ToString(),
                                GANDER = (row["GANDER"].ToString() == null) ? "" : row["GANDER"].ToString(),
                                NIK = (row["NIK"].ToString() == null) ? "" : row["NIK"].ToString(),
                                DOJ = (row["DOJ"].ToString() == null) ? "" : row["DOJ"].ToString(),
                                DOE = (row["DOE"].ToString() == null) ? "" : row["DOE"].ToString(),
                                TAHUN = (row["TAHUN"].ToString() == null) ? "" : row["TAHUN"].ToString(),
                                BULAN = (row["BULAN"].ToString() == null) ? "" : row["BULAN"].ToString(),
                                HARI = (row["HARI"].ToString() == null) ? "" : row["HARI"].ToString(),
                                SERVICE_YEAR = (row["SERVICE_YEAR"].ToString() == null) ? "" : row["SERVICE_YEAR"].ToString(),
                                DEPT = (row["DEPT"].ToString() == null) ? "" : row["DEPT"].ToString(),
                                STATUS = (row["STATUS"].ToString() == null) ? "" : row["STATUS"].ToString(),
                            }).ToList();

                return DATA;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public List<REPORT_PARTICULAR_FORM> WEB_GETREPORT_FORM1(string BATCH_EMP)
        {
            try
            {
                var DATASET = new DataSet();
                SQL = @"EXEC [SP_WEB_GETREPORT_FORM1]'" + BATCH_EMP + "'";
                //SQL = @"EXEC [SP_WEB_GET_CANDIDATE_DETAILS] 'ER-2201-099-001'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATASET   = s.ExecDSQuery(EREC_CON, SQL, null, null, false);
                }
                var xx = DATASET;
                var DATA0 = (from row in DATASET.Tables[0].AsEnumerable()
                             select new REPORT_PARTICULAR_FORM()
                            {

                                 EMP_NAME = (row["EMP_NAME"].ToString() == null) ? "-" : row["EMP_NAME"].ToString(),
                                 EMP_GANDER = (row["EMP_GANDER"].ToString() == null) ? "-" : row["EMP_GANDER"].ToString(),
                                 EM_BIRTHPLACE = (row["EM_BIRTHPLACE"].ToString() == null) ? "-" : row["EM_BIRTHPLACE"].ToString(),
                                 EMP_BIRTHDATE = (row["EMP_BIRTHDATE"].ToString() == null) ? "-" : row["EMP_BIRTHDATE"].ToString(),
                                 EMP_ADDRESS = (row["EMP_ADDRESS"].ToString() == null) ? "-" : row["EMP_ADDRESS"].ToString(),
                                 EMP_RT = (row["EMP_RT"].ToString() == null) ? "-" : row["EMP_RT"].ToString(),
                                 EMP_RW = (row["EMP_RW"].ToString() == null) ? "-" : row["EMP_RW"].ToString(),
                                 EMP_KELURAHAN = (row["EMP_KELURAHAN"].ToString() == null) ? "-" : row["EMP_KELURAHAN"].ToString(),
                                 EMP_KECAMATAN = (row["EMP_KECAMATAN"].ToString() == null) ? "-" : row["EMP_KECAMATAN"].ToString(),
                                 EMP_RACE = (row["EMP_RACE"].ToString() == null) ? "-" : row["EMP_RACE"].ToString(),
                                 EMP_MARITAL = (row["EMP_MARITAL"].ToString() == null) ? "" : row["EMP_MARITAL"].ToString(),
                                 EMP_HEIGHT = (row["EMP_HEIGHT"].ToString() == null) ? "-" : row["EMP_HEIGHT"].ToString(),
                                 EMP_WEIGHT = (row["EMP_WEIGHT"].ToString() == null) ? "-" : row["EMP_WEIGHT"].ToString(),
                                 EMP_RELIGION = (row["EMP_RELIGION"].ToString() == null) ? "-" : row["EMP_RELIGION"].ToString(),
                                 EMP_EMAIL = (row["EMP_EMAIL"].ToString() == null) ? "-" : row["EMP_EMAIL"].ToString(),
                                 EMP_PHONE = (row["EMP_PHONE"].ToString() == null) ? "-" : row["EMP_PHONE"].ToString(),
                                 EMP_TELEGRAM = (row["EMP_TELEGRAM"].ToString() == null) ? "-" : row["EMP_TELEGRAM"].ToString(),
                                 EMP_WHATSAPP = (row["EMP_WHATSAPP"].ToString() == null) ? "-" : row["EMP_WHATSAPP"].ToString(),

                                 EMP_LAST_EDU = (row["EMP_LAST_EDU"].ToString() == null) ? "-" : row["EMP_LAST_EDU"].ToString(),
                                 EMP_SCHOOL_NAME = (row["EMP_SCHOOL_NAME"].ToString() == null) ? "-" : row["EMP_SCHOOL_NAME"].ToString(),
                                 EMP_SCHOOL_MAJOR = (row["EMP_SCHOOL_MAJOR"].ToString() == null) ? "-" : row["EMP_SCHOOL_MAJOR"].ToString(),
                                 EMP_CERT_NO = (row["EMP_CERT_NO"].ToString() == null) ? "-" : row["EMP_CERT_NO"].ToString(),
                                 EMP_GRAD_YEAR = (row["EMP_GRAD_YEAR"].ToString() == null) ? "-" : row["EMP_GRAD_YEAR"].ToString(),
                                 EMP_GRAD_COUN = (row["EMP_GRAD_COUN"].ToString() == null) ? "-" : row["EMP_GRAD_COUN"].ToString(),
                                 EMP_WORK_EXP = (row["EMP_WORK_EXP"].ToString() == "True") ? "Yes" : "No",

                                 EMP_REF_NAME = (row["EMP_REF_NAME"].ToString() == null) ? "-" : row["EMP_REF_NAME"].ToString(),
                                 EMP_REF_COMPANY = (row["EMP_REF_COMPANY"].ToString() == null) ? "-" : row["EMP_REF_COMPANY"].ToString(),
                                 EMP_REF_TITLE = (row["EMP_REF_TITLE"].ToString() == null) ? "-" : row["EMP_REF_TITLE"].ToString(),
                                 EMP_REF_MOBILE = (row["EMP_REF_MOBILE"].ToString() == null) ? "-" : row["EMP_REF_MOBILE"].ToString(),
                                 EMP_REF_EMAIL = (row["EMP_REF_EMAIL"].ToString() == null) ? "-" : row["EMP_REF_EMAIL"].ToString(),

                                 EMP_EYECHECK = (row["EMP_EYECHECK"].ToString() == "True") ? "Yes" : "No",
                                 EMP_EYEVALUE = (row["EMP_EYEVALUE"].ToString() == null) ? "-" : row["EMP_EYEVALUE"].ToString(),
                                 EMP_SMOKIN = (row["EMP_SMOKIN"].ToString() == "True") ? "Yes" : "No",
                                 EMP_CRIME = (row["EMP_CRIME"].ToString() == "True") ? "Yes" : "No",
                                 EMP_MENTAL_DISEASE = (row["EMP_MENTAL_DISEASE"].ToString() == "True") ? "Yes" : "No",

                                 EMP_DEPARTMENT = (row["EMP_DEPARTMENT"].ToString() == null) ? "-" : row["EMP_DEPARTMENT"].ToString(),
                                 EMP_POSITION = (row["EMP_POSITION"].ToString() == null) ? "-" : row["EMP_POSITION"].ToString(),
                                 EMP_PERIOD = (row["EMP_PERIOD"].ToString() == null) ? "-" : row["EMP_PERIOD"].ToString(),
                                 EMP_TIER = (row["EMP_TIER"].ToString() == null) ? "-" : row["EMP_TIER"].ToString(),
                                 EMP_DOJ = (row["EMP_DOJ"].ToString() == null) ? "-" : row["EMP_DOJ"].ToString(),

                                 EMP_SALARY = (row["EMP_SALARY"].ToString() == null) ? "-" : row["EMP_SALARY"].ToString(),
                                 EMP_ACKNOWLEDGE = (row["EMP_ACKNOWLEDGE"].ToString() == null) ? "-" : row["EMP_ACKNOWLEDGE"].ToString()

                             }).ToList();

                var DATA1 = (from row in DATASET.Tables[1].AsEnumerable()
                             select new REPORT_PARTICULAR_FORM_FAMILY()
                             {
                                 NAMA_KELUARGA = (row["NAMA_KELUARGA"].ToString() == null) ? "" : row["NAMA_KELUARGA"].ToString(),
                                 HUBUNGAN_KELUARGA = (row["HUBUNGAN_KELUARGA"].ToString() == null) ? "" : row["HUBUNGAN_KELUARGA"].ToString(),
                                 UMUR_KELUARGA = (row["UMUR_KELUARGA"].ToString() == null) ? "" : row["UMUR_KELUARGA"].ToString(),
                                 PEKERJAAN_KELUARGA = (row["PEKERJAAN_KELUARGA"].ToString() == null) ? "" : row["PEKERJAAN_KELUARGA"].ToString(),
                             }).ToList();

                var DATA2 = (from row in DATASET.Tables[2].AsEnumerable()
                             select new REPORT_PARTICULAR_FORM_WORK_EXP()
                             {
                                 COMPANY_NAME = (row["COMPANY_NAME"].ToString() == null) ? "" : row["COMPANY_NAME"].ToString(),
                                 POSITION = (row["POSITION"].ToString() == null) ? "" : row["POSITION"].ToString(),
                                 START_YEAR = (row["START_YEAR"].ToString() == null) ? "" : row["START_YEAR"].ToString(),
                                 END_YEAR = (row["END_YEAR"].ToString() == null) ? "" : row["END_YEAR"].ToString(),
                                 REASON_LEAVE = (row["REASON_LEAVE"].ToString() == null) ? "" : row["REASON_LEAVE"].ToString(),
                             }).ToList();


                var RESULT = (from x in DATA0
                              select new REPORT_PARTICULAR_FORM
                              {
                                  EMP_NAME = x.EMP_NAME,
                                  EMP_GANDER = x.EMP_GANDER,
                                  EM_BIRTHPLACE = x.EM_BIRTHPLACE,
                                  EMP_BIRTHDATE = x.EMP_BIRTHDATE,
                                  EMP_ADDRESS = x.EMP_ADDRESS,
                                  EMP_RT = x.EMP_RT,
                                  EMP_RW = x.EMP_RW,
                                  EMP_KELURAHAN = x.EMP_KELURAHAN,
                                  EMP_KECAMATAN = x.EMP_KECAMATAN,
                                  EMP_RACE = x.EMP_RACE,
                                  EMP_MARITAL = x.EMP_MARITAL,
                                  EMP_HEIGHT = x.EMP_HEIGHT,
                                  EMP_WEIGHT = x.EMP_WEIGHT,
                                  EMP_RELIGION = x.EMP_RELIGION,
                                  EMP_EMAIL = x.EMP_EMAIL,
                                  EMP_PHONE = x.EMP_PHONE,
                                  EMP_TELEGRAM = x.EMP_TELEGRAM,
                                  EMP_WHATSAPP = x.EMP_WHATSAPP,
                                  EMP_LAST_EDU = x.EMP_LAST_EDU,
                                  EMP_SCHOOL_NAME = x.EMP_SCHOOL_NAME,
                                  EMP_SCHOOL_MAJOR = x.EMP_SCHOOL_MAJOR,
                                  EMP_CERT_NO = x.EMP_CERT_NO,
                                  EMP_GRAD_YEAR = x.EMP_GRAD_YEAR,
                                  EMP_GRAD_COUN = x.EMP_GRAD_COUN,
                                  FAMILY = (from y in DATA1
                                            select new REPORT_PARTICULAR_FORM_FAMILY
                                            {
                                                NAMA_KELUARGA = y.NAMA_KELUARGA,
                                                HUBUNGAN_KELUARGA = y.HUBUNGAN_KELUARGA,
                                                UMUR_KELUARGA = y.UMUR_KELUARGA,
                                                PEKERJAAN_KELUARGA = y.PEKERJAAN_KELUARGA.Truncate(34)
                                            }).ToList(),
                                  EMP_WORK_EXP = x.EMP_WORK_EXP,
                                  WORK_EXP = (from y in DATA2
                                              select new REPORT_PARTICULAR_FORM_WORK_EXP
                                              {
                                                  COMPANY_NAME = y.COMPANY_NAME,
                                                  POSITION = y.POSITION,
                                                  START_YEAR = y.START_YEAR,
                                                  END_YEAR = y.END_YEAR,
                                                  REASON_LEAVE = y.REASON_LEAVE
                                              }).ToList(),
                                  EMP_REF_NAME = x.EMP_REF_NAME,
                                  EMP_REF_COMPANY = x.EMP_REF_COMPANY,
                                  EMP_REF_TITLE = x.EMP_REF_TITLE,
                                  EMP_REF_MOBILE = x.EMP_REF_MOBILE,
                                  EMP_REF_EMAIL = x.EMP_REF_EMAIL,

                                  EMP_EYECHECK = x.EMP_EYECHECK,
                                  EMP_EYEVALUE = x.EMP_EYEVALUE,
                                  EMP_SMOKIN = x.EMP_SMOKIN,
                                  EMP_CRIME = x.EMP_CRIME,
                                  EMP_MENTAL_DISEASE = x.EMP_MENTAL_DISEASE,

                                  EMP_DEPARTMENT = x.EMP_DEPARTMENT,
                                  EMP_POSITION = x.EMP_POSITION,
                                  EMP_PERIOD = x.EMP_PERIOD,
                                  EMP_TIER = x.EMP_TIER,
                                  EMP_DOJ = x.EMP_DOJ,
                                  EMP_SALARY = x.EMP_SALARY,
                                  EMP_ACKNOWLEDGE = x.EMP_ACKNOWLEDGE,

                              }).ToList();


                return RESULT;
            }
            catch (Exception msg)
            {
                return null;
            }

        }
        
    }
    public static class StringExtension
    {
        public static string Truncate(this string input, int strLength)
        {
            if (string.IsNullOrEmpty(input)) return input;
            return input.Length <= strLength ? input : input.Substring(0, strLength) + "...";
        }
    }
}