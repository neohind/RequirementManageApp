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
    public partial class frmRequirement : Form
    {
        enum RemarkAction
        {
            NoAction,
            New,
            Edit,
            Delete
        }


        
        public event EventHandler OnRequirementUpdated;

        private List<ModelCategory> m_aryAllCategories = null;
        private ModelCategory m_curCategory = null;        
        private ModelRemark m_selectedRemark = null;
        
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
            }
        }

        public ModelReqmnt CurRequirement
        {
            get;
            set;
        }

        public frmRequirement()
        {
            InitializeComponent();
            DataManager.Current.Category.OnSelectedCategoryChanged += Category_OnSelectedCategoryChanged;
            Init();
        }


        public void Destory()
        {
            m_bIsDestory = true;
            this.Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (m_bIsDestory)
                base.OnClosing(e);
            else
            {
                if (OnRequirementUpdated != null)
                    OnRequirementUpdated(this, EventArgs.Empty);
                e.Cancel = true;
                this.Hide();
            }
        }


        void Category_OnSelectedCategoryChanged(ModelCategory model)
        {
            if (cmbPath.Items.Count > 0)
            {
                int nIndex = cmbPath.Items.IndexOf(model);
                cmbPath.SelectedIndex = nIndex;
            }
        }



        protected override void OnVisibleChanged(EventArgs e)
        {
            Init();
            base.OnVisibleChanged(e);
        }

        private void CollapsRemark(bool bIsCollas)
        {
            splitContainer1.Panel2Collapsed = bIsCollas;
            this.Height = (bIsCollas) ? 200 : 420;
        }

        private void Init()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(Init));
            else
            {
                CollapsRemark(true);
                cmbPath.Enabled = false;

                ModelCategory selectedCategory = DataManager.Current.Category.SelectedCategory;
                cmbPath.DataSource = null;
                cmbPath.DataSource = DataManager.Current.Category.AllCategoryExceptRoot;
                cmbPath.DisplayMember = "PATH";
                Category_OnSelectedCategoryChanged(selectedCategory);

                if (CurRequirement == null)
                {
                    CurRequirement = DataManager.Current.Requirement.NewRequirement();
                    cmbPath.Enabled = true;
                    txtIndex.Enabled = true;
                }
                ModelCategory category = DataManager.Current.Category.AllCategoryExceptRoot.Find(m => m.Id == CurRequirement.CategoryId);
                if (category == null)
                {
                    category = DataManager.Current.Category.ETC;
                }

                int nIndex = cmbPath.Items.IndexOf(category);
                cmbPath.SelectedIndex = nIndex;


                txtIndex.Text = Convert.ToString(CurRequirement.Index);
                txtRequirements.Text = CurRequirement.Requirement;
                listRemark.DataSource = CurRequirement.AllRemark;
                listRemark.DisplayMember = "Contents";   
            }
        }

        


        private void btnOK_Click(object sender, EventArgs e)
        {
            int nSelectedIndex = cmbPath.SelectedIndex;
            ModelCategory category = (ModelCategory)cmbPath.Items[nSelectedIndex];
            CurRequirement.CategoryId = category.Id;
            CurRequirement.CategoryPath = category.Path;


            CurRequirement.Index = Convert.ToInt32(txtIndex.Text);
            CurRequirement.Requirement = txtRequirements.Text;
            DataManager.Current.Requirement.Save(CurRequirement);
            this.Close();
        }

        private void btnOKandNew_Click(object sender, EventArgs e)
        {
            int nSelectedIndex = cmbPath.SelectedIndex;
            ModelCategory category = (ModelCategory)cmbPath.Items[nSelectedIndex];
            CurRequirement.CategoryId = category.Id;
            CurRequirement.CategoryPath = category.Path;

            CurRequirement.Index = Convert.ToInt32(txtIndex.Text);
            CurRequirement.Requirement = txtRequirements.Text;
            DataManager.Current.Requirement.Save(CurRequirement);
            CurRequirement = null;
            Init();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        internal void SetAllCategories()
        {
            m_curCategory = DataManager.Current.Category.SelectedCategory;
            cmbPath.DataSource = DataManager.Current.Category.AllCategories;
            cmbPath.DisplayMember = "Path";            
        }

        internal void SetClose()
        {
            m_bIsDestory = true;
            this.Close();
        }


        private void btnRemarkApply_Click(object sender, EventArgs e)
        {
            switch(m_curAction)
            {
                case RemarkAction.New:
                    if (string.IsNullOrEmpty(txtRemark.Text) == false)
                    {
                        DataManager.Current.Requirement.AddRemark(CurRequirement, txtRemark.Text);
                        
                        txtRemark.Text = string.Empty;
                        btnRemarkApply.Enabled = false;
                        btnRemarkCancel.Enabled = false;
                        txtRemark.Enabled = false;

                        btnRemarkNew.Enabled = true;
                        btnRemarkEdit.Enabled = true;
                        btnRemarkDelete.Enabled = true;

                        listRemark.Enabled = true;

                        listRemark.DataSource = null;
                        listRemark.DataSource = CurRequirement.AllRemark;
                        listRemark.DisplayMember = "Contents";
                        
                        m_curAction = RemarkAction.NoAction;
                    }
                    break;
                case RemarkAction.Edit:
                    {
                        m_selectedRemark.Contents = txtRemark.Text;
                        DataManager.Current.Requirement.UpdateRemark(m_selectedRemark);
                        m_selectedRemark = null;

                        txtRemark.Text = string.Empty;
                        btnRemarkApply.Enabled = false;
                        btnRemarkCancel.Enabled = false;
                        txtRemark.Enabled = false;

                        btnRemarkNew.Enabled = true;
                        btnRemarkEdit.Enabled = true;
                        btnRemarkDelete.Enabled = true;

                        listRemark.Enabled = true;

                        listRemark.DataSource = null;
                        listRemark.DataSource = CurRequirement.AllRemark;
                        listRemark.DisplayMember = "Contents";

                        m_curAction = RemarkAction.NoAction;
                    }
                    break;
            }
            
        }

        private void btnRemarkCancel_Click(object sender, EventArgs e)
        {
            txtRemark.Text = string.Empty;

            btnRemarkApply.Enabled = false;
            btnRemarkCancel.Enabled = false;
            txtRemark.Enabled = false;

            btnRemarkNew.Enabled = true;
            btnRemarkEdit.Enabled = true;
            btnRemarkDelete.Enabled = true;

            listRemark.Enabled = true;

        }

        private void btnRemarkNew_Click(object sender, EventArgs e)
        {
            m_curAction = RemarkAction.New;
            txtRemark.Enabled = true;
            listRemark.Enabled = false;

            btnRemarkNew.Enabled = false;
            btnRemarkEdit.Enabled = false;
            btnRemarkDelete.Enabled = false;

            btnRemarkApply.Enabled = true;
            btnRemarkCancel.Enabled = true;
          

            txtRemark.Focus();
        }


        private void btnRemarkEdit_Click(object sender, EventArgs e)
        {
            int nSelectedIndex = listRemark.SelectedIndex;
            if (nSelectedIndex > -1)
            {
                m_selectedRemark = (ModelRemark)listRemark.Items[nSelectedIndex];
                txtRemark.Text = m_selectedRemark.Contents;

                m_curAction = RemarkAction.Edit;
                txtRemark.Enabled = true;
                listRemark.Enabled = false;

                btnRemarkNew.Enabled = false;
                btnRemarkEdit.Enabled = false;
                btnRemarkDelete.Enabled = false;

                btnRemarkApply.Enabled = true;
                btnRemarkCancel.Enabled = true;

                txtRemark.Focus();
            }
        }


        private void btnRemarkDelete_Click(object sender, EventArgs e)
        {
            int nSelectedIndex = listRemark.SelectedIndex;
            if (nSelectedIndex > -1)
            {
                ModelRemark selectedRemark = (ModelRemark)listRemark.Items[nSelectedIndex];
                if (selectedRemark != null)
                {
                    string sMessage = string.Format("Really remove this remark\r\n {0}?", selectedRemark.Contents);
                    if (MessageBox.Show(sMessage, "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        DataManager.Current.Requirement.DeleteRemark(CurRequirement, selectedRemark);
                        listRemark.DataSource = null;
                        listRemark.DataSource = CurRequirement.AllRemark;
                        listRemark.DisplayMember = "Contents";
                    }
                }
            }
        }

        private void btnRemark_Click(object sender, EventArgs e)
        {
            CollapsRemark(!splitContainer1.Panel2Collapsed);
        }


       

  
        
    }
}
