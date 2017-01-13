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

        

        public void AddRequirement(ModelReqmnt newRequirement)
        {
            int nLastedId = -1;

            UDataQuerySet set = new UDataQuerySet("SP_REQ_INSERT", CommandType.StoredProcedure);

            set.AddParam("@PRJID", newRequirement.ProjectId);
            set.AddParam("@CATID", newRequirement.CategoryId);
            set.AddParam("@IDX", newRequirement.Index);
            set.AddParam("@SRCID", newRequirement.SourceId);
            set.AddParam("@REQNMT", newRequirement.Requirement);

            try
            {
                nLastedId = m_agent.GetValue<int>(set);
                newRequirement.Id = nLastedId;
                foreach (ModelRemark remark in newRequirement.AllRemark)
                {
                    remark.RequirementId = newRequirement.Id;
                    AddRemark(remark);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                newRequirement.Id = -1;
            }
        }


        public void UpdateRequirement(ModelReqmnt requirement)
        {
            UDataQuerySet set = new UDataQuerySet("SP_REQ_UPDATE", CommandType.StoredProcedure);

            set.AddParam("@ID", requirement.Id);
            set.AddParam("@CATID", requirement.CategoryId);
            set.AddParam("@IDX", requirement.Index);
            set.AddParam("@REQNMT", requirement.Requirement);

            try
            {
                m_agent.ExecuteQuery(set);  
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }



        public void AddRemark(ModelRemark remark)
        {
            if (remark.RequirementId > -1)
            {
                UDataQuerySet set = new UDataQuerySet("SP_REQ_REMARK_INSERT", CommandType.StoredProcedure);
                set.AddParam("@PRJID", remark.ProjectId);
                set.AddParam("@REQID", remark.RequirementId);
                set.AddParam("@REMARK", remark.Contents);

                try
                {
                    int nRemarkID = m_agent.GetValue<int>(set);
                    remark.ID = nRemarkID;
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    remark.ID = -1;
                }
            }
        }

        public void UpdateRemark(ModelRemark remark)
        {
            UDataQuerySet set = new UDataQuerySet("SP_REQ_REMARK_UPDATE", CommandType.StoredProcedure);
            set.AddParam("@ID", remark.ID);
            set.AddParam("@REMARK", remark.Contents);

            try
            {
                m_agent.ExecuteQuery(set);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        internal void DeleteRemark(ModelRemark selectedRemark)
        {
            UDataQuerySet set = new UDataQuerySet("SP_REQ_REMARK_DELETE", CommandType.StoredProcedure);
            set.AddParam("@ID", selectedRemark.ID);

            try
            {
                m_agent.ExecuteQuery(set);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        internal void DelRequirement(ModelReqmnt selectedRequirement)
        {
            UDataQuerySet set = new UDataQuerySet("SP_REQ_DELETE", CommandType.StoredProcedure);
            set.AddParam("@ID", selectedRequirement.Id);

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
