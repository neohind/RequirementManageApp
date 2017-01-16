using RequireManager.Dac;
using RequireManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RequireManager.Manager
{
    public class MgrRequirement
    {
        DataManager m_parent = null;
        List<ModelReqmnt> m_aryAllRequirements = null;

        public MgrRequirement(DataManager parent)
        {
            m_parent = parent;
            m_aryAllRequirements = new List<ModelReqmnt>();
            SelectedRequirements = new List<ModelReqmnt>();
        }

        public List<ModelReqmnt> SelectedRequirements
        {
            get;
            private set;
        }


        public void Load()
        {
            ModelProject selectedProject = m_parent.SelectedProject;
            if (selectedProject != null)
            {
                m_aryAllRequirements = DacFactory.Current.Requiremnt.GetAllRequirements(selectedProject);
                UpdatePath(m_parent.Category.Root);
            }
        }

        public List<ModelReqmnt> SetCategory(ModelCategory category)
        {
            UpdateSelectedRequirements(category);

            return SelectedRequirements;
        }

        private void UpdateSelectedRequirements(ModelCategory category)
        {
            //if (category.ParentId == -1)
            //{
            //    SelectedRequirements.Clear();
            //    SelectedRequirements.AddRange(m_aryAllRequirements);
            //}
            //else
            //{
                List<ModelCategory> aryAllChildCategories = m_parent.Category.GetAllChildCategories(category.Id);

                SelectedRequirements.Clear();
                foreach(ModelCategory curCategory in aryAllChildCategories)
                {
                    List<ModelReqmnt> aryRequirement = m_aryAllRequirements.FindAll(m => m.CategoryId == curCategory.Id);
                    foreach (ModelReqmnt req in aryRequirement)
                        req.CategoryPath = curCategory.Path;
                    SelectedRequirements.AddRange(aryRequirement);
                }
            //}
        }

        internal List<ModelReqmnt> FindAll(int nCategoryID)
        {
            return m_aryAllRequirements.FindAll(m => m.CategoryId == nCategoryID);    
        }

        internal void UpdatePath(ModelCategory modelCategory)
        {

            int nCategoryID = modelCategory.Id;
            List<ModelReqmnt> aryTargetReqs = FindAll(nCategoryID);
            foreach(ModelReqmnt req in aryTargetReqs)
            {
                req.CategoryPath = modelCategory.Path;
            }

            foreach (ModelCategory childCategory in modelCategory.Childs)
                UpdatePath(childCategory);
        }

        internal ModelReqmnt NewRequirement()
        {
            ModelReqmnt newReq = new ModelReqmnt();
            if (m_parent != null && m_parent.SelectedProject != null)
            {
                int nMaxIndex = 0;
                foreach (ModelReqmnt req in SelectedRequirements)
                    if (req.Index > nMaxIndex)
                        nMaxIndex = req.Index;                     
                newReq.Id = -1;
                newReq.Index = nMaxIndex + 1;
                newReq.ProjectId = m_parent.SelectedProject.ID;
                newReq.CategoryId = m_parent.Category.SelectedCategory.Id;
                newReq.CategoryPath = m_parent.Category.SelectedCategory.Path;
            }
            return newReq;
        }

        internal void Save(ModelReqmnt SelectedRequirement)
        {
            if (SelectedRequirement.Id == -1)
            {
                DacFactory.Current.Requiremnt.AddRequirement(SelectedRequirement);
                m_aryAllRequirements.Add(SelectedRequirement);
                SelectedRequirements.Add(SelectedRequirement);
            }
            else
            {
                DacFactory.Current.Requiremnt.UpdateRequirement(SelectedRequirement);
            }            
        }

        internal void AddRemark(ModelReqmnt curReq, string sContents)
        {
            ModelRemark remark = new ModelRemark();
            remark.ProjectId = curReq.ProjectId;            
            remark.RequirementId = curReq.Id;
            remark.Contents = sContents;
            curReq.AllRemark.Add(remark);

            DacFactory.Current.Requiremnt.AddRemark(remark);
        }

        internal void UpdateRemark(ModelRemark selectedRemark)
        {
            DacFactory.Current.Requiremnt.UpdateRemark(selectedRemark);
        }

        internal void DeleteRemark(ModelReqmnt curReq, ModelRemark selectedRemark)
        {
            DacFactory.Current.Requiremnt.DeleteRemark(selectedRemark);
            curReq.AllRemark.Remove(selectedRemark);
         
        }

        internal void Delete(ModelReqmnt selectedRequirement)
        {
            DacFactory.Current.Requiremnt.DelRequirement(selectedRequirement);
            m_aryAllRequirements.Remove(selectedRequirement);
            SelectedRequirements.Remove(selectedRequirement);
        }

        internal void ReorderIndex()
        {
            if(SelectedRequirements.Count> 0)
            {
                SelectedRequirements.Sort((m, n) => m.Index - n.Index);
                int nIndex = 1;
                foreach(ModelReqmnt req in SelectedRequirements)
                {
                    req.Index = nIndex;
                    DacFactory.Current.Requiremnt.UpdateRequirement(req);
                    nIndex++;
                }
            }
        }
    }
}
