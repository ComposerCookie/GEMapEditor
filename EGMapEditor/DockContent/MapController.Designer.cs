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
            this.mapViewer = new SFML.Winforms.SFMLSurface();
            this.SuspendLayout();
            // 
            // vScrTileset
            // 
            this.vScrTileset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrTileset.Location = new System.Drawing.Point(360, 1);
            this.vScrTileset.Name = "vScrTileset";
            this.vScrTileset.Size = new System.Drawing.Size(22, 331);
            this.vScrTileset.TabIndex = 4;
            this.vScrTileset.Scroll += new System.Windows.Forms.ScrollEventHandler(this.moveCamera);
            // 
            // hScrTileset
            // 
            this.hScrTileset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrTileset.Location = new System.Drawing.Point(0, 332);
            this.hScrTileset.Name = "hScrTileset";
            this.hScrTileset.Size = new System.Drawing.Size(360, 22);
            this.hScrTileset.TabIndex = 3;
            this.hScrTileset.Scroll += new System.Windows.Forms.ScrollEventHandler(this.moveCamera);
            // 
            // mapViewer
            // 
            this.mapViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapViewer.AutoDraw = true;
            this.mapViewer.ClearColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mapViewer.Location = new System.Drawing.Point(0, 1);
            this.mapViewer.Name = "mapViewer";
            this.mapViewer.Size = new System.Drawing.Size(360, 331);
            this.mapViewer.TabIndex = 5;
            this.mapViewer.Text = null;
            this.mapViewer.View = null;
            this.mapViewer.Render += new SFML.Winforms.SFMLSurface.NullEventArgs(this.mapViewer_Render);
            this.mapViewer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapViewer_MouseDown);
            this.mapViewer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapViewer_MouseMove);
            this.mapViewer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mapViewer_MouseUp);
            this.mapViewer.Resize += new System.EventHandler(this.mapViewer_Resize);
            // 
            // MapController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 353);
            this.Controls.Add(this.mapViewer);
            this.Controls.Add(this.vScrTileset);
            this.Controls.Add(this.hScrTileset);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MapController";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar vScrTileset;
        private System.Windows.Forms.HScrollBar hScrTileset;
        private SFML.Winforms.SFMLSurface mapViewer;
    }
}
