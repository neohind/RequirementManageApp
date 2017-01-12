using RequireManager.Dac;
using RequireManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RequireManager.Manager
{
    public class DataManager
    {
        


        public static DataManager Current
        {
            get;
            private set;
        }

        static DataManager()
        {
            if (Current == null)
                Current = new DataManager();
        }

        public ModelProject SelectedProject
        {
            get;
            private set;
        }

        public MgrCategory Category
        {
            get;
            private set;
        }

        public MgrRequirement Requirement
        {
            get;
            private set;
        }


        private DataManager()
        {
            Category = new MgrCategory(this);
            Requirement = new MgrRequirement(this);
        }

        public void SetProject(ModelProject project)
        {
            SelectedProject = project;

            Reload();
        }

        public void Reload()
        {
            if(SelectedProject != null)
            {
                Category.Load();
                Requirement.Load();
                SetCategory(Category.Root);
            }
        }

        internal List<ModelReqmnt> SetCategory(ModelCategory category)
        {
            Category.SetCategory(category);
            return Requirement.SetCategory(category);
        }

        internal void DeleteCategory(ModelCategory selectedCategory)
        {
            List<ModelReqmnt> aryReqs = Requirement.FindAll(selectedCategory.Id);
            foreach (ModelReqmnt req in aryReqs)
                req.CategoryId = Category.ETC.Id;
            Category.Remove(selectedCategory);
        }

        internal void UpdateCategory(ModelCategory modelCategory)
        {
            Requirement.UpdatePath(modelCategory);
            Category.Edit(modelCategory);
        }
    }
}
