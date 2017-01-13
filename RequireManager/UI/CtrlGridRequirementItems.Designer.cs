﻿namespace RequireManager.UI
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
            this.pATHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rEQNMTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRJIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cATIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sRCIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eNABLEDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cREATEDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uPDATEDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemReorder = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sRCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSRC = new System.Data.DataColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            this.pATHDataGridViewTextBoxColumn,
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
            this.gridItems.RowHeadersVisible = false;
            this.gridItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridItems.Size = new System.Drawing.Size(821, 498);
            this.gridItems.TabIndex = 1;
            this.gridItems.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridItems_CellMouseDown);
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(179, 120);
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
            this.colSRC});
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
            // pATHDataGridViewTextBoxColumn
            // 
            this.pATHDataGridViewTextBoxColumn.DataPropertyName = "PATH";
            this.pATHDataGridViewTextBoxColumn.HeaderText = "Path";
            this.pATHDataGridViewTextBoxColumn.Name = "pATHDataGridViewTextBoxColumn";
            this.pATHDataGridViewTextBoxColumn.Width = 250;
            // 
            // iDXDataGridViewTextBoxColumn
            // 
            this.iDXDataGridViewTextBoxColumn.DataPropertyName = "IDX";
            this.iDXDataGridViewTextBoxColumn.HeaderText = "Index";
            this.iDXDataGridViewTextBoxColumn.Name = "iDXDataGridViewTextBoxColumn";
            // 
            // rEQNMTDataGridViewTextBoxColumn
            // 
            this.rEQNMTDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.rEQNMTDataGridViewTextBoxColumn.DataPropertyName = "REQNMT";
            this.rEQNMTDataGridViewTextBoxColumn.HeaderText = "Requirement";
            this.rEQNMTDataGridViewTextBoxColumn.Name = "rEQNMTDataGridViewTextBoxColumn";
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // pRJIDDataGridViewTextBoxColumn
            // 
            this.pRJIDDataGridViewTextBoxColumn.DataPropertyName = "PRJID";
            this.pRJIDDataGridViewTextBoxColumn.HeaderText = "PRJID";
            this.pRJIDDataGridViewTextBoxColumn.Name = "pRJIDDataGridViewTextBoxColumn";
            this.pRJIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // cATIDDataGridViewTextBoxColumn
            // 
            this.cATIDDataGridViewTextBoxColumn.DataPropertyName = "CATID";
            this.cATIDDataGridViewTextBoxColumn.HeaderText = "CATID";
            this.cATIDDataGridViewTextBoxColumn.Name = "cATIDDataGridViewTextBoxColumn";
            this.cATIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // sRCIDDataGridViewTextBoxColumn
            // 
            this.sRCIDDataGridViewTextBoxColumn.DataPropertyName = "SRCID";
            this.sRCIDDataGridViewTextBoxColumn.HeaderText = "SRCID";
            this.sRCIDDataGridViewTextBoxColumn.Name = "sRCIDDataGridViewTextBoxColumn";
            this.sRCIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // eNABLEDDataGridViewTextBoxColumn
            // 
            this.eNABLEDDataGridViewTextBoxColumn.DataPropertyName = "ENABLED";
            this.eNABLEDDataGridViewTextBoxColumn.HeaderText = "ENABLED";
            this.eNABLEDDataGridViewTextBoxColumn.Name = "eNABLEDDataGridViewTextBoxColumn";
            this.eNABLEDDataGridViewTextBoxColumn.Visible = false;
            // 
            // cREATEDDataGridViewTextBoxColumn
            // 
            this.cREATEDDataGridViewTextBoxColumn.DataPropertyName = "CREATED";
            this.cREATEDDataGridViewTextBoxColumn.HeaderText = "CREATED";
            this.cREATEDDataGridViewTextBoxColumn.Name = "cREATEDDataGridViewTextBoxColumn";
            this.cREATEDDataGridViewTextBoxColumn.Visible = false;
            // 
            // uPDATEDDataGridViewTextBoxColumn
            // 
            this.uPDATEDDataGridViewTextBoxColumn.DataPropertyName = "UPDATED";
            this.uPDATEDDataGridViewTextBoxColumn.HeaderText = "UPDATED";
            this.uPDATEDDataGridViewTextBoxColumn.Name = "uPDATEDDataGridViewTextBoxColumn";
            this.uPDATEDDataGridViewTextBoxColumn.Visible = false;
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "SRC";
            this.dataGridViewTextBoxColumn1.HeaderText = "SRC";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // sRCDataGridViewTextBoxColumn
            // 
            this.sRCDataGridViewTextBoxColumn.DataPropertyName = "SRC";
            this.sRCDataGridViewTextBoxColumn.HeaderText = "SRC";
            this.sRCDataGridViewTextBoxColumn.Name = "sRCDataGridViewTextBoxColumn";
            this.sRCDataGridViewTextBoxColumn.Visible = false;
            // 
            // colSRC
            // 
            this.colSRC.ColumnName = "SRC";
            this.colSRC.DataType = typeof(object);
            // 
            // CtrlGridRequirementItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridItems);
            this.Name = "CtrlGridRequirementItems";
            this.Size = new System.Drawing.Size(821, 498);
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemReqAdd;
        private System.Windows.Forms.ToolStripMenuItem menuItemReqEdit;
        private System.Windows.Forms.ToolStripMenuItem menuItemReqDel;
        private System.Data.DataColumn colSRC;
        private System.Windows.Forms.DataGridViewTextBoxColumn pATHDataGridViewTextBoxColumn;
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemReorder;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}
