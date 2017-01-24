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
    public partial class frmCreateProject : Form
    {
        public frmCreateProject()
        {
            InitializeComponent();

            List<ModelProject> aryProjects =  Dac.DacFactory.Current.Project.GetAllProject();
            TB_PROJECT.Rows.Clear();
            foreach(ModelProject project in aryProjects)
            {
                DataRow row = TB_PROJECT.NewRow();
                project.UpdataeData( row);
                TB_PROJECT.Rows.Add(row);
            }
            dataGridView1.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) == false)
            {
                Dac.DacFactory.Current.Project.AddProject(txtName.Text, txtDescription.Text);
                this.Close();
            }
        }
    }
}
