using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RequireManager.Dac
{
    public class DacSetting : DacBase
    {
        public DacSetting(string sConnectionString)
            : base(sConnectionString)
        {   
        }

        internal void InitValidation()
        {
            string sQuery = @"CREATE TABLE IF NOT EXISTS TB_SETTINGS (
	                            id integer primary KEY,
                              name varchar(30),
                              value varchar(100)
                            )";
            UDataQuerySet set = new UDataQuerySet(sQuery);
            m_agent.ExecuteQuery(set);
        }


        public string GetProjectName()
        {

            return GetValue("PROJECTNM");



        }

        private string GetValue(string sKey)
        {
            string sQuery = @"SELECT VALUE FROM TB_SETTINGS WHERE KEY = @KEY";
            UDataQuerySet set = new UDataQuerySet(sQuery);
            set.AddParam("@KEY", sKey);
            string sResult = string.Empty;

            sResult = m_agent.GetValue<string>(set);

            return sResult;
        }
    }
}
