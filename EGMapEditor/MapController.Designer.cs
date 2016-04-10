namespace EGMapEditor
{
    partial class MapController
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
            this.vScrTileset = new System.Windows.Forms.VScrollBar();
            this.hScrTileset = new System.Windows.Forms.HScrollBar();
            this.SuspendLayout();
            // 
            // vScrTileset
            // 
            this.vScrTileset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrTileset.Location = new System.Drawing.Point(598, 1);
            this.vScrTileset.Name = "vScrTileset";
            this.vScrTileset.Size = new System.Drawing.Size(22, 597);
            this.vScrTileset.TabIndex = 4;
            this.vScrTileset.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrTileset_Scroll);
            // 
            // hScrTileset
            // 
            this.hScrTileset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hScrTileset.Location = new System.Drawing.Point(0, 598);
            this.hScrTileset.Name = "hScrTileset";
            this.hScrTileset.Size = new System.Drawing.Size(598, 22);
            this.hScrTileset.TabIndex = 3;
            this.hScrTileset.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrTileset_Scroll);
            // 
            // MapController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vScrTileset);
            this.Controls.Add(this.hScrTileset);
            this.Name = "MapController";
            this.Size = new System.Drawing.Size(620, 620);
            this.Resize += new System.EventHandler(this.MapController_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar vScrTileset;
        private System.Windows.Forms.HScrollBar hScrTileset;
    }
}
