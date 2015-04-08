namespace ePubIntegrator.ui
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDataPath = new System.Windows.Forms.TextBox();
            this.txtSettingsPath = new System.Windows.Forms.TextBox();
            this.txtGalleryFoldePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDataPath = new System.Windows.Forms.Button();
            this.btnSettingsPath = new System.Windows.Forms.Button();
            this.btnGalleryPath = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEndPoint = new System.Windows.Forms.TextBox();
            this.btnEndPoint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Application data path:";
            // 
            // txtDataPath
            // 
            this.txtDataPath.Location = new System.Drawing.Point(168, 62);
            this.txtDataPath.Name = "txtDataPath";
            this.txtDataPath.Size = new System.Drawing.Size(275, 20);
            this.txtDataPath.TabIndex = 1;
            // 
            // txtSettingsPath
            // 
            this.txtSettingsPath.Location = new System.Drawing.Point(168, 100);
            this.txtSettingsPath.Name = "txtSettingsPath";
            this.txtSettingsPath.Size = new System.Drawing.Size(275, 20);
            this.txtSettingsPath.TabIndex = 2;
            // 
            // txtGalleryFoldePath
            // 
            this.txtGalleryFoldePath.Location = new System.Drawing.Point(168, 136);
            this.txtGalleryFoldePath.Name = "txtGalleryFoldePath";
            this.txtGalleryFoldePath.Size = new System.Drawing.Size(275, 20);
            this.txtGalleryFoldePath.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Application settings path:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Gallery folder path:";
            // 
            // btnDataPath
            // 
            this.btnDataPath.Location = new System.Drawing.Point(449, 60);
            this.btnDataPath.Name = "btnDataPath";
            this.btnDataPath.Size = new System.Drawing.Size(75, 23);
            this.btnDataPath.TabIndex = 6;
            this.btnDataPath.Text = "Change";
            this.btnDataPath.UseVisualStyleBackColor = true;
            this.btnDataPath.Click += new System.EventHandler(this.btnDataPath_Click);
            // 
            // btnSettingsPath
            // 
            this.btnSettingsPath.Location = new System.Drawing.Point(449, 98);
            this.btnSettingsPath.Name = "btnSettingsPath";
            this.btnSettingsPath.Size = new System.Drawing.Size(75, 23);
            this.btnSettingsPath.TabIndex = 7;
            this.btnSettingsPath.Text = "Change";
            this.btnSettingsPath.UseVisualStyleBackColor = true;
            this.btnSettingsPath.Click += new System.EventHandler(this.btnSettingsPath_Click);
            // 
            // btnGalleryPath
            // 
            this.btnGalleryPath.Location = new System.Drawing.Point(449, 134);
            this.btnGalleryPath.Name = "btnGalleryPath";
            this.btnGalleryPath.Size = new System.Drawing.Size(75, 23);
            this.btnGalleryPath.TabIndex = 8;
            this.btnGalleryPath.Text = "Change";
            this.btnGalleryPath.UseVisualStyleBackColor = true;
            this.btnGalleryPath.Click += new System.EventHandler(this.btnGalleryPath_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "WebService EndPoint:";
            // 
            // txtEndPoint
            // 
            this.txtEndPoint.Location = new System.Drawing.Point(168, 174);
            this.txtEndPoint.Name = "txtEndPoint";
            this.txtEndPoint.Size = new System.Drawing.Size(275, 20);
            this.txtEndPoint.TabIndex = 11;
            // 
            // btnEndPoint
            // 
            this.btnEndPoint.Location = new System.Drawing.Point(449, 172);
            this.btnEndPoint.Name = "btnEndPoint";
            this.btnEndPoint.Size = new System.Drawing.Size(75, 23);
            this.btnEndPoint.TabIndex = 12;
            this.btnEndPoint.Text = "Change";
            this.btnEndPoint.UseVisualStyleBackColor = true;
            this.btnEndPoint.Click += new System.EventHandler(this.btnEndPoint_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 251);
            this.Controls.Add(this.btnEndPoint);
            this.Controls.Add(this.txtEndPoint);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGalleryPath);
            this.Controls.Add(this.btnSettingsPath);
            this.Controls.Add(this.btnDataPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGalleryFoldePath);
            this.Controls.Add(this.txtSettingsPath);
            this.Controls.Add(this.txtDataPath);
            this.Controls.Add(this.label1);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDataPath;
        private System.Windows.Forms.TextBox txtSettingsPath;
        private System.Windows.Forms.TextBox txtGalleryFoldePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDataPath;
        private System.Windows.Forms.Button btnSettingsPath;
        private System.Windows.Forms.Button btnGalleryPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEndPoint;
        private System.Windows.Forms.Button btnEndPoint;
    }
}