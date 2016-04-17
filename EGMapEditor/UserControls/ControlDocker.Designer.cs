namespace EGMapEditor
{
    partial class ControlDocker
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
            this.dockContainer = new System.Windows.Forms.SplitContainer();
            this.tabDockBottom = new System.Windows.Forms.TabControl();
            this.tabDockTop = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.dockContainer)).BeginInit();
            this.dockContainer.Panel1.SuspendLayout();
            this.dockContainer.Panel2.SuspendLayout();
            this.dockContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockContainer
            // 
            this.dockContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockContainer.Location = new System.Drawing.Point(0, 0);
            this.dockContainer.Name = "dockContainer";
            this.dockContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // dockContainer.Panel1
            // 
            this.dockContainer.Panel1.Controls.Add(this.tabDockTop);
            // 
            // dockContainer.Panel2
            // 
            this.dockContainer.Panel2.Controls.Add(this.tabDockBottom);
            this.dockContainer.Size = new System.Drawing.Size(381, 636);
            this.dockContainer.SplitterDistance = 314;
            this.dockContainer.TabIndex = 0;
            // 
            // tabDockBottom
            // 
            this.tabDockBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDockBottom.Location = new System.Drawing.Point(0, 0);
            this.tabDockBottom.Name = "tabDockBottom";
            this.tabDockBottom.SelectedIndex = 0;
            this.tabDockBottom.Size = new System.Drawing.Size(381, 318);
            this.tabDockBottom.TabIndex = 0;
            // 
            // tabDockTop
            // 
            this.tabDockTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDockTop.Location = new System.Drawing.Point(0, 0);
            this.tabDockTop.Name = "tabDockTop";
            this.tabDockTop.SelectedIndex = 0;
            this.tabDockTop.Size = new System.Drawing.Size(381, 314);
            this.tabDockTop.TabIndex = 1;
            // 
            // ControlDocker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dockContainer);
            this.Name = "ControlDocker";
            this.Size = new System.Drawing.Size(381, 636);
            this.dockContainer.Panel1.ResumeLayout(false);
            this.dockContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dockContainer)).EndInit();
            this.dockContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer dockContainer;
        private System.Windows.Forms.TabControl tabDockTop;
        private System.Windows.Forms.TabControl tabDockBottom;
    }
}
