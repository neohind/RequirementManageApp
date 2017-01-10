namespace RequireManager.UI
{
    partial class CtrlCategoryNavigator
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
            this.treeCategory = new System.Windows.Forms.TreeView();
            this.ctxTreeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemAddCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEditCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDelCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxTreeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeCategory
            // 
            this.treeCategory.AllowDrop = true;
            this.treeCategory.ContextMenuStrip = this.ctxTreeMenu;
            this.treeCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeCategory.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeCategory.FullRowSelect = true;
            this.treeCategory.HideSelection = false;
            this.treeCategory.Location = new System.Drawing.Point(0, 0);
            this.treeCategory.Margin = new System.Windows.Forms.Padding(4);
            this.treeCategory.Name = "treeCategory";
            this.treeCategory.ShowNodeToolTips = true;
            this.treeCategory.ShowPlusMinus = false;
            this.treeCategory.ShowRootLines = false;
            this.treeCategory.Size = new System.Drawing.Size(189, 504);
            this.treeCategory.TabIndex = 1;
            this.treeCategory.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeCategory_ItemDrag);
            this.treeCategory.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeCategory_NodeMouseClick);
            this.treeCategory.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeCategory_DragDrop);
            this.treeCategory.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeCategory_DragEnter);
            // 
            // ctxTreeMenu
            // 
            this.ctxTreeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAddCategory,
            this.menuItemEditCategory,
            this.menuItemDelCategory});
            this.ctxTreeMenu.Name = "ctxTreeMenu";
            this.ctxTreeMenu.Size = new System.Drawing.Size(148, 70);
            // 
            // menuItemAddCategory
            // 
            this.menuItemAddCategory.Name = "menuItemAddCategory";
            this.menuItemAddCategory.Size = new System.Drawing.Size(147, 22);
            this.menuItemAddCategory.Text = "Add Category";
            this.menuItemAddCategory.Click += new System.EventHandler(this.menuCategory_Click);
            // 
            // menuItemEditCategory
            // 
            this.menuItemEditCategory.Name = "menuItemEditCategory";
            this.menuItemEditCategory.Size = new System.Drawing.Size(147, 22);
            this.menuItemEditCategory.Text = "Edit Category";
            this.menuItemEditCategory.Click += new System.EventHandler(this.menuCategory_Click);
            // 
            // menuItemDelCategory
            // 
            this.menuItemDelCategory.Name = "menuItemDelCategory";
            this.menuItemDelCategory.Size = new System.Drawing.Size(147, 22);
            this.menuItemDelCategory.Text = "Del Category";
            this.menuItemDelCategory.Click += new System.EventHandler(this.menuCategory_Click);
            // 
            // CtrlCategoryNavigator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeCategory);
            this.Name = "CtrlCategoryNavigator";
            this.Size = new System.Drawing.Size(189, 504);
            this.ctxTreeMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeCategory;
        private System.Windows.Forms.ContextMenuStrip ctxTreeMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemAddCategory;
        private System.Windows.Forms.ToolStripMenuItem menuItemEditCategory;
        private System.Windows.Forms.ToolStripMenuItem menuItemDelCategory;
    }
}
