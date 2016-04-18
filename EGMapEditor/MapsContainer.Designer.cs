namespace EGMapEditor
{
    partial class MapsContainer
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
            this.chkGrid = new System.Windows.Forms.CheckBox();
            this.tabMapsController = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // chkGrid
            // 
            this.chkGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkGrid.AutoSize = true;
            this.chkGrid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.chkGrid.Location = new System.Drawing.Point(721, 584);
            this.chkGrid.Name = "chkGrid";
            this.chkGrid.Size = new System.Drawing.Size(45, 17);
            this.chkGrid.TabIndex = 0;
            this.chkGrid.Text = "Grid";
            this.chkGrid.UseVisualStyleBackColor = true;
            this.chkGrid.CheckedChanged += new System.EventHandler(this.chkGrid_CheckedChanged);
            // 
            // tabMapsController
            // 
            this.tabMapsController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMapsController.Location = new System.Drawing.Point(0, 0);
            this.tabMapsController.Name = "tabMapsController";
            this.tabMapsController.SelectedIndex = 0;
            this.tabMapsController.Size = new System.Drawing.Size(769, 578);
            this.tabMapsController.TabIndex = 0;
            // 
            // MapsContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkGrid);
            this.Controls.Add(this.tabMapsController);
            this.Name = "MapsContainer";
            this.Size = new System.Drawing.Size(769, 604);
            this.Resize += new System.EventHandler(this.MapsContainer_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkGrid;
        private System.Windows.Forms.TabControl tabMapsController;
    }
}
