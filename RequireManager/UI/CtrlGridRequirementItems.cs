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
        frmRequirement m_frmRequirement = new frmRequirement();

        public CtrlGridRequirementItems()
        {
            InitializeComponent();
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
 	         base.OnHandleDestroyed(e);
                m_frmRequirement.SetClose();
        }


        public void SetDataSource(List<ModelCategory> categories, ModelCategory selectedCategory, List<ModelReqmnt> requirements)
        {
            
        }

        private void gridItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }



        private void gridItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }



        internal void Reload()
        {
            m_frmRequirement.SetAllCategories();
            List<ModelReqmnt> requirements = DataManager.Current.Requirement.SelectedRequirements;
            tbRequirement.Rows.Clear();
            foreach (ModelReqmnt req in requirements)
            {
                DataRow row = tbRequirement.NewRow();
                req.UpdataeData(row);
                tbRequirement.Rows.Add(row);
            }
            gridItems.Update();
        }
    }
}
