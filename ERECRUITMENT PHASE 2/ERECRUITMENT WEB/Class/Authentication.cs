using ERECRUITMENT_WEB.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ERECRUITMENT_WEB.Class
{
    public class Authentication
    {
        DataTable DATATABLE;
        string SQL = "";
        public string EREC_CON = ConfigurationManager.ConnectionStrings["EREC_CON"].ToString();
        public PP<USERINFO> SignIn(string USEID, string PASSWORD)
        {
            try
            {
                if (WindowsAuth(USEID, PASSWORD) != false)
                {
                    SQL = @"EXEC [SP_WEB_GETUSERINFO] '" + USEID + "'";
                    using (ClassMSSQL s = new ClassMSSQL())
                    {
                        DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                    }
                    if (DATATABLE.Rows.Count > 0)
                    {
                        
                        var DATA0 = (from row in DATATABLE.AsEnumerable()
                                     select new USERINFO()
                                     {
                                         USEID      = row["USEID"].ToString(),
                                         USENAM     = row["USENAM"].ToString(),
                                         BUSFUNC    = row["BUSFUNC"].ToString(),
                                         ISWINDOWS  = row["ISWINDOWS"].ToBoolean()
                                     }).First();

                        return new PP<USERINFO>
                        {
                            Result = true,
                            Message = StringConst.SUCCESS,
                            Data = DATA0
                        };
                    }
                    else
                    {
                        return new PP<USERINFO>
                        {
                            Result = false,
                            Message = StringConst.USER_DOESNT_EXIST,
                            Data = null
                        };
                    }
                }
                else
                {
                    return new PP<USERINFO>
                    {
                        Result = false,
                        Message = StringConst.INVALID_WIN_CREDENTIALS,
                        Data = null
                    };
                }
            }
            catch(Exception msg)
            {
                return new PP<USERINFO>
                {
                    Result = false,
                    Message = msg.Message.ToString(),
                    Data = null
                };
            }
        }
        public bool WindowsAuth(string USEID, string PASSWORD)
        {
            WindowsAuth WA = new WindowsAuth();
            return WA.WinAuth(USEID, PASSWORD, false, "SHIMANOACE");
        }
        public PP<RESPONSE_LOGIN_MOBILE> Mobile_SignIn(string UNIQUEID)
        {
            try
            {
                SQL = @"EXEC [SP_WEB_GETUNIQUE] '" + UNIQUEID + "'";

                using (ClassMSSQL s = new ClassMSSQL())
                {
                    DATATABLE = s.ExecDTQuery(EREC_CON, SQL, null, null, false);
                }
                var DATA0 = (from row in DATATABLE.AsEnumerable()
                             select new RESPONSE_LOGIN_MOBILE()
                             {
                                 RESULT  = row["RESULT"].ToBoolean(),
                                 MESSAGE = row["MESSAGE"].ToString()

                             }).First();

                return new PP<RESPONSE_LOGIN_MOBILE>
                {
                    Result = DATA0.RESULT,
                    Message = DATA0.MESSAGE.ToString()
                };
            }
            catch(Exception msg)
            {
                return new PP<RESPONSE_LOGIN_MOBILE>
                {
                    Result = false,
                    Message = msg.Message.ToString()
                };
            }
        }
    }
}