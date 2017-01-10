using RequireManager.Dac;
using RequireManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RequireManager
{
    public partial class frmMain : Form
    {
        
        ModelProject m_selectedProject = null;
        ModelCategory m_selectedCategory = null;
        string m_sCurrentPath = string.Empty;

        List<ModelCategory> m_aryAllCategories = null;
        List<ModelReqmnt> m_aryAllRequirement = null;
        List<ModelReqmnt> m_aryCurRequirements = null;
        
        

        public frmMain()
        {
            InitializeComponent();
                      
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            m_aryAllCategories = DacFactory.Current.Category.GetAllCategory(m_selectedProject);
            m_aryAllRequirement = DacFactory.Current.Requiremnt.GetAllRequirements(m_selectedProject);
            RebuildPath();
           
            
            ctrlCategoryNavigator1.CurrentProject = m_selectedProject;
            ctrlCategoryNavigator1.AllCategories = m_aryAllCategories;
            ctrlCategoryNavigator1.OnChangeSelectCategory += ctrlCategoryNavigator1_OnChangeSelectCategory;

            UpdateRequirementGrid(null);
        }

        void ctrlCategoryNavigator1_OnChangeSelectCategory(ModelCategory category)
        {
            
            m_selectedCategory = category;

            List<ModelReqmnt> aryRequirements = m_aryAllRequirement.FindAll(m => (m.CategoryId == m_selectedCategory.Id) || (m_selectedCategory.ParentId == -1));

            ctrlGridRequirementItems1.SetDataSource(m_aryAllCategories , category,aryRequirements);

        }

        private void RebuildPath()
        {
            foreach(ModelCategory category in m_aryAllCategories)
            {
                if ("ROOT".Equals(category.Code))
                    continue;
                List<ModelReqmnt> aryTargetRequirements = m_aryAllRequirement.FindAll(m => m.CategoryId == category.Id);
                
                string sCurPath = MakePath(m_aryAllCategories, category);
                category.Path = sCurPath;
                foreach (ModelReqmnt req in aryTargetRequirements)
                    req.CategoryPath = sCurPath;

            }
        }

        static string MakePath(List<ModelCategory> aryAllCategory, ModelCategory curCategory)
        {
            if(curCategory != null && curCategory.ParentId != -1)
            {
                ModelCategory parent = aryAllCategory.Find(m=> m.Id == curCategory.ParentId);
                if(parent.ParentId > -1)
                    return string.Format("{0}-{1}", MakePath(aryAllCategory, parent), curCategory.Code);
                return curCategory.Code;
            }
            return string.Empty;
        }


        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            
        }

       
        internal void SetSelectedProject(ModelProject modelProject)
        {
            m_selectedProject = modelProject;
        }

       
    

        private void btnRequirementAdd_Click(object sender, EventArgs e)
        {
            
        }



        void UpdateRequirementGrid(ModelCategory category)
        {
            m_aryCurRequirements = m_aryAllRequirement;
            if(category != null)
                m_aryCurRequirements = m_aryAllRequirement.FindAll(m => m.CategoryId == category.Id);

            //gridItems.DataSource = m_aryCurRequirements;
        }


        private void btnMoveToCategory_Click(object sender, EventArgs e)
        {
            //if (gridItems.SelectedRows.Count > 0)
            //{
            //    ModelCategory categoryOrigin =    (ModelCategory)m_selectedNodeCategory.Tag;


                
            //    frmMoveToCategory frm = new frmMoveToCategory();
            //    frm.AllCategory = m_aryAllCategories;


            //    frm.SelectedCategory =  categoryOrigin;

            //    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {
            //        int nSelectedCategoryID = frm.SelectedCategory.Id;

            //        foreach (DataGridViewRow row in gridItems.SelectedRows)
            //        {
            //            DataGridViewCell cellReqId = row.Cells["colGridReqID"];
            //            DataGridViewCell cellCategoryId = row.Cells["colGridReqCategoryID"];
            //            int nReqID = Convert.ToInt32(cellReqId.Value);
            //            int nCategoryID = Convert.ToInt32(cellCategoryId.Value);

            //            if (nCategoryID != nSelectedCategoryID)
            //            {
            //                DacFactory.Current.Requiremnt.MoveToCategory(nReqID, nSelectedCategoryID);
            //                ModelReqmnt req = m_aryAllRequirement.Find(m => m.Id == nReqID);
            //                if (req != null)
            //                {
            //                    req.CategoryId = nSelectedCategoryID;                                
            //                }

            //                //TreeNode nodeSelectedCategory = FindNode(null, nSelectedCategoryID);
            //                //string sPath = GetPath(nodeSelectedCategory);
            //                //req.CategoryPath = sPath;
            //            }
            //        }
            //        UpdateRequirementGrid(categoryOrigin);
            //    }
            //}
        }

        private void btnReqIndexFix_Click(object sender, EventArgs e)
        {
            if (m_aryCurRequirements == null || m_aryAllRequirement.Count == m_aryCurRequirements.Count)
                return;

            m_aryCurRequirements.Sort((m, n) => n.Index - m.Index);

            int nIndex = 1;
            foreach(ModelReqmnt req in m_aryCurRequirements)
            {
                req.Index = nIndex;
                DacFactory.Current.Requiremnt.UpdateIndex(req);
                nIndex++;
            }
            
            //UpdateRequirementGrid((ModelCategory)m_selectedNodeCategory.Tag);
        }

        private void btnRequirementEdit_Click(object sender, EventArgs e)
        {

        }

      
    }
}
