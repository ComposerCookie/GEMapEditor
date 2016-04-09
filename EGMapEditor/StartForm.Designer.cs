namespace EGMapEditor
{
    partial class StartForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEnter = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.rdbtnOffline = new System.Windows.Forms.RadioButton();
            this.rdbtnOnline = new System.Windows.Forms.RadioButton();
            this.btnConnect = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbtnSSize1 = new System.Windows.Forms.RadioButton();
            this.rdbtnSSize2 = new System.Windows.Forms.RadioButton();
            this.rdbtnSSize3 = new System.Windows.Forms.RadioButton();
            this.rdbtnSSize4 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEnter
            // 
            this.btnEnter.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnEnter.Enabled = false;
            this.btnEnter.Location = new System.Drawing.Point(416, 179);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(94, 32);
            this.btnEnter.TabIndex = 0;
            this.btnEnter.Text = "Enter";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.txtIp);
            this.groupBox1.Controls.Add(this.rdbtnOffline);
            this.groupBox1.Controls.Add(this.rdbtnOnline);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 199);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Type";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(78, 120);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(204, 20);
            this.txtPass.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Username:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP Address:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(78, 94);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(204, 20);
            this.txtUser.TabIndex = 3;
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(78, 68);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(204, 20);
            this.txtIp.TabIndex = 2;
            // 
            // rdbtnOffline
            // 
            this.rdbtnOffline.AutoSize = true;
            this.rdbtnOffline.Location = new System.Drawing.Point(18, 157);
            this.rdbtnOffline.Name = "rdbtnOffline";
            this.rdbtnOffline.Size = new System.Drawing.Size(55, 17);
            this.rdbtnOffline.TabIndex = 1;
            this.rdbtnOffline.Text = "Offline";
            this.rdbtnOffline.UseVisualStyleBackColor = true;
            this.rdbtnOffline.CheckedChanged += new System.EventHandler(this.rdbtnOffline_CheckedChanged);
            // 
            // rdbtnOnline
            // 
            this.rdbtnOnline.AutoSize = true;
            this.rdbtnOnline.Checked = true;
            this.rdbtnOnline.Location = new System.Drawing.Point(18, 30);
            this.rdbtnOnline.Name = "rdbtnOnline";
            this.rdbtnOnline.Size = new System.Drawing.Size(55, 17);
            this.rdbtnOnline.TabIndex = 0;
            this.rdbtnOnline.TabStop = true;
            this.rdbtnOnline.Text = "Online";
            this.rdbtnOnline.UseVisualStyleBackColor = true;
            this.rdbtnOnline.CheckedChanged += new System.EventHandler(this.rdbtnOnline_CheckedChanged);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(316, 179);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(94, 32);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbtnSSize4);
            this.groupBox2.Controls.Add(this.rdbtnSSize3);
            this.groupBox2.Controls.Add(this.rdbtnSSize2);
            this.groupBox2.Controls.Add(this.rdbtnSSize1);
            this.groupBox2.Location = new System.Drawing.Point(316, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 161);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Screen Size";
            // 
            // rdbtnSSize1
            // 
            this.rdbtnSSize1.AutoSize = true;
            this.rdbtnSSize1.Location = new System.Drawing.Point(19, 30);
            this.rdbtnSSize1.Name = "rdbtnSSize1";
            this.rdbtnSSize1.Size = new System.Drawing.Size(66, 17);
            this.rdbtnSSize1.TabIndex = 0;
            this.rdbtnSSize1.Text = "800x600";
            this.rdbtnSSize1.UseVisualStyleBackColor = true;
            // 
            // rdbtnSSize2
            // 
            this.rdbtnSSize2.AutoSize = true;
            this.rdbtnSSize2.Checked = true;
            this.rdbtnSSize2.Location = new System.Drawing.Point(19, 53);
            this.rdbtnSSize2.Name = "rdbtnSSize2";
            this.rdbtnSSize2.Size = new System.Drawing.Size(72, 17);
            this.rdbtnSSize2.TabIndex = 1;
            this.rdbtnSSize2.TabStop = true;
            this.rdbtnSSize2.Text = "1024x768";
            this.rdbtnSSize2.UseVisualStyleBackColor = true;
            // 
            // rdbtnSSize3
            // 
            this.rdbtnSSize3.AutoSize = true;
            this.rdbtnSSize3.Location = new System.Drawing.Point(19, 76);
            this.rdbtnSSize3.Name = "rdbtnSSize3";
            this.rdbtnSSize3.Size = new System.Drawing.Size(72, 17);
            this.rdbtnSSize3.TabIndex = 2;
            this.rdbtnSSize3.Text = "1366x768";
            this.rdbtnSSize3.UseVisualStyleBackColor = true;
            // 
            // rdbtnSSize4
            // 
            this.rdbtnSSize4.AutoSize = true;
            this.rdbtnSSize4.Location = new System.Drawing.Point(19, 99);
            this.rdbtnSSize4.Name = "rdbtnSSize4";
            this.rdbtnSSize4.Size = new System.Drawing.Size(78, 17);
            this.rdbtnSSize4.TabIndex = 4;
            this.rdbtnSSize4.Text = "1920x1080";
            this.rdbtnSSize4.UseVisualStyleBackColor = true;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 222);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEnter);
            this.Name = "StartForm";
            this.Text = "EG Map Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.RadioButton rdbtnOffline;
        private System.Windows.Forms.RadioButton rdbtnOnline;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdbtnSSize4;
        private System.Windows.Forms.RadioButton rdbtnSSize3;
        private System.Windows.Forms.RadioButton rdbtnSSize2;
        private System.Windows.Forms.RadioButton rdbtnSSize1;
    }
}

