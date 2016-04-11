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
            this.tabMapsController = new System.Windows.Forms.TabControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkGrid = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMapsController
            // 
            this.tabMapsController.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabMapsController.Location = new System.Drawing.Point(0, 0);
            this.tabMapsController.Name = "tabMapsController";
            this.tabMapsController.SelectedIndex = 0;
            this.tabMapsController.Size = new System.Drawing.Size(769, 540);
            this.tabMapsController.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.chkGrid);
            this.groupBox2.Location = new System.Drawing.Point(3, 546);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(762, 55);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options:";
            // 
            // chkGrid
            // 
            this.chkGrid.AutoSize = true;
            this.chkGrid.Location = new System.Drawing.Point(6, 19);
            this.chkGrid.Name = "chkGrid";
            this.chkGrid.Size = new System.Drawing.Size(45, 17);
            this.chkGrid.TabIndex = 0;
            this.chkGrid.Text = "Grid";
            this.chkGrid.UseVisualStyleBackColor = true;
            this.chkGrid.CheckedChanged += new System.EventHandler(this.chkGrid_CheckedChanged);
            // 
            // MapsContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabMapsController);
            this.Name = "MapsContainer";
            this.Size = new System.Drawing.Size(769, 604);
            this.Resize += new System.EventHandler(this.MapsContainer_Resize);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabMapsController;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkGrid;
    }
}
