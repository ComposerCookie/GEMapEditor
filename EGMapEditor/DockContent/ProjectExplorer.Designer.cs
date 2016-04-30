namespace EGMapEditor
{
    partial class ProjectExplorer
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
            this.trvExplorer = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // trvExplorer
            // 
            this.trvExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvExplorer.Location = new System.Drawing.Point(0, 0);
            this.trvExplorer.Name = "trvExplorer";
            this.trvExplorer.Size = new System.Drawing.Size(287, 237);
            this.trvExplorer.TabIndex = 0;
            // 
            // ProjectExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 237);
            this.Controls.Add(this.trvExplorer);
            this.DockAreas = ((System.Windows.Forms.DockPanel.DockAreas)(((((System.Windows.Forms.DockPanel.DockAreas.Float | System.Windows.Forms.DockPanel.DockAreas.DockLeft) 
            | System.Windows.Forms.DockPanel.DockAreas.DockRight) 
            | System.Windows.Forms.DockPanel.DockAreas.DockTop) 
            | System.Windows.Forms.DockPanel.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ProjectExplorer";
            this.ShowIcon = false;
            this.Text = "Project Explorer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trvExplorer;
    }
}
