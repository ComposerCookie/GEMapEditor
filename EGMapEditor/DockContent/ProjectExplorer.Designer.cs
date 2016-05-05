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
            this.trvExplorer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trvExplorer.Name = "trvExplorer";
            this.trvExplorer.Size = new System.Drawing.Size(215, 181);
            this.trvExplorer.TabIndex = 0;
            this.trvExplorer.DoubleClick += new System.EventHandler(this.trvExplorer_DoubleClick);
            // 
            // ProjectExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 181);
            this.Controls.Add(this.trvExplorer);
            this.DockAreas = ((System.Windows.Forms.DockAreas)(((((System.Windows.Forms.DockAreas.Float | System.Windows.Forms.DockAreas.DockLeft) 
            | System.Windows.Forms.DockAreas.DockRight) 
            | System.Windows.Forms.DockAreas.DockTop) 
            | System.Windows.Forms.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ProjectExplorer";
            this.ShowIcon = false;
            this.Text = "Project Explorer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trvExplorer;
    }
}
