using ERECRUITMENT_WEB.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ERECRUITMENT_WEB.Class
{
    public class MasterData
    {
        DataTable DATATABLE;
        string SQL = "";
        public string EREC_CON = ConfigurationManager.ConnectionStrings["EREC_CON"].ToString();
        public List<MASTERDATA_RELIGION> WEB_GET_RELIGION()
        {
            try
            {
                SQL = @"EXEC [WEB_GET_RELIGION]";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new MASTERDATA_RELIGION()
                             {
                                 RELIGION = (row["RELIGION"].ToString() == null) ? "" : row["RELIGION"].ToString()
                             }).ToList();

                return DATA0;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public List<MASTERDATA_RACE> WEB_GET_RACE()
        {
            try
            {
                SQL = @"EXEC [WEB_GET_RACE]";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new MASTERDATA_RACE()
                             {

                                 RACE = (row["RACE"].ToString() == null) ? "" : row["RACE"].ToString()

                             }).ToList();

                return DATA0;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public List<MASTERDATA_EDU> WEB_GET_EDU()
        {
            try
            {
                SQL = @"EXEC [WEB_GET_EDU]";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new MASTERDATA_EDU()
                             {

                                 EDUCATION = (row["EDUCATION"].ToString() == null) ? "" : row["EDUCATION"].ToString().Replace("\r\n", "")

                             }).ToList();

                return DATA0;
            }
            catch (Exception msg)
            {
                return null;
            }
        }

        public List<MASTERDATA_PERSONALITY> WEB_GET_PERSONALITY()
        {
            try
            {
                SQL = @"EXEC [WEB_GET_PERSONALITY]";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new MASTERDATA_PERSONALITY()
                             {

                                 PERSONALITY = (row["PERSONALITY"].ToString() == null) ? "" : (row["PERSONALITY"].ToString().Replace("\r\n", ""))

                             }).ToList();

                return DATA0;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public List<MASTERDATA_THINKING_STY> WEB_GET_THINKING_STY()
        {
            try
            {
                SQL = @"EXEC [WEB_GET_THINKING_STY]";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new MASTERDATA_THINKING_STY()
                             {

                                 THINKING_STY = (row["THINKING_STY"].ToString() == null) ? "" : (row["THINKING_STY"].ToString().Replace("\r\n",""))

                             }).ToList();

                return DATA0;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public List<MASTERDATA_WORKING_STY> WEB_GET_WORKING_STY()
        {
            try
            {
                SQL = @"EXEC [WEB_GET_WORKING_STY]";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new MASTERDATA_WORKING_STY()
                             {

                                 WORKING_STY = (row["WORKING_STY"].ToString() == null) ? "" : (row["WORKING_STY"].ToString().Replace("\r\n", ""))

                             }).ToList();

                return DATA0;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public List<MASTERDATA_GENDER> MOBILE_GET_GENDER()
        {
            try
            {
                SQL = @"EXEC [MOBILE_GET_GENDER]";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new MASTERDATA_GENDER()
                             {
                                 VALUE = (row["VALUE"].ToString() == null) ? "" : (row["VALUE"].ToString().Replace("\r\n", "")),
                                 TEXT = (row["TEXT"].ToString() == null) ? "" : (row["TEXT"].ToString().Replace("\r\n", ""))
                             }).ToList();

                return DATA0;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public List<MASTERDATA_MARITAL> MOBILE_GET_MARITAL()
        {
            try
            {
                SQL = @"EXEC [MOBILE_GET_MARITAL]";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new MASTERDATA_MARITAL()
                             {
                                 VALUE = (row["VALUE"].ToString() == null) ? "" : (row["VALUE"].ToString().Replace("\r\n", "")),
                                 TEXT = (row["TEXT"].ToString() == null) ? "" : (row["TEXT"].ToString().Replace("\r\n", ""))
                             }).ToList();

                return DATA0;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public List<MASTERDATA_DISTRICT> MOBILE_GET_DISTRICT()
        {
            try
            {
                SQL = @"EXEC [MOBILE_GET_DISTRICT]";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new MASTERDATA_DISTRICT()
                             {
                                 VALUE = (row["VALUE"].ToString() == null) ? "" : (row["VALUE"].ToString().Replace("\r\n", "")),
                                 TEXT = (row["TEXT"].ToString() == null) ? "" : (row["TEXT"].ToString().Replace("\r\n", ""))
                             }).ToList();

                return DATA0;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public List<MASTERDATA_VILLAGE> MOBILE_GET_VILLAGE(string DISTRICT)
        {
            try
            {
                SQL = @"EXEC [MOBILE_GET_VILLAGE] '" + DISTRICT + "'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new MASTERDATA_VILLAGE()
                             {
                                 VALUE = (row["VALUE"].ToString() == null) ? "" : (row["VALUE"].ToString().Replace("\r\n", "")),
                                 TEXT = (row["TEXT"].ToString() == null) ? "" : (row["TEXT"].ToString().Replace("\r\n", ""))
                             }).ToList();

                return DATA0;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public List<USERINFO> WEB_GET_USERTABLE()
        {
            try
            {
                SQL = @"SELECT USEID, USENAM, BUSFUNC, CreUsr AS CREATEDBY, CreDat AS CREATEDON FROM USR ORDER BY CREATEDON DESC";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new USERINFO()
                             {
                                 USEID = (row["USEID"].ToString() == null) ? "" : row["USEID"].ToString(),
                                 USENAM = (row["USENAM"].ToString() == null) ? "" : row["USENAM"].ToString(),
                                 BUSFUNC = (row["BUSFUNC"].ToString() == null) ? "" : row["BUSFUNC"].ToString(),
                                 CREATEDBY = (row["CREATEDBY"].ToString() == null) ? "" : row["CREATEDBY"].ToString(),
                                 CREATEDON = (row["CREATEDON"].ToString() == null) ? "" : row["CREATEDON"].ToString()
                             }).ToList();

                return DATA0;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public List<USERGROUP> WEB_GET_GROUPTABLE()
        {
            try
            {
                SQL = @"SELECT * FROM MD_BUSFUNC";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new USERGROUP()
                             {
                                 GROUP = (row["BUSFUNC"].ToString() == null) ? "" : row["BUSFUNC"].ToString(),
                                 DESCRIPTION = (row["DESCRIPTION"].ToString() == null) ? "" : row["DESCRIPTION"].ToString(),
                                 UPDATEDBY = (row["UPDATEBY"].ToString() == null) ? "" : row["UPDATEBY"].ToString(),
                                 UPDATEDON = (row["UPDATEON"].ToString() == null) ? "" : row["UPDATEON"].ToString(),
                                 CREATEDBY = (row["CREATEDBY"].ToString() == null) ? "" : row["CREATEDBY"].ToString(),
                                 CREATEDON = (row["CREATEDON"].ToString() == null) ? "" : row["CREATEDON"].ToString()
                             }).ToList();

                return DATA0;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public PP<RESPONSE2> WEB_CREATE_GROUP(string GROUPNAME, string GROUPDESC, string USERID)
        {
            try
            {
                SQL = @"INSERT INTO MD_BUSFUNC VALUES ('"+ GROUPNAME + "', '" + GROUPDESC + "', '" + USERID + "', GETDATE(),'" + USERID + "', GETDATE())" +
                    "SELECT 1 AS RESULT, 'GROUP "+ GROUPNAME +" SUCCESSFULLY CREATED' AS MESSAGE";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA = (from row in DATATABLE.AsEnumerable()
                            select new RESPONSE2()
                            {
                                RESULT = row["RESULT"].ToBoolean(),
                                MESSAGE = (row["MESSAGE"].ToString() == null) ? "" : row["MESSAGE"].ToString()
                            }).FirstOrDefault();

                return new PP<RESPONSE2>
                {
                    Result = true,
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
        public PP<RESPONSE2> WEB_DELETE_GROUP(string GROUP)
        {
            try
            {
                SQL = @"DELETE FROM MD_BUSFUNC WHERE BUSFUNC = '"+ GROUP + "'" +
                    "SELECT 1 AS RESULT, '"+ GROUP + " SUCCESSFULLY DELETED' AS MESSAGE";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA = (from row in DATATABLE.AsEnumerable()
                             select new RESPONSE2()
                             {
                                 RESULT = row["RESULT"].ToBoolean(),
                                 MESSAGE = (row["MESSAGE"].ToString() == null) ? "" : row["MESSAGE"].ToString()
                             }).FirstOrDefault();

                return new PP<RESPONSE2>
                {
                    Result = true,
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
        public List<USERGROUP> WEB_GET_USER_GROUP()
        {
            try
            {
                SQL = @"SELECT BUSFUNC AS [GROUP], [DESCRIPTION] AS [NAME] FROM [DBERECRUITMENT].[dbo].[MD_BUSFUNC]";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA = (from row in DATATABLE.AsEnumerable()
                            select new USERGROUP()
                            {
                                GROUP = (row["GROUP"].ToString() == null) ? "" : row["GROUP"].ToString(),
                                DESCRIPTION = (row["NAME"].ToString() == null) ? "" : row["NAME"].ToString()
                            }).ToList();

                return DATA;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public PP<RESPONSE2> WEB_CREATE_USER(string USER_ID, string USER_NAME, string USER_GROUP, string USER_CREATOR)
        {
            try
            {
                SQL = @"EXEC [SP_POST_NEW_USER] '"+ USER_ID + "','" + USER_NAME + "','" + USER_GROUP + "','" + USER_CREATOR + "'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA = (from row in DATATABLE.AsEnumerable()
                            select new RESPONSE2()
                            {
                                RESULT = row["RESULT"].ToBoolean(),
                                MESSAGE = (row["MESSAGE"].ToString() == null) ? "" : row["MESSAGE"].ToString()
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
        public PP<RESPONSE2> WEB_DELETE_USER(string USERID)
        {
            try
            {
                SQL = @"DELETE FROM USR WHERE USEID = '" + USERID + "'" +
                    "SELECT 1 AS RESULT, '" + USERID + " SUCCESSFULLY DELETED' AS MESSAGE";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA = (from row in DATATABLE.AsEnumerable()
                            select new RESPONSE2()
                            {
                                RESULT = row["RESULT"].ToBoolean(),
                                MESSAGE = (row["MESSAGE"].ToString() == null) ? "" : row["MESSAGE"].ToString()
                            }).FirstOrDefault();

                return new PP<RESPONSE2>
                {
                    Result = true,
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
        public List<DASHBOARD_DETAIL> WEB_GET_DASHBOARD_DETAIL(string BATCHNO)
        {
            try
            {
                SQL = @"EXEC [WEB_GET_DASHBOARD_DETAIL] '"+ BATCHNO + "'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA = (from row in DATATABLE.AsEnumerable()
                            select new DASHBOARD_DETAIL()
                            {
                                TOTAL = (row["TOTAL"].ToString() == null) ? "" : row["TOTAL"].ToString(),
                                PASSED = (row["PASSED"].ToString() == null) ? "" : row["PASSED"].ToString(),
                                FAILED = (row["FAILED"].ToString() == null) ? "" : row["FAILED"].ToString()
                            }).ToList();
                return DATA;
            }
            catch (Exception msg)
            {
                return null;
            }
        }



        public List<MD_REGION> WEB_GET_MD_PROVINCIES()
        {
            try
            {
                SQL = @"EXEC [WEB_GET_PROVINCIES]";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA = (from row in DATATABLE.AsEnumerable()
                            select new MD_REGION()
                            {
                                ID = (row["ID"].ToString() == null) ? "" : row["ID"].ToString(),
                                NAME = (row["NAME"].ToString() == null) ? "" : row["NAME"].ToString(),

                            }).ToList();

                return DATA;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public List<MD_REGION> WEB_GET_MD_REGENCIES(string ID_PROVINCIES)
        {
            try
            {
                SQL = @"EXEC [WEB_GET_REGENCIES] '" + ID_PROVINCIES + "'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA = (from row in DATATABLE.AsEnumerable()
                            select new MD_REGION()
                            {
                                ID = (row["ID"].ToString() == null) ? "" : row["ID"].ToString(),
                                NAME = (row["NAME"].ToString() == null) ? "" : row["NAME"].ToString(),
                            }).ToList();
                return DATA;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public List<MD_REGION> WEB_GET_MD_DISTRICTS(string ID_REGENCIES)
        {
            try
            {
                SQL = @"EXEC [WEB_GET_DISTRICTS] '" + ID_REGENCIES + "'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA = (from row in DATATABLE.AsEnumerable()
                            select new MD_REGION()
                            {
                                ID = (row["ID"].ToString() == null) ? "" : row["ID"].ToString(),
                                NAME = (row["NAME"].ToString() == null) ? "" : row["NAME"].ToString(),
                            }).ToList();
                return DATA;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public List<MD_REGION> WEB_GET_MD_VILLAGES(string ID_DISTRICTS)
        {
            try
            {
                SQL = @"EXEC [WEB_GET_VILLAGES] '" + ID_DISTRICTS + "'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA = (from row in DATATABLE.AsEnumerable()
                            select new MD_REGION()
                            {
                                ID = (row["ID"].ToString() == null) ? "" : row["ID"].ToString(),
                                NAME = (row["NAME"].ToString() == null) ? "" : row["NAME"].ToString(),
                            }).ToList();
                return DATA;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public List<MD_CHART2_STATUS_VALUE> LOADCHART()
        {
            try
            { 
                var DATASET = new DataSet();
                SQL = @"
                        SELECT DISTINCT BATCHNO FROM BATCHHEADER BH

                        SELECT DISTINCT BATCHNO,
                        (SELECT COUNT(*) FROM BATCHDETAIL WHERE STATUSEMP = '2000' AND BatchNo = BH.BATCHNO) AS 'STAT_1',
                        (SELECT COUNT(*) FROM BATCHDETAIL WHERE STATUSEMP = '2100' AND BatchNo = BH.BATCHNO) AS 'STAT_2',
                        (SELECT COUNT(*) FROM BATCHDETAIL WHERE STATUSEMP = '2200' AND BatchNo = BH.BATCHNO) AS 'STAT_3',
                        (SELECT COUNT(*) FROM BATCHDETAIL WHERE STATUSEMP = '2300' AND BatchNo = BH.BATCHNO) AS 'STAT_4',
                        (SELECT COUNT(*) FROM BATCHDETAIL WHERE STATUSEMP = '2400' AND BatchNo = BH.BATCHNO) AS 'STAT_5',
                        (SELECT COUNT(*) FROM BATCHDETAIL WHERE STATUSEMP = '2500' AND BatchNo = BH.BATCHNO) AS 'STAT_6',
                        (SELECT COUNT(*) FROM BATCHDETAIL WHERE STATUSEMP = '2600' AND BatchNo = BH.BATCHNO) AS 'STAT_7',
                        (SELECT COUNT(*) FROM BATCHDETAIL WHERE STATUSEMP = '2700' AND BatchNo = BH.BATCHNO) AS 'STAT_8',
                        (SELECT COUNT(*) FROM BATCHDETAIL WHERE STATUSEMP = '2800' AND BatchNo = BH.BATCHNO) AS 'STAT_9',
                        (SELECT COUNT(*) FROM BATCHDETAIL WHERE STATUSEMP = '3000' AND BatchNo = BH.BATCHNO) AS 'STAT_10',
                        (SELECT COUNT(*) FROM BATCHDETAIL WHERE STATUSEMP = '3100' AND BatchNo = BH.BATCHNO) AS 'STAT_11',
                        (SELECT COUNT(*) FROM BATCHDETAIL WHERE STATUSEMP = '3200' AND BatchNo = BH.BATCHNO) AS 'STAT_12',
                        (SELECT COUNT(*) FROM BATCHDETAIL WHERE STATUSEMP = '5001' AND BatchNo = BH.BATCHNO) AS 'STAT_13',
                        (SELECT COUNT(*) FROM BATCHDETAIL WHERE STATUSEMP = '5002' AND BatchNo = BH.BATCHNO) AS 'STAT_14',
                        (SELECT COUNT(*) FROM BATCHDETAIL WHERE STATUSEMP = '5003' AND BatchNo = BH.BATCHNO) AS 'STAT_15',
                        (SELECT COUNT(*) FROM BATCHDETAIL WHERE STATUSEMP = '5004' AND BatchNo = BH.BATCHNO) AS 'STAT_16',
                        (SELECT COUNT(*) FROM BATCHDETAIL WHERE STATUSEMP = '5005' AND BatchNo = BH.BATCHNO) AS 'STAT_17',
                        (SELECT COUNT(*) FROM BATCHDETAIL WHERE STATUSEMP = '5006' AND BatchNo = BH.BATCHNO) AS 'STAT_18',
                        (SELECT COUNT(*) FROM BATCHDETAIL WHERE STATUSEMP = '5007' AND BatchNo = BH.BATCHNO) AS 'STAT_19',
                        (SELECT COUNT(*) FROM BATCHDETAIL WHERE STATUSEMP = '5008' AND BatchNo = BH.BATCHNO) AS 'STAT_20',
                        (SELECT COUNT(*) FROM BATCHDETAIL WHERE STATUSEMP = '6005' AND BatchNo = BH.BATCHNO) AS 'STAT_21',
                        (SELECT COUNT(*) FROM BATCHDETAIL WHERE STATUSEMP = '6006' AND BatchNo = BH.BATCHNO) AS 'STAT_22',
                        (SELECT COUNT(*) FROM BATCHDETAIL WHERE STATUSEMP = '6007' AND BatchNo = BH.BATCHNO) AS 'STAT_23',
                        (SELECT COUNT(*) FROM BATCHDETAIL WHERE STATUSEMP = '6008' AND BatchNo = BH.BATCHNO) AS 'STAT_24'
                        FROM BATCHHEADER BH

                        ";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATASET = s.ExecDSQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA1 = (from row in DATASET.Tables[1].AsEnumerable()
                             select new MD_CHART2_STATUS_VALUE()
                             {
                                 BATCHNO = (row["BATCHNO"].ToString() == null) ? "-" : row["BATCHNO"].ToString(),
                                 STAT_1 = Convert.ToInt32(row["STAT_1"]),
                                 STAT_2 = Convert.ToInt32(row["STAT_2"]),
                                 STAT_3 = Convert.ToInt32(row["STAT_3"]),
                                 STAT_4 = Convert.ToInt32(row["STAT_4"]),
                                 STAT_5 = Convert.ToInt32(row["STAT_5"]),
                                 STAT_6 = Convert.ToInt32(row["STAT_6"]),
                                 STAT_7 = Convert.ToInt32(row["STAT_7"]),
                                 STAT_8 = Convert.ToInt32(row["STAT_8"]),
                                 STAT_9 = Convert.ToInt32(row["STAT_9"]),
                                 STAT_10 = Convert.ToInt32(row["STAT_10"]),
                                 STAT_11 = Convert.ToInt32(row["STAT_11"]),
                                 STAT_12 = Convert.ToInt32(row["STAT_12"]),
                                 STAT_13 = Convert.ToInt32(row["STAT_13"]),
                                 STAT_14 = Convert.ToInt32(row["STAT_14"]),
                                 STAT_15 = Convert.ToInt32(row["STAT_15"]),
                                 STAT_16 = Convert.ToInt32(row["STAT_16"]),
                                 STAT_17 = Convert.ToInt32(row["STAT_17"]),
                                 STAT_18 = Convert.ToInt32(row["STAT_18"]),
                                 STAT_19 = Convert.ToInt32(row["STAT_19"]),
                                 STAT_20 = Convert.ToInt32(row["STAT_20"]),
                                 STAT_21 = Convert.ToInt32(row["STAT_21"]),
                                 STAT_22 = Convert.ToInt32(row["STAT_22"]),
                                 STAT_23 = Convert.ToInt32(row["STAT_23"]),
                                 STAT_24 = Convert.ToInt32(row["STAT_24"])
                             }).ToList();

                var DATA0 = (from row in  DATASET.Tables[0].AsEnumerable()
                            select new MD_CHART2()
                            {
                                BATCHNO = (row["BATCHNO"].ToString() == null) ? "-" : row["BATCHNO"].ToString(),
                                STATUS_VALUE = (from x in DATA1
                                                select new MD_CHART2_STATUS_VALUE
                                                {
                                                    STAT_1 = x.STAT_1,
                                                    STAT_2 = x.STAT_2,
                                                    STAT_3 = x.STAT_3,
                                                    STAT_4 = x.STAT_4,
                                                    STAT_5 = x.STAT_5,
                                                    STAT_6 = x.STAT_6,
                                                    STAT_7 = x.STAT_7,
                                                    STAT_8 = x.STAT_8,
                                                    STAT_9 = x.STAT_9,
                                                    STAT_10 = x.STAT_10,
                                                    STAT_11 = x.STAT_11,
                                                    STAT_12 = x.STAT_12,
                                                    STAT_13 = x.STAT_13,
                                                    STAT_14 = x.STAT_14,
                                                    STAT_15 = x.STAT_15,
                                                    STAT_16 = x.STAT_16,
                                                    STAT_17 = x.STAT_17,
                                                    STAT_18 = x.STAT_18,
                                                    STAT_19 = x.STAT_19,
                                                    STAT_20 = x.STAT_20,
                                                    STAT_21 = x.STAT_21,
                                                    STAT_22 = x.STAT_22,
                                                    STAT_23 = x.STAT_23,
                                                    STAT_24 = x.STAT_24
                                                }).Where(x => x.BATCHNO == row["BATCHNO"].ToString()).ToList()
                            }).ToList();

                return DATA1;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
    }
}