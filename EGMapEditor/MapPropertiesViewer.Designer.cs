namespace EGMapEditor
{
    partial class MapPropertiesViewer
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
            this.lstProperties = new System.Windows.Forms.ListView();
            this.propertiesName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.propertiesValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lstProperties
            // 
            this.lstProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.propertiesName,
            this.propertiesValue});
            this.lstProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstProperties.Location = new System.Drawing.Point(0, 0);
            this.lstProperties.Name = "lstProperties";
            this.lstProperties.Size = new System.Drawing.Size(340, 309);
            this.lstProperties.TabIndex = 0;
            this.lstProperties.UseCompatibleStateImageBehavior = false;
            // 
            // propertiesName
            // 
            this.propertiesName.Text = "Properties Name";
            // 
            // propertiesValue
            // 
            this.propertiesValue.Text = "Properties Value";
            // 
            // PropertiesViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstProperties);
            this.Name = "PropertiesViewer";
            this.Size = new System.Drawing.Size(340, 309);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader propertiesName;
        private System.Windows.Forms.ColumnHeader propertiesValue;
        private System.Windows.Forms.ListView lstProperties;
    }
}
