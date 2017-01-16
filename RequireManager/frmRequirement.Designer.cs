namespace RequireManager
{
    partial class frmRequirement
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnOKandNew = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnRemark = new System.Windows.Forms.Button();
            this.cmbPath = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRequirements = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRemarkDelete = new System.Windows.Forms.Button();
            this.btnRemarkNew = new System.Windows.Forms.Button();
            this.btnRemarkEdit = new System.Windows.Forms.Button();
            this.btnRemarkCancel = new System.Windows.Forms.Button();
            this.btnRemarkApply = new System.Windows.Forms.Button();
            this.listRemark = new System.Windows.Forms.ListBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(312, 121);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(24, 121);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(124, 24);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnOKandNew
            // 
            this.btnOKandNew.Location = new System.Drawing.Point(154, 121);
            this.btnOKandNew.Name = "btnOKandNew";
            this.btnOKandNew.Size = new System.Drawing.Size(109, 24);
            this.btnOKandNew.TabIndex = 34;
            this.btnOKandNew.Text = "Save and new";
            this.btnOKandNew.UseVisualStyleBackColor = true;
            this.btnOKandNew.Click += new System.EventHandler(this.btnOKandNew_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnRemark);
            this.splitContainer1.Panel1.Controls.Add(this.cmbPath);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.btnOKandNew);
            this.splitContainer1.Panel1.Controls.Add(this.txtIndex);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txtRequirements);
            this.splitContainer1.Panel1.Controls.Add(this.btnOK);
            this.splitContainer1.Panel1.Controls.Add(this.btnCancel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.btnRemarkDelete);
            this.splitContainer1.Panel2.Controls.Add(this.btnRemarkNew);
            this.splitContainer1.Panel2.Controls.Add(this.btnRemarkEdit);
            this.splitContainer1.Panel2.Controls.Add(this.btnRemarkCancel);
            this.splitContainer1.Panel2.Controls.Add(this.btnRemarkApply);
            this.splitContainer1.Panel2.Controls.Add(this.listRemark);
            this.splitContainer1.Panel2.Controls.Add(this.txtRemark);
            this.splitContainer1.Size = new System.Drawing.Size(658, 376);
            this.splitContainer1.SplitterDistance = 152;
            this.splitContainer1.TabIndex = 36;
            // 
            // btnRemark
            // 
            this.btnRemark.Location = new System.Drawing.Point(503, 122);
            this.btnRemark.Name = "btnRemark";
            this.btnRemark.Size = new System.Drawing.Size(140, 23);
            this.btnRemark.TabIndex = 37;
            this.btnRemark.Text = "Open/Close Remark";
            this.btnRemark.UseVisualStyleBackColor = true;
            this.btnRemark.Click += new System.EventHandler(this.btnRemark_Click);
            // 
            // cmbPath
            // 
            this.cmbPath.FormattingEnabled = true;
            this.cmbPath.Location = new System.Drawing.Point(108, 14);
            this.cmbPath.Name = "cmbPath";
            this.cmbPath.Size = new System.Drawing.Size(527, 23);
            this.cmbPath.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 35;
            this.label2.Text = "Path";
            // 
            // txtIndex
            // 
            this.txtIndex.Location = new System.Drawing.Point(108, 48);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(58, 23);
            this.txtIndex.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 34;
            this.label3.Text = "#Index";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 33;
            this.label1.Text = "Requirement";
            // 
            // txtRequirements
            // 
            this.txtRequirements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRequirements.Location = new System.Drawing.Point(108, 82);
            this.txtRequirements.Name = "txtRequirements";
            this.txtRequirements.Size = new System.Drawing.Size(527, 23);
            this.txtRequirements.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 41;
            this.label4.Text = "Remark";
            // 
            // btnRemarkDelete
            // 
            this.btnRemarkDelete.Location = new System.Drawing.Point(568, 79);
            this.btnRemarkDelete.Name = "btnRemarkDelete";
            this.btnRemarkDelete.Size = new System.Drawing.Size(75, 23);
            this.btnRemarkDelete.TabIndex = 36;
            this.btnRemarkDelete.Text = "Delete";
            this.btnRemarkDelete.UseVisualStyleBackColor = true;
            this.btnRemarkDelete.Click += new System.EventHandler(this.btnRemarkDelete_Click);
            // 
            // btnRemarkNew
            // 
            this.btnRemarkNew.Location = new System.Drawing.Point(568, 21);
            this.btnRemarkNew.Name = "btnRemarkNew";
            this.btnRemarkNew.Size = new System.Drawing.Size(75, 23);
            this.btnRemarkNew.TabIndex = 37;
            this.btnRemarkNew.Text = "New";
            this.btnRemarkNew.UseVisualStyleBackColor = true;
            this.btnRemarkNew.Click += new System.EventHandler(this.btnRemarkNew_Click);
            // 
            // btnRemarkEdit
            // 
            this.btnRemarkEdit.Location = new System.Drawing.Point(568, 50);
            this.btnRemarkEdit.Name = "btnRemarkEdit";
            this.btnRemarkEdit.Size = new System.Drawing.Size(75, 23);
            this.btnRemarkEdit.TabIndex = 38;
            this.btnRemarkEdit.Text = "Edit";
            this.btnRemarkEdit.UseVisualStyleBackColor = true;
            this.btnRemarkEdit.Click += new System.EventHandler(this.btnRemarkEdit_Click);
            // 
            // btnRemarkCancel
            // 
            this.btnRemarkCancel.Location = new System.Drawing.Point(189, 182);
            this.btnRemarkCancel.Name = "btnRemarkCancel";
            this.btnRemarkCancel.Size = new System.Drawing.Size(75, 23);
            this.btnRemarkCancel.TabIndex = 39;
            this.btnRemarkCancel.Text = "Cancel";
            this.btnRemarkCancel.UseVisualStyleBackColor = true;
            this.btnRemarkCancel.Click += new System.EventHandler(this.btnRemarkCancel_Click);
            // 
            // btnRemarkApply
            // 
            this.btnRemarkApply.Location = new System.Drawing.Point(108, 182);
            this.btnRemarkApply.Name = "btnRemarkApply";
            this.btnRemarkApply.Size = new System.Drawing.Size(75, 23);
            this.btnRemarkApply.TabIndex = 40;
            this.btnRemarkApply.Text = "Apply";
            this.btnRemarkApply.UseVisualStyleBackColor = true;
            this.btnRemarkApply.Click += new System.EventHandler(this.btnRemarkApply_Click);
            // 
            // listRemark
            // 
            this.listRemark.FormattingEnabled = true;
            this.listRemark.ItemHeight = 15;
            this.listRemark.Location = new System.Drawing.Point(108, 21);
            this.listRemark.Name = "listRemark";
            this.listRemark.Size = new System.Drawing.Size(454, 94);
            this.listRemark.TabIndex = 35;
            // 
            // txtRemark
            // 
            this.txtRemark.Enabled = false;
            this.txtRemark.Location = new System.Drawing.Point(108, 124);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemark.Size = new System.Drawing.Size(454, 52);
            this.txtRemark.TabIndex = 34;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnNext);
            this.splitContainer2.Panel1.Controls.Add(this.btnPrev);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(658, 419);
            this.splitContainer2.SplitterDistance = 39;
            this.splitContainer2.TabIndex = 37;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(93, 8);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(12, 8);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 23);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "<<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // frmRequirement
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(658, 419);
            this.Controls.Add(this.splitContainer2);
            this.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.Name = "frmRequirement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Requirement Detail Editor";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnOKandNew;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnRemark;
        private System.Windows.Forms.ComboBox cmbPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIndex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRequirements;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRemarkDelete;
        private System.Windows.Forms.Button btnRemarkNew;
        private System.Windows.Forms.Button btnRemarkEdit;
        private System.Windows.Forms.Button btnRemarkCancel;
        private System.Windows.Forms.Button btnRemarkApply;
        private System.Windows.Forms.ListBox listRemark;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;

    }
}