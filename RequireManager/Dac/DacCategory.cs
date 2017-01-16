using RequireManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RequireManager.Dac
{
    public class DacCategory : DacBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public DacCategory(string sConnectionString)
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

        public List<ModelCategory> GetAllCategory(ModelProject selectedProject)
        {
            List<ModelCategory> aryResult = new List<ModelCategory>();

            DataTable tbResult = null;
            UDataQuerySet set = new UDataQuerySet("SP_CAT_SELECT", CommandType.StoredProcedure);
            set.AddParam("@PRJID", selectedProject.ID);

            try
            {
                tbResult = m_agent.GetDataTable(set);

                foreach (DataRow row in tbResult.Rows)
                {
                    ModelCategory category = new ModelCategory();
                    category.WriteData(row);
                    aryResult.Add(category);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            finally
            {
                if (tbResult != null)
                    tbResult.Dispose();
            }


            return aryResult;
        }

        public void AddCategory(ModelCategory newCategory)
        {
            int nLastedId = -1;
            string sQuery = @"INSERT INTO TB_CATEGORY (PID,PRJID,CODE,DISPNM,DESCRPT,CREATED,UPDATED)
     VALUES (@PID ,@PRJID ,@CODE ,@DISPNM ,@DESCRPT ,GETDATE() ,NULL)
            SELECT IDENT_CURRENT('TB_CATEGORY')";

            UDataQuerySet set = new UDataQuerySet(sQuery);
            set.AddParam("@PID", newCategory.ParentId);
            set.AddParam("@PRJID", newCategory.ProjectId);
            set.AddParam("@CODE", newCategory.Code);
            set.AddParam("@DISPNM", newCategory.DisplayName);
            set.AddParam("@DESCRPT", newCategory.Description);

            try
            {
                nLastedId = m_agent.GetValue<int>(set);
                newCategory.Id = nLastedId;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                newCategory.Id = -1;
            }
        }


        internal void UpdateCategory(ModelCategory selectedCategory)
        {
            string sQuery = "UPDATE TB_CATEGORY SET PID = @PID,CODE = @CODE, DISPNM = @DISPNM,DESCRPT = @DESCRPT, UPDATED = GETDATE() WHERE ID = @ID AND PRJID = @PRJID";
            UDataQuerySet set = new UDataQuerySet(sQuery);
            set.AddParam("@ID", selectedCategory.Id);
            set.AddParam("@PID", selectedCategory.ParentId);
            set.AddParam("@PRJID", selectedCategory.ProjectId);
            set.AddParam("@CODE", selectedCategory.Code.Trim());
            set.AddParam("@DISPNM", selectedCategory.DisplayName.Trim());
            set.AddParam("@DESCRPT", selectedCategory.Description.Trim());
              try
            {
                m_agent.ExecuteQuery(set);                
            }
            catch (Exception ex)
            {
                log.Error(ex);                
            }
        }

        internal void DelCategot(ModelCategory selectedCategory)
        {
            string sQuery = "DELETE TB_CATEGORY WHERE ID = @ID AND PRJID = @PRJID";
            UDataQuerySet set = new UDataQuerySet(sQuery);
            set.AddParam("@ID", selectedCategory.Id);
            set.AddParam("@PRJID", selectedCategory.ProjectId);       

            try
            {
                m_agent.ExecuteQuery(set);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

        }
    }
}
