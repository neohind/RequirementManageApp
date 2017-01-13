using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RequireManager.Models;
using RequireManager.Dac;
using RequireManager.Manager;

namespace RequireManager.UI
{
    public partial class CtrlCategoryNavigator : UserControl
    {
        public delegate void OnChangeSelectCategoryHandler(ModelCategory category);
        public event OnChangeSelectCategoryHandler OnChangeSelectCategory;


        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        TreeNode m_selectedNodeCategory = null;
        TreeNode m_dragNode = null;
        TreeNodeCategory m_rootNode = null;


        public CtrlCategoryNavigator()
        {
            InitializeComponent();
            if (DataManager.Current != null)
            {
                m_rootNode = null;
                ModelCategory modelRoot = DataManager.Current.Category.Root;
                if (modelRoot != null)
                {
                    m_rootNode = new TreeNodeCategory(modelRoot);
                    m_rootNode.Tag = modelRoot;
                    treeCategory.Nodes.Add(m_rootNode);

                    PopulateCategory(m_rootNode);

                    m_rootNode.ExpandAll();
                    treeCategory.SelectedNode = m_rootNode;
                }
                DataManager.Current.Category.OnCategoryAdded += Category_OnCategoryAdded;
                DataManager.Current.Category.OnCategoryDeleted += Category_OnCategoryDeleted;
            }
        }

       

        private void PopulateCategory(TreeNode current)
        {
            ModelCategory curModel = (ModelCategory)current.Tag;

            foreach (ModelCategory childModel in curModel.Childs)
            {
                TreeNode childNode = new TreeNodeCategory(childModel);
                current.Nodes.Add(childNode);
                PopulateCategory(childNode);
            }
        }


        void Category_OnCategoryAdded(ModelCategory model)
        {
            if (this.InvokeRequired)
                this.Invoke(new MgrCategory.OnCategorySingleModelHandler(Category_OnCategoryAdded), model);
            else if (model != null && model.Parent != null)
            {
                string sPath = model.Parent.FullPath;
                TreeNodeCategory parentNode = m_rootNode.FindNode(sPath);
                if (parentNode != null)
                {
                    TreeNode node = new TreeNodeCategory(model);
                    parentNode.Nodes.Add(node);
                    SelectedNodeChange(node);
                }
            }
        }

        void Category_OnCategoryDeleted(ModelCategory model)
        {
            if (this.InvokeRequired)
                this.Invoke(new MgrCategory.OnCategorySingleModelHandler(Category_OnCategoryDeleted), model);
            else if (model != null)
            {
                string sPath = model.FullPath;
                TreeNodeCategory node = m_rootNode.FindNode(sPath);
                TreeNode parentNode = node.Parent;

                if (parentNode != null)
                {
                    parentNode.Nodes.Remove(node);
                    SelectedNodeChange(parentNode);
                }
            }
        }




        private void menuCategory_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripItem)
            {
                if (m_selectedNodeCategory != null)
                {
                    ModelCategory selectedCategory = (ModelCategory)m_selectedNodeCategory.Tag;
                    ToolStripItem item = (ToolStripItem)sender;

                    switch (item.Name)
                    {
                        case "menuItemAddCategory":
                            {
                                if ("ETC".Equals(selectedCategory.Code))
                                    return;

                                frmCategory frm = new frmCategory();                                
                                frm.CurAction = frmCategory.ActionType.Add;
                                frm.ParentModel = selectedCategory;                                
                                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    if (frm.CurModel != null)
                                        DataManager.Current.Category.AddCategory(frm.ParentModel, frm.CurModel);                                                                                
                                }
                            }
                            break;
                        case "menuItemDelCategory":
                            {
                                if ("ROOT".Equals(selectedCategory.Code) || "ETC".Equals(selectedCategory.Code))
                                    return;

                                ModelCategory categoryChild = DataManager.Current.Category.FindByParentID(selectedCategory.Id);
                                if (categoryChild != null)
                                {
                                    MessageBox.Show("Can't delete because this has child categories", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                string sMessage = string.Format("Really delete {0}[{1}]?", selectedCategory.DisplayName, selectedCategory.Code);
                                if (MessageBox.Show(sMessage, "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    DataManager.Current.DeleteCategory(selectedCategory);
                                }
                            }
                            break;
                        case "menuItemEditCategory":
                            {
                                if ("ROOT".Equals(selectedCategory.Code) || "ETC".Equals(selectedCategory.Code))
                                    return;

                                frmCategory frm = new frmCategory();
                                
                                frm.CurAction = frmCategory.ActionType.Edit;
                                frm.ParentModel = selectedCategory.Parent;
                                frm.CurModel = selectedCategory;                                
                                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    DataManager.Current.UpdateCategory(frm.CurModel);                                     
                                    
                                    SelectedNodeChange(m_selectedNodeCategory);

                                }
                            }
                            break;
                    }
                }
            }
        }


        private void treeCategory_DragDrop(object sender, DragEventArgs e)
        {
            log.Debug(sender);
            Point pos = treeCategory.PointToClient(new Point(e.X, e.Y));
            pos.Offset(this.Padding.Left * -1, this.Padding.Top * -1);
            TreeNode selectedNode = treeCategory.GetNodeAt(pos);            
            if (m_dragNode != null)
            {
                TreeNode sourceNode = m_dragNode;
                m_dragNode = null;

                ModelCategory targetModel = (ModelCategory)selectedNode.Tag;
                ModelCategory sourceModel = (ModelCategory)sourceNode.Tag;

                //if ("ETC".Equals(targetModel.Code) || targetModel.Id == sourceModel.ParentId
                //    || m_aryAllCategories.Find(m => m.ParentId == targetModel.Id && m.Code.Equals(sourceModel.Code)) != null)
                //    return;

                string sMessage = string.Format("Really move '{0}[{1}]' to '{2}[{3}]'?"
                    , sourceModel.DisplayName, sourceModel.Code
                    , targetModel.DisplayName, targetModel.Code);
                if (MessageBox.Show(sMessage, "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    sourceModel.ParentId = targetModel.Id;
                    DacFactory.Current.Category.UpdateCategory(sourceModel);
                    sourceNode.Parent.Nodes.Remove(sourceNode);
                    selectedNode.Nodes.Add(sourceNode);
                    selectedNode.ExpandAll();
                }
            }
        }

        private void treeCategory_DragEnter(object sender, DragEventArgs e)
        {
            log.Debug(sender);
            e.Effect = DragDropEffects.Move;
        }

        private void treeCategory_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Item is TreeNode)
            {
                TreeNode node = (TreeNode)e.Item;
                ModelCategory category = (ModelCategory)node.Tag;
                if ("ROOT".Equals(category.Code) || "ETC".Equals(category.Code))
                    return;

                m_dragNode = node;
                DoDragDrop(category, DragDropEffects.Move);
            }
        }

        private void treeCategory_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectedNodeChange(e.Node);
        }



        private void SelectedNodeChange(TreeNode node)
        {
            if (node != null)
            {
                ModelCategory category = (ModelCategory)node.Tag;

                if (object.Equals(node, m_selectedNodeCategory) == false)
                {
                    m_selectedNodeCategory = node;
                    treeCategory.SelectedNode = node;
                    if (OnChangeSelectCategory != null)
                        OnChangeSelectCategory(category);
                }

                

                //string sPath = GetPath(node);

                //if ("ROOT".Equals(category.Code))
                //{
                //    btnRequirementAdd.Enabled = false;
                //    UpdateRequirementGrid(null);
                //}
                //else
                //{
                //    btnRequirementAdd.Enabled = true;
                //    UpdateRequirementGrid(category);
                //}

                //lblPath.Text = sPath;
                //m_frmAddReq.CurrentCategory = category;
                //m_frmAddReq.Path = sPath;
            }
        }


        private TreeNode FindNode(TreeNode current, int nCategoryID)
        {
            if (current == null)
                current = treeCategory.Nodes[0];

            foreach (TreeNode node in current.Nodes)
            {
                ModelCategory category = node.Tag as ModelCategory;
                if (category.Id == nCategoryID)
                    return node;

                TreeNode foundNode = FindNode(node, nCategoryID);
                if (foundNode != null)
                    return foundNode;
            }
            return null;
        }



        private string GetPath(TreeNode node)
        {
            string[] aryPath = node.FullPath.Split("\\".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string sPath = string.Empty;
            if (aryPath.Length == 1)
                sPath = aryPath[0];
            else
            {
                StringBuilder sbPath = new StringBuilder();
                for (int i = 1; i < aryPath.Length; i++)
                {
                    if (i > 1)
                        sbPath.Append("-");
                    sbPath.Append(aryPath[i]);
                }
                sPath = sbPath.ToString();
            }

            return sPath;
        }




    }
}
