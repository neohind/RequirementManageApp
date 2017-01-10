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
    public partial class frmMoveToCategory : Form
    {
        public List<ModelCategory> AllCategory
        {
            get;
            set;
        }

        public ModelCategory SelectedCategory
        {
            get;
            set;
        }

        public frmMoveToCategory()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            TreeNode nodeRoot;
            ModelCategory rootModel = null;
            if (AllCategory.Count > 0)
            {
                rootModel = AllCategory.Find(m => m.ParentId == -1);
                nodeRoot = new TreeNode(rootModel.DisplayName);
                nodeRoot.Tag = rootModel;

                treeCategory.Nodes.Add(nodeRoot);
                PopulateCategory(nodeRoot, string.Empty);
                nodeRoot.ExpandAll();
                treeCategory.SelectedNode = nodeRoot;
                SelectedNodeChange(nodeRoot);
            }

        }

        private void PopulateCategory(TreeNode current, string sCurPath)
        {
            ModelCategory curModel = (ModelCategory)current.Tag;


            List<ModelCategory> childModels = AllCategory.FindAll(m => m.ParentId == curModel.Id);
            foreach (ModelCategory childModel in childModels)
            {
                TreeNode childNode = new TreeNode(childModel.Code);
                childNode.Tag = childModel;
                SetNodeTooltip(childNode, childModel.DisplayName, childModel.Description);
                current.Nodes.Add(childNode);
                PopulateCategory(childNode, sCurPath);
            }
        }

        private void SetNodeTooltip(TreeNode node, string sDisplayName, string sDescription)
        {
            StringBuilder sbMessage = new StringBuilder();
            sbMessage.Append(sDisplayName);
            if (string.IsNullOrEmpty(sDescription) == false)
            {
                sbMessage.AppendLine();
                sbMessage.AppendFormat("> {0}", sDescription);
            }
            node.ToolTipText = sbMessage.ToString();
        }


        private void SelectedNodeChange(TreeNode node)
        {
            if (node != null)
            {
                ModelCategory category = (ModelCategory)node.Tag;

                if ("ROOT".Equals(category.Code))
                {
                    SelectedNodeChange(node.Nodes[0]);
                }
                else if (object.Equals(SelectedCategory, category) == false)
                {
                    SelectedCategory = category;
                }
            }
        }

        private void treeCategory_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectedNodeChange(e.Node);

        }



    }
}
