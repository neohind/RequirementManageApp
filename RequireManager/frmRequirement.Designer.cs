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
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNewReq = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRequirements = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.cmbPath = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.listRemark = new System.Windows.Forms.ListBox();
            this.btnRemarkApply = new System.Windows.Forms.Button();
            this.btnRemarkEdit = new System.Windows.Forms.Button();
            this.btnRemarkDelete = new System.Windows.Forms.Button();
            this.btnRemarkNew = new System.Windows.Forms.Button();
            this.btnRemarkCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtIndex
            // 
            this.txtIndex.Location = new System.Drawing.Point(99, 88);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(58, 23);
            this.txtIndex.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 27;
            this.label3.Text = "#Index";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(163, 340);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnNewReq
            // 
            this.btnNewReq.Location = new System.Drawing.Point(12, 12);
            this.btnNewReq.Name = "btnNewReq";
            this.btnNewReq.Size = new System.Drawing.Size(81, 24);
            this.btnNewReq.TabIndex = 2;
            this.btnNewReq.Text = "New";
            this.btnNewReq.UseVisualStyleBackColor = true;
            this.btnNewReq.Click += new System.EventHandler(this.btnNewReq_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 21;
            this.label1.Text = "Requirement";
            // 
            // txtRequirements
            // 
            this.txtRequirements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRequirements.Location = new System.Drawing.Point(99, 122);
            this.txtRequirements.Name = "txtRequirements";
            this.txtRequirements.Size = new System.Drawing.Size(547, 23);
            this.txtRequirements.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 29;
            this.label2.Text = "Path";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(15, 340);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(124, 24);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnAddReqAndContinue_Click);
            // 
            // cmbPath
            // 
            this.cmbPath.FormattingEnabled = true;
            this.cmbPath.Location = new System.Drawing.Point(99, 54);
            this.cmbPath.Name = "cmbPath";
            this.cmbPath.Size = new System.Drawing.Size(546, 23);
            this.cmbPath.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 21;
            this.label4.Text = "Remarks";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(99, 262);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemark.Size = new System.Drawing.Size(467, 52);
            this.txtRemark.TabIndex = 31;
            this.txtRemark.Text = "test 한글\r\ntest  한글";
            // 
            // listRemark
            // 
            this.listRemark.FormattingEnabled = true;
            this.listRemark.ItemHeight = 15;
            this.listRemark.Location = new System.Drawing.Point(99, 159);
            this.listRemark.Name = "listRemark";
            this.listRemark.Size = new System.Drawing.Size(467, 94);
            this.listRemark.TabIndex = 32;
            this.listRemark.SelectedIndexChanged += new System.EventHandler(this.listRemark_SelectedIndexChanged);
            // 
            // btnRemarkApply
            // 
            this.btnRemarkApply.Location = new System.Drawing.Point(573, 262);
            this.btnRemarkApply.Name = "btnRemarkApply";
            this.btnRemarkApply.Size = new System.Drawing.Size(73, 23);
            this.btnRemarkApply.TabIndex = 33;
            this.btnRemarkApply.Text = "Apply";
            this.btnRemarkApply.UseVisualStyleBackColor = true;
            this.btnRemarkApply.Click += new System.EventHandler(this.btnRemarkApply_Click);
            // 
            // btnRemarkEdit
            // 
            this.btnRemarkEdit.Location = new System.Drawing.Point(572, 189);
            this.btnRemarkEdit.Name = "btnRemarkEdit";
            this.btnRemarkEdit.Size = new System.Drawing.Size(73, 23);
            this.btnRemarkEdit.TabIndex = 33;
            this.btnRemarkEdit.Text = "Edit";
            this.btnRemarkEdit.UseVisualStyleBackColor = true;
            // 
            // btnRemarkDelete
            // 
            this.btnRemarkDelete.Location = new System.Drawing.Point(572, 218);
            this.btnRemarkDelete.Name = "btnRemarkDelete";
            this.btnRemarkDelete.Size = new System.Drawing.Size(73, 23);
            this.btnRemarkDelete.TabIndex = 33;
            this.btnRemarkDelete.Text = "Delete";
            this.btnRemarkDelete.UseVisualStyleBackColor = true;
            // 
            // btnRemarkNew
            // 
            this.btnRemarkNew.Location = new System.Drawing.Point(572, 159);
            this.btnRemarkNew.Name = "btnRemarkNew";
            this.btnRemarkNew.Size = new System.Drawing.Size(73, 23);
            this.btnRemarkNew.TabIndex = 33;
            this.btnRemarkNew.Text = "New";
            this.btnRemarkNew.UseVisualStyleBackColor = true;
            this.btnRemarkNew.Click += new System.EventHandler(this.btnRemarkNew_Click);
            // 
            // btnRemarkCancel
            // 
            this.btnRemarkCancel.Location = new System.Drawing.Point(573, 291);
            this.btnRemarkCancel.Name = "btnRemarkCancel";
            this.btnRemarkCancel.Size = new System.Drawing.Size(73, 23);
            this.btnRemarkCancel.TabIndex = 33;
            this.btnRemarkCancel.Text = "Cancel";
            this.btnRemarkCancel.UseVisualStyleBackColor = true;
            this.btnRemarkCancel.Click += new System.EventHandler(this.btnRemarkCancel_Click);
            // 
            // frmRequirement
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(658, 384);
            this.Controls.Add(this.btnRemarkDelete);
            this.Controls.Add(this.btnRemarkNew);
            this.Controls.Add(this.btnRemarkEdit);
            this.Controls.Add(this.btnRemarkCancel);
            this.Controls.Add(this.btnRemarkApply);
            this.Controls.Add(this.listRemark);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.cmbPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIndex);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnNewReq);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRequirements);
            this.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.Name = "frmRequirement";
            this.Text = "frmRequirement";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIndex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNewReq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRequirements;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ComboBox cmbPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.ListBox listRemark;
        private System.Windows.Forms.Button btnRemarkApply;
        private System.Windows.Forms.Button btnRemarkEdit;
        private System.Windows.Forms.Button btnRemarkDelete;
        private System.Windows.Forms.Button btnRemarkNew;
        private System.Windows.Forms.Button btnRemarkCancel;

    }
}