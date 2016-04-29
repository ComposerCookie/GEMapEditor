namespace EGMapEditor
{
    partial class MapLayersViewer
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
            this.trvLayers = new System.Windows.Forms.TreeView();
            this.btnAddLayer = new System.Windows.Forms.Button();
            this.btnEditLayer = new System.Windows.Forms.Button();
            this.btnMoveLayerUp = new System.Windows.Forms.Button();
            this.btnMoveLayerDown = new System.Windows.Forms.Button();
            this.btnDeleteLayer = new System.Windows.Forms.Button();
            this.btnDuplicateLayer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // trvLayers
            // 
            this.trvLayers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvLayers.Location = new System.Drawing.Point(0, 0);
            this.trvLayers.Name = "trvLayers";
            this.trvLayers.Size = new System.Drawing.Size(284, 185);
            this.trvLayers.TabIndex = 0;
            this.trvLayers.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvLayers_AfterSelect);
            // 
            // btnAddLayer
            // 
            this.btnAddLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddLayer.Location = new System.Drawing.Point(1, 191);
            this.btnAddLayer.Name = "btnAddLayer";
            this.btnAddLayer.Size = new System.Drawing.Size(42, 30);
            this.btnAddLayer.TabIndex = 1;
            this.btnAddLayer.Text = "Add";
            this.btnAddLayer.UseVisualStyleBackColor = true;
            this.btnAddLayer.Click += new System.EventHandler(this.btnAddLayer_Click);
            // 
            // btnEditLayer
            // 
            this.btnEditLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditLayer.Location = new System.Drawing.Point(49, 191);
            this.btnEditLayer.Name = "btnEditLayer";
            this.btnEditLayer.Size = new System.Drawing.Size(42, 30);
            this.btnEditLayer.TabIndex = 2;
            this.btnEditLayer.Text = "Edit";
            this.btnEditLayer.UseVisualStyleBackColor = true;
            // 
            // btnMoveLayerUp
            // 
            this.btnMoveLayerUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMoveLayerUp.Location = new System.Drawing.Point(97, 191);
            this.btnMoveLayerUp.Name = "btnMoveLayerUp";
            this.btnMoveLayerUp.Size = new System.Drawing.Size(42, 30);
            this.btnMoveLayerUp.TabIndex = 3;
            this.btnMoveLayerUp.Text = "^";
            this.btnMoveLayerUp.UseVisualStyleBackColor = true;
            this.btnMoveLayerUp.Click += new System.EventHandler(this.btnMoveLayerUp_Click);
            // 
            // btnMoveLayerDown
            // 
            this.btnMoveLayerDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMoveLayerDown.Location = new System.Drawing.Point(145, 191);
            this.btnMoveLayerDown.Name = "btnMoveLayerDown";
            this.btnMoveLayerDown.Size = new System.Drawing.Size(42, 30);
            this.btnMoveLayerDown.TabIndex = 4;
            this.btnMoveLayerDown.Text = "v";
            this.btnMoveLayerDown.UseVisualStyleBackColor = true;
            this.btnMoveLayerDown.Click += new System.EventHandler(this.btnMoveLayerDown_Click);
            // 
            // btnDeleteLayer
            // 
            this.btnDeleteLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteLayer.Location = new System.Drawing.Point(193, 191);
            this.btnDeleteLayer.Name = "btnDeleteLayer";
            this.btnDeleteLayer.Size = new System.Drawing.Size(42, 30);
            this.btnDeleteLayer.TabIndex = 5;
            this.btnDeleteLayer.Text = "Rem";
            this.btnDeleteLayer.UseVisualStyleBackColor = true;
            this.btnDeleteLayer.Click += new System.EventHandler(this.btnDeleteLayer_Click);
            // 
            // btnDuplicateLayer
            // 
            this.btnDuplicateLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDuplicateLayer.Location = new System.Drawing.Point(241, 191);
            this.btnDuplicateLayer.Name = "btnDuplicateLayer";
            this.btnDuplicateLayer.Size = new System.Drawing.Size(42, 30);
            this.btnDuplicateLayer.TabIndex = 6;
            this.btnDuplicateLayer.Text = "Dup";
            this.btnDuplicateLayer.UseVisualStyleBackColor = true;
            // 
            // MapLayersViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 227);
            this.Controls.Add(this.btnDuplicateLayer);
            this.Controls.Add(this.btnDeleteLayer);
            this.Controls.Add(this.btnMoveLayerDown);
            this.Controls.Add(this.btnMoveLayerUp);
            this.Controls.Add(this.btnEditLayer);
            this.Controls.Add(this.btnAddLayer);
            this.Controls.Add(this.trvLayers);
            this.DockAreas = ((System.Windows.Forms.DockPanel.DockAreas)(((((System.Windows.Forms.DockPanel.DockAreas.Float | System.Windows.Forms.DockPanel.DockAreas.DockLeft) 
            | System.Windows.Forms.DockPanel.DockAreas.DockRight) 
            | System.Windows.Forms.DockPanel.DockAreas.DockTop) 
            | System.Windows.Forms.DockPanel.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MapLayersViewer";
            this.ShowIcon = false;
            this.Text = "Layers";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trvLayers;
        private System.Windows.Forms.Button btnAddLayer;
        private System.Windows.Forms.Button btnEditLayer;
        private System.Windows.Forms.Button btnMoveLayerUp;
        private System.Windows.Forms.Button btnMoveLayerDown;
        private System.Windows.Forms.Button btnDeleteLayer;
        private System.Windows.Forms.Button btnDuplicateLayer;
    }
}
