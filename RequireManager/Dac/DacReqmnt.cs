using RequireManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RequireManager.Dac
{
    public class DacReqmnt : DacBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public DacReqmnt(string sConnectionString)
            : base(sConnectionString)
        {   
        }

        public void AddRequirement(ModelReqmnt newRequirement)
        {
                  
            int nLastedId = -1;
            string sQuery = @"INSERT INTO TB_REQS (PRJID,CATID,IDX,SRCID,REQNMT,ENABLED,CREATED) VALUES (@PRJID, @CATID, @IDX, @SRCID,@REQNMT,'Y', GETDATE())
                              SELECT IDENT_CURRENT('TB_REQS')";

            UDataQuerySet set = new UDataQuerySet(sQuery);

            set.AddParam("@PRJID", newRequirement.ProjectId);
            set.AddParam("@CATID", newRequirement.CategoryId);
            set.AddParam("@IDX", newRequirement.Index);
            set.AddParam("@SRCID", newRequirement.SourceId);
            set.AddParam("@REQNMT", newRequirement.Requirement);

            try
            {
                nLastedId = m_agent.GetValue<int>(set);
                newRequirement.Id = nLastedId;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                newRequirement.Id = -1;
            }       
        }


        public void MoveToCategory(int nReqId, int nCategoryId)
        {



            int nLastedId = -1;
            string sQuery = @"UPDATE TB_REQS SET CATID=@CATID WHERE ID = @ID";

            UDataQuerySet set = new UDataQuerySet(sQuery);

            set.AddParam("@ID", nReqId);
            set.AddParam("@CATID", nCategoryId);

            try
            {
                nLastedId = m_agent.ExecuteQuery(set);
            }
            catch (Exception ex)
            {
                log.Error(ex);

            }
        }


        internal List<ModelReqmnt> GetAllRequirements(ModelProject selectedProject)
        {
            List<ModelReqmnt> aryResult = new List<ModelReqmnt>();
            
            DataTable tbResult = null;
            DataTable tbResultRemark = null;
            UDataQuerySet set = new UDataQuerySet("SP_REQ_SELECT", CommandType.StoredProcedure);
            set.AddParam("@PRJID", selectedProject.ID);

            UDataQuerySet setRemark = new UDataQuerySet("SP_REQ_REMARK_SELECT", CommandType.StoredProcedure);            
            setRemark.AddParam("@PRJID", selectedProject.ID);

            try
            {
                tbResult = m_agent.GetDataTable(set);
                tbResultRemark = m_agent.GetDataTable(setRemark);

                foreach (DataRow row in tbResult.Rows)
                {
                    ModelReqmnt req = new ModelReqmnt();
                    req.WriteData(row);
                    aryResult.Add(req);

                    DataRow[] aryRemarks = tbResultRemark.Select(string.Format("REQID = {0}", req.Id));
                    foreach(DataRow rowRemark in aryRemarks)
                    {
                        ModelRemark remark = new ModelRemark();
                        remark.WriteData(rowRemark);
                        req.AllRemark.Add(remark);
                    }
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
                if (tbResultRemark != null)
                    tbResultRemark.Dispose();
            }

            return aryResult;
        }

        internal void UpdateIndex(ModelReqmnt req)
        {
            int nLastedId = -1;
            string sQuery = @"UPDATE TB_REQS SET IDX=@IDX WHERE ID = @ID";

            UDataQuerySet set = new UDataQuerySet(sQuery);

            set.AddParam("@ID", req.Id);
            set.AddParam("@IDX", req.Index);

            try
            {
                nLastedId = m_agent.ExecuteQuery(set);
            }
            catch (Exception ex)
            {
                log.Error(ex);

            }
        }

        internal void AddRemark(ModelReqmnt m_selectedRequirement, string sRemark)
        {
            UDataQuerySet set = new UDataQuerySet("SP_REQ_REMARK_INSERT", CommandType.StoredProcedure);
            set.AddParam("@PRJID", m_selectedRequirement.ProjectId);
            set.AddParam("@REQID", m_selectedRequirement.Id);
            set.AddParam("@REMARK", sRemark);

            try
            {
                int nRemarkID = m_agent.GetValue<int>(set);
                ModelRemark remark = new ModelRemark();
                remark.ProjectId = m_selectedRequirement.ProjectId;
                remark.RequirementId = m_selectedRequirement.Id;
                remark.ID = nRemarkID;
                remark.Contents = sRemark;

                m_selectedRequirement.AllRemark.Add(remark);
            }
            catch(Exception ex)
            {
                log.Error(ex);
            }
        }
    }
}
