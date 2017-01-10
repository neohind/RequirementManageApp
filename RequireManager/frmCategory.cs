using RequireManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RequireManager
{
    public partial class frmCategory : Form
    {
        public enum ActionType
        {
            Add,
            Del,
            Edit
        }

        public string Path
        {
            get;
            set;
        }

        public ActionType CurAction
        {
            get;
            set;
        }

        public ModelCategory CurModel
        {
            get;
            set;
        }

        public ModelCategory ParentModel
        {
            get;
            set;
        }

        public List<ModelCategory> AllCategories
        {
            get;
            set;
        }

        public frmCategory()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            switch(CurAction)
            {
                case ActionType.Add:
                    lblActionTitle.Text = "Add New Category";
                    this.CurModel = new ModelCategory();
                    this.CurModel.ParentId = ParentModel.Id;
                    this.CurModel.ProjectId = ParentModel.ProjectId;
                    break;
                case ActionType.Edit:
                    lblActionTitle.Text = "Edit Current Category";
                    txtCode.Text = this.CurModel.Code;
                    txtDescription.Text = this.CurModel.Description;
                    txtDisplayName.Text = this.CurModel.DisplayName;
                    break;
                case ActionType.Del:
                    lblActionTitle.Text = "Delete Current Category";


                    break;
            }
            lblPath.Text = Path.Replace("\\", " > ");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(Regex.IsMatch(txtCode.Text, @"^[A-Za-z0-9]{1,14}\b") == false)
            {
                MessageBox.Show("Invalid Code - First char is only alphbet / 4~15 char len / Only alphabet and digit", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCode.Focus();
                return;
            }

            if(txtCode.Text.Length < 2 && char.IsDigit(txtCode.Text[0]))
            {
                txtCode.Text = txtCode.Text.PadLeft(2, '0');
            }


            ModelCategory findSameCategory = AllCategories.Find(m => m.ParentId == this.CurModel.ParentId && string.Equals(m.Code, txtCode.Text, StringComparison.InvariantCultureIgnoreCase));

            if (findSameCategory != null)
            {
                if (this.CurAction == ActionType.Edit && findSameCategory.Id != this.CurModel.Id 
                    || this.CurAction == ActionType.Add)                    
                    {
                        MessageBox.Show("Duplicate Code - Already Used", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCode.Focus();
                        return;
                    }
            }

            if(txtDisplayName.TextLength < 2)
            {
                MessageBox.Show("Invalid Diplay Name - Muse 4 letter over", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDisplayName.Focus();
                return;
            }

            this.CurModel.Code = txtCode.Text;
            this.CurModel.DisplayName = txtDisplayName.Text;
            this.CurModel.Description = txtDescription.Text;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }



        
    }
}
