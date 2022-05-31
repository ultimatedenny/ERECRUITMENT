using ERECRUITMENT_WEB.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ERECRUITMENT_WEB.Class
{
    public class GeneralNameList
    {
        DataTable DATATABLE;
        string SQL = "";
        public string EREC_CON = ConfigurationManager.ConnectionStrings["EREC_CON"].ToString();
        public List<GENERAL_NAME_LIST> WEB_GET_TABLE_GENERAL(string BATCHNO,string STATUS, string KEYWORD)
        {
            try
            {
                SQL = @"EXEC [SP_WEB_GET_GENERANAMELIST] '" + BATCHNO + "','" + STATUS + "','" + KEYWORD + "'";
                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA = (from row in DATATABLE.AsEnumerable()
                             select new GENERAL_NAME_LIST()
                             {

                                 BATCH_NO = (row["BATCH_NO"].ToString() == null) ? "" : row["BATCH_NO"].ToString(),
                                 BATCH_EMP = (row["BATCH_EMP"].ToString() == null) ? "" : row["BATCH_EMP"].ToString(),
                                 NAME_EMP = (row["NAME_EMP"].ToString() == null) ? "" : row["NAME_EMP"].ToString(),
                                 GANDER = (row["GANDER"].ToString() == null) ? "" : row["GANDER"].ToString(),
                                 NO_EMP = (row["NO_EMP"].ToString() == null) ? "" : row["NO_EMP"].ToString(),
                                 FORM = (row["FORM"].ToString() == null) ? "" : row["FORM"].ToString(),
                                 DOJ = (row["DOJ"].ToString() == null) ? "" : row["DOJ"].ToString(),
                                 DOE = (row["DOE"].ToString() == null) ? "" : row["DOE"].ToString(),
                                 TAX = (row["TAX"].ToString() == null) ? "" : row["TAX"].ToString(),
                                 TIER = (row["TIER"].ToString() == null) ? "" : row["TIER"].ToString(),
                                 DEPT = (row["DEPT"].ToString() == null) ? "" : row["DEPT"].ToString(),
                                 STATUS = (row["STATUS"].ToString() == null) ? "" : row["STATUS"].ToString(),
                                 COMPLETED_ON = (row["COMPLETED_ON"].ToString() == null) ? "" : row["COMPLETED_ON"].ToString(),
                                 SEND_ON = (row["SEND_ON"].ToString() == null) ? "" : row["SEND_ON"].ToString(),
                                 VERIFY_ON = (row["VERIFY_ON"].ToString() == null) ? "" : row["VERIFY_ON"].ToString(),
                             }).ToList();

                return DATA;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        public DataTable EXPORT(string BatchNo)
        {
            DataTable dt = new DataTable();
            SQL = @"EXEC [SP_EXPORTEXCEL_GENERALNAMELIST] '" + BatchNo + "'";
            var param = new List<ctSqlVariable>();
            using (ClassMSSQL s = new ClassMSSQL())
            {
                DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
            }
            return DATATABLE;
        }
        public PP<RESPONSE2> WEB_UPDATE_USER_GENERAL(DataTable dt, string USERID)
        {
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var BATCH_NO = dt.Rows[i]["BATCH_NO"].ToString();
                    var BATCH_EMP = dt.Rows[i]["BATCH_EMP"].ToString();
                    var NAME_EMP = dt.Rows[i]["NAME_EMP"].ToString();
                    var GANDER = dt.Rows[i]["GANDER"].ToString();
                    var NO_EMP = dt.Rows[i]["NO_EMP"].ToString();
                    var DOE = dt.Rows[i]["DOE"].ToString();
                    var DOJ = dt.Rows[i]["DOJ"].ToString();
                    var TAX = dt.Rows[i]["TAX"].ToString();
                    var TIER = dt.Rows[i]["TIER"].ToString();
                    var DEPT = dt.Rows[i]["DEPT"].ToString();

                    SQL = @"EXEC [WEB_UPDATE_USER_GENERAL] '" + BATCH_NO + "','" + BATCH_EMP + "','" + NAME_EMP + "','" + GANDER + "','" + NO_EMP + "','" + DOE + "','" + DOJ + "','" + TAX + "','" + TIER + "','" + DEPT + "','"+ USERID + "'";
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
        public PP<RESPONSE2> WEB_SUBMIT_USER_GENERAL(string BATCHNO, string USERID)
        {
            try
            {
                SQL = @"EXEC [WEB_SUBMIT_USER_GENERAL] '" + BATCHNO + "','" + USERID + "'";
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
        public PP<RESPONSE2> WEB_VERIFY_USER_GENERAL(string BATCHNO, string USERID)
        {
            try
            {
                SQL = @"EXEC [WEB_VERIFY_USER_GENERAL] '" + BATCHNO + "','" + USERID + "'";
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
    }
}