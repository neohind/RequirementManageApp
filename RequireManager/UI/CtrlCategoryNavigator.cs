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
    

        public CtrlCategoryNavigator()
        {
            InitializeComponent();
            if(DataManager.Current != null)
            {
                
                    TreeNode nodeRoot = null;
                    ModelCategory modelRoot = DataManager.Current.Category.Root;
                    if (modelRoot != null)
                    {
                        nodeRoot = new TreeNodeCategory(modelRoot);
                        nodeRoot.Tag = modelRoot;
                        treeCategory.Nodes.Add(nodeRoot);

                        PopulateCategory(nodeRoot);

                        nodeRoot.ExpandAll();
                        treeCategory.SelectedNode = nodeRoot;
                    }
                }
        }


        private void PopulateCategory(TreeNode current)
        {
            ModelCategory curModel = (ModelCategory)current.Tag;

            foreach (ModelCategory childModel in curModel.Childs)
            {
                TreeNode childNode = new TreeNodeCategory(childModel);
                childNode.Tag = childModel;
                SetNodeTooltip(childNode, childModel.DisplayName, childModel.Description);
                current.Nodes.Add(childNode);
                PopulateCategory(childNode);
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
                                frm.Path = m_selectedNodeCategory.FullPath;
                                frm.CurAction = frmCategory.ActionType.Add;
                                frm.ParentModel = selectedCategory;
                                //frm.AllCategories = m_aryAllCategories;
                                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    if (frm.CurModel != null)
                                    {
                                       // m_aryAllCategories.Add(frm.CurModel);
                                        DacFactory.Current.Category.AddCategory(frm.CurModel);
                                        TreeNode node = new TreeNodeCategory(frm.CurModel);
                                        SetNodeTooltip(node, frm.CurModel.DisplayName, frm.CurModel.Description);
                                        m_selectedNodeCategory.Nodes.Add(node);
                                        SelectedNodeChange(node);
                                        node.ExpandAll();
                                    }
                                }
                            }
                            break;
                        case "menuItemDelCategory":
                            {
                                if ("ROOT".Equals(selectedCategory.Code) || "ETC".Equals(selectedCategory.Code))
                                    return;

                                ModelCategory categoryChild = null; // m_aryAllCategories.Find(m => m.ParentId.Equals(selectedCategory.Id));
                                if (categoryChild != null)
                                    return;

                                string sMessage = string.Format("Really delete {0}[{1}]?", selectedCategory.DisplayName, selectedCategory.Code);
                                if (MessageBox.Show(sMessage, "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    ModelCategory categoryETC = new ModelCategory(); // m_aryAllCategories.Find(m => "ETC".Equals(m.Code));
                                    TreeNode nodeEtc = FindNode(null, categoryETC.Id);
                                    string sPath = GetPath(nodeEtc);
                                    //List<ModelReqmnt> aryMovingRequirements = m_aryAllRequirement.FindAll(m => m.CategoryId == selectedCategory.Id);
                                    //foreach (ModelReqmnt req in aryMovingRequirements)
                                    //{
                                    //    req.CategoryId = categoryETC.Id;
                                    //    req.CategoryPath = sPath;
                                    //    DacFactory.Current.Requiremnt.MoveToCategory(req.Id, categoryETC.Id);
                                    //}
                                    TreeNode selectedNode = m_selectedNodeCategory;
                                    TreeNode nodeParent = selectedNode.Parent;
                                    SelectedNodeChange(nodeParent);
                                    nodeParent.Nodes.Remove(selectedNode);
                                    //m_aryAllCategories.Remove(selectedCategory);
                                    DacFactory.Current.Category.DelCategot(selectedCategory);

                                    SelectedNodeChange(nodeEtc);

                                }
                            }
                            break;
                        case "menuItemEditCategory":
                            {
                                if ("ROOT".Equals(selectedCategory.Code) || "ETC".Equals(selectedCategory.Code))
                                    return;

                                frmCategory frm = new frmCategory();
                                frm.Path = m_selectedNodeCategory.FullPath;
                                frm.CurAction = frmCategory.ActionType.Edit;
                                frm.CurModel = (ModelCategory)m_selectedNodeCategory.Tag;
                                //frm.AllCategories = m_aryAllCategories;
                                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    DacFactory.Current.Category.UpdateCategory(frm.CurModel);
                                    m_selectedNodeCategory.Text = frm.CurModel.Code;
                                    SetNodeTooltip(m_selectedNodeCategory, frm.CurModel.DisplayName, frm.CurModel.Description);
                                    SelectedNodeChange(m_selectedNodeCategory);

                                }
                            }
                            break;
                    }
                }
            }
        }

        private void SetNodeTooltip(TreeNode node, string sDisplayName, string sDescription)
        {
            node.ToolTipText = sDisplayName;
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
