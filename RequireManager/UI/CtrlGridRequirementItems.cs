using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RequireManager.Models;
using RequireManager.Manager;

namespace RequireManager.UI
{
    public partial class CtrlGridRequirementItems : UserControl
    {
        Point m_posDragStart = Point.Empty;
        frmRequirement m_frmRequirement = new frmRequirement();
        ModelReqmnt m_selectedRequirement = null;

        public CtrlGridRequirementItems()
        {
            InitializeComponent();
            m_frmRequirement.OnRequirementUpdated += m_frmRequirement_OnRequirementUpdated;
            DataManager.Current.Requirement.OnUpdateRequirements += Requirement_OnUpdateRequirements;
        }

        void Requirement_OnUpdateRequirements()
        {
            ReloadRequirements();
        }

        void m_frmRequirement_OnRequirementUpdated(object sender, EventArgs e)
        {
            ReloadRequirements();
            
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
 	         base.OnHandleDestroyed(e);
                m_frmRequirement.SetClose();
        }


        private void gridItems_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                gridItems.Rows[e.RowIndex].Selected = true;
                DataRowView row = (DataRowView)gridItems.Rows[e.RowIndex].DataBoundItem;
                m_selectedRequirement = row["SRC"] as ModelReqmnt;
            }
        }



        internal void Reload()
        {
            m_frmRequirement.SetAllCategories();
            ReloadRequirements();
            if (m_frmRequirement.Visible)
                m_frmRequirement.Close();
        }

        private void ReloadRequirements()
        {
            lblPath.Text = (DataManager.Current.Category.SelectedCategory == null
                || string.IsNullOrEmpty(DataManager.Current.Category.SelectedCategory.Path))
                ? "ROOT"
                : DataManager.Current.Category.SelectedCategory.Path;


            List<ModelReqmnt> requirements = DataManager.Current.Requirement.SelectedRequirements;
            tbRequirement.Rows.Clear();
            foreach (ModelReqmnt req in requirements)
            {
                DataRow row = tbRequirement.NewRow();
                req.UpdataeData(row);
                row["SRC"] = req;
                tbRequirement.Rows.Add(row);
            }
            gridItems.Update();
        }

        private void ContextMenu_Click(object sender, EventArgs e)
        {
            if(sender is ToolStripMenuItem)
            {
                string sMenuName = ((ToolStripMenuItem)sender).Name;                
                switch(sMenuName)
                {
                    case "menuItemReqAdd":
                        {
                            m_frmRequirement.CurRequirement = null;
                            m_frmRequirement.Show();
                            m_frmRequirement.BringToFront();
                        }
                        break;
                    case "menuItemReqEdit":
                        {
                            if (m_selectedRequirement !=null )
                            {
                                m_frmRequirement.CurRequirement = m_selectedRequirement;
                                m_frmRequirement.Show();
                                m_frmRequirement.BringToFront();
                            }
                        }
                        break;
                    case "menuItemReqDel":
                        {
                            string sMessage = string.Format("Really remove requirement? \r\n {0}", m_selectedRequirement.Requirement);
                            if(MessageBox.Show(sMessage, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                DataManager.Current.Requirement.Delete(m_selectedRequirement);
                                ReloadRequirements();
                            }
                        }
                        break;
                    case "menuItemReorder":
                        {
                            DataManager.Current.Requirement.ReorderIndex();
                            ReloadRequirements();
                        }
                        break;
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            menuItemReorder.Enabled = true;
            ModelCategory category = DataManager.Current.Category.SelectedCategory;
            if(category == null ||  category.ParentId == -1 || DataManager.Current.Requirement.SelectedRequirements.Count == 0)
            {
                menuItemReorder.Enabled = false;
            }
        }

        private void gridItems_MouseDown(object sender, MouseEventArgs e)
        {
            m_posDragStart = e.Location;
        }

        private void gridItems_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_posDragStart.IsEmpty == false)
            {
                if (Math.Abs(m_posDragStart.X - e.Location.X) > 10
                    && Math.Abs(m_posDragStart.Y - e.Location.Y) > 8)
                {

                    List<ModelReqmnt> arySelectedItems = new List<ModelReqmnt>();
                    foreach (DataGridViewRow row in gridItems.SelectedRows)
                    {
                        DataRowView curRow = row.DataBoundItem as DataRowView;
                        arySelectedItems.Add(curRow["SRC"] as ModelReqmnt);
                    }
                    
                    this.DoDragDrop(arySelectedItems, DragDropEffects.Move);
                    m_posDragStart = Point.Empty;
                }
                
            }
        }

        private void gridItems_MouseUp(object sender, MouseEventArgs e)
        {
            m_posDragStart = Point.Empty;
        }

        
    }
}
