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
            this.components = new System.ComponentModel.Container();
            this.gridItems = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemReqAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemReqEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemReqDel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemReorder = new System.Windows.Forms.ToolStripMenuItem();
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
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblPath = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSRC = new System.Data.DataColumn();
            this.pATHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CATNM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rEQNMTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRJIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cATIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sRCIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eNABLEDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cREATEDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uPDATEDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sRCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dsRequirements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRequirement)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.pATHDataGridViewTextBoxColumn,
            this.CATNM,
            this.iDXDataGridViewTextBoxColumn,
            this.rEQNMTDataGridViewTextBoxColumn,
            this.iDDataGridViewTextBoxColumn,
            this.pRJIDDataGridViewTextBoxColumn,
            this.cATIDDataGridViewTextBoxColumn,
            this.sRCIDDataGridViewTextBoxColumn,
            this.eNABLEDDataGridViewTextBoxColumn,
            this.cREATEDDataGridViewTextBoxColumn,
            this.uPDATEDDataGridViewTextBoxColumn,
            this.sRCDataGridViewTextBoxColumn});
            this.gridItems.ContextMenuStrip = this.contextMenuStrip1;
            this.gridItems.DataMember = "tbRequirement";
            this.gridItems.DataSource = this.m_dsRequirements;
            this.gridItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridItems.Location = new System.Drawing.Point(0, 0);
            this.gridItems.Margin = new System.Windows.Forms.Padding(4);
            this.gridItems.Name = "gridItems";
            this.gridItems.ReadOnly = true;
            this.gridItems.RowHeadersVisible = false;
            this.gridItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridItems.Size = new System.Drawing.Size(821, 452);
            this.gridItems.TabIndex = 1;
            this.gridItems.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridItems_CellMouseDown);
            this.gridItems.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridItems_MouseDown);
            this.gridItems.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridItems_MouseMove);
            this.gridItems.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridItems_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemReqAdd,
            this.menuItemReqEdit,
            this.menuItemReqDel,
            this.toolStripSeparator1,
            this.menuItemReorder});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(179, 98);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // menuItemReqAdd
            // 
            this.menuItemReqAdd.Name = "menuItemReqAdd";
            this.menuItemReqAdd.Size = new System.Drawing.Size(178, 22);
            this.menuItemReqAdd.Text = "Add Requirement";
            this.menuItemReqAdd.Click += new System.EventHandler(this.ContextMenu_Click);
            // 
            // menuItemReqEdit
            // 
            this.menuItemReqEdit.Name = "menuItemReqEdit";
            this.menuItemReqEdit.Size = new System.Drawing.Size(178, 22);
            this.menuItemReqEdit.Text = "Edit Requirement";
            this.menuItemReqEdit.Click += new System.EventHandler(this.ContextMenu_Click);
            // 
            // menuItemReqDel
            // 
            this.menuItemReqDel.Name = "menuItemReqDel";
            this.menuItemReqDel.Size = new System.Drawing.Size(178, 22);
            this.menuItemReqDel.Text = "Delete Requirement";
            this.menuItemReqDel.Click += new System.EventHandler(this.ContextMenu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // menuItemReorder
            // 
            this.menuItemReorder.Name = "menuItemReorder";
            this.menuItemReorder.Size = new System.Drawing.Size(178, 22);
            this.menuItemReorder.Text = "Reorder Index";
            this.menuItemReorder.Click += new System.EventHandler(this.ContextMenu_Click);
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
            this.colPATH,
            this.colSRC,
            this.dataColumn1});
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "SRC";
            this.dataGridViewTextBoxColumn1.HeaderText = "SRC";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblPath);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridItems);
            this.splitContainer1.Size = new System.Drawing.Size(821, 498);
            this.splitContainer1.SplitterDistance = 42;
            this.splitContainer1.TabIndex = 2;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPath.Location = new System.Drawing.Point(67, 11);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(0, 20);
            this.lblPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PATH : ";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SRC";
            this.dataGridViewTextBoxColumn2.HeaderText = "SRC";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "CATNM";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SRC";
            this.dataGridViewTextBoxColumn3.HeaderText = "SRC";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // colSRC
            // 
            this.colSRC.ColumnName = "SRC";
            this.colSRC.DataType = typeof(object);
            // 
            // pATHDataGridViewTextBoxColumn
            // 
            this.pATHDataGridViewTextBoxColumn.DataPropertyName = "PATH";
            this.pATHDataGridViewTextBoxColumn.HeaderText = "Path";
            this.pATHDataGridViewTextBoxColumn.Name = "pATHDataGridViewTextBoxColumn";
            this.pATHDataGridViewTextBoxColumn.ReadOnly = true;
            this.pATHDataGridViewTextBoxColumn.Width = 220;
            // 
            // CATNM
            // 
            this.CATNM.DataPropertyName = "CATNM";
            this.CATNM.HeaderText = "Name";
            this.CATNM.Name = "CATNM";
            this.CATNM.ReadOnly = true;
            this.CATNM.Width = 150;
            // 
            // iDXDataGridViewTextBoxColumn
            // 
            this.iDXDataGridViewTextBoxColumn.DataPropertyName = "IDX";
            this.iDXDataGridViewTextBoxColumn.HeaderText = "Index";
            this.iDXDataGridViewTextBoxColumn.Name = "iDXDataGridViewTextBoxColumn";
            this.iDXDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDXDataGridViewTextBoxColumn.Width = 45;
            // 
            // rEQNMTDataGridViewTextBoxColumn
            // 
            this.rEQNMTDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.rEQNMTDataGridViewTextBoxColumn.DataPropertyName = "REQNMT";
            this.rEQNMTDataGridViewTextBoxColumn.HeaderText = "Requirement";
            this.rEQNMTDataGridViewTextBoxColumn.Name = "rEQNMTDataGridViewTextBoxColumn";
            this.rEQNMTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // pRJIDDataGridViewTextBoxColumn
            // 
            this.pRJIDDataGridViewTextBoxColumn.DataPropertyName = "PRJID";
            this.pRJIDDataGridViewTextBoxColumn.HeaderText = "PRJID";
            this.pRJIDDataGridViewTextBoxColumn.Name = "pRJIDDataGridViewTextBoxColumn";
            this.pRJIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.pRJIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // cATIDDataGridViewTextBoxColumn
            // 
            this.cATIDDataGridViewTextBoxColumn.DataPropertyName = "CATID";
            this.cATIDDataGridViewTextBoxColumn.HeaderText = "CATID";
            this.cATIDDataGridViewTextBoxColumn.Name = "cATIDDataGridViewTextBoxColumn";
            this.cATIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.cATIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // sRCIDDataGridViewTextBoxColumn
            // 
            this.sRCIDDataGridViewTextBoxColumn.DataPropertyName = "SRCID";
            this.sRCIDDataGridViewTextBoxColumn.HeaderText = "SRCID";
            this.sRCIDDataGridViewTextBoxColumn.Name = "sRCIDDataGridViewTextBoxColumn";
            this.sRCIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.sRCIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // eNABLEDDataGridViewTextBoxColumn
            // 
            this.eNABLEDDataGridViewTextBoxColumn.DataPropertyName = "ENABLED";
            this.eNABLEDDataGridViewTextBoxColumn.HeaderText = "ENABLED";
            this.eNABLEDDataGridViewTextBoxColumn.Name = "eNABLEDDataGridViewTextBoxColumn";
            this.eNABLEDDataGridViewTextBoxColumn.ReadOnly = true;
            this.eNABLEDDataGridViewTextBoxColumn.Visible = false;
            // 
            // cREATEDDataGridViewTextBoxColumn
            // 
            this.cREATEDDataGridViewTextBoxColumn.DataPropertyName = "CREATED";
            this.cREATEDDataGridViewTextBoxColumn.HeaderText = "CREATED";
            this.cREATEDDataGridViewTextBoxColumn.Name = "cREATEDDataGridViewTextBoxColumn";
            this.cREATEDDataGridViewTextBoxColumn.ReadOnly = true;
            this.cREATEDDataGridViewTextBoxColumn.Visible = false;
            // 
            // uPDATEDDataGridViewTextBoxColumn
            // 
            this.uPDATEDDataGridViewTextBoxColumn.DataPropertyName = "UPDATED";
            this.uPDATEDDataGridViewTextBoxColumn.HeaderText = "UPDATED";
            this.uPDATEDDataGridViewTextBoxColumn.Name = "uPDATEDDataGridViewTextBoxColumn";
            this.uPDATEDDataGridViewTextBoxColumn.ReadOnly = true;
            this.uPDATEDDataGridViewTextBoxColumn.Visible = false;
            // 
            // sRCDataGridViewTextBoxColumn
            // 
            this.sRCDataGridViewTextBoxColumn.DataPropertyName = "SRC";
            this.sRCDataGridViewTextBoxColumn.HeaderText = "SRC";
            this.sRCDataGridViewTextBoxColumn.Name = "sRCDataGridViewTextBoxColumn";
            this.sRCDataGridViewTextBoxColumn.ReadOnly = true;
            this.sRCDataGridViewTextBoxColumn.Visible = false;
            // 
            // CtrlGridRequirementItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "CtrlGridRequirementItems";
            this.Size = new System.Drawing.Size(821, 498);
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dsRequirements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRequirement)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemReqAdd;
        private System.Windows.Forms.ToolStripMenuItem menuItemReqEdit;
        private System.Windows.Forms.ToolStripMenuItem menuItemReqDel;
        private System.Data.DataColumn colSRC;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemReorder;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Data.DataColumn dataColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn pATHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CATNM;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rEQNMTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRJIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cATIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sRCIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eNABLEDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cREATEDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uPDATEDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sRCDataGridViewTextBoxColumn;
    }
}
