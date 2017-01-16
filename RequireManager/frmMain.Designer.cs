namespace RequireManager
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.ctrlCategoryNavigator1 = new RequireManager.UI.CtrlCategoryNavigator();
            this.ctrlGridRequirementItems1 = new RequireManager.UI.CtrlGridRequirementItems();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ctrlCategoryNavigator1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ctrlGridRequirementItems1);
            this.splitContainer1.Size = new System.Drawing.Size(1274, 602);
            this.splitContainer1.SplitterDistance = 269;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(5, 5);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer3.Size = new System.Drawing.Size(1274, 651);
            this.splitContainer3.SplitterDistance = 45;
            this.splitContainer3.TabIndex = 2;
            // 
            // ctrlCategoryNavigator1
            // 
            this.ctrlCategoryNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlCategoryNavigator1.Location = new System.Drawing.Point(0, 0);
            this.ctrlCategoryNavigator1.Name = "ctrlCategoryNavigator1";
            this.ctrlCategoryNavigator1.Size = new System.Drawing.Size(269, 602);
            this.ctrlCategoryNavigator1.TabIndex = 0;
            // 
            // ctrlGridRequirementItems1
            // 
            this.ctrlGridRequirementItems1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlGridRequirementItems1.Location = new System.Drawing.Point(0, 0);
            this.ctrlGridRequirementItems1.Name = "ctrlGridRequirementItems1";
            this.ctrlGridRequirementItems1.Size = new System.Drawing.Size(1000, 602);
            this.ctrlGridRequirementItems1.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.splitContainer3);
            this.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "frmMain";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private UI.CtrlCategoryNavigator ctrlCategoryNavigator1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private UI.CtrlGridRequirementItems ctrlGridRequirementItems1;
    }
}

