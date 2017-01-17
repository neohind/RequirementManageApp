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
        public delegate void OnUpdateRequirementsHandler();
        public event OnUpdateRequirementsHandler OnUpdateRequirements;


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
                m_aryAllRequirements = DacFactory.Current.Requiremnt.GetAllRequirements(selectedProject, m_parent.Category.AllCategories);
                
                    
            }
        }

        public List<ModelReqmnt> SetCategory(ModelCategory category)
        {
            UpdateSelectedRequirements(category);

            return SelectedRequirements;
        }

        private void UpdateSelectedRequirements(ModelCategory category)
        {
            List<ModelCategory> aryAllChildCategories = m_parent.Category.GetAllChildCategories(category.Id);
            SelectedRequirements.Clear();
            foreach(ModelCategory curCategory in aryAllChildCategories)
            {
                List<ModelReqmnt> aryRequirement = m_aryAllRequirements.FindAll(m => m.CategoryId == curCategory.Id);                   
                SelectedRequirements.AddRange(aryRequirement);
            }
        }

        internal List<ModelReqmnt> FindAll(int nCategoryID)
        {
            return m_aryAllRequirements.FindAll(m => m.CategoryId == nCategoryID);    
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
                newReq.Category = m_parent.Category.SelectedCategory;
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
            if (m_parent.Category.SelectedCategory != null && SelectedRequirements.Count > 0)
            {
                List<ModelReqmnt> aryRequirement = SelectedRequirements.FindAll(m => m.CategoryId == m_parent.Category.SelectedCategory.Id);

                if (aryRequirement.Count > 0)
                {
                    aryRequirement.Sort((m, n) => m.Index - n.Index);
                    int nIndex = 1;
                    foreach (ModelReqmnt req in aryRequirement)
                    {
                        req.Index = nIndex;
                        DacFactory.Current.Requiremnt.UpdateRequirement(req);
                        nIndex++;
                    }
                }
            }
        }

        internal void ChangeCategory(ModelCategory targetModel, List<ModelReqmnt> aryRequirements)
        {
            foreach (ModelReqmnt req in aryRequirements)
            {
                req.Category = targetModel;  
            }
            UpdateSelectedRequirements(targetModel);
            if (OnUpdateRequirements != null)
                OnUpdateRequirements();
        }

        internal void Search(string sSearchWordAll)
        {

            string[] aryWordToken = sSearchWordAll.Split(" ".ToCharArray());

            SelectedRequirements.Clear();
            List<ModelReqmnt> aryResult = new List<ModelReqmnt>();
            aryResult.AddRange(m_aryAllRequirements);
            
            foreach (string sSearchWord in aryWordToken)
            {
                aryResult = Search(sSearchWord.ToUpper(), aryResult);
            }

            SelectedRequirements.AddRange(aryResult);
            if (OnUpdateRequirements != null)
                OnUpdateRequirements();
        }

        private List<ModelReqmnt> Search(string sSearchWord, List<ModelReqmnt> source)
        {
            List<ModelReqmnt> aryResult = source.FindAll(m => m.CategoryPath.Contains(sSearchWord));

            foreach (ModelReqmnt req in source)
            {
                if (req.Requirement.ToUpper().Contains(sSearchWord))
                {
                    if (aryResult.Contains(req) == false)
                        aryResult.Add(req);
                }
                else
                {
                    foreach (ModelRemark remark in req.AllRemark)
                        if (remark.Contents.ToUpper().Contains(sSearchWord))
                        {
                            if (aryResult.Contains(req) == false)
                                aryResult.Add(req);
                        }
                }
            }

            return aryResult;
        }
    }
}
