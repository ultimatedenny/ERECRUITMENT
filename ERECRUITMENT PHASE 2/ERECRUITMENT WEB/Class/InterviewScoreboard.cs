using ERECRUITMENT_WEB.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ERECRUITMENT_WEB.Class
{
    public class InterviewScoreboard
    {
        DataTable DATATABLE;
        string SQL = "";
        public string EREC_CON = ConfigurationManager.ConnectionStrings["EREC_CON"].ToString();
        public List<INTERVIEWSCOREBOARD_MODEL> WEB_GETTABLE_INTERVIEWSCOREBOARD(string BATCHNO, string BATCHCATEGORY, string BATCHSTATUS, string FROM, string TO)
        {
            try
            {
                SQL = @"EXEC [SP_WEB_GETTABLE_INTERVIEWSCOREBOARD] '"+ BATCHNO + "','" + BATCHCATEGORY + "','" + BATCHSTATUS + "','"+ FROM + "','" + TO + "'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new INTERVIEWSCOREBOARD_MODEL()
                             {

                                 BATCHNO            = row["BATCHNO"].ToString() ?? "",
                                 TOTALINVITATION    = row["TOTALINVITATION"].ToString() ?? "",
                                 TOTALATTENDANCE    = (row["TOTALATTENDANCE"].ToString() == null) ? ""  : row["TOTALATTENDANCE"].ToString(),
                                 FROM               = (row["REQUESTDATE"].ToString() == null) ? ""      : Convert.ToDateTime(row["REQUESTDATE"].ToString()).ToString("yyyy-MM-dd") ,
                                 STATUS             = (row["STATUSBATCH"].ToString() == null) ? ""      : row["STATUSBATCH"].ToString(),
                                 UNTIL              = (row["INVITATIONDATE"].ToString() == null) ? ""   : Convert.ToDateTime(row["INVITATIONDATE"].ToString()).ToString("yyyy-MM-dd"),
                                 CATEGORY           = (row["CATEGORY"].ToString() == null) ? ""         : row["CATEGORY"].ToString(),
                                 SUBCATEGORY        = (row["SUBCATEGORY"].ToString() == null) ? ""      : row["SUBCATEGORY"].ToString(),
                             }).ToList();

                return DATA0;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public List<INTERVIEWSCOREBOARD_DETAIL_MODEL> WEB_GETTABLE_INTERVIEWSCOREBOARD_DETAIL(string BATCHNO, string KEYWROD, string STATUS)
        {
            try
            {
                SQL = @"EXEC [SP_WEB_GETTABLE_INTERVIEWSCOREBOARD_DETAIL] '" + BATCHNO + "','"+ KEYWROD + "','" + STATUS + "'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new INTERVIEWSCOREBOARD_DETAIL_MODEL()
                             {

                                 NAME_EMP   = (row["NAME_EMP"].ToString() == null) ? "" : row["NAME_EMP"].ToString(),
                                 BATCH_EMP  = (row["BATCH_EMP"].ToString() == null) ? "" : row["BATCH_EMP"].ToString(),
                                 GANDER     = (row["GANDER"].ToString() == null) ? "" : row["GANDER"].ToString(),
                                 NIK        = (row["NIK"].ToString() == null) ? "" : row["NIK"].ToString(),
                                 PHONE      = (row["PHONE"].ToString() == null) ? "" : row["PHONE"].ToString(),
                                 JAFORM     = (row["JAFORM"].ToString() == null) ? "" : row["JAFORM"].ToString(),
                                 PREVYEAR   = (row["PREVYEAR"].ToString() == null) ? "" : row["PREVYEAR"].ToString(),
                                 ATTN_EMP   = (row["ATTN_EMP"].ToString() == null) ? "" : row["ATTN_EMP"].ToString(),
                                 WRTN_TST   = (row["WRTN_TST"].ToString() == null) ? "" : row["WRTN_TST"].ToString(),
                                 PRTC_TST   = (row["PRTC_TST"].ToString() == null) ? "" : row["PRTC_TST"].ToString(),
                                 INTR_TST   = (row["INTR_TST"].ToString() == null) ? "" : row["INTR_TST"].ToString(),
                                 MDCL_TST   = (row["MDCL_TST"].ToString() == null) ? "" : row["MDCL_TST"].ToString(),
                                 STATUSEMP  = (row["STATUSEMP"].ToString() == null) ? "" : row["STATUSEMP"].ToString(),
                             }).ToList();

                return DATA0;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public List<CANDIDATE_DETAILS> WEB_GET_CANDIDATE_DETAIL(string BATCHNO)
        {
            try
            {
                var DATASET = new DataSet();
                SQL = @"EXEC [SP_WEB_GET_CANDIDATE_DETAILS] '" + BATCHNO + "'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    //DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                    DATASET   = s.ExecDSQuery(EREC_CON, SQL, null, null, false);
                }
                string olds = "\\\\172.18.100.125\\hrd_common\\20. RECRUITMENT\\40. ERECRUITMENT\\";
                string news = "\\ERECRUITMENT2\\ERECRUITMENT\\";
                var DATA1 = (from row in DATASET.Tables[1].AsEnumerable()
                             select new CANDIDATE_DETAILS_WORK_EXP()
                             {
                                 COMPANY_NAME = (row["COMPANY_NAME"].ToString() == null) ? "" : row["COMPANY_NAME"].ToString(),
                                 POSITION = (row["POSITION"].ToString() == null) ? "" : row["POSITION"].ToString(),
                                 START_YEAR = (row["START_YEAR"].ToString() == null) ? "" : row["START_YEAR"].ToString(),
                                 END_YEAR = (row["END_YEAR"].ToString() == null) ? "" : row["END_YEAR"].ToString(),
                                 REASON_LEAVE = (row["REASON_LEAVE"].ToString() == null) ? "" : row["REASON_LEAVE"].ToString(),
                                 CERT_PHOTO = (row["CERT_PHOTO"].ToString().Replace(olds, news) == null) ? "" : row["CERT_PHOTO"].ToString().Replace(olds, news),
                             }).ToList();

                var DATA2 = (from row in DATASET.Tables[2].AsEnumerable()
                             select new CANDIDATE_DETAILS_SIBLINGS()
                             {
                                 ID = (row["ID"].ToString() == null) ? "" : row["ID"].ToString(),
                                 NAME = (row["NAME"].ToString() == null) ? "" : row["NAME"].ToString(),
                                 AGE = (row["AGE"].ToString() == null) ? "" : row["AGE"].ToString(),
                                 JOB = (row["JOB"].ToString() == null) ? "" : row["JOB"].ToString(),
                             }).ToList();

                var DATA3 = (from row in DATASET.Tables[3].AsEnumerable()
                             select new CANDIDATE_DETAILS_LANGUAGE()
                             {
                                 LANGUAGE_ID = (row["LANGUAGE_ID"].ToString() == null) ? "" : row["LANGUAGE_ID"].ToString(),
                                 LANGUAGE = (row["LANGUAGE"].ToString() == null) ? "" : row["LANGUAGE"].ToString(),
                                 LEVEL = (row["LEVEL"].ToString() == null) ? "" : row["LEVEL"].ToString(),
                                 
                             }).ToList();

                var DATA4 = (from row in DATASET.Tables[4].AsEnumerable()
                             select new CANDIDATE_DETAILS_CHILD()
                             {
                                 CHILD_NAME = (row["CHILD_NAME"].ToString() == null) ? "" : row["CHILD_NAME"].ToString(),
                                 CHILD_NIK = (row["CHILD_NIK"].ToString() == null) ? "" : row["CHILD_NIK"].ToString(),
                                 CHILD_BIRTH_DATE = (row["CHILD_BIRTH_DATE"].ToString() == null) ? "" : row["CHILD_BIRTH_DATE"].ToString(),
                                 CHILD_BIRTH_PLACE = (row["CHILD_BIRTH_PLACE"].ToString() == null) ? "" : row["CHILD_BIRTH_PLACE"].ToString(),

                             }).ToList();

                var DATA0 = (from row in DATASET.Tables[0].AsEnumerable()
                             select new CANDIDATE_DETAILS()
                             {
                                 
                                 EMP_NAME = (row["EMP_NAME"].ToString() == null) ? "" : row["EMP_NAME"].ToString(),
                                 EMP_NIK = (row["EMP_NIK"].ToString() == null) ? "" : row["EMP_NIK"].ToString(),
                                 EMP_GANDER = (row["EMP_GANDER"].ToString() == null) ? "" : row["EMP_GANDER"].ToString(),
                                 EMP_MARITAL = (row["EMP_MARITAL"].ToString() == null) ? "" : row["EMP_MARITAL"].ToString(),
                                 EMP_RELIGION = (row["EMP_RELIGION"].ToString() == null) ? "" : row["EMP_RELIGION"].ToString(),
                                 EMP_HEIGHT = (row["EMP_HEIGHT"].ToString() == null) ? "" : row["EMP_HEIGHT"].ToString(),
                                 EMP_WEIGHT = (row["EMP_WEIGHT"].ToString() == null) ? "" : row["EMP_WEIGHT"].ToString(),
                                 EMP_BIRTHPLACE = (row["EMP_BIRTHPLACE"].ToString() == "") ? "" : row["EMP_BIRTHPLACE"].ToString(),
                                 EMP_BIRTHDATE = (row["EMP_BIRTHDATE"].ToString() == "") ? "" : row["EMP_BIRTHDATE"].ToString(),
                                 EMP_RACE = (row["EMP_RACE"].ToString() == null) ? "" : row["EMP_RACE"].ToString(),
                                 EMP_MOBILE = (row["EMP_MOBILE"].ToString() == null) ? "" : row["EMP_MOBILE"].ToString(),
                                 EMP_TELEGRAM = (row["EMP_TELEGRAM"].ToString() == null) ? "" : row["EMP_TELEGRAM"].ToString(),
                                 EMP_WHATSAPP = (row["EMP_WHATSAPP"].ToString() == null) ? "" : row["EMP_WHATSAPP"].ToString(),
                                 EMP_PASFOTO = (row["EMP_PASFOTO"].ToString().Replace(olds, news) == null) ? "" : row["EMP_PASFOTO"].ToString().Replace(olds, news),
                                 EMP_KTPFOTO = (row["EMP_KTPFOTO"].ToString().Replace(olds, news) == null) ? "" : row["EMP_KTPFOTO"].ToString().Replace(olds, news),

                                 EMP_EMAIL = (row["EMP_EMAIL"].ToString() == null) ? "" : row["EMP_EMAIL"].ToString(),
                                 EMP_LINKEDIN = (row["EMP_LINKEDIN"].ToString() == null) ? "" : row["EMP_LINKEDIN"].ToString(),

                                 EMP_ADDRESS = (row["EMP_ADDRESS"].ToString() == null) ? "" : row["EMP_ADDRESS"].ToString(),
                                 EMP_BLOK = (row["EMP_BLOK"].ToString() == null) ? "" : row["EMP_BLOK"].ToString(),
                                 EMP_NOMOR = (row["EMP_NOMOR"].ToString() == null) ? "" : row["EMP_NOMOR"].ToString(),
                                 EMP_RT = (row["EMP_RT"].ToString() == null) ? "" : row["EMP_RT"].ToString(),
                                 EMP_RW = (row["EMP_RW"].ToString() == null) ? "" : row["EMP_RW"].ToString(),

                                 EMP_PANTS_SIZE = (row["EMP_PANTS_SIZE"].ToString() == null) ? "" : row["EMP_PANTS_SIZE"].ToString(),
                                 EMP_SHIRT_SIZE = (row["EMP_SHIRT_SIZE"].ToString() == null) ? "" : row["EMP_SHIRT_SIZE"].ToString(),

                                 EMP_PHOTOKK = (row["EMP_PHOTOKK"].ToString().Replace(olds, news) == null) ? "" : row["EMP_PHOTOKK"].ToString().Replace(olds, news),
                                 EMP_NOKK = (row["EMP_NOKK"].ToString() == null) ? "" : row["EMP_NOKK"].ToString(),
                                 EMP_FATHER_ALIVE = row["EMP_FATHER_ALIVE"].ToBoolean(),
                                 EMP_FATHER_NAME = (row["EMP_FATHER_NAME"].ToString() == null) ? "" : row["EMP_FATHER_NAME"].ToString(),
                                 EMP_FATHER_AGE = (row["EMP_FATHER_AGE"].ToString() == null) ? "" : row["EMP_FATHER_AGE"].ToString(),
                                 EMP_FATHER_JOB = (row["EMP_FATHER_JOB"].ToString() == null) ? "" : row["EMP_FATHER_JOB"].ToString(),
                                 EMP_NIK_FATHER = (row["EMP_NIK_FATHER"].ToString() == null) ? "" : row["EMP_NIK_FATHER"].ToString(),
                                 EMP_FATHER_BIRTHPLACE = (row["EMP_FATHER_BIRTHPLACE"].ToString() == null) ? "" : row["EMP_FATHER_BIRTHPLACE"].ToString(),
                                 EMP_FATHER_BIRTHDAY = (row["EMP_FATHER_BIRTHDAY"].ToString() == null) ? "" : row["EMP_FATHER_BIRTHDAY"].ToString(),
                                 EMP_FATHER_MOBILE = (row["EMP_FATHER_MOBILE"].ToString() == null) ? "" : row["EMP_FATHER_MOBILE"].ToString(),
                                 EMP_MOTHER_ALIVE = row["EMP_MOTHER_ALIVE"].ToBoolean(),
                                 EMP_MOTHER_NAME = (row["EMP_MOTHER_NAME"].ToString() == null) ? "" : row["EMP_MOTHER_NAME"].ToString(),
                                 EMP_MOTHER_AGE = (row["EMP_MOTHER_AGE"].ToString() == null) ? "" : row["EMP_MOTHER_AGE"].ToString(),
                                 EMP_MOTHER_JOB = (row["EMP_MOTHER_JOB"].ToString() == null) ? "" : row["EMP_MOTHER_JOB"].ToString(),
                                 EMP_NIK_MOTHER = (row["EMP_NIK_MOTHER"].ToString() == null) ? "" : row["EMP_NIK_MOTHER"].ToString(),
                                 EMP_MOTHER_BIRTHPLACE = (row["EMP_MOTHER_BIRTHPLACE"].ToString() == null) ? "" : row["EMP_MOTHER_BIRTHPLACE"].ToString(),
                                 EMP_MOTHER_BIRTHDAY = (row["EMP_MOTHER_BIRTHDAY"].ToString() == null) ? "" : row["EMP_MOTHER_BIRTHDAY"].ToString(),
                                 EMP_MOTHER_MOBILE = (row["EMP_MOTHER_MOBILE"].ToString() == null) ? "" : row["EMP_MOTHER_MOBILE"].ToString(),

                                 EMP_ISFAMILY = row["EMP_ISFAMILY"].ToBoolean(),
                                 EMP_WIFE_NAME = (row["EMP_WIFE_NAME"].ToString() == null) ? "" : row["EMP_WIFE_NAME"].ToString(),
                                 EMP_WIFE_NIK = (row["EMP_WIFE_NIK"].ToString() == null) ? "" : row["EMP_WIFE_NIK"].ToString(),
                                 EMP_WIFE_BIRTH_PLACE = (row["EMP_WIFE_BIRTH_PLACE"].ToString() == null) ? "" : row["EMP_WIFE_BIRTH_PLACE"].ToString(),
                                 EMP_WIFE_BIRTH_DATE = (row["EMP_WIFE_BIRTH_DATE"].ToString() == null) ? "" : row["EMP_WIFE_BIRTH_DATE"].ToString(),
                                 EMP_WIFE_MOBILE = (row["EMP_WIFE_MOBILE"].ToString() == null) ? "" : row["EMP_WIFE_MOBILE"].ToString(),
                                 EMP_WIFE_BNIKAH = (row["EMP_WIFE_BNIKAH"].ToString().Replace(olds, news) == null) ? "" : row["EMP_WIFE_BNIKAH"].ToString().Replace(olds, news),

                                 EMP_EM_NAME = (row["EMP_EM_NAME"].ToString() == null) ? "" : row["EMP_EM_NAME"].ToString(),
                                 EMP_EM_REL = (row["EMP_EM_REL"].ToString() == null) ? "" : row["EMP_EM_REL"].ToString(),
                                 EMP_EM_MOBILE = (row["EMP_EM_MOBILE"].ToString() == null) ? "" : row["EMP_EM_MOBILE"].ToString(),
                                 EMP_EM_ADDR = (row["EMP_EM_ADDR"].ToString() == null) ? "" : row["EMP_EM_ADDR"].ToString(),
                                 EMP_EM_RT = (row["EMP_EM_RT"].ToString() == null) ? "" : row["EMP_EM_RT"].ToString(),
                                 EMP_EM_RW = (row["EMP_EM_RW"].ToString() == null) ? "" : row["EMP_EM_RW"].ToString(),
                                 EMP_EM_PROVINSI = (row["EMP_EM_PROVINSI"].ToString() == null) ? "" : row["EMP_EM_PROVINSI"].ToString(),
                                 EMP_EM_KABUPATEN = (row["EMP_EM_KABUPATEN"].ToString() == null) ? "" : row["EMP_EM_KABUPATEN"].ToString(),
                                 EMP_EM_KECAMATAN = (row["EMP_EM_KECAMATAN"].ToString() == null) ? "" : row["EMP_EM_KECAMATAN"].ToString(),
                                 EMP_EM_KELURAHAN = (row["EMP_EM_KELURAHAN"].ToString() == null) ? "" : row["EMP_EM_KELURAHAN"].ToString(),

                                 EMP_LAST_EDU = (row["EMP_LAST_EDU"].ToString() == null) ? "" : row["EMP_LAST_EDU"].ToString(),
                                 EMP_SCHOOL_NAME = (row["EMP_SCHOOL_NAME"].ToString() == null) ? "" : row["EMP_SCHOOL_NAME"].ToString(),
                                 EMP_SCHOOL_MAJOR = (row["EMP_SCHOOL_MAJOR"].ToString() == null) ? "" : row["EMP_SCHOOL_MAJOR"].ToString(),
                                 EMP_AVG_SCORE = Convert.ToInt32(row["EMP_AVG_SCORE"]),
                                 EMP_CERT_NO = (row["EMP_CERT_NO"].ToString() == null) ? "" : row["EMP_CERT_NO"].ToString(),
                                 EMP_PHOTO_CERT_F = (row["EMP_PHOTO_CERT_F"].ToString().Replace(olds, news) == null) ? "" : row["EMP_PHOTO_CERT_F"].ToString().Replace(olds, news),
                                 EMP_PHOTO_CERT_B = (row["EMP_PHOTO_CERT_B"].ToString().Replace(olds, news) == null) ? "" : row["EMP_PHOTO_CERT_B"].ToString().Replace(olds, news),
                                 EMP_HOLD_WILLINGLY = row["EMP_HOLD_WILLINGLY"].ToBoolean(),
                                 EMP_FACULTY = (row["EMP_FACULTY"].ToString() == null) ? "" : row["EMP_FACULTY"].ToString(),
                                 EMP_GRADUATE_YEAR = (row["EMP_GRADUATE_YEAR"].ToString() == null) ? "" : row["EMP_GRADUATE_YEAR"].ToString(),
                                 EMP_GRADUATE_PLACE = (row["EMP_GRADUATE_PLACE"].ToString() == null) ? "" : row["EMP_GRADUATE_PLACE"].ToString(),

                                 EMP_GRADUATE_COUNTRY = (row["EMP_GRADUATE_COUNTRY"].ToString() == null) ? "" : row["EMP_GRADUATE_COUNTRY"].ToString(),
                                 EMP_GRADUATE_DISTRICT = (row["EMP_GRADUATE_DISTRICT"].ToString() == null) ? "" : row["EMP_GRADUATE_DISTRICT"].ToString(),
                                 EMP_GRADUATE_CITY = (row["EMP_GRADUATE_CITY"].ToString() == null) ? "" : row["EMP_GRADUATE_CITY"].ToString(),

                                 EMP_MOTIVASI = (row["EMP_MOTIVASI"].ToString() == null) ? "" : row["EMP_MOTIVASI"].ToString(),
                                 EMP_KOMITMEN = (row["EMP_KOMITMEN"].ToString() == null) ? "" : row["EMP_KOMITMEN"].ToString(),
                                 EMP_CRIME = row["EMP_CRIME"].ToBoolean(),
                                 EMP_MENTAL_DISEASE = row["EMP_MENTAL_DISEASE"].ToBoolean(),
                                 EMP_WORKED_ON_SHIMANO = row["EMP_WORKED_ON_SHIMANO"].ToBoolean(),
                                 EMP_SHAMANO_START = (row["EMP_SHAMANO_START"].ToString() == null) ? "" : row["EMP_SHAMANO_START"].ToString(),
                                 EMP_SHIMANO_END = (row["EMP_SHIMANO_END"].ToString() == null) ? "" : row["EMP_SHIMANO_END"].ToString(),
                                 EMP_STUDY_PLAN = row["EMP_STUDY_PLAN"].ToBoolean(),
                                 EMP_SAPORCOMP = row["EMP_SAPORCOMP"].ToBoolean(),

                                 EMP_EYE_CHECK = row["EMP_EYE_CHECK"].ToBoolean(),
                                 EMP_EYE_VALUE = (row["EMP_EYE_VALUE"].ToString() == null) ? "" : row["EMP_EYE_VALUE"].ToString(),
                                 EMP_EYE_GLASSES = row["EMP_EYE_GLASSES"].ToBoolean(),
                                 EMP_LAST_SMOKING = (row["EMP_LAST_SMOKING"].ToString() == null) ? "" : row["EMP_LAST_SMOKING"].ToString(),
                                 EMP_SMOKING = row["EMP_SMOKING"].ToBoolean(),
                                 EMP_LEFT_HANDED = row["EMP_LEFT_HANDED"].ToBoolean(),

                                 EMP_CL = (row["EMP_CL"].ToString() == null) ? "" : row["EMP_CL"].ToString(),
                                 EMP_CV = (row["EMP_KOMITMEN"].ToString() == null) ? "" : row["EMP_CV"].ToString(),
                                 EMP_ACCOUNT_BCA = (row["EMP_ACCOUNT_BCA"].ToString() == null) ? "" : row["EMP_ACCOUNT_BCA"].ToString(),
                                 EMP_ACCOUNT_NPWP = (row["EMP_ACCOUNT_NPWP"].ToString() == null) ? "" : row["EMP_ACCOUNT_NPWP"].ToString(),
                                 EMP_ACCOUNT_EFIN = (row["EMP_ACCOUNT_EFIN"].ToString() == null) ? "" : row["EMP_ACCOUNT_EFIN"].ToString(),
                                 EMP_ACCOUNT_BPJS_KES = (row["EMP_ACCOUNT_BPJS_KES"].ToString() == null) ? "" : row["EMP_ACCOUNT_BPJS_KES"].ToString(),
                                 EMP_ACCOUNT_BPJS_TKJ = (row["EMP_ACCOUNT_BPJS_TKJ"].ToString() == null) ? "" : row["EMP_ACCOUNT_BPJS_TKJ"].ToString(),
                                 EMP_IMG_BCA = (row["EMP_IMG_BCA"].ToString().Replace(olds, news) == null) ? "" : row["EMP_IMG_BCA"].ToString().Replace(olds, news),
                                 EMP_IMG_NPWP = (row["EMP_IMG_NPWP"].ToString().Replace(olds, news) == null) ? "" : row["EMP_IMG_NPWP"].ToString().Replace(olds, news),
                                 EMP_IMG_EFIN = (row["EMP_IMG_EFIN"].ToString().Replace(olds, news) == null) ? "" : row["EMP_IMG_EFIN"].ToString().Replace(olds, news),
                                 EMP_IMG_BPJS_KES = (row["EMP_IMG_BPJS_KES"].ToString().Replace(olds, news) == null) ? "" : row["EMP_IMG_BPJS_KES"].ToString().Replace(olds, news),
                                 EMP_IMG_BPJS_TKJ = (row["EMP_IMG_BPJS_TKJ"].ToString().Replace(olds, news) == null) ? "" : row["EMP_IMG_BPJS_TKJ"].ToString().Replace(olds, news),
                                 EMP_IMG_SIM_C = (row["EMP_IMG_SIM_C"].ToString().Replace(olds, news) == null) ? "" : row["EMP_IMG_SIM_C"].ToString().Replace(olds, news),
                                 EMP_IMG_VAKSIN = (row["EMP_IMG_VAKSIN"].ToString().Replace(olds, news) == null) ? "" : row["EMP_IMG_VAKSIN"].ToString().Replace(olds, news),

                                 EMP_IMG_SKCK = (row["EMP_IMG_SKCK"].ToString().Replace(olds, news) == null) ? "" : row["EMP_IMG_SKCK"].ToString().Replace(olds, news),
                                 EMP_IMG_SERTIFIKAT_KOMPETENSI = (row["EMP_IMG_SERTIFIKAT_KOMPETENSI"].ToString().Replace(olds, news) == null) ? "" : row["EMP_IMG_SERTIFIKAT_KOMPETENSI"].ToString().Replace(olds, news),
                                 EMP_IMG_PENGALAMAN = (row["EMP_IMG_PENGALAMAN"].ToString().Replace(olds, news) == null) ? "" : row["EMP_IMG_PENGALAMAN"].ToString().Replace(olds, news),
                                 EMP_IMG_SURAT_SEHAT = (row["EMP_IMG_SURAT_SEHAT"].ToString().Replace(olds, news) == null) ? "" : row["EMP_IMG_SURAT_SEHAT"].ToString().Replace(olds, news),
                                 EMP_IMG_KARTU_KUNING = (row["EMP_IMG_KARTU_KUNING"].ToString().Replace(olds, news) == null) ? "" : row["EMP_IMG_KARTU_KUNING"].ToString().Replace(olds, news),
                                 EMP_IMG_SIO = (row["EMP_IMG_SIO"].ToString().Replace(olds, news) == null) ? "" : row["EMP_IMG_SIO"].ToString().Replace(olds, news),

                                 EMP_BATCH_EMP = (row["EMP_BATCH_EMP"].ToString() == null) ? "" : row["EMP_BATCH_EMP"].ToString(),
                                 EMP_INVITECODE = (row["EMP_INVITECODE"].ToString() == null) ? "" : row["EMP_INVITECODE"].ToString(),
                                 EMP_PERSONALITY = (row["EMP_PERSONALITY"].ToString() == null) ? "" : row["EMP_PERSONALITY"].ToString(),
                                 EMP_THINKING_STY = (row["EMP_THINKING_STY"].ToString() == null) ? "" : row["EMP_THINKING_STY"].ToString(),
                                 EMP_WORKING_STY = (row["EMP_WORKING_STY"].ToString() == null) ? "" : row["EMP_WORKING_STY"].ToString(),
                                 EMP_TEST_IQ  = Convert.ToInt32(row["EMP_TEST_IQ"]),
                                 EMP_TEST_MTH = Convert.ToInt32(row["EMP_TEST_MTH"]),
                                 EMP_TEST_ACC = Convert.ToInt32(row["EMP_TEST_ACC"]),
                                 EMP_TEST_ENG = Convert.ToInt32(row["EMP_TEST_ENG"]),
                                 EMP_WRITTEN_SCORE = Convert.ToInt32(row["EMP_WRITTEN_SCORE"]),

                                 EMP_TEST_1 = (row["EMP_TEST_1"].ToString() == null) ? "" : row["EMP_TEST_1"].ToString(),
                                 EMP_TIME_TEST_1 = (row["EMP_TIME_TEST_1"].ToString() == null) ? "" : row["EMP_TIME_TEST_1"].ToString(),
                                 EMP_TEST_2 = (row["EMP_TEST_2"].ToString() == null) ? "" : row["EMP_TEST_2"].ToString(),
                                 EMP_TIME_TEST_2 = (row["EMP_TIME_TEST_2"].ToString() == null) ? "" : row["EMP_TIME_TEST_2"].ToString(),
                                 EMP_PRACTICAL_SCORE = Convert.ToInt32(row["EMP_PRACTICAL_SCORE"]),
                                 EMP_REMARK = (row["EMP_REMARK"].ToString() == null) ? "" : row["EMP_REMARK"].ToString(),

                                 EMP_MEMORY_SCORE = Convert.ToInt32(row["EMP_MEMORY_SCORE"]),
                                 EMP_ATTN_EMP = row["EMP_ATTN_EMP"].ToBoolean(),
                                 EMP_MDCL_TST = row["EMP_MDCL_TST"].ToBoolean(),
                                 EMP_FIN_DES = row["EMP_FIN_DES"].ToBoolean(),
                                 EMP_SUM_REMARK = (row["EMP_SUM_REMARK"].ToString() == null) ? "" : row["EMP_SUM_REMARK"].ToString(),
                                 EMP_UPDT_USER = (row["EMP_UPDT_USER"].ToString() == null) ? "" : row["EMP_UPDT_USER"].ToString(),
                                 EMP_UPDT_TIME = (row["EMP_UPDT_TIME"].ToString() == null) ? "" : row["EMP_UPDT_TIME"].ToString(),

                                 WORK_EXP = (from x in DATA1
                                             select new CANDIDATE_DETAILS_WORK_EXP
                                             {
                                                 COMPANY_NAME = x.COMPANY_NAME,
                                                 POSITION = x.POSITION,
                                                 START_YEAR = x.START_YEAR,
                                                 END_YEAR = x.END_YEAR,
                                                 REASON_LEAVE = x.REASON_LEAVE,
                                                 CERT_PHOTO = x.CERT_PHOTO.Replace(olds, news)
                                             }).ToList(),
                                 SIBLINGS = (from y in DATA2
                                             select new CANDIDATE_DETAILS_SIBLINGS
                                             {
                                                 ID = y.ID,
                                                 NAME = y.NAME,
                                                 AGE = y.AGE,
                                                 JOB = y.JOB,
                                             }).ToList(),
                                 LANGUAGE = (from z in DATA3
                                               select new CANDIDATE_DETAILS_LANGUAGE
                                               {
                                                   LANGUAGE_ID = z.LANGUAGE_ID,
                                                   LANGUAGE = z.LANGUAGE,
                                                   LEVEL = z.LEVEL
                                               }).ToList(),
                                 CHILD = (from z in DATA4
                                             select new CANDIDATE_DETAILS_CHILD
                                             {
                                                 CHILD_NAME = z.CHILD_NAME,
                                                 CHILD_NIK = z.CHILD_NIK,
                                                 CHILD_BIRTH_DATE = z.CHILD_BIRTH_DATE,
                                                 CHILD_BIRTH_PLACE = z.CHILD_BIRTH_PLACE
                                             }).ToList(),
                             }).ToList();

                return DATA0;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        static T Cast<T>(object value)
        {
            if (value is T)
                return (T)value;
            else
                return default(T);
        }
        //WEB_GET_STATUS_DETAIL
        public List<INTERVIEWSCOREBOARD_MODEL> WEB_GET_STATUS_DETAIL(string BATCHNO)
        {
            try
            {
                SQL = @"EXEC [WEB_GET_STATUS_DETAIL] '"+ BATCHNO + "'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new INTERVIEWSCOREBOARD_MODEL()
                             {
                                 STATUS = (row["STATUS"].ToString() == null) ? "" : row["STATUS"].ToString()
                             }).ToList();

                return DATA0;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public List<INTERVIEWSCOREBOARD_MODEL> WEB_GETBATCH_DROPDOWN()
        {
            try
            {
                SQL = @"EXEC [SP_WEB_GETBATCH_DROPDOWN]";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new INTERVIEWSCOREBOARD_MODEL()
                             {
                                 BATCHNO = (row["BATCHNO"].ToString() == null) ? "" : row["BATCHNO"].ToString()
                             }).ToList();

                return DATA0;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public List<INTERVIEWSCOREBOARD_MODEL> WEB_GETCATEGORY_DROPDOWN()
        {
            try
            {
                SQL = @"EXEC [SP_WEB_GETCATEGORY_DROPDOWN]";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new INTERVIEWSCOREBOARD_MODEL()
                             {
                                 CATEGORY = (row["CATEGORY"].ToString() == null) ? "" : row["CATEGORY"].ToString()
                             }).ToList();

                return DATA0;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public List<INTERVIEWSCOREBOARD_MODEL> WEB_GETBATSTAT_DROPDOWN()
        {
            try
            {
                SQL = @"EXEC [SP_WEB_GETBATSTAT_DROPDOWN]";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new INTERVIEWSCOREBOARD_MODEL()
                             {
                                 STATUS = (row["STATUS"].ToString() == null) ? "" : row["STATUS"].ToString()
                             }).ToList();

                return DATA0;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public List<INTERVIEWSCOREBOARD_MODEL> WEB_GETEMPSTAT_DROPDOWN()
        {
            try
            {
                SQL = @"EXEC [SP_WEB_GETEMPSTAT_DROPDOWN]";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new INTERVIEWSCOREBOARD_MODEL()
                             {
                                 STATUS = (row["STATUS"].ToString() == null) ? "" : row["STATUS"].ToString()
                             }).ToList();

                return DATA0;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public List<INTERVIEWSCOREBOARD_COMPLETED> WEB_GETSCOREBOARD(string BATCH_EMP)
        {
            try
            {
                SQL = @"EXEC [SP_WEB_GET_INTERVIEWBOARD_SCOREBOARD] '" + BATCH_EMP + "'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new INTERVIEWSCOREBOARD_COMPLETED()
                             {
                                 BATCH_NO = (row["BATCH_NO"].ToString() == null) ? "" : row["BATCH_NO"].ToString(),
                                 BATCH_EMP = (row["BATCH_EMP"].ToString() == null) ? "" : row["BATCH_EMP"].ToString(),
                                 NAME_EMP = (row["NAME_EMP"].ToString() == null) ? "" : row["NAME_EMP"].ToString(),
                                 RACE = (row["RACE"].ToString() == null) ? "" : row["RACE"].ToString(),
                                 PHONE = (row["PHONE"].ToString() == null) ? "" : row["PHONE"].ToString(),
                                 WHATSAPP = (row["WHATSAPP"].ToString() == null) ? "" : row["WHATSAPP"].ToString(),
                                 GANDER = (row["GANDER"].ToString() == null) ? "" : row["GANDER"].ToString(),
                                 AGE = (Convert.ToInt32(row["AGE"]) == 0) ? 0 : Convert.ToInt32(row["AGE"]),
                                 RELIGION = (row["RELIGION"].ToString() == null) ? "" : row["RELIGION"].ToString(),
                                 ADDRESS = (row["ADDRESS"].ToString() == null) ? "" : row["ADDRESS"].ToString(),
                                 LEFT_HANDED = (row["LEFT_HANDED"].ToBoolean() == false) ? false : row["LEFT_HANDED"].ToBoolean(),
                                 HEIGHT = (Convert.ToInt32(row["HEIGHT"]) == 0) ? 0 : Convert.ToInt32(row["HEIGHT"]),
                                 WEIGHT = (Convert.ToInt32(row["WEIGHT"]) == 0) ? 0 : Convert.ToInt32(row["WEIGHT"]),
                                 PERSONALITY = (row["PERSONALITY"].ToString() == null) ? "" : row["PERSONALITY"].ToString().Replace("\n", ""),
                                 THINKING_STY = (row["THINKING_STY"].ToString() == null) ? "" : row["THINKING_STY"].ToString().Replace("\n", ""),
                                 WORKING_STY = (row["WORKING_STY"].ToString() == null) ? "" : row["WORKING_STY"].ToString().Replace("\n", ""),

                                 LAST_EDU = (row["LAST_EDU"].ToString() == null) ? "" : row["LAST_EDU"].ToString().Replace("\n", ""),
                                 SCHOOL_NAME = (row["SCHOOL_NAME"].ToString() == null) ? "" : row["SCHOOL_NAME"].ToString().Replace("\n", ""),
                                 SCHOOL_MAJOR = (row["SCHOOL_MAJOR"].ToString() == null) ? "" : row["SCHOOL_MAJOR"].ToString().Replace("\n", ""),
                                 AVG_SCORE = (Convert.ToInt32(row["AVG_SCORE"]) == 0) ? 0 : Convert.ToInt32(row["AVG_SCORE"]),
                                 CERT_NO = (row["CERT_NO"].ToString() == null) ? "" : row["CERT_NO"].ToString().Replace("\n", ""),
                                 PHOTO_CERT = (row["PHOTO_CERT"].ToString() == null) ? "" : row["PHOTO_CERT"].ToString().Replace("\n", ""),
                                 HOLD_WILLINGLY = (row["HOLD_WILLINGLY"].ToBoolean() == false) ? false : row["HOLD_WILLINGLY"].ToBoolean(),

                                 TEST_IQ = (Convert.ToInt32(row["TEST_IQ"]) == 0) ? 0 : Convert.ToInt32(row["TEST_IQ"]),
                                 TEST_MTH = (Convert.ToInt32(row["TEST_MTH"]) == 0) ? 0 : Convert.ToInt32(row["TEST_MTH"]),
                                 TEST_ACC = (Convert.ToInt32(row["TEST_ACC"]) == 0) ? 0 : Convert.ToInt32(row["TEST_ACC"]),
                                 TEST_ENG = (Convert.ToInt32(row["TEST_ENG"]) == 0) ? 0 : Convert.ToInt32(row["TEST_ENG"]),
                                 WRITTEN_SCORE = (Convert.ToInt32(row["WRITTEN_SCORE"]) == 0) ? 0 : Convert.ToInt32(row["WRITTEN_SCORE"]),

                                 TEST_1 = (row["TEST_1"].ToString() == null) ? "" : row["TEST_1"].ToString(),
                                 TIME_TEST_1 = (row["TIME_TEST_1"].ToString() == null) ? "" : row["TIME_TEST_1"].ToString(),
                                 TEST_2 = (row["TEST_2"].ToString() == null) ? "" : row["TEST_2"].ToString(),
                                 TIME_TEST_2 = (row["TIME_TEST_2"].ToString() == null) ? "" : row["TIME_TEST_2"].ToString(),
                                 REMARK = (row["REMARK"].ToString() == null) ? "" : row["REMARK"].ToString(),

                                 DIGIT_1 = (Convert.ToInt32(row["DIGIT_1"]) == 0) ? 0 : Convert.ToInt32(row["DIGIT_1"]),
                                 DIGIT_2 = (Convert.ToInt32(row["DIGIT_2"]) == 0) ? 0 : Convert.ToInt32(row["DIGIT_2"]),
                                 DIGIT_3 = (Convert.ToInt32(row["DIGIT_3"]) == 0) ? 0 : Convert.ToInt32(row["DIGIT_3"]),
                                 DIGIT_4 = (Convert.ToInt32(row["DIGIT_4"]) == 0) ? 0 : Convert.ToInt32(row["DIGIT_4"]),
                                 DIGIT_5 = (Convert.ToInt32(row["DIGIT_5"]) == 0) ? 0 : Convert.ToInt32(row["DIGIT_5"]),
                                 DIGITS =  Convert.ToString(row["DIGITS"]),

                                 DIGIT_USER_1 = (Convert.ToInt32(row["DIGIT_USER_1"]) == 0) ? 0 : Convert.ToInt32(row["DIGIT_USER_1"]),
                                 DIGIT_USER_2 = (Convert.ToInt32(row["DIGIT_USER_2"]) == 0) ? 0 : Convert.ToInt32(row["DIGIT_USER_2"]),
                                 DIGIT_USER_3 = (Convert.ToInt32(row["DIGIT_USER_3"]) == 0) ? 0 : Convert.ToInt32(row["DIGIT_USER_3"]),
                                 DIGIT_USER_4 = (Convert.ToInt32(row["DIGIT_USER_4"]) == 0) ? 0 : Convert.ToInt32(row["DIGIT_USER_4"]),
                                 DIGIT_USER_5 = (Convert.ToInt32(row["DIGIT_USER_5"]) == 0) ? 0 : Convert.ToInt32(row["DIGIT_USER_5"]),
                                 MEMORY_SCORE = (Convert.ToInt32(row["MEMORY_SCORE"]) == 0) ? 0 : Convert.ToInt32(row["MEMORY_SCORE"]),

                                 SAPORCOMP = (row["SAPORCOMP"].ToBoolean() == false) ? false : row["SAPORCOMP"].ToBoolean(),
                                 COLLEGE = (row["COLLEGE"].ToBoolean() == false) ? false : row["COLLEGE"].ToBoolean(),
                                 EYEGLASSES = (row["EYEGLASSES"].ToBoolean() == false) ? false : row["EYEGLASSES"].ToBoolean(),
                                 EYECHECK = (row["EYECHECK"].ToBoolean() == false) ? false : row["EYECHECK"].ToBoolean(),
                                 EYEVALUE = (row["EYEVALUE"].ToString() == null) ? "" : row["EYEVALUE"].ToString(),
                                 SMOKING = (row["SMOKING"].ToBoolean() == false) ? false : row["SMOKING"].ToBoolean(),

                                 FINALRESULT = (row["FINALRESULT"].ToBoolean() == false) ? false : row["FINALRESULT"].ToBoolean(),
                                 FINALREMARK = (row["FINALREMARK"].ToString() == null) ? "" : row["FINALREMARK"].ToString(),

                             }).ToList();

                return DATA0;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public PP<RESPONSE2> WEB_SETDIGIT(string BATCH_EMP)
        {
            try
            {
                SQL = @"EXEC [WEB_SETDIGIT] '" + BATCH_EMP + "'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA = (from ROW in DATATABLE.AsEnumerable()
                            select new RESPONSE2
                            {
                                RESULT = ROW["RESULT"].ToBoolean(),
                                MESSAGE = ROW["MESSAGE"].ToString()

                            }).FirstOrDefault();

                return new PP<RESPONSE2>
                {
                    Result = DATA.RESULT,
                    Message = DATA.MESSAGE,
                    Data = null
                };
            }
            catch (Exception msg)
            {
                return new PP<RESPONSE2>
                {
                    Result = false,
                    Message = msg.Message.ToString(),
                    Data = null
                };
            }
        }
        public List<INTERVIEWSCOREBOARD_DIGITS> WEB_SHOWDIGIT(string BATCH_EMP)
        {
            try
            {
                SQL = @"EXEC [WEB_SHOWDIGIT] '" + BATCH_EMP + "'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA = (from ROW in DATATABLE.AsEnumerable()
                            select new INTERVIEWSCOREBOARD_DIGITS
                            {
                                DIGITS = ROW["DIGITS"].ToString()
                            }).ToList();

                return DATA;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public PP<RESPONSE2> WEB_INTERVIEWBOARD_SAVE_PERSONAL(INTERVIEWSCOREBOARD_COMPLETED MODEL)
        {
            try
            {
                SQL = @"EXEC [WEB_INTERVIEWBOARD_SAVE_PERSONAL] '" + MODEL.BATCH_EMP + "','" + MODEL.RACE + "','" + MODEL.RELIGION + "','" + MODEL.WHATSAPP + "','" + MODEL.GANDER + "'," + MODEL.AGE + ",'" + MODEL.ADDRESS + "'," + MODEL.LEFT_HANDED + ","+MODEL.HEIGHT+","+MODEL.WEIGHT+",'"+MODEL.PERSONALITY + "','" + MODEL.THINKING_STY + "','"+MODEL.WORKING_STY+"'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA = (from ROW in DATATABLE.AsEnumerable()
                             select new RESPONSE2
                             { 
                                 RESULT = ROW["RESULT"].ToBoolean(),
                                 MESSAGE = ROW["MESSAGE"].ToString()

                             }).FirstOrDefault();

                return new PP<RESPONSE2>
                {
                    Result = DATA.RESULT,
                    Message = DATA.MESSAGE,
                    Data = null
                };
            }
            catch(Exception msg)
            {
                return new PP<RESPONSE2>
                {
                    Result = false,
                    Message = msg.Message.ToString(),
                    Data = null
                };
            }
        }
        public PP<RESPONSE2> WEB_INTERVIEWBOARD_SAVE_EDICATION(INTERVIEWSCOREBOARD_COMPLETED MODEL)
        {
            try
            {

                SQL = @"EXEC [WEB_INTERVIEWBOARD_SAVE_EDUCATION] 
                        '"  + MODEL.BATCH_EMP + "'," +
                        "'" + ((MODEL.LAST_EDU == null) ? "" : MODEL.LAST_EDU.ToString().Replace("\r\n", "")) + "'," +
                        "'" + ((MODEL.SCHOOL_NAME == null) ? "" : MODEL.SCHOOL_NAME.ToString().Replace("\r\n", "")) + "'," +
                        "'" + ((MODEL.SCHOOL_MAJOR == null) ? "" : MODEL.SCHOOL_MAJOR.ToString().Replace("\r\n", "")) + "'," +
                        ""  + MODEL.AVG_SCORE + "," +
                        "'" + ((MODEL.CERT_NO == null) ? "" : MODEL.CERT_NO.ToString().Replace("\r\n", "")) + "'," +
                        "'" + ((MODEL.PHOTO_CERT == null) ? "" : MODEL.PHOTO_CERT.ToString().Replace("\r\n", "")) + "'," +
                        ""  + MODEL.HOLD_WILLINGLY +"";
                //NAMEEMP = (row["NAMEEMP"].ToString() == null) ? "" : row["NAMEEMP"].ToString(),
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA = (from ROW in DATATABLE.AsEnumerable()
                            select new RESPONSE2
                            {
                                RESULT = ROW["RESULT"].ToBoolean(),
                                MESSAGE = ROW["MESSAGE"].ToString()

                            }).FirstOrDefault();

                return new PP<RESPONSE2>
                {
                    Result = DATA.RESULT,
                    Message = DATA.MESSAGE,
                    Data = null
                };
            }
            catch (Exception msg)
            {
                return new PP<RESPONSE2>
                {
                    Result = false,
                    Message = ""+ msg.Message.ToString()+ " - "  +MODEL.BATCH_EMP + "",
                    Data = null
                };
            }
        }
        public PP<RESPONSE2> WEB_INTERVIEWBOARD_SAVE_WRITTEN(INTERVIEWSCOREBOARD_COMPLETED MODEL, string USERID)
        {
            try
            {
                SQL = @"EXEC [WEB_INTERVIEWBOARD_SAVE_WRITTEN] '" + MODEL.BATCH_EMP + "'," + MODEL.TEST_IQ + "," + MODEL.TEST_MTH + "," + MODEL.TEST_ACC + "," + MODEL.TEST_ENG + ",'" + USERID + "'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA = (from ROW in DATATABLE.AsEnumerable()
                            select new RESPONSE2
                            {
                                RESULT = ROW["RESULT"].ToBoolean(),
                                MESSAGE = ROW["MESSAGE"].ToString()

                            }).FirstOrDefault();

                return new PP<RESPONSE2>
                {
                    Result = DATA.RESULT,
                    Message = DATA.MESSAGE,
                    Data = null
                };
            }
            catch (Exception msg)
            {
                return new PP<RESPONSE2>
                {
                    Result = false,
                    Message = msg.Message.ToString(),
                    Data = null
                };
            }
        }
        public PP<RESPONSE2> WEB_INTERVIEWBOARD_SAVE_PRACTICAL(INTERVIEWSCOREBOARD_COMPLETED MODEL, string USERID)
        {
            try
            {
                SQL = @"EXEC [WEB_INTERVIEWBOARD_SAVE_PRACTICAL] '" + MODEL.BATCH_EMP + "','" + MODEL.TEST_1 + "','" + MODEL.TIME_TEST_1 + "','" + MODEL.TEST_2 + "','" + MODEL.TIME_TEST_2 + "','" + MODEL.REMARK + "','" + USERID + "'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA = (from ROW in DATATABLE.AsEnumerable()
                            select new RESPONSE2
                            {
                                RESULT = ROW["RESULT"].ToBoolean(),
                                MESSAGE = ROW["MESSAGE"].ToString()

                            }).FirstOrDefault();

                return new PP<RESPONSE2>
                {
                    Result = DATA.RESULT,
                    Message = DATA.MESSAGE,
                    Data = null
                };
            }
            catch (Exception msg)
            {
                return new PP<RESPONSE2>
                {
                    Result = false,
                    Message = msg.Message.ToString(),
                    Data = null
                };
            }
        }
        public PP<RESPONSE2> WEB_INTERVIEWBOARD_SAVE_MEMORY(INTERVIEWSCOREBOARD_COMPLETED MODEL, string USERID)
        {
            try
            {
                SQL = @"EXEC [WEB_INTERVIEWBOARD_SAVE_MEMORY] '" + MODEL.BATCH_EMP + "','" + MODEL.MEMORY_SCORE + "','" + USERID + "'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA = (from ROW in DATATABLE.AsEnumerable()
                            select new RESPONSE2
                            {
                                RESULT = ROW["RESULT"].ToBoolean(),
                                MESSAGE = ROW["MESSAGE"].ToString()

                            }).FirstOrDefault();

                return new PP<RESPONSE2>
                {
                    Result = DATA.RESULT,
                    Message = DATA.MESSAGE,
                    Data = null
                };
            }
            catch (Exception msg)
            {
                return new PP<RESPONSE2>
                {
                    Result = false,
                    Message = msg.Message.ToString(),
                    Data = null
                };
            }
        }
        public PP<RESPONSE2> WEB_INTERVIEWBOARD_SAVE_OTHER(INTERVIEWSCOREBOARD_COMPLETED MODEL, string USERID)
        {
            try
            {
                SQL = @"EXEC [WEB_INTERVIEWBOARD_SAVE_OTHER] '" + MODEL.BATCH_EMP + "'," + MODEL.SAPORCOMP + "," + MODEL.COLLEGE + "," + MODEL.EYEGLASSES + "," + MODEL.EYECHECK + ",'" + MODEL.EYEVALUE + "'," + MODEL.SMOKING + ",'" + USERID + "'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA = (from ROW in DATATABLE.AsEnumerable()
                            select new RESPONSE2
                            {
                                RESULT = ROW["RESULT"].ToBoolean(),
                                MESSAGE = ROW["MESSAGE"].ToString()

                            }).FirstOrDefault();

                return new PP<RESPONSE2>
                {
                    Result = DATA.RESULT,
                    Message = DATA.MESSAGE,
                    Data = null
                };
            }
            catch (Exception msg)
            {
                return new PP<RESPONSE2>
                {
                    Result = false,
                    Message = msg.Message.ToString(),
                    Data = null
                };
            }
        }
        public PP<RESPONSE2> WEB_INTERVIEWBOARD_SAVE_FINAL(INTERVIEWSCOREBOARD_COMPLETED MODEL, string USERID)
        {
            try
            {
                SQL = @"EXEC [WEB_INTERVIEWBOARD_SAVE_FINAL] '" + MODEL.BATCH_EMP + "'," + MODEL.FINALRESULT + ",'" + MODEL.FINALREMARK + "','" + USERID + "'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA = (from ROW in DATATABLE.AsEnumerable()
                            select new RESPONSE2
                            {
                                RESULT = ROW["RESULT"].ToBoolean(),
                                MESSAGE = ROW["MESSAGE"].ToString()

                            }).FirstOrDefault();

                return new PP<RESPONSE2>
                {
                    Result = DATA.RESULT,
                    Message = DATA.MESSAGE,
                    Data = null
                };
            }
            catch (Exception msg)
            {
                return new PP<RESPONSE2>
                {
                    Result = false,
                    Message = msg.Message.ToString(),
                    Data = null
                };
            }
        }
        public PP<RESPONSE2> WEB_UPDATE_PTM(DataTable dt, string USERID)
        {
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var BATCH_EMP = dt.Rows[i]["BATCH_EMP"].ToString();
                    var PERSONALITY = dt.Rows[i]["PERSONALITY"].ToString();
                    var THINKING_STY = dt.Rows[i]["THINKING_STY"].ToString();
                    var WORKING_STY = dt.Rows[i]["WORKING_STY"].ToString();
                    var MDCL_TST = dt.Rows[i]["MDCL_TST"].ToBoolean();
                    SQL = @"EXEC [WEB_UPDATE_PTM] '" + BATCH_EMP + "','" + PERSONALITY + "','" + THINKING_STY + "','" + WORKING_STY + "'," + MDCL_TST + ",'"+ USERID + "'";
                    using (ClassMSSQL s = new ClassMSSQL())
                    {
                        DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                    }
                }
                var DATA = (from ROW in DATATABLE.AsEnumerable()
                            select new RESPONSE2
                            {
                                RESULT = ROW["RESULT"].ToBoolean(),
                                MESSAGE = ROW["MESSAGE"].ToString()

                            }).FirstOrDefault();

                return new PP<RESPONSE2>
                {
                    Result = DATA.RESULT,
                    Message = DATA.MESSAGE,
                    Data = null
                };
            }
            catch (Exception msg)
            {
                return new PP<RESPONSE2>
                {
                    Result = false,
                    Message = msg.Message.ToString(),
                    Data = null
                };
            }
        }
        public DataTable EXPORT1(string BatchNo)
        {
            DataTable dt = new DataTable();
            SQL = @"EXEC [SP_EXPORT1] '"+ BatchNo + "'";
            var param = new List<ctSqlVariable>();
            using (ClassMSSQL s = new ClassMSSQL())
            {
                DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
            }
            return DATATABLE;
        }
        public DataTable EXPORTPERSONALITYANDMEDICAL(string BATCHNO, string CATEGORY)
        {
            DataTable dt = new DataTable();
            SQL = @"EXEC [SP_EXPORTPERSONALITYANDMEDICAL] '" + BATCHNO + "','" + CATEGORY + "'";
            var param = new List<ctSqlVariable>();
            using (ClassMSSQL s = new ClassMSSQL())
            {
                DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
            }
            return DATATABLE;
        }
        public PP<RESPONSE2> WEB_INTERVIEWBOARD_SAVE_WRITTEN_DMR(List<FILE_DMR> MODEL, string USEID)
        {
            try
            {
                for (int i = 0; i < MODEL.Count; i++)
                {
                    System.Threading.Thread.Sleep(200);
                    var WA = "";
                    if(MODEL[i].WHATSAPP.Replace("\r\n", "").StartsWith("08"))
                    {
                        var WA1 = MODEL[i].WHATSAPP.Replace("\r\n", "").Substring(0,2);
                        var WA2 = MODEL[i].WHATSAPP.Replace("\r\n", "").Substring(2);
                        WA1 = WA1.Replace("08","+628");
                        WA = WA1 + WA2;
                    }
                    SQL = @"EXEC [WEB_INTERVIEWBOARD_SAVE_WRITTEN_DMR] '" + MODEL[i].BATCH_NO.Replace("\r\n", "") + "','" + WA + "'," + MODEL[i].IQ + "," + MODEL[i].MTK + "," + MODEL[i].ACC + "," + MODEL[i].ENG + "," + MODEL[i].TOTAL + ",'" + USEID + "'";
                    using (ClassMSSQL s = new ClassMSSQL())
                    {
                        DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                    }
                }
                
                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new RESPONSE2()
                             {
                                 RESULT = row["RESULT"].ToBoolean(),
                                 MESSAGE = (row["MESSAGE"].ToString() == null) ? "" : row["MESSAGE"].ToString(),
                             }).ToList();
                return new PP<RESPONSE2>
                {
                    Result = true,
                    Message = "SUCCESS",
                    Data = null
                };
            }
            catch (Exception msg)
            {
                SQL = @"EXEC [WEB_INTERVIEWBOARD_UNDO_WRITTEN_DMR] '" + MODEL[0].BATCH_NO.Replace("\r\n", "") + "'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                return new PP<RESPONSE2>
                {
                    Result = false,
                    Message = msg.Message.ToString(),
                    Data = null
                };
            }
        }
        public List<USER_REPORT> WEB_GETTABLE_REPORT(string STATUS)
        {
            try
            {
                SQL = @"SELECT * FROM USER_REPORT WHERE REPORT_STATUS  = '"+ STATUS + "' ORDER BY REPORT_ID DESC";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new USER_REPORT()
                             {

                                 BATCH_NO = (row["BATCH_NO"].ToString() == null) ? "" : row["BATCH_NO"].ToString(),
                                 BATCH_EMP = (row["BATCH_EMP"].ToString() == null) ? "" : row["BATCH_EMP"].ToString(),
                                 NAME_EMP = (row["NAME_EMP"].ToString() == null) ? "" : row["NAME_EMP"].ToString(),
                                 REPORT_ID = (row["REPORT_ID"].ToString() == null) ? "" : row["REPORT_ID"].ToString(),
                                 REPORT_CATE = (row["REPORT_CATE"].ToString() == null) ? "" : row["REPORT_CATE"].ToString(),
                                 REPORT_DESC = (row["REPORT_DESC"].ToString() == null) ? "" : row["REPORT_DESC"].ToString(),
                                 REPORT_IMG = (row["REPORT_IMG"].ToString() == null) ? "" : row["REPORT_IMG"].ToString(),
                                 REPORT_STATUS = (row["REPORT_STATUS"].ToString() == null) ? "" : row["REPORT_STATUS"].ToString(),
                                 UPDT_TIME = (row["UPDT_TIME"].ToString() == null) ? "" : row["UPDT_TIME"].ToString(),
                                 UPDT_USER= (row["UPDT_USER"].ToString() == null) ? "" : row["UPDT_USER"].ToString(),
                             }).ToList();

                return DATA0;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public List<USER_REPORT> WEB_GET_DETAIL_REPORT(string REPORTID)
        {
            try
            {
                SQL = @"SELECT * FROM USER_REPORT WHERE REPORT_ID = '"+ REPORTID + "'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new USER_REPORT()
                             {

                                 BATCH_NO = (row["BATCH_NO"].ToString() == null) ? "" : row["BATCH_NO"].ToString(),
                                 BATCH_EMP = (row["BATCH_EMP"].ToString() == null) ? "" : row["BATCH_EMP"].ToString(),
                                 NAME_EMP = (row["NAME_EMP"].ToString() == null) ? "" : row["NAME_EMP"].ToString(),
                                 REPORT_ID = (row["REPORT_ID"].ToString() == null) ? "" : row["REPORT_ID"].ToString(),
                                 REPORT_CATE = (row["REPORT_CATE"].ToString() == null) ? "" : row["REPORT_CATE"].ToString(),
                                 REPORT_DESC = (row["REPORT_DESC"].ToString() == null) ? "" : row["REPORT_DESC"].ToString(),
                                 REPORT_IMG = (row["REPORT_IMG"].ToString() == null) ? "" : row["REPORT_IMG"].ToString(),
                                 REPORT_STATUS = (row["REPORT_STATUS"].ToString() == null) ? "" : row["REPORT_STATUS"].ToString(),
                                 REPORT_ACTION = (row["REPORT_ACTION"].ToString() == null) ? "" : row["REPORT_ACTION"].ToString(),
                                 UPDT_TIME = (row["UPDT_TIME"].ToString() == null) ? "" : row["UPDT_TIME"].ToString(),
                                 UPDT_USER = (row["UPDT_USER"].ToString() == null) ? "" : row["UPDT_USER"].ToString(),
                             }).ToList();

                return DATA0;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public PP<RESPONSE2> WEB_SAVE_DETAIL_REPORT(USER_REPORT MODEL, string USERID)
        {
            try
            {
                SQL = @"EXEC [WEB_SAVE_DETAIL_REPORT] '" + MODEL.REPORT_ID + "','" + MODEL.REPORT_STATUS + "','" + MODEL.REPORT_ACTION + "','" + USERID + "'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA = (from ROW in DATATABLE.AsEnumerable()
                            select new RESPONSE2
                            {
                                RESULT = ROW["RESULT"].ToBoolean(),
                                MESSAGE = ROW["MESSAGE"].ToString()

                            }).FirstOrDefault();

                return new PP<RESPONSE2>
                {
                    Result = DATA.RESULT,
                    Message = DATA.MESSAGE,
                    Data = null
                };
            }
            catch (Exception msg)
            {
                return new PP<RESPONSE2>
                {
                    Result = false,
                    Message = msg.Message.ToString(),
                    Data = null
                };
            }
        }
        public PP<RESPONSE2> WEB_CANDIDATE_DETAILS_SAVE(CANDIDATE_DETAILS2 MODEL)
        {
            try
            {
                string USERID = Sessions.GetUseID().ToString();
                if (MODEL.TYPE == "1")
                {
                    SQL = @"EXEC [WEB_CANDIDATE_DETAILS_SAVE_1] '" + USERID + "'," +
                            "'" + MODEL.BATCH_EMP + "'," +
                            "'" + MODEL.EMP_NAME + "'," +
                            "'" + MODEL.EMP_NIK + "'," +
                            "'" + MODEL.EMP_GANDER + "'," +
                            "'" + MODEL.EMP_MARITAL + "'," +
                            "'" + MODEL.EMP_HEIGHT + "'," +
                            "'" + MODEL.EMP_WEIGHT + "'," +
                            "'" + MODEL.EMP_BIRTHPLACE + "'," +
                            "'" + MODEL.EMP_BIRTHDATE + "'," +
                            "'" + MODEL.EMP_RELIGION + "'," +
                            "'" + MODEL.EMP_RACE + "'," +
                            "'" + MODEL.EMP_MOBILE + "'," +
                            "'" + MODEL.EMP_TELEGRAM + "'," +
                            "'" + MODEL.EMP_WHATSAPP + "'," +
                            "'" + MODEL.EMP_EMAIL + "'," +
                            "'" + MODEL.EMP_LINKEDIN + "'," +
                            "'" + MODEL.EMP_ADDRESS + "'," +
                            "'" + MODEL.EMP_BLOK + "'," +
                            "'" + MODEL.EMP_NOMOR + "'," +
                            "'" + MODEL.EMP_RT + "'," +
                            "'" + MODEL.EMP_RW + "'," +
                            "'" + MODEL.EMP_SHIRT_SIZE + "'," +
                            "'" + MODEL.EMP_PANTS_SIZE + "'";
                }
                else if (MODEL.TYPE == "2")
                {
                    SQL = @"EXEC [WEB_CANDIDATE_DETAILS_SAVE_2] '" + USERID + "'," +
                        "'" + MODEL.BATCH_EMP + "'," +
                        "'" + MODEL.EMP_NOKK + "'," +
                        "" + MODEL.EMP_FATHER_ALIVE + "," +
                        "'" + MODEL.EMP_FATHER_NAME + "'," +
                        "'" + MODEL.EMP_FATHER_AGE + "'," +
                        "'" + MODEL.EMP_FATHER_JOB + "'," +
                        "'" + MODEL.EMP_NIK_FATHER + "'," +
                        "'" + MODEL.EMP_FATHER_BIRTHPLACE + "'," +
                        "'" + MODEL.EMP_FATHER_BIRTHDAY + "'," +
                        "'" + MODEL.EMP_FATHER_MOBILE + "'," +
                        "" + MODEL.EMP_MOTHER_ALIVE + "," +
                        "'" + MODEL.EMP_MOTHER_NAME + "'," +
                        "'" + MODEL.EMP_MOTHER_AGE + "'," +
                        "'" + MODEL.EMP_MOTHER_JOB + "'," +
                        "'" + MODEL.EMP_NIK_MOTHER + "'," +
                        "'" + MODEL.EMP_MOTHER_BIRTHPLACE + "'," +
                        "'" + MODEL.EMP_MOTHER_BIRTHDAY + "'," +
                        "'" + MODEL.EMP_MOTHER_MOBILE + "'";
                }
                else if (MODEL.TYPE == "3")
                {
                    SQL = @"EXEC [WEB_CANDIDATE_DETAILS_SAVE_3] '" + USERID + "'," +
                        "'" + MODEL.BATCH_EMP + "'," +
                        ""  + MODEL.EMP_ISFAMILY + "," +
                        "'" + MODEL.EMP_WIFE_NAME + "'," +
                        "'" + MODEL.EMP_WIFE_NIK + "'," +
                        "'" + MODEL.EMP_WIFE_BIRTH_PLACE + "'," +
                        "'" + MODEL.EMP_WIFE_BIRTH_DATE + "'," +
                        "'" + MODEL.EMP_WIFE_MOBILE + "'";
                }
                else if (MODEL.TYPE == "4")
                {
                    SQL = @"EXEC [WEB_CANDIDATE_DETAILS_SAVE_4] '" + USERID + "'," +
                        "'" + MODEL.BATCH_EMP + "'," +
                        "'" + MODEL.EMP_EM_NAME + "'," +
                        "'" + MODEL.EMP_EM_REL + "'," +
                        "'" + MODEL.EMP_EM_MOBILE + "'," +
                        "'" + MODEL.EMP_EM_ADDR + "'," +
                        "'" + MODEL.EMP_EM_RT + "'," +
                        "'" + MODEL.EMP_EM_RW + "'," +
                        "'" + MODEL.EMP_EM_PROVINSI + "'," +
                        "'" + MODEL.EMP_EM_KABUPATEN + "'," +
                        "'" + MODEL.EMP_EM_KECAMATAN + "'," +
                        "'" + MODEL.EMP_EM_KELURAHAN + "'";
                }
                else if (MODEL.TYPE == "5")
                {
                    SQL = @"EXEC [WEB_CANDIDATE_DETAILS_SAVE_5] '" + USERID + "'," +
                        "'" + MODEL.BATCH_EMP + "'," +
                        "'" + MODEL.EMP_LAST_EDU + "'," +
                        "'" + MODEL.EMP_SCHOOL_NAME + "'," +
                        "'" + MODEL.EMP_SCHOOL_MAJOR + "'," +
                        "'" + MODEL.EMP_FACULTY + "'," +
                        "'" + MODEL.EMP_GRADUATE_YEAR + "'," +
                        "'" + MODEL.EMP_GRADUATE_PLACE + "'," +
                        "'" + MODEL.EMP_GRADUATE_COUNTRY + "'," +
                        "'" + MODEL.EMP_GRADUATE_DISTRICT + "'," +
                        "'" + MODEL.EMP_GRADUATE_CITY + "'," +
                        "" + MODEL.EMP_AVG_SCORE + "," +
                        "'" + MODEL.EMP_CERT_NO + "'," +
                        "" + MODEL.EMP_HOLD_WILLINGLY + "";
                }
                else if (MODEL.TYPE == "6")
                {
                    return new PP<RESPONSE2>
                    {
                        Result = false,
                        Message = "Sorry, this feature unavailable at this moment.",
                        Data = null
                    };
                }
                else if (MODEL.TYPE == "7")
                {
                    SQL = @"EXEC [WEB_CANDIDATE_DETAILS_SAVE_7] '" + USERID + "'," +
                        "'" + MODEL.BATCH_EMP + "'," +
                        "'" + MODEL.EMP_MOTIVASI + "'," +
                        "'" + MODEL.EMP_KOMITMEN + "'," +
                        "" + MODEL.EMP_LEFT_HANDED + "," +
                        "" + MODEL.EMP_CRIME + "," +
                        "" + MODEL.EMP_MENTAL_DISEASE + "," +
                        "" + MODEL.EMP_WORKED_ON_SHIMANO + "," +
                        "'" + MODEL.EMP_SHAMANO_START + "'," +
                        "'" + MODEL.EMP_SHIMANO_END + "'," +
                        "" + MODEL.EMP_SAPORCOMP + "," +
                        "" + MODEL.EMP_EYE_CHECK + "," +
                        "'" + MODEL.EMP_EYE_VALUE + "'," +
                        "" + MODEL.EMP_EYE_GLASSES + "," +
                        "" + MODEL.EMP_STUDY_PLAN + "," +
                        "" + MODEL.EMP_SMOKING + "," +
                        "'" + MODEL.EMP_LAST_SMOKING + "'";
                }
                else if (MODEL.TYPE == "8")
                {
                    SQL = @"EXEC [WEB_CANDIDATE_DETAILS_SAVE_8] '" + USERID + "'," +
                        "'" + MODEL.BATCH_EMP + "'," +
                        "'" + MODEL.EMP_ACCOUNT_BCA + "'," +
                        "'" + MODEL.EMP_ACCOUNT_NPWP + "'," +
                        "'" + MODEL.EMP_ACCOUNT_EFIN + "'," +
                        "'" + MODEL.EMP_ACCOUNT_BPJS_KES + "'," +
                        "'" + MODEL.EMP_ACCOUNT_BPJS_TKJ + "'";
                }
                else if (MODEL.TYPE == "9")
                {
                    SQL = @"EXEC [WEB_CANDIDATE_DETAILS_SAVE_9] '" + USERID + "'," +
                        "'" + MODEL.BATCH_EMP + "'," +
                        "'" + MODEL.EMP_PERSONALITY + "'," +
                        "'" + MODEL.EMP_THINKING_STY + "'," +
                        "'" + MODEL.EMP_WORKING_STY + "'," +
                        "" + MODEL.EMP_TEST_IQ + "," +
                        "" + MODEL.EMP_TEST_MTH + "," +
                        "" + MODEL.EMP_TEST_ACC + "," +
                        "" + MODEL.EMP_TEST_ENG + "," +
                        "" + MODEL.EMP_WRITTEN_SCORE + "," +
                        "'" + MODEL.EMP_TEST_1 + "'," +
                        "'" + MODEL.EMP_TIME_TEST_1 + "'," +
                        "'" + MODEL.EMP_TEST_2 + "'," +
                        "'" + MODEL.EMP_TIME_TEST_2 + "'," +
                        "" + MODEL.EMP_PRACTICAL_SCORE + "," +
                        "'" + MODEL.EMP_REMARK + "'," +
                        "" + MODEL.EMP_MEMORY_SCORE + "," +
                        "" + MODEL.EMP_ATTN_EMP + "," +
                        "" + MODEL.EMP_MDCL_TST + "," +
                        "" + MODEL.EMP_FIN_DES + "," +                       
                        "'" + MODEL.EMP_SUM_REMARK + "'";
                }
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA = (from ROW in DATATABLE.AsEnumerable()
                            select new RESPONSE2
                            {
                                RESULT = ROW["RESULT"].ToBoolean(),
                                MESSAGE = ROW["MESSAGE"].ToString()

                            }).FirstOrDefault();
                return new PP<RESPONSE2>
                {
                    Result = DATA.RESULT,
                    Message = DATA.MESSAGE,
                    Data = null
                };
            }
            catch (Exception msg)
            {
                return new PP<RESPONSE2>
                {
                    Result = false,
                    Message = msg.Message.ToString(),
                    Data = null
                };
            }
        }
        public PP<RESPONSE2> WEB_CANDIDATE_DETAILS_SAVE_SIBLINGS(List<CANDIDATE_DETAILS_SIBLINGS> MODEL)
        {
            try
            {
                string USERID = Sessions.GetUseID().ToString();
                for (int i = 0; i < MODEL.Count; i++)
                {
                    SQL =  @"EXEC [WEB_CANDIDATE_DETAILS_SAVE_2_SIBLINGS]
                            '" + USERID + "'," +
                            "'" + MODEL[i].ID.Replace("\r\n", "") + "'," +
                            "'" + MODEL[i].NAME.Replace("\r\n", "") + "'," +
                            "'" + MODEL[i].AGE.Replace("\r\n", "") + "'," +
                            "'" + MODEL[i].JOB.Replace("\r\n", "") + "'";
                    using (ClassMSSQL s = new ClassMSSQL())
                    {
                        DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                    }
                }

                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new RESPONSE2()
                             {
                                 RESULT = row["RESULT"].ToBoolean(),
                                 MESSAGE = (row["MESSAGE"].ToString() == null) ? "" : row["MESSAGE"].ToString(),
                             }).ToList();

                return new PP<RESPONSE2>
                {
                    Result = DATA0[0].RESULT,
                    Message = DATA0[0].MESSAGE,
                    Data = null
                };
            }
            catch(Exception msg)
            {
                return new PP<RESPONSE2>
                {
                    Result = false,
                    Message = msg.Message.ToString(),
                    Data = null
                };
            }
        }
        public PP<RESPONSE2> WEB_CANDIDATE_DETAILS_SAVE_LANGUAGES(List<CANDIDATE_DETAILS_LANGUAGE> MODEL)
        {
            try
            {
                string USERID = Sessions.GetUseID().ToString();
                for (int i = 0; i < MODEL.Count; i++)
                {
                    SQL = @"EXEC [WEB_CANDIDATE_DETAILS_SAVE_2_LANGUAGES]
                            '" + USERID + "'," +
                            "'" + MODEL[i].LANGUAGE_ID.Replace("\r\n", "") + "'," +
                            "'" + MODEL[i].LANGUAGE.Replace("\r\n", "") + "'," +
                            "'" + MODEL[i].LEVEL.Replace("\r\n", "") + "'";
                    using (ClassMSSQL s = new ClassMSSQL())
                    {
                        DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                    }
                }

                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new RESPONSE2()
                             {
                                 RESULT = row["RESULT"].ToBoolean(),
                                 MESSAGE = (row["MESSAGE"].ToString() == null) ? "" : row["MESSAGE"].ToString(),
                             }).ToList();

                return new PP<RESPONSE2>
                {
                    Result = DATA0[0].RESULT,
                    Message = DATA0[0].MESSAGE,
                    Data = null
                };
            }
            catch (Exception msg)
            {
                return new PP<RESPONSE2>
                {
                    Result = false,
                    Message = msg.Message.ToString(),
                    Data = null
                };
            }
        }
        public DataTable EXPORT2(string BatchNo)
        {
            DataTable dt = new DataTable();
            SQL = @"EXEC [SP_EXPORT2] '" + BatchNo + "'";
            var param = new List<ctSqlVariable>();
            using (ClassMSSQL s = new ClassMSSQL())
            {
                DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
            }
            return DATATABLE;
        }
        public DataTable SP_EXPORTEXCEL_INBOX(string BATCHNO, string STATUS)
        {
            DataTable dt = new DataTable();
            SQL = @"EXEC [SP_EXPORTEXCEL_INBOX] '" + BATCHNO + "','" + STATUS + "'";
            var param = new List<ctSqlVariable>();
            using (ClassMSSQL s = new ClassMSSQL())
            {
                DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
            }
            return DATATABLE;
        }
    }
}