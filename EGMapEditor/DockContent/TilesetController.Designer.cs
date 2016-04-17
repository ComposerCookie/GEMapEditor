namespace EGMapEditor
{
    partial class TilesetController
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
            this.hScrTileset = new System.Windows.Forms.HScrollBar();
            this.vScrTileset = new System.Windows.Forms.VScrollBar();
            this.txtTileset = new System.Windows.Forms.TextBox();
            this.btnTSInc = new System.Windows.Forms.Button();
            this.btnTSDec = new System.Windows.Forms.Button();
            this.chkGrid = new System.Windows.Forms.CheckBox();
            this.tilesetViewer = new SFML.Winforms.SFMLSurface();
            this.SuspendLayout();
            // 
            // hScrTileset
            // 
            this.hScrTileset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrTileset.Location = new System.Drawing.Point(0, 353);
            this.hScrTileset.Name = "hScrTileset";
            this.hScrTileset.Size = new System.Drawing.Size(351, 22);
            this.hScrTileset.TabIndex = 1;
            this.hScrTileset.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrTileset_Scroll);
            // 
            // vScrTileset
            // 
            this.vScrTileset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrTileset.Location = new System.Drawing.Point(351, 0);
            this.vScrTileset.Name = "vScrTileset";
            this.vScrTileset.Size = new System.Drawing.Size(22, 353);
            this.vScrTileset.TabIndex = 2;
            this.vScrTileset.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrTileset_Scroll);
            // 
            // txtTileset
            // 
            this.txtTileset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTileset.Location = new System.Drawing.Point(57, 378);
            this.txtTileset.Margin = new System.Windows.Forms.Padding(5);
            this.txtTileset.Name = "txtTileset";
            this.txtTileset.ReadOnly = true;
            this.txtTileset.Size = new System.Drawing.Size(201, 19);
            this.txtTileset.TabIndex = 3;
            this.txtTileset.Text = "0/0";
            this.txtTileset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnTSInc
            // 
            this.btnTSInc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTSInc.Location = new System.Drawing.Point(268, 378);
            this.btnTSInc.Margin = new System.Windows.Forms.Padding(5);
            this.btnTSInc.Name = "btnTSInc";
            this.btnTSInc.Size = new System.Drawing.Size(39, 27);
            this.btnTSInc.TabIndex = 4;
            this.btnTSInc.Text = ">";
            this.btnTSInc.UseVisualStyleBackColor = true;
            this.btnTSInc.Click += new System.EventHandler(this.btnTSInc_Click);
            // 
            // btnTSDec
            // 
            this.btnTSDec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTSDec.Location = new System.Drawing.Point(0, 378);
            this.btnTSDec.Margin = new System.Windows.Forms.Padding(5);
            this.btnTSDec.Name = "btnTSDec";
            this.btnTSDec.Size = new System.Drawing.Size(39, 27);
            this.btnTSDec.TabIndex = 5;
            this.btnTSDec.Text = "<";
            this.btnTSDec.UseVisualStyleBackColor = true;
            this.btnTSDec.Click += new System.EventHandler(this.btnTSDec_Click);
            // 
            // chkGrid
            // 
            this.chkGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkGrid.AutoSize = true;
            this.chkGrid.Location = new System.Drawing.Point(325, 377);
            this.chkGrid.Margin = new System.Windows.Forms.Padding(5);
            this.chkGrid.Name = "chkGrid";
            this.chkGrid.Size = new System.Drawing.Size(45, 17);
            this.chkGrid.TabIndex = 6;
            this.chkGrid.Text = "Grid";
            this.chkGrid.UseVisualStyleBackColor = true;
            this.chkGrid.CheckedChanged += new System.EventHandler(this.chkGrid_CheckedChanged);
            // 
            // tilesetViewer
            // 
            this.tilesetViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tilesetViewer.AutoDraw = false;
            this.tilesetViewer.ClearColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tilesetViewer.Location = new System.Drawing.Point(0, 0);
            this.tilesetViewer.Margin = new System.Windows.Forms.Padding(4);
            this.tilesetViewer.Name = "tilesetViewer";
            this.tilesetViewer.Size = new System.Drawing.Size(351, 353);
            this.tilesetViewer.TabIndex = 7;
            this.tilesetViewer.Text = null;
            this.tilesetViewer.View = null;
            this.tilesetViewer.Render += new SFML.Winforms.SFMLSurface.NullEventArgs(this.tilesetViewer_Render);
            this.tilesetViewer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tilesetViewer_MouseDown);
            this.tilesetViewer.MouseLeave += new System.EventHandler(this.tilesetViewer_MouseLeave);
            this.tilesetViewer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tilesetViewer_MouseMove);
            this.tilesetViewer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tilesetViewer_MouseUp);
            this.tilesetViewer.Resize += new System.EventHandler(this.tilesetViewer_Resize);
            // 
            // TilesetController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 411);
            this.Controls.Add(this.tilesetViewer);
            this.Controls.Add(this.chkGrid);
            this.Controls.Add(this.btnTSDec);
            this.Controls.Add(this.btnTSInc);
            this.Controls.Add(this.txtTileset);
            this.Controls.Add(this.vScrTileset);
            this.Controls.Add(this.hScrTileset);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(360, 450);
            this.Name = "TilesetController";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private System.Windows.Forms.HScrollBar hScrTileset;
        private System.Windows.Forms.VScrollBar vScrTileset;
        private System.Windows.Forms.TextBox txtTileset;
        private System.Windows.Forms.Button btnTSDec;
        private System.Windows.Forms.Button btnTSInc;
        private System.Windows.Forms.CheckBox chkGrid;
        private SFML.Winforms.SFMLSurface tilesetViewer;
    }
}
