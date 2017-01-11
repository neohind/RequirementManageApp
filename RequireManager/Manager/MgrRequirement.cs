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
            }
        }

        public List<ModelReqmnt> SetCategory(ModelCategory category)
        {
            SelectedRequirements = m_aryAllRequirements.FindAll(m => m.CategoryId == category.Id && category.ParentId == -1);
            return SelectedRequirements;
        }
    }
}
