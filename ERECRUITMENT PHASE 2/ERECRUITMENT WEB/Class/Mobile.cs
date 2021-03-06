using ERECRUITMENT_WEB.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ERECRUITMENT_WEB.Class
{
    public class Mobile
    {
        DataTable DATATABLE;
        string SQL = "";
        public string EREC_CON = ConfigurationManager.ConnectionStrings["EREC_CON"].ToString();

        public List<MOBILE_DASHBOARD> GET_MOBILE_DASHBOARD(string INVITATION)
        {
            try
            {
                SQL = @"EXEC [GET_MOBILE_DASHBOARD] '" + INVITATION + "'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new MOBILE_DASHBOARD()
                             {
                                 NAMEEMP = (row["NAMEEMP"].ToString() == null) ? "" : row["NAMEEMP"].ToString(),
                                 PHONE = (row["PHONE"].ToString() == null) ? "" : row["PHONE"].ToString(),
                                 MESSAGEHEADER = (row["MESSAGEHEADER"].ToString() == null) ? "" : row["MESSAGEHEADER"].ToString(),
                                 MESSAGEBODY = (row["MESSAGEBODY"].ToString() == null) ? "" : row["MESSAGEBODY"].ToString(),
                                 IMAGEDASHBOARD = (row["IMAGEDASHBOARD"].ToString() == null) ? "" : row["IMAGEDASHBOARD"].ToString(),

                             }).ToList();
                return DATA0;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public PP<RESPONSE2> MOBILE_SAVE_PERSONALFORM(USER_PROFILE MODEL, string KTP_DIR, string PASFOTO_DIR)
        {
            try
            {
                if(MODEL.EXPIRE_TYPE == true)
                {
                    MODEL.EXPIRE_DATE = Convert.ToDateTime("01-01-2999").ToString();
                }
                string LINKEDIN = (MODEL.LINKEDIN == null) ? "" : MODEL.LINKEDIN.ToString().Replace("\r\n", "");
                SQL = @"EXEC [MOBILE_SAVE_PERSONALFORM] 
                      '"  + MODEL.BATCH_EMP.Replace("\r\n", "") + "'," +
                      "'" + MODEL.NIK.Replace("\r\n","") + "'," +
                      "" + MODEL.EXPIRE_TYPE + "," +
                      "'" + MODEL.EXPIRE_DATE + "'," +
                      "'" + MODEL.RACE.Replace("\r\n", "") + "'," +
                      "'" + MODEL.RELIGION.Replace("\r\n", "") + "'," +
                      "'" + MODEL.PHONE.Replace("\r\n", "") + "'," +
                      "'" + MODEL.EMAIL.Replace("\r\n", "") + "'," +
                      "'" + MODEL.WHATSAPP.Replace("\r\n", "") + "'," +
                      "'" + MODEL.TELEGRAM.Replace("\r\n", "") + "'," +
                      "'" + LINKEDIN + "'," +
                      "'" + MODEL.GANDER.Replace("\r\n", "") + "'," +
                      ""  + MODEL.AGE + "," +
                      "'" + MODEL.MARITAL.Replace("\r\n", "") + "',"+
                      ""  + MODEL.LEFT_HANDED + "," +
                      ""  + MODEL.HEIGHT + "," +
                      ""  + MODEL.WEIGHT + "," +
                      "'" + MODEL.ADDRESS + "'," +
                      "'" + MODEL.BLOK + "'," +
                      "'" + MODEL.NOMOR + "'," +
                      "'" + MODEL.RT + "'," +
                      "'" + MODEL.RW + "'," +
                      "'" + MODEL.KECAMATAN + "'," +
                      "'" + MODEL.KELURAHAN + "'," +
                      "'" + KTP_DIR + "'," +
                      "'" + PASFOTO_DIR + "',"+
                      "'" + MODEL.BIRTHDATE + "'," +
                      "'" + MODEL.BIRTHPLACE + "'," +
                      "'" + MODEL.HOME_STATUS + "'";

                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
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
        public PP<RESPONSE2> MOBILE_SAVE_FAMILYFORM(USER_FAMILY MODEL, string KK_DIR)
        {
            try
            {
                SQL = @"EXEC [MOBILE_SAVE_FAMILYFORM] 
                      '"  + MODEL.BATCH_EMP.Replace("\r\n", "") + "','" + MODEL.NOKK.Replace("\r\n", "") + "','" + MODEL.FATHER_NAME.Replace("\r\n", "") + "'," +
                      "'" + MODEL.FATHER_AGE.Replace("\r\n", "") + "','" + MODEL.FATHER_JOB.Replace("\r\n", "") + "'," +
                      "'" + MODEL.MOTHER_NAME.Replace("\r\n", "") + "','" + MODEL.MOTHER_AGE.Replace("\r\n", "") + "'," +
                      "'" + MODEL.MOTHER_JOB.Replace("\r\n", "") + "','" + KK_DIR.Replace("\r\n", "") + "'";

                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
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
        public PP<RESPONSE2> MOBILE_SAVE_EDUCATIONFORM(USER_EDUCATION MODEL, string IJAZAH_DIR_F, string IJAZAH_DIR_B)
        {
            try
            {
                SQL = @"EXEC [MOBILE_SAVE_EDUCATIONFORM]
                      '"  + MODEL.BATCH_EMP.Replace("\r\n", "")      + "'," +
                      "'" + MODEL.LAST_EDU.Replace("\r\n", "")       + "'," +
                      "'" + MODEL.SCHOOL_NAME.Replace("\r\n", "")    + "'," +
                      "'" + MODEL.SCHOOL_MAJOR.Replace("\r\n", "")   + "'," +
                      "'" + MODEL.SCHOOL_FACULTY.Replace("\r\n", "") + "'," +
                      "'" + MODEL.GRADUATE_YEAR.Replace("\r\n", "")  + "'," +
                      "'" + (MODEL.GRADUATE_PLACE == null ? "" : MODEL.GRADUATE_PLACE.Replace("\r\n", "")) + "'," +
                      "'" + (MODEL.GRADUATE_COUNTRY == null ? "" : MODEL.GRADUATE_COUNTRY.Replace("\r\n", "")) + "'," +
                      "'" + (MODEL.GRADUATE_DISTRICT == null ? "" : MODEL.GRADUATE_DISTRICT.Replace("\r\n", "")) + "'," +
                      "'" + (MODEL.GRADUATE_CITY == null ? "" : MODEL.GRADUATE_CITY.Replace("\r\n", "")) + "'," +
                      ""  + MODEL.AVG_SCORE + "," +
                      "'" + MODEL.CERT_NO.Replace("\r\n", "") + "'," +
                      "'" + IJAZAH_DIR_F.Replace("\r\n", "") + "'," +
                      "'" + IJAZAH_DIR_B.Replace("\r\n", "") + "'," +
                      "" + MODEL.HOLD_WILLINGLY + "";

                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
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
        public PP<RESPONSE2> MOBILE_SAVE_SIBLINGSFORM(List<USER_SIBLINGS> MODEL)
        {
            try
            {
                if(MODEL.Count == 1)
                {
                    if((MODEL[0].SIBLINGS_NAME == null) && (MODEL[0].SIBLINGS_AGE == null) && (MODEL[0].SIBLINGS_JOB == null))
                    {
                        return new PP<RESPONSE2>
                        {
                            Result = true,
                            Message = "SUCCESS",
                            Data = null
                        };
                    }
                    else
                    {
                        for (int i = 0; i < MODEL.Count; i++)
                        {
                            Guid SIBLINGS_ID = Guid.NewGuid();
                            SQL = @"EXEC [MOBILE_SAVE_SIBLINGSFORM] 
                                    '"  + MODEL[i].BATCH_EMP.Replace("\r\n", "") + "'," +
                                    "'" + SIBLINGS_ID.ToString().ToUpper() + "'," +
                                    "'" + MODEL[i].SIBLINGS_NAME.Replace("\r\n", "") + "'," +
                                    "'" + MODEL[i].SIBLINGS_AGE.Replace("\r\n", "") + "'," +
                                    "'" + MODEL[i].SIBLINGS_JOB.Replace("\r\n", "") + "'";
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
                }
                else
                {
                    for (int i = 0; i < MODEL.Count; i++)
                    {
                        Guid SIBLINGS_ID = Guid.NewGuid();
                        SQL = @"EXEC [MOBILE_SAVE_SIBLINGSFORM] 
                                    '" + MODEL[i].BATCH_EMP.Replace("\r\n", "") + "'," +
                                "'" + SIBLINGS_ID.ToString().ToUpper() + "'," +
                                "'" + MODEL[i].SIBLINGS_NAME.Replace("\r\n", "") + "'," +
                                "'" + MODEL[i].SIBLINGS_AGE.Replace("\r\n", "") + "'," +
                                "'" + MODEL[i].SIBLINGS_JOB.Replace("\r\n", "") + "'";
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
        public PP<RESPONSE2> GET_MOBILE_CANEDIT_PERSONALFORM(string UNIQUEID)
        {
            try
            {
                SQL = @"EXEC [MOBILE_CHECK_CANEDIT_PERSONALFORM] '" + UNIQUEID + "'";

                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new RESPONSE2()
                             {
                                 RESULT  = row["RESULT"].ToBoolean(),
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
        public PP<RESPONSE2> GET_MOBILE_CANEDIT_FAMILYFORM(string UNIQUEID)
        {
            try
            {
                SQL = @"EXEC [MOBILE_CHECK_CANEDIT_FAMILYFORM] '" + UNIQUEID + "'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
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
        public PP<RESPONSE2> GET_MOBILE_CANEDIT_EDUCATIONFORM(string UNIQUEID)
        {
            try
            {
                SQL = @"EXEC [MOBILE_CHECK_CANEDIT_EDUCATIONFORM] '" + UNIQUEID + "'";

                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
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
        public PP<RESPONSE2> GET_MOBILE_CANEDIT_LANGUAGEFORM(string UNIQUEID)
        {
            try
            {
                SQL = @"EXEC [MOBILE_CHECK_CANEDIT_LANGUAGEFORM] '" + UNIQUEID + "'";

                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
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
        public PP<RESPONSE2> MOBILE_SAVE_LANGUAGEFORM(List<USER_LANGUAGE> MODEL)
        {
            try
            {
                for (int i = 0; i < MODEL.Count; i++)
                {
                    Guid LANGUAGE_ID = new Guid();
                    SQL = @"EXEC [MOBILE_SAVE_LANGUAGEFORM] 
                            '" + MODEL[i].BATCH_EMP.Replace("\r\n", "") + "'," +
                            "'" + LANGUAGE_ID.ToString().ToUpper() + "'," +
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
        public PP<RESPONSE2> GET_MOBILE_CANEDIT_WORKEXPFORM(string UNIQUEID)
        {
            try
            {
                SQL = @"EXEC [MOBILE_CHECK_CANEDIT_WORKEXPFORM] '" + UNIQUEID + "'";

                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
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
        public PP<RESPONSE2> MOBILE_SAVE_WORKEXPFORM(List<USER_WORKEXP> MODEL)
        {
            try
            {
                if(MODEL.Count == 1)
                {
                    SQL = @"EXEC [MOBILE_SAVE_WORKEXPFORM] 
                            '"  + MODEL[0].BATCH_EMP + "'," +
                            ""  + MODEL[0].ISEXPERIENCED + "," +
                            "'" + MODEL[0].COMPANY_NAME + "'," +
                            "'" + MODEL[0].POSITION + "'," +
                            "'" + MODEL[0].START_YEAR + "'," +
                            "'" + MODEL[0].END_YEAR + "'," +
                            "'" + MODEL[0].REASON_LEAVE + "'," +
                            "'" + MODEL[0].CERT_PHOTO + "'";
                    using (ClassMSSQL s = new ClassMSSQL())
                    {
                        DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                    }
                }
                else
                {
                    for (int i = 0; i < MODEL.Count; i++)
                    {
                        SQL = @"EXEC [MOBILE_SAVE_WORKEXPFORM] 
                            '"  + MODEL[i].BATCH_EMP + "'," +
                            ""  + MODEL[i].ISEXPERIENCED + "," +
                            "'" + MODEL[i].COMPANY_NAME + "'," +
                            "'" + MODEL[i].POSITION + "'," +
                            "'" + MODEL[i].START_YEAR + "'," +
                            "'" + MODEL[i].END_YEAR + "'," +
                            "'" + MODEL[i].REASON_LEAVE + "'," +
                            "'" + MODEL[i].CERT_PHOTO + "'";

                        using (ClassMSSQL s = new ClassMSSQL())
                        {
                            DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                        }
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
        public PP<RESPONSE2> GET_MOBILE_CANEDIT_ADDITIONALFORM(string UNIQUEID)
        {
            try
            {
                SQL = @"EXEC [MOBILE_CHECK_CANEDIT_ADDITIONALFORM] '" + UNIQUEID + "'";

                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
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
        public PP<RESPONSE2> MOBILE_SAVE_ADDITIONALFORM(USER_ADDITIONAL MODEL, string CV, string CL)
        {
            try
            {
                SQL = @"EXEC [MOBILE_SAVE_ADDITIONALFORM]
                      '" + MODEL.BATCH_EMP.Replace("\r\n", "") + "'," +
                      "'" + MODEL.MOTIVASI.Replace("\r\n", "") + "'," +
                      "'" + MODEL.KOMITMEN.Replace("\r\n", "") + "'," +
                      "" + MODEL.CRIME + "," +
                      "" + MODEL.MENTAL_DISEASE + "," +
                      "" + MODEL.WORKED_ON_SHIMANO + "," +
                      "'" + MODEL.SHAMANO_START + "'," +
                      "'" + MODEL.SHIMANO_END + "'," +
                      "" + MODEL.STUDY_PLAN + "," +
                      "" + MODEL.EYECHECK + "," +
                      "'" + MODEL.EYEVALUE + "'," +
                      "" + MODEL.SMOKING + "," +
                      "'" + MODEL.LAST_SMOKING + "'," +
                      "" + MODEL.ACCEPT_TERMS + ","+
                      "'" + CV + "',"+
                      "'" + CL + "'";

                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
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

        public PP<RESPONSE2> GET_MOBILE_GATENAME_UNIFORM(string UNIQUEID)
        {
            try
            {
                SQL = @"EXEC [MOBILE_MOBILE_GATENAME_UNIFORM] '" + UNIQUEID + "'";

                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
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

        public PP<RESPONSE2> MOBILE_SAVE_UNIFORMFORM(USER_UNIFORM MODEL)
        {
            try
            {
                SQL = @"EXEC [MOBILE_SAVE_USERUNIFORM] '" + MODEL.BATCH_EMP+"','"+MODEL.SHIRT_SIZE+ "','" + MODEL.PANTS_SIZE + "'";

                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
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

        public PP<RESPONSE2> MOBILE_SAVE_EMERGENCYCONTACT(USER_EMERGENCY MODEL)
        {
            try
            {
                SQL = @"EXEC [MOBILE_SAVE_EMERGENCYCONTACT] '" + MODEL.BATCH_EMP + "'," +
                    "'" + MODEL.EM_NAME + "'," +
                    "'" + MODEL.EM_REL + "'," +
                    "'" + MODEL.EM_JOB + "'," +
                    "'" + MODEL.EM_MOBILE + "'," +
                    "'" + MODEL.EM_ADDR + "'," +
                    "'" + MODEL.EM_BLOK + "'," +
                    "'" + MODEL.EM_NO + "'," +
                    "'" + MODEL.EM_RT + "'," +
                    "'" + MODEL.EM_RW + "'," +
                    "'" + MODEL.EM_PROVINSI + "'," +
                    "'" + MODEL.EM_KABUPATEN + "'," +
                    "'" + MODEL.EM_KECAMATAN + "'," +
                    "'" + MODEL.EM_KELURAHAN + "'";

                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
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
        public PP<RESPONSE2> MOBILE_GET_MOBILE_GOTOFORM(string UNIQUEID)
        {
            try
            {
                SQL = @"EXEC [MOBILE_GET_MOBILE_GOTOFORM] '" + UNIQUEID + "'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
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
        public PP<USER_FAMILY> GET_MOBILE_GETPARENTS(string UNIQUEID)
        {
            try
            {
                SQL = @"EXEC [GET_MOBILE_GETPARENTS] '" + UNIQUEID + "'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new USER_FAMILY()
                             {
                                 NOKK = (row["NOKK"].ToString() == null) ? "" : row["NOKK"].ToString(),
                                 FATHER_NAME = (row["FATHER_NAME"].ToString() == null) ? "" : row["FATHER_NAME"].ToString(),
                                 MOTHER_NAME = (row["MOTHER_NAME"].ToString() == null) ? "" : row["MOTHER_NAME"].ToString(),

                             }).FirstOrDefault();

                return new PP<USER_FAMILY>
                {
                    Result = true,
                    Message = "SUCCESS",
                    Data = DATA0
                };
            }
            catch (Exception msg)
            {
                return new PP<USER_FAMILY>
                {
                    Result = false,
                    Message = msg.Message.ToString(),
                    Data = null
                };
            }
        }
        public PP<RESPONSE2> MOBILE_SAVE_FAMILYBACKGROUND(USER_FAMILY MODEL)
        {
            try
            {
                SQL = @"EXEC [MOBILE_SAVE_FAMILYBACKGROUND] '" + MODEL.BATCH_EMP + "'," +
                    ""  + MODEL.FATHER_ALIVE + "," +
                    "'" + MODEL.FATHER_NIK + "'," +
                    "'" + MODEL.FATHER_BIRTHPLACE + "'," +
                    "'" + MODEL.FATHER_BIRTHDATE + "'," +
                    "'"  + MODEL.FATHER_MOBILE + "'," +

                    "" + MODEL.MOTHER_ALIVE + "," +
                    "'" + MODEL.MOTHER_NIK + "'," +
                    "'" + MODEL.MOTHER_BIRTHPLACE + "'," +
                    "'" + MODEL.MOTHER_BIRTHDATE + "'," +
                    "'" + MODEL.MOTHER_MOBILE + "'";

                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
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
        public PP<RESPONSE2> MOBILE_SAVE_SPOUSE(USER_SPOUSE MODEL)
        {
            try
            {
                SQL = @"EXEC [MOBILE_SAVE_SPOUSE_WIFE] 
                    '"  + MODEL.BATCH_EMP + "'," +
                    ""  + MODEL.ISFAMILY + "," +
                    "'" + MODEL.WIFE_NAME + "'," +
                    "'" + MODEL.WIFE_NIK + "'," +
                    "'" + MODEL.WIFE_BIRTH_PLACE + "'," +
                    "'" + MODEL.WIFE_BIRTH_DATE + "'," +
                    "'" + MODEL.WIFE_MOBILE + "'," +
                    "'" + MODEL.BNIKAH + "'";

                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
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
        public PP<RESPONSE2> MOBILE_SAVE_CHILD(List<USER_CHILD> MODEL)
        {
            try
            {
                for (int i = 0; i < MODEL.Count; i++)
                {
                    SQL = @"EXEC [MOBILE_SAVE_SPOUSE_CHILD] 
                            '" + MODEL[i].BATCH_EMP + "'," +
                            "'" + MODEL[i].CHILD_NAME + "'," +
                            "'" + MODEL[i].CHILD_NIK + "'," +
                            "'" + MODEL[i].CHILD_BIRTH_PLACE + "'," +
                            "'" + MODEL[i].CHILD_BIRTH_DATE + "'," +
                            "'" + MODEL[i].CHILD_MOBILE + "'," +
                            "'" + MODEL[i].CHILD_DOC + "'";

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
        public PP<RESPONSE2> MOBILE_SAVE_REFERENCE_PERSON(USER_REFERENCE MODEL)
        {
            try
            {
                SQL = @"EXEC [MOBILE_SAVE_REFERENCE_PERSON] '" + MODEL.BATCH_EMP + "'," +
                    "" + MODEL.ISREFERENCE + "," +
                    "'" + MODEL.REF_NAME + "'," +
                    "'" + MODEL.REF_TITLE + "'," +
                    "'" + MODEL.REF_COMPANY + "'," +
                    "'" + MODEL.REF_MOBILE + "'," +
                    "'" + MODEL.REF_EMAIL + "'";

                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
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
        public PP<RESPONSE2> MOBILE_SAVE_HEALTH(USER_HEALTH MODEL)
        {
            try
            {
                SQL = @"EXEC [MOBILE_SAVE_HEALTH] '" + MODEL.BATCH_EMP + "'," +
                    "" + MODEL.LIQUID_TINNER + "," +
                    "" + MODEL.STOMACH_ACID + "," +
                    "" + MODEL.PNEUMONIA + "," +
                    "" + MODEL.LUNG_DISEASE + "," +
                    "" + MODEL.ASTHMA + "," +
                    "" + MODEL.FRACTURE + "," +
                    "" + MODEL.SURGERY + "";

                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
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
        public PP<RESPONSE2> MOBILE_SAVE_DOCUMENT(USER_DOCUMENT MODEL, string IMG_BCA,
                string IMG_NPWP,
                string IMG_EFIN,
                string IMG_BPJS_KES,
                string IMG_BPJS_TKJ,
                string IMG_SIM_C,
                string IMG_VAKSIN,
                string IMG_SKCK,
                string IMG_SERTIFIKAT_KOMPETENSI,
                string IMG_PENGALAMAN,
                string IMG_SURAT_SEHAT,
                string IMG_KARTU_KUNING,
                string IMG_SIO)
        {
            try
            {
                SQL = @"EXEC [MOBILE_SAVE_USERDOCUMENT] '" + MODEL.BATCH_EMP + "'," +
                    "'" + MODEL.ACCOUNT_BCA + "'," +
                    "'" + MODEL.ACCOUNT_NPWP + "'," +
                    "'" + MODEL.ACCOUNT_EFIN + "'," +
                    "'" + MODEL.ACCOUNT_BPJS_KES + "'," +
                    "'" + MODEL.ACCOUNT_BPJS_TKJ + "'," +
                    "'" + IMG_BCA + "'," +
                    "'" + IMG_NPWP + "'," +
                    "'" + IMG_EFIN + "'," +
                    "'" + IMG_BPJS_KES + "'," +
                    "'" + IMG_BPJS_TKJ + "'," +
                    "'" + IMG_SIM_C + "'," +
                    "'" + IMG_VAKSIN + "'," +
                    "'" + IMG_SKCK + "'," +
                    "'" + IMG_SERTIFIKAT_KOMPETENSI + "'," +
                    "'" + IMG_PENGALAMAN + "'," +
                    "'" + IMG_SURAT_SEHAT + "'," +
                    "'" + IMG_KARTU_KUNING + "'," +
                    "'" + IMG_SIO + "'";

                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
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

        public PP<RESPONSE2> MOBILE_SAVE_REPORT(USER_REPORT MODEL, string REPORT_DIR)
        {
            try
            {
                string VAR = RandomString(8).ToString().ToUpper();
                SQL = @"EXEC [MOBILE_SAVE_REPORT] 
                    '" + MODEL.BATCH_EMP + "'," +
                    "'R-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-tt").ToUpper() + "-"+ VAR + "'," +
                    "'" + MODEL.REPORT_CATE + "'," +
                    "'" + MODEL.REPORT_DESC + "'," +
                    "'" + REPORT_DIR + "'";

                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
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
        string RandomString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[length];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            return finalString;
        }
    }
}