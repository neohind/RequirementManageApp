using RequireManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RequireManager.Dac
{
    public class DacProject : DacBase
    {
        public DacProject(string sConnectionString) : base(sConnectionString)
        {   
        }

        public List<ModelProject> GetAllProject()
        {
            List<ModelProject> aryResult = new List<ModelProject>();
            UDataQuerySet set = new UDataQuerySet("SELECT ID ,PRJNM,DESCRPT ,ENABLED FROM TB_PROJECTS WHERE ENABLED = 'Y'");
            DataTable tbResult = null;

            try
            {
                tbResult = m_agent.GetDataTable(set);
                foreach(DataRow row in tbResult.Rows)
                {
                    ModelProject project = new ModelProject();
                    project.WriteData(row);
                    aryResult.Add(project);
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                if (tbResult != null)
                    tbResult.Dispose();
            }
            return aryResult;
        }


    }
}
