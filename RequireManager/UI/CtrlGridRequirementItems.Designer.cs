namespace RequireManager.UI
{
    partial class CtrlGridRequirementItems
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridItems = new System.Windows.Forms.DataGridView();
            this.m_dsRequirements = new System.Data.DataSet();
            this.tbRequirement = new System.Data.DataTable();
            this.colID = new System.Data.DataColumn();
            this.colPRJID = new System.Data.DataColumn();
            this.colCATID = new System.Data.DataColumn();
            this.colIDX = new System.Data.DataColumn();
            this.colSRCID = new System.Data.DataColumn();
            this.colREQNMT = new System.Data.DataColumn();
            this.colENABLED = new System.Data.DataColumn();
            this.colCREATED = new System.Data.DataColumn();
            this.colUPDATED = new System.Data.DataColumn();
            this.colPATH = new System.Data.DataColumn();
            this.colGridReqPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGridReqID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGridReqProjectId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGridReqCategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGridReqSourceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGridReqIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGridReqRequirement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGridReqEnabledStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGridReqCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGridReqUpdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dsRequirements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRequirement)).BeginInit();
            this.SuspendLayout();
            // 
            // gridItems
            // 
            this.gridItems.AllowUserToAddRows = false;
            this.gridItems.AllowUserToDeleteRows = false;
            this.gridItems.AllowUserToOrderColumns = true;
            this.gridItems.AllowUserToResizeRows = false;
            this.gridItems.AutoGenerateColumns = false;
            this.gridItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGridReqPath,
            this.colGridReqID,
            this.colGridReqProjectId,
            this.colGridReqCategoryID,
            this.colGridReqSourceId,
            this.colGridReqIndex,
            this.colGridReqRequirement,
            this.colGridReqEnabledStr,
            this.colGridReqCreated,
            this.colGridReqUpdated});
            this.gridItems.DataMember = "tbRequirement";
            this.gridItems.DataSource = this.m_dsRequirements;
            this.gridItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridItems.Location = new System.Drawing.Point(0, 0);
            this.gridItems.Margin = new System.Windows.Forms.Padding(4);
            this.gridItems.Name = "gridItems";
            this.gridItems.RowHeadersVisible = false;
            this.gridItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridItems.Size = new System.Drawing.Size(821, 498);
            this.gridItems.TabIndex = 1;
            this.gridItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridItems_CellClick);
            this.gridItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridItems_CellDoubleClick);
            // 
            // m_dsRequirements
            // 
            this.m_dsRequirements.DataSetName = "NewDataSet";
            this.m_dsRequirements.Tables.AddRange(new System.Data.DataTable[] {
            this.tbRequirement});
            // 
            // tbRequirement
            // 
            this.tbRequirement.Columns.AddRange(new System.Data.DataColumn[] {
            this.colID,
            this.colPRJID,
            this.colCATID,
            this.colIDX,
            this.colSRCID,
            this.colREQNMT,
            this.colENABLED,
            this.colCREATED,
            this.colUPDATED,
            this.colPATH});
            this.tbRequirement.TableName = "tbRequirement";
            // 
            // colID
            // 
            this.colID.ColumnName = "ID";
            // 
            // colPRJID
            // 
            this.colPRJID.ColumnName = "PRJID";
            // 
            // colCATID
            // 
            this.colCATID.ColumnName = "CATID";
            // 
            // colIDX
            // 
            this.colIDX.ColumnName = "IDX";
            // 
            // colSRCID
            // 
            this.colSRCID.ColumnName = "SRCID";
            // 
            // colREQNMT
            // 
            this.colREQNMT.ColumnName = "REQNMT";
            // 
            // colENABLED
            // 
            this.colENABLED.ColumnName = "ENABLED";
            // 
            // colCREATED
            // 
            this.colCREATED.ColumnName = "CREATED";
            // 
            // colUPDATED
            // 
            this.colUPDATED.ColumnName = "UPDATED";
            // 
            // colPATH
            // 
            this.colPATH.Caption = "PATH";
            this.colPATH.ColumnName = "PATH";
            // 
            // colGridReqPath
            // 
            this.colGridReqPath.DataPropertyName = "PATH";
            this.colGridReqPath.HeaderText = "Path";
            this.colGridReqPath.Name = "colGridReqPath";
            this.colGridReqPath.ReadOnly = true;
            this.colGridReqPath.Width = 165;
            // 
            // colGridReqID
            // 
            this.colGridReqID.DataPropertyName = "ID";
            this.colGridReqID.HeaderText = "ID";
            this.colGridReqID.Name = "colGridReqID";
            this.colGridReqID.Visible = false;
            // 
            // colGridReqProjectId
            // 
            this.colGridReqProjectId.DataPropertyName = "PRJID";
            this.colGridReqProjectId.HeaderText = "ProjectId";
            this.colGridReqProjectId.Name = "colGridReqProjectId";
            this.colGridReqProjectId.Visible = false;
            // 
            // colGridReqCategoryID
            // 
            this.colGridReqCategoryID.DataPropertyName = "CATID";
            this.colGridReqCategoryID.HeaderText = "CategoryID";
            this.colGridReqCategoryID.Name = "colGridReqCategoryID";
            this.colGridReqCategoryID.Visible = false;
            // 
            // colGridReqSourceId
            // 
            this.colGridReqSourceId.DataPropertyName = "SRCID";
            this.colGridReqSourceId.HeaderText = "SourceId";
            this.colGridReqSourceId.Name = "colGridReqSourceId";
            this.colGridReqSourceId.Visible = false;
            // 
            // colGridReqIndex
            // 
            this.colGridReqIndex.DataPropertyName = "IDX";
            this.colGridReqIndex.HeaderText = "Index";
            this.colGridReqIndex.Name = "colGridReqIndex";
            this.colGridReqIndex.Width = 40;
            // 
            // colGridReqRequirement
            // 
            this.colGridReqRequirement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colGridReqRequirement.DataPropertyName = "REQNMT";
            this.colGridReqRequirement.HeaderText = "Requirement";
            this.colGridReqRequirement.Name = "colGridReqRequirement";
            this.colGridReqRequirement.ReadOnly = true;
            // 
            // colGridReqEnabledStr
            // 
            this.colGridReqEnabledStr.DataPropertyName = "ENABLED";
            this.colGridReqEnabledStr.HeaderText = "EnabledStr";
            this.colGridReqEnabledStr.Name = "colGridReqEnabledStr";
            this.colGridReqEnabledStr.Visible = false;
            // 
            // colGridReqCreated
            // 
            this.colGridReqCreated.DataPropertyName = "CREATED";
            this.colGridReqCreated.HeaderText = "Created";
            this.colGridReqCreated.Name = "colGridReqCreated";
            this.colGridReqCreated.Visible = false;
            // 
            // colGridReqUpdated
            // 
            this.colGridReqUpdated.DataPropertyName = "UPDATED";
            this.colGridReqUpdated.HeaderText = "Updated";
            this.colGridReqUpdated.Name = "colGridReqUpdated";
            this.colGridReqUpdated.Visible = false;
            // 
            // CtrlGridRequirementItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridItems);
            this.Name = "CtrlGridRequirementItems";
            this.Size = new System.Drawing.Size(821, 498);
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dsRequirements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRequirement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridItems;
        private System.Data.DataSet m_dsRequirements;
        private System.Data.DataTable tbRequirement;
        private System.Data.DataColumn colID;
        private System.Data.DataColumn colPRJID;
        private System.Data.DataColumn colCATID;
        private System.Data.DataColumn colIDX;
        private System.Data.DataColumn colSRCID;
        private System.Data.DataColumn colREQNMT;
        private System.Data.DataColumn colENABLED;
        private System.Data.DataColumn colCREATED;
        private System.Data.DataColumn colUPDATED;
        private System.Data.DataColumn colPATH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGridReqPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGridReqID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGridReqProjectId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGridReqCategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGridReqSourceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGridReqIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGridReqRequirement;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGridReqEnabledStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGridReqCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGridReqUpdated;
    }
}
