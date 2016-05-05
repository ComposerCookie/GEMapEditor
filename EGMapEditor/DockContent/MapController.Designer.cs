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
            this.vScrTileset.Location = new System.Drawing.Point(277, 0);
            this.vScrTileset.Name = "vScrTileset";
            this.vScrTileset.Size = new System.Drawing.Size(22, 213);
            this.vScrTileset.TabIndex = 4;
            this.vScrTileset.Scroll += new System.Windows.Forms.ScrollEventHandler(this.MoveCamera);
            // 
            // hScrTileset
            // 
            this.hScrTileset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrTileset.Location = new System.Drawing.Point(0, 209);
            this.hScrTileset.Name = "hScrTileset";
            this.hScrTileset.Size = new System.Drawing.Size(278, 22);
            this.hScrTileset.TabIndex = 3;
            this.hScrTileset.Scroll += new System.Windows.Forms.ScrollEventHandler(this.MoveCamera);
            // 
            // mapViewer
            // 
            this.mapViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapViewer.AutoDraw = true;
            this.mapViewer.ClearColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(227)))));
            this.mapViewer.Location = new System.Drawing.Point(0, 0);
            this.mapViewer.Margin = new System.Windows.Forms.Padding(5);
            this.mapViewer.Name = "mapViewer";
            this.mapViewer.Size = new System.Drawing.Size(278, 210);
            this.mapViewer.TabIndex = 5;
            this.mapViewer.Text = null;
            this.mapViewer.View = null;
            this.mapViewer.Render += new SFML.Winforms.SFMLSurface.NullEventArgs(this.mapViewer_Render);
            this.mapViewer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mapViewer_KeyPress);
            this.mapViewer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapViewer_MouseDown);
            this.mapViewer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapViewer_MouseMove);
            this.mapViewer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mapViewer_MouseUp);
            this.mapViewer.Resize += new System.EventHandler(this.mapViewer_Resize);
            // 
            // MapController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(298, 231);
            this.Controls.Add(this.mapViewer);
            this.Controls.Add(this.vScrTileset);
            this.Controls.Add(this.hScrTileset);
            this.DockAreas = ((System.Windows.Forms.DockAreas)((System.Windows.Forms.DockAreas.Float | System.Windows.Forms.DockAreas.Document)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "MapController";
            this.ShowIcon = false;
            this.Text = "New Map";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MapController_FormClosing);
            this.Enter += new System.EventHandler(this.MapController_Enter);
            this.Resize += new System.EventHandler(this.MapController_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar vScrTileset;
        private System.Windows.Forms.HScrollBar hScrTileset;
        private SFML.Winforms.SFMLSurface mapViewer;
    }
}
