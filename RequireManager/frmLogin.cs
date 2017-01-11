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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();


            string sConnectionString = Convert.ToString(Application.UserAppDataRegistry.GetValue("LASTDBNAME"));
            if (string.IsNullOrEmpty(sConnectionString) == false)
                txtConnectionString.Text = sConnectionString;

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            int nSelectedIndex = cmbProjects.SelectedIndex;
            if (nSelectedIndex > -1)
            {
                ModelProject selectedProject = cmbProjects.Items[nSelectedIndex] as ModelProject;
                DataManager.Current.SetProject(selectedProject);                
                Application.UserAppDataRegistry.SetValue("LASTDBNAME", txtConnectionString.Text);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtConnectionString.Text) == false)
            {
                DacFactory.Current.Init(txtConnectionString.Text);
                List<ModelProject> aryProject = DacFactory.Current.Project.GetAllProject();

                if (aryProject.Count > 0)
                {
                    cmbProjects.DataSource = aryProject;
                    cmbProjects.DisplayMember = "ProjectName";
                    txtConnectionString.Enabled = false;
                    btnConnect.Enabled = false;
                    btnOpen.Enabled = true;
                    btnCancel.Enabled = true;
                    cmbProjects.Enabled = true;
                }
            }
        }
    }
}
