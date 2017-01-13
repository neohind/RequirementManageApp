using RequireManager.Dac;
using RequireManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RequireManager.Manager
{
    public class MgrCategory
    {
        public delegate void OnCategorySingleModelHandler(ModelCategory model);


        public event OnCategorySingleModelHandler OnSelectedCategoryChanged;
        public event OnCategorySingleModelHandler OnCategoryAdded;
        public event OnCategorySingleModelHandler OnCategoryDeleted;

        DataManager m_parent = null;
        

        public ModelCategory Root
        {
            get;
            private set;
        }

        public ModelCategory ETC
        {
            get;
            private set;
        }

        public ModelCategory SelectedCategory
        {
            get;
            private set;
        }

        public List<ModelCategory> AllCategories
        {
            get;
            private set;
        }

        public List<ModelCategory> AllCategoryExceptRoot
        {
            get
            {
                List<ModelCategory> aryResults = new List<ModelCategory>();
                aryResults.AddRange(AllCategories);
                aryResults.Remove(Root);
                return aryResults;
            }
            
        }


        public MgrCategory(DataManager parent)
        {
            m_parent = parent;
            AllCategories = new List<ModelCategory>();            
        }


        public void Load()
        {
            ModelProject selectedProject = m_parent.SelectedProject;
            if (selectedProject != null)
            {
                AllCategories = DacFactory.Current.Category.GetAllCategory(selectedProject);
                MakeHeirachy();
            }
        }

        private void MakeHeirachy()
        {
            Root = Find("ROOT");
            ETC = Find("ETC");
            MakeHeirachy(Root);
        }

        private void MakeHeirachy(ModelCategory curCategory)
        {
            if(curCategory != null)
            {
                List<ModelCategory> aryChildren = FindAllByParentID(curCategory.Id);
                foreach(ModelCategory child in aryChildren)
                {
                    curCategory.Childs.Add(child);
                    child.Parent = curCategory;
                    MakeHeirachy(child);
                }
            }
        }

        public ModelCategory Find(int nID)
        {
            if (AllCategories == null)
                return null;
            return AllCategories.Find(m => m.Id == nID);
        }

        public ModelCategory Find(string sCode)
        {
            if (AllCategories == null)
                return null;
            return AllCategories.Find(m => string.Equals(sCode, m.Code));
        }



        public ModelCategory FindByParentID(int nID)
        {
            if (AllCategories == null)
                return null;
            return AllCategories.Find(m => m.ParentId == nID);
        }

        public List<ModelCategory> FindAllByParentID(int nID)
        {
            if (AllCategories == null)
                return new List<ModelCategory>();
            return AllCategories.FindAll(m => m.ParentId == nID);
        }

        internal void SetCategory(ModelCategory category)
        {               
            SelectedCategory = category;
            if (OnSelectedCategoryChanged != null)
                OnSelectedCategoryChanged(category);
        }

        internal void AddCategory(ModelCategory modelParentCategory, ModelCategory modelCategory)
        {
            AllCategories.Add(modelCategory);
            modelParentCategory.Childs.Add(modelCategory);
            modelCategory.Parent = modelParentCategory;
            DacFactory.Current.Category.AddCategory(modelCategory);

            if (OnCategoryAdded != null)
                OnCategoryAdded(modelCategory);
        }

        internal void Edit(ModelCategory modelCategory)
        {
            DacFactory.Current.Category.UpdateCategory(modelCategory);
            modelCategory.Refresh();
        }

        internal void Remove(ModelCategory selectedCategory)
        {
            DacFactory.Current.Category.DelCategot(selectedCategory);
            selectedCategory.Parent.Childs.Remove(selectedCategory);
            if (OnCategoryDeleted != null)
                OnCategoryDeleted(selectedCategory);
        }
    }
}
