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


        public void Load(List<ModelCategory> aryAllCategories)
        {
            ModelProject selectedProject = m_parent.SelectedProject;
            if (selectedProject != null)
            {
                m_aryAllRequirements = DacFactory.Current.Requiremnt.GetAllRequirements(selectedProject);                
                foreach(ModelCategory category in aryAllCategories)
                {
                    List<ModelReqmnt> aryReq = m_aryAllRequirements.FindAll(m => m.CategoryId == category.Id);
                    foreach (ModelReqmnt req in aryReq)
                        req.CategoryPath = category.Path;
                }
            }
        }

        public List<ModelReqmnt> SetCategory(ModelCategory category)
        {
            if (category.ParentId == -1)
            {
                SelectedRequirements.Clear();
                SelectedRequirements.AddRange(m_aryAllRequirements);
            }
            else
            {
                SelectedRequirements = m_aryAllRequirements.FindAll(m => m.CategoryId == category.Id);
                foreach (ModelReqmnt req in SelectedRequirements)
                    req.CategoryPath = category.Path;
            }
            return SelectedRequirements;
        }
    }
}
