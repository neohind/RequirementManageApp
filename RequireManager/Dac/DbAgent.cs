using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RequireManager.Dac
{
    public class DbAgent 
    {
        static private string g_sProviderName = string.Empty;        

        
        public string ConnectionString
        {
            get;
            set;
        }

        public DbAgent(string sConnectionString)
            : base()
        {
            this.ConnectionString = sConnectionString;            
            
        }     

        public DataTable GetDataTable(string query)
        {
            return GetDataTable(query, new List<SqlParameter>());
        }

        public DataTable GetDataTable(string query, List<SqlParameter> paramters)
        {
            UDataQuerySet set = new UDataQuerySet(query);
            set.Parameters.AddRange(paramters);
            return GetDataTable(set);
        }

        public DataTable GetDataTable(UDataQuerySet set)
        {
            DataTable dtResult = new DataTable();

            SqlConnection sqlConnection = new SqlConnection(this.ConnectionString);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = null;            
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(set.Query, sqlConnection);
                sqlCommand.CommandTimeout = set.Timeout;
                sqlCommand.CommandType = set.CmdType;
                if (set.Parameters.Count > 0)
                {
                    sqlCommand.Parameters.AddRange(set.Parameters.ToArray());
                }
                sqlAdapter.SelectCommand = sqlCommand;
                sqlAdapter.Fill(dtResult);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (sqlAdapter != null)
                    sqlAdapter.Dispose();

                if (sqlConnection != null)
                {
                    if (sqlConnection.State == ConnectionState.Open)
                    {
                        sqlConnection.Close();
                    }
                    sqlConnection.Dispose();
                }
            }
            return dtResult;
        }

        public  DataSet GetDataSet(string query)
        {
            UDataQuerySet set = new UDataQuerySet(query);
            return GetDataSet(set);
        }

        public DataSet GetDataSet(UDataQuerySet set)
        {
            DataSet dsResult = new DataSet();
            SqlConnection sqlConnection = new SqlConnection(this.ConnectionString);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = null;
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(set.Query, sqlConnection);
                sqlCommand.CommandTimeout = set.Timeout;
                sqlCommand.CommandType = set.CmdType;
                if (set.Parameters.Count > 0)
                    sqlCommand.Parameters.AddRange(set.Parameters.ToArray());
                sqlAdapter.SelectCommand = sqlCommand;
                sqlAdapter.Fill(dsResult);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (sqlAdapter != null)
                    sqlAdapter.Dispose();

                if (sqlConnection != null)
                {
                    if (sqlConnection.State == ConnectionState.Open)
                    {
                        sqlConnection.Close();
                    }
                    sqlConnection.Dispose();
                }
            }
            return dsResult;
        }

        /// <summary>
        /// 문자열을 이용하여 트렌젝트 실행을 하고 영향 받는 Row수를 반환 한다. 
        /// </summary>
        /// <param name="query">질의 문자열</param>
        /// <returns>영향 받은 Row수</returns>
        public  int ExecuteQuery(string query)
        {
            return ExecuteQuery(query, new List<SqlParameter>());
        }

        public int ExecuteQuery(string sQuery, CommandType commandType)
        {
            UDataQuerySet set = new UDataQuerySet();
            set.Query = sQuery;
            set.CmdType = commandType;
            return ExecuteQuery(set);
        }

        /// <summary>
        /// 문자열을 이용하여 트렌젝트 실행을 하고 영향 받는 Row수를 반환 한다. 
        /// </summary>
        /// <param name="query">질의 문자열</param>
        /// <returns>영향 받은 Row수</returns>
        public int ExecuteQuery(string query, List<SqlParameter> paramters)
        {
            List<UDataQuerySet> aryQuerySet = new List<UDataQuerySet>();
            UDataQuerySet querySet = new UDataQuerySet(query);
            querySet.Parameters.AddRange(paramters);
            aryQuerySet.Add(querySet);

            return ExecuteQuery(aryQuerySet);
        }


        public int ExecuteQuery(UDataQuerySet set)
        {
            List<UDataQuerySet> aryQuerySet = new List<UDataQuerySet>();
            aryQuerySet.Add(set);
            return ExecuteQuery(aryQuerySet);
        }

        /// <summary>
        /// 문자열을 이용하여 트렌젝트 실행을 하고 영향 받는 Row수를 반환 한다. 
        /// </summary>
        /// <param name="aryQuerySet">MSSqlQuerySet 리스트</param>
        /// <returns>영향 받은 Row수</returns>
        public  int ExecuteQuery(List<UDataQuerySet> aryQuerySet)
        {
            int affectedRows = 0;
            int nCount = 0;
            SqlConnection sqlConnection = new SqlConnection(this.ConnectionString);
            SqlCommand sqlCommand = null;
            SqlTransaction transaction = null;
            string sCurrentExecuteQuery = string.Empty;
            try
            {
                sqlConnection.Open();
                transaction = sqlConnection.BeginTransaction();
                foreach (UDataQuerySet query in aryQuerySet)
                {
                    sqlCommand = new SqlCommand(query.Query, sqlConnection);
                    sqlCommand.CommandType = query.CmdType;
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Transaction = transaction;
                    sqlCommand.CommandTimeout = query.Timeout;
                    sCurrentExecuteQuery = query.Query;
                    if (query.Parameters.Count > 0)                        
                        sqlCommand.Parameters.AddRange(query.Parameters.ToArray());
                        
                    affectedRows += sqlCommand.ExecuteNonQuery();
                    sqlCommand.Parameters.Clear();
                    sqlCommand.Dispose();
                    sqlCommand = null;
                    nCount++;                        
                }
                transaction.Commit();                    
                
            }
            catch (Exception ex)
            {                
                if (transaction != null)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {   
                    }
                }
                throw ex;
            }
            finally
            {
                if (transaction != null)
                    transaction.Dispose();

                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (sqlConnection != null)
                {
                    if (sqlConnection.State == ConnectionState.Open)
                    {
                        sqlConnection.Close();
                    }
                    sqlConnection.Dispose();
                }
              
            }
            return affectedRows;
        }


        public T GetValue<T>(UDataQuerySet set)
        {
            T value = default(T);

            SqlConnection sqlConnection = new SqlConnection(this.ConnectionString);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = null;
            
            try
            {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand(set.Query, sqlConnection);
                    sqlCommand.CommandType = set.CmdType;
                    sqlCommand.CommandTimeout = set.Timeout;
                    if (set.Parameters.Count > 0)
                        sqlCommand.Parameters.AddRange(set.Parameters.ToArray());
                    object objResult = sqlCommand.ExecuteScalar();
                    if (objResult != null && DBNull.Value.Equals(objResult) == false)
                    {
                        objResult = Convert.ChangeType(objResult, typeof(T));
                        value = (T)objResult;
                    }
                
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (sqlAdapter != null)
                    sqlAdapter.Dispose();

                if (sqlConnection != null)
                {
                    if (sqlConnection.State == ConnectionState.Open)
                    {
                        sqlConnection.Close();
                    }
                    sqlConnection.Dispose();
                }
            }
            return value;
        }


        internal T GetValue<T>(string query)
        {
            UDataQuerySet set = new UDataQuerySet(query);
            return GetValue<T>(set);
        }

        public object GetValue(UDataQuerySet set)
        {
            object value = null;

            SqlConnection sqlConnection = new SqlConnection(this.ConnectionString);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = null;

            try
            {
                                    sqlConnection.Open();
                    sqlCommand = new SqlCommand(set.Query, sqlConnection);
                    sqlCommand.CommandType = set.CmdType;
                    sqlCommand.CommandTimeout = set.Timeout;
                    if (set.Parameters.Count > 0)
                        sqlCommand.Parameters.AddRange(set.Parameters.ToArray());
                    value = sqlCommand.ExecuteScalar();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (sqlAdapter != null)
                    sqlAdapter.Dispose();

                if (sqlConnection != null)
                {
                    if (sqlConnection.State == ConnectionState.Open)
                    {
                        sqlConnection.Close();
                    }
                    sqlConnection.Dispose();
                }
            }
            return value;
        }

        internal object GetValue(string query)
        {
            UDataQuerySet set = new UDataQuerySet(query);
            return GetValue(set);
        }

        internal bool TestConnect()
        {
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            try
            {
                 sqlConnection = new SqlConnection(this.ConnectionString);
                sqlConnection.Open();
                sqlCommand = new SqlCommand("SELECT 1", sqlConnection);
                 sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandTimeout = 5;
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch
            {

            }
            finally
            {
                if(sqlCommand != null)
                    sqlCommand.Dispose();
                if (sqlConnection != null)
                    sqlConnection.Close();
            }
            return false;


        }
    }
}
