namespace EGMapEditor
{
    partial class MapEditor
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.stuffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddTileset = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddMap = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pushToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUndoMap = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRedoMap = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.explorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesetControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dockPrimary = new System.Windows.Forms.DockPanel.DockPanel();
            this.dockSecondary = new System.Windows.Forms.DockPanel.DockPanel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stuffToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.windowToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1159, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // stuffToolStripMenuItem
            // 
            this.stuffToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.connectToolStripMenuItem,
            this.pushToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.stuffToolStripMenuItem.Name = "stuffToolStripMenuItem";
            this.stuffToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.stuffToolStripMenuItem.Text = "File";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddTileset,
            this.menuAddMap});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // menuAddTileset
            // 
            this.menuAddTileset.Name = "menuAddTileset";
            this.menuAddTileset.Size = new System.Drawing.Size(152, 22);
            this.menuAddTileset.Text = "Tileset";
            this.menuAddTileset.Click += new System.EventHandler(this.menuAddTileset_Click);
            // 
            // menuAddMap
            // 
            this.menuAddMap.Name = "menuAddMap";
            this.menuAddMap.Size = new System.Drawing.Size(152, 22);
            this.menuAddMap.Text = "Map";
            this.menuAddMap.Click += new System.EventHandler(this.menuAddMap_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            // 
            // pushToolStripMenuItem
            // 
            this.pushToolStripMenuItem.Name = "pushToolStripMenuItem";
            this.pushToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pushToolStripMenuItem.Text = "Push";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUndoMap,
            this.menuRedoMap});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // menuUndoMap
            // 
            this.menuUndoMap.Name = "menuUndoMap";
            this.menuUndoMap.Size = new System.Drawing.Size(152, 22);
            this.menuUndoMap.Text = "Undo";
            this.menuUndoMap.Click += new System.EventHandler(this.menuUndoMap_Click);
            // 
            // menuRedoMap
            // 
            this.menuRedoMap.Name = "menuRedoMap";
            this.menuRedoMap.Size = new System.Drawing.Size(152, 22);
            this.menuRedoMap.Text = "Redo";
            this.menuRedoMap.Click += new System.EventHandler(this.menuRedoMap_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.explorerToolStripMenuItem,
            this.tilesetControllerToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // explorerToolStripMenuItem
            // 
            this.explorerToolStripMenuItem.Name = "explorerToolStripMenuItem";
            this.explorerToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.explorerToolStripMenuItem.Text = "Explorer";
            // 
            // tilesetControllerToolStripMenuItem
            // 
            this.tilesetControllerToolStripMenuItem.Name = "tilesetControllerToolStripMenuItem";
            this.tilesetControllerToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.tilesetControllerToolStripMenuItem.Text = "Tileset Controller";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dockPrimary);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dockSecondary);
            this.splitContainer1.Size = new System.Drawing.Size(1159, 640);
            this.splitContainer1.SplitterDistance = 600;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 13;
            // 
            // dockPrimary
            // 
            this.dockPrimary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPrimary.DocumentStyle = System.Windows.Forms.DockPanel.DocumentStyle.DockingWindow;
            this.dockPrimary.Location = new System.Drawing.Point(0, 0);
            this.dockPrimary.Margin = new System.Windows.Forms.Padding(2);
            this.dockPrimary.Name = "dockPrimary";
            this.dockPrimary.Size = new System.Drawing.Size(600, 640);
            this.dockPrimary.TabIndex = 0;
            // 
            // dockSecondary
            // 
            this.dockSecondary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockSecondary.DocumentStyle = System.Windows.Forms.DockPanel.DocumentStyle.DockingWindow;
            this.dockSecondary.Location = new System.Drawing.Point(0, 0);
            this.dockSecondary.Margin = new System.Windows.Forms.Padding(2);
            this.dockSecondary.Name = "dockSecondary";
            this.dockSecondary.Size = new System.Drawing.Size(556, 640);
            this.dockSecondary.TabIndex = 2;
            // 
            // MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 664);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MapEditor";
            this.Text = "MapEditor";
            this.Shown += new System.EventHandler(this.MapEditor_Shown);
            this.Resize += new System.EventHandler(this.MapEditor_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem stuffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem explorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tilesetControllerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pushToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuAddMap;
        private System.Windows.Forms.ToolStripMenuItem menuAddTileset;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DockPanel.DockPanel dockPrimary;
        private System.Windows.Forms.DockPanel.DockPanel dockSecondary;
        private System.Windows.Forms.ToolStripMenuItem menuUndoMap;
        private System.Windows.Forms.ToolStripMenuItem menuRedoMap;
    }
}