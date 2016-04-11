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
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.explorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesetControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapsContainer = new EGMapEditor.MapsContainer();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
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
            this.addToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // menuAddTileset
            // 
            this.menuAddTileset.Name = "menuAddTileset";
            this.menuAddTileset.Size = new System.Drawing.Size(108, 22);
            this.menuAddTileset.Text = "Tileset";
            this.menuAddTileset.Click += new System.EventHandler(this.menuAddTileset_Click);
            // 
            // menuAddMap
            // 
            this.menuAddMap.Name = "menuAddMap";
            this.menuAddMap.Size = new System.Drawing.Size(108, 22);
            this.menuAddMap.Text = "Map";
            this.menuAddMap.Click += new System.EventHandler(this.menuAddMap_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(116, 6);
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            // 
            // pushToolStripMenuItem
            // 
            this.pushToolStripMenuItem.Name = "pushToolStripMenuItem";
            this.pushToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.pushToolStripMenuItem.Text = "Push";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
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
            // mapsContainer
            // 
            this.mapsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapsContainer.Location = new System.Drawing.Point(0, 24);
            this.mapsContainer.Name = "mapsContainer";
            this.mapsContainer.Size = new System.Drawing.Size(1159, 640);
            this.mapsContainer.TabIndex = 1;
            // 
            // MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 664);
            this.Controls.Add(this.mapsContainer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MapEditor";
            this.Text = "MapEditor";
            this.Load += new System.EventHandler(this.MapEditor_Load);
            this.Shown += new System.EventHandler(this.MapEditor_Shown);
            this.Resize += new System.EventHandler(this.MapEditor_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private MapsContainer mapsContainer;
    }
}