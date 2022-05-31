using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ERECRUITMENT_WEB.Class
{
    public class ClassMSSQL : IDisposable
    {
        static string ConnectionDB = ConfigurationManager.ConnectionStrings["EREC_CON"].ToString();
        bool disposed = false;
        public SqlConnection SqlConHd = new SqlConnection();
        public bool SQLCon(string ConStr)
        {
            SqlConHd.ConnectionString = ConStr;
            try
            {
                SqlConHd.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void SQLCloseCon()
        {
            SqlConnection.ClearPool(SqlConHd);
            SqlConHd.Dispose();
            SqlConHd.Close();
        }
        public DataTable ExecDTQuery(string Connection, string command, List<ctSqlVariable> parameters, SqlTransaction Tranx, bool _persist)
        {
            try
            {
                if (SqlConHd.State == ConnectionState.Closed)
                {
                    SQLCon(Connection);
                }
                SqlCommand Selectcommand = new SqlCommand(command, SqlConHd);
                DataSet ds = new DataSet();
                SqlDataAdapter DataAd = new SqlDataAdapter();
                DataAd.SelectCommand = Selectcommand;
                if (parameters != null)
                {
                    foreach (var row in parameters)
                    {
                        Selectcommand.Parameters.Add("@" + row.Name, SqlDbType.VarChar).Value = row.Value;
                    }
                }

                if (Tranx != null)
                {
                    DataAd.SelectCommand.Transaction = Tranx;
                }
                DataAd.Fill(ds);
                if ((ds != null) && (ds.Tables.Count > 0))
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                if (Tranx != null)
                {
                    Tranx.Rollback();
                }
                throw ex;
            }
            finally
            {
                if (!_persist)
                {
                    SQLCloseCon();
                }
            }
        }
        public DataSet ExecDSQuery(string Connection, string command, List<ctSqlVariable> parameters, SqlTransaction Tranx, bool _persist)
        {
            try
            {
                if (SqlConHd.State == ConnectionState.Closed)
                {
                    SQLCon(Connection);
                }

                SqlCommand Selectcommand = new SqlCommand(command, SqlConHd);
                DataSet ds = new DataSet();
                SqlDataAdapter DataAd = new SqlDataAdapter();
                DataAd.SelectCommand = Selectcommand;
                if (parameters != null)
                {
                    foreach (var row in parameters)
                    {
                        Selectcommand.Parameters.Add("@" + row.Name, SqlDbType.VarChar).Value = row.Value;
                    }
                }
                if (Tranx != null)
                {
                    DataAd.SelectCommand.Transaction = Tranx;
                }
                DataAd.Fill(ds);
                if ((ds != null) && (ds.Tables.Count > 0))
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                if (Tranx != null)
                {
                    Tranx.Rollback();
                }
                throw ex;
            }
            finally
            {
                if (!_persist)
                {
                    SQLCloseCon();
                }

            }
        }
        public Int64 ExecNonQuery(string Connection, string command, List<ctSqlVariable> parameters, SqlTransaction Tranx, bool _persist)
        {
            bool isSuccess = true;
            try
            {
                if (SqlConHd.State == ConnectionState.Closed)
                {
                    SQLCon(Connection);
                }
                if (SqlConHd.State == ConnectionState.Closed)
                {
                    return -1;
                }
                SqlCommand SqlCom = new SqlCommand(command, SqlConHd);
                if (parameters != null)
                {
                    foreach (var row in parameters)
                    {
                        SqlCom.Parameters.Add("@" + row.Name, SqlDbType.VarChar).Value = row.Value;
                    }
                }
                if (Tranx != null)
                {
                    SqlCom.Transaction = Tranx;

                }

                Int64 num = new Int64();

                num = SqlCom.ExecuteNonQuery();

                return num;
            }
            catch (Exception Exp)
            {
                isSuccess = false;
                if (Tranx != null)
                {
                    Tranx.Rollback();
                }
                throw Exp;
            }
            finally
            {
                if (!_persist)
                {
                    if (Tranx != null && isSuccess)
                    {
                        Tranx.Commit();
                    }
                    SQLCloseCon();
                }
            }
        }
        public Int64 ExecuteNonQuery(string Connection, string command, SqlTransaction Tranx, bool _persist)
        {
            try
            {
                if (SqlConHd.State == ConnectionState.Closed)
                {
                    SQLCon(Connection);
                }
                if (SqlConHd.State == ConnectionState.Closed)
                {
                    return -1;
                }
                SqlCommand SqlCom = new SqlCommand(command, SqlConHd);
                if (Tranx != null)
                {
                    SqlCom.Transaction = Tranx;
                }

                Int64 num = new Int64();

                num = SqlCom.ExecuteNonQuery();

                return num;
            }
            catch (Exception Exp)
            {
                if (Tranx != null)
                {
                    Tranx.Rollback();
                }
                throw Exp;
            }
            finally
            {
                if (!_persist)
                {
                    SQLCloseCon();
                }
            }
        }
        public string ExecuteScalar(string Connection, string command, List<ctSqlVariable> parameters, SqlTransaction Tranx, bool _persist)
        {
            try
            {
                if (SqlConHd.State == ConnectionState.Closed)
                {
                    SQLCon(Connection);
                }
                if (SqlConHd.State == ConnectionState.Closed)
                {
                    return "-1";
                }

                SqlCommand SqlCom = new SqlCommand(command, SqlConHd);
                if (Tranx != null)
                {
                    SqlCom.Transaction = Tranx;
                }
                return SqlCom.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                if (Tranx != null)
                {
                    Tranx.Rollback();
                }
                throw ex;
            }
            finally
            {
                if (!_persist)
                {
                    SQLCloseCon();
                }
            }
        }
        public DataTable ExecuteStoProcDT(string StrCon, string SqlCmd, List<ctSqlVariable> param)
        {
            DataTable table = new DataTable();
            try
            {

                using (var con = new SqlConnection(StrCon))
                using (var cmd = new SqlCommand(SqlCmd, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var row in param)
                    {
                        cmd.Parameters.Add("@" + row.Name, SqlDbType.VarChar).Value = row.Value;
                    }
                    da.Fill(table);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return table;
        }
        public DataSet ExecuteStoProcDS(string StrCon, string SqlCmd, List<ctSqlVariable> param)
        {
            DataSet dataSet = new DataSet();
            try
            {

                using (var con = new SqlConnection(StrCon))
                using (var cmd = new SqlCommand(SqlCmd, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var row in param)
                    {
                        cmd.Parameters.Add("@" + row.Name, SqlDbType.VarChar).Value = row.Value;
                    }
                    da.Fill(dataSet);
                    return ((dataSet != null) && (dataSet.Tables.Count > 0)) ? dataSet : null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public long ExecuteStoProcNonQuery(string StrCon, string SqlCmd, List<ctSqlVariable> param)
        {
            try
            {

                using (var con = new SqlConnection(StrCon))
                using (var cmd = new SqlCommand(SqlCmd, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var row in param)
                    {
                        cmd.Parameters.Add("@" + row.Name, SqlDbType.VarChar).Value = row.Value;
                    }
                    return cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ExecuteStoProcScalar(string StrCon, string SqlCmd, List<ctSqlVariable> param)
        {
            try
            {

                using (var con = new SqlConnection(StrCon))
                using (var cmd = new SqlCommand(SqlCmd, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var row in param)
                    {
                        cmd.Parameters.Add("@" + row.Name, SqlDbType.VarChar).Value = row.Value;
                    }
                    return cmd.ExecuteScalar().ToString();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool isSystemConnected(string Connection, bool _persist)
        {
            try
            {
                if (SqlConHd.State == ConnectionState.Closed)
                {
                    SQLCon(Connection);
                }

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (!_persist)
                {
                    SQLCloseCon();
                }
            }
            return true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
        ~ClassMSSQL()
        {
            Dispose(false);
        }
    }
    public class ctSqlVariable
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}