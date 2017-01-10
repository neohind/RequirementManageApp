using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace RequireManager.Dac
{
    public class UDataQuerySet 
    {
        /// <summary>
        /// 로그를 남기기 위한 log4net 개체
        /// </summary>
        
        public string Query
        {
            get;
            set;
        }

        public List<SqlParameter> Parameters
        {
            get;
            set;
        }

        public CommandType CmdType
        {
            get;
            set;
        }

        public string FunName
        {
            get;
            set;
        }

        public int Timeout
        {
            get;
            set;
        }

        public UDataQuerySet()
        {
            this.Parameters = new List<SqlParameter>();
            CmdType = CommandType.Text;
            Timeout = 30;
        }


        public UDataQuerySet(string sQuery)
            : this()
        {
            this.Query = sQuery;
        }

        public UDataQuerySet(string sQuery, CommandType type) : this(sQuery)
        {
            this.CmdType = type;
        }


        public void AddParam(string sName, object objValue)
        {
            if (objValue == null)
                objValue = DBNull.Value;
            SqlParameter parameter = new SqlParameter(sName, objValue);            
            Parameters.Add(parameter);
        }

        public void AddParam(string sName,SqlDbType sqldbType, object objValue)
        {
            if (objValue == null)
                objValue = DBNull.Value;
            SqlParameter parameter = new SqlParameter(sName, objValue);
            parameter.SqlDbType = sqldbType;
            Parameters.Add(parameter);
        }

        public void AddParam(string sName, System.Data.DbType sqldbType, object objValue)
        {
            if (objValue == null)
                objValue = DBNull.Value;
            SqlParameter parameter = new SqlParameter(sName, objValue);
            parameter.SqlDbType = (SqlDbType)sqldbType;
            Parameters.Add(parameter);
        }

        internal void AddOutput(string sName, SqlDbType sqlDbType)
        {
            SqlParameter parameter = new SqlParameter(sName, sqlDbType);
            parameter.Direction = ParameterDirection.Output;
            Parameters.Add(parameter);
        }

        public void AddParamRange(List<SqlParameter> parameters)
        {
            this.Parameters.Clear();
            this.Parameters.AddRange(parameters);
        }

        public T GetOutput<T>(string sName)
        {
            T value = default(T);
            foreach(SqlParameter param in Parameters)
            {
                if(param.ParameterName.Equals(sName) && param.Value is T)
                {
                    try
                    {
                        value = (T)Convert.ChangeType(param.Value, typeof(T));
                        return value;
                    }
                    catch
                    {
                    }
                }
            }
            return value;
        }


        public override string ToString()
        {
            StringBuilder sbLogForQuery = new StringBuilder();            
            sbLogForQuery.AppendLine("Query : ");
            sbLogForQuery.AppendLine(this.Query);
            sbLogForQuery.AppendLine("Params : ");
            foreach (System.Data.SqlClient.SqlParameter parameter in this.Parameters)
            {
                sbLogForQuery.AppendFormat("  {0} -> {1}", parameter.ParameterName, parameter.Value);
            }
            sbLogForQuery.AppendLine();
            return sbLogForQuery.ToString();
        }
    }
}
