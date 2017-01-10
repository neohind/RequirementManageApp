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
    public partial class frmRequirement : Form
    {
        enum RemarkAction
        {
            NoAction,
            New,
            Edit,
            Delete
        }


        public delegate void OnRequirementAddedHandler(ModelReqmnt req);
        public event OnRequirementAddedHandler OnRequirementAdded;

        private List<ModelCategory> m_aryAllCategories = null;
        private ModelCategory m_curCategory = null;
        private ModelReqmnt m_selectedRequirement = null;
        
        private string m_sPath = string.Empty;
        private bool m_bIsDestory = false;
        private int m_nMaxIndex = 0;
        private RemarkAction m_curAction = RemarkAction.NoAction;

        public string Path
        {
            get
            {
                return m_sPath;
            }
            set
            {
                m_sPath = value;
                Init();
            }
        }



        public frmRequirement()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
        }

        


        protected override void OnShown(EventArgs e)
        {                 
            Init();
            base.OnShown(e);
        }

        private void Init()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(Init));
            else
            {
                 if(m_curCategory != null)
                 {



                 }
            }
        }

        private void AddRequirement()
        {
            
        }

        private void btnAddReq_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAddReqAndContinue_Click(object sender, EventArgs e)
        {
            
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (m_bIsDestory)
                base.OnClosing(e);
            else
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        public void Distory()
        {
            m_bIsDestory = true;
            this.Close();
        }



        internal void SetRequirement(ModelReqmnt selectedRequirement, int nMaxIndex)
        {
            m_nMaxIndex = nMaxIndex;
            m_selectedRequirement = selectedRequirement;

            m_curCategory = m_aryAllCategories.Find(m => m.Id == selectedRequirement.CategoryId);
            if(m_curCategory != null)
                cmbPath.SelectedIndex = (m_aryAllCategories.IndexOf(m_curCategory));
            txtIndex.Text = Convert.ToString(selectedRequirement.Index);
            txtRequirements.Text = selectedRequirement.Requirement;

            txtRemark.Text = string.Empty;
            listRemark.DataSource = selectedRequirement.AllRemark;
            listRemark.DisplayMember = "Contents";
            

            btnRemarkNew.Enabled = true;
            btnRemarkEdit.Enabled = false;
            btnRemarkDelete.Enabled = false;
            btnRemarkApply.Enabled = false;
            btnRemarkCancel.Enabled = false;
            txtRemark.Enabled = false;
        }

        internal void SetAllCategories(List<ModelCategory> categories, ModelCategory selectedCategory)
        {
            m_aryAllCategories = categories;
            m_curCategory = selectedCategory;
            cmbPath.DataSource = m_aryAllCategories;
            cmbPath.DisplayMember = "Path";
            cmbPath.SelectedIndex = categories.IndexOf(selectedCategory);
        }

        internal void SetClose()
        {
            m_bIsDestory = true;
            this.Close();
        }

        private void btnNewReq_Click(object sender, EventArgs e)
        {
           
        }

        private void btnRemarkApply_Click(object sender, EventArgs e)
        {
            switch(m_curAction)
            {
                case RemarkAction.New:
                    if (string.IsNullOrEmpty(txtRemark.Text) == false)
                    {
                        Dac.DacFactory.Current.Requiremnt.AddRemark(m_selectedRequirement, txtRemark.Text);
                        txtRemark.Text = string.Empty;
                        btnRemarkApply.Enabled = false;
                        btnRemarkCancel.Enabled = false;
                        txtRemark.Enabled = false;
                        btnRemarkNew.Enabled = true;
                        listRemark.DataSource = null;                        
                        listRemark.DataSource = m_selectedRequirement.AllRemark;
                        listRemark.DisplayMember = "Contents";
                    }
                    break;
            }
            
        }

        private void btnRemarkCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnRemarkNew_Click(object sender, EventArgs e)
        {
            m_curAction = RemarkAction.New;
            txtRemark.Enabled = true;
            btnRemarkApply.Enabled = true;
            btnRemarkCancel.Enabled = true;
            btnNewReq.Enabled = false;

            txtRemark.Focus();
        }

        private void listRemark_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nSelectedIndex = listRemark.SelectedIndex;
            if(nSelectedIndex > -1)
            {
                ModelRemark selectedRemark = (ModelRemark)listRemark.Items[nSelectedIndex];
                if(selectedRemark != null)
                {
                    btnRemarkEdit.Enabled = true;
                    txtRemark.Text = selectedRemark.Contents;
                }
            }
        }
    }
}
