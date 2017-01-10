using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RequireManager.Models;

namespace RequireManager.UI
{
    public partial class CtrlGridRequirementItems : UserControl
    {
        List<ModelReqmnt> m_aryDataSource = null;
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
            m_frmRequirement.SetAllCategories(categories, selectedCategory);     
            m_aryDataSource = requirements;
            tbRequirement.Rows.Clear();
            foreach(ModelReqmnt req in requirements)
            {
                DataRow row = tbRequirement.NewRow();
                req.UpdataeData(row);
                tbRequirement.Rows.Add(row);
            }



            gridItems.Update();
        }

        private void gridItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        private int GetLastIndex()
        {
            int nMaxIndex = 0;
            if (m_aryDataSource != null)
            {
                foreach (ModelReqmnt req in m_aryDataSource)
                {
                    if (req.Index > nMaxIndex)
                        nMaxIndex = req.Index;
                }
            }
            return nMaxIndex + 1;

        }

        private void gridItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >  -1)
            {
                DataGridViewRow row = gridItems.Rows[e.RowIndex];
                int nReqID = Convert.ToInt32(row.Cells[colGridReqID.Name].Value);

                ModelReqmnt selectedRequirement = m_aryDataSource.Find(m => m.Id == nReqID);
                m_frmRequirement.SetRequirement(selectedRequirement, GetLastIndex());

                m_frmRequirement.Show();
                m_frmRequirement.BringToFront();
            }
        }

       
    }
}
