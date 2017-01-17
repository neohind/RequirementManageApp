using RequireManager.Dac;
using RequireManager.Manager;
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
        public frmMain()
        {
            InitializeComponent();
            ctrlCategoryNavigator1.OnChangeSelectCategory += ctrlCategoryNavigator1_OnChangeSelectCategory;           
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ctrlGridRequirementItems1.Reload();
        }

        void ctrlCategoryNavigator1_OnChangeSelectCategory(ModelCategory category)
        {

            List<ModelReqmnt> aryRequirements = DataManager.Current.SetCategory(category);
            ctrlGridRequirementItems1.Reload();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchWord.Text) == false)
            {
                DataManager.Current.Search(txtSearchWord.Text);
            }
        }

        private void txtSearchWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(this, e);
        }
    }
}

