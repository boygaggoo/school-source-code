namespace ePubIntegrator.ui
{
    partial class AboutForm
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
            this.btnOk = new System.Windows.Forms.Button();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAuthors = new System.Windows.Forms.Label();
            this.lblRealStuff = new System.Windows.Forms.Label();
            this.lblDeveloped = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(213, 199);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Location = new System.Drawing.Point(99, 55);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(146, 13);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Eng. Informática - 2014/2015";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(71, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(194, 31);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "ePubIntegrator";
            // 
            // lblAuthors
            // 
            this.lblAuthors.AutoSize = true;
            this.lblAuthors.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthors.Location = new System.Drawing.Point(176, 108);
            this.lblAuthors.Name = "lblAuthors";
            this.lblAuthors.Size = new System.Drawing.Size(152, 66);
            this.lblAuthors.TabIndex = 4;
            this.lblAuthors.Text = "- Alexandre Olival\r\n- Joaquim Ley\r\n- Tiago Coito";
            this.lblAuthors.Click += new System.EventHandler(this.lblAlex_Click);
            // 
            // lblRealStuff
            // 
            this.lblRealStuff.AutoSize = true;
            this.lblRealStuff.Location = new System.Drawing.Point(9, 92);
            this.lblRealStuff.Name = "lblRealStuff";
            this.lblRealStuff.Size = new System.Drawing.Size(161, 130);
            this.lblRealStuff.TabIndex = 7;
            this.lblRealStuff.Text = "This program was developed for \r\nSystems Integration course.\r\n\r\nWe learned:\r\n- C#" +
    " programing\r\n- .NET framework\r\n- Microsoft SQL Server\r\n- WCF (webservice)\r\n- XML" +
    " handling and parsing\r\n- SOAP Requests";
            this.lblRealStuff.Click += new System.EventHandler(this.lblRealStuff_Click);
            // 
            // lblDeveloped
            // 
            this.lblDeveloped.AutoSize = true;
            this.lblDeveloped.Location = new System.Drawing.Point(177, 92);
            this.lblDeveloped.Name = "lblDeveloped";
            this.lblDeveloped.Size = new System.Drawing.Size(76, 13);
            this.lblDeveloped.TabIndex = 8;
            this.lblDeveloped.Text = "Developed by:";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(260, 34);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(28, 13);
            this.lblVersion.TabIndex = 9;
            this.lblVersion.Text = "v1.0";
            // 
            // AboutForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 238);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblDeveloped);
            this.Controls.Add(this.lblRealStuff);
            this.Controls.Add(this.lblAuthors);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubTitle);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAuthors;
        private System.Windows.Forms.Label lblRealStuff;
        private System.Windows.Forms.Label lblDeveloped;
        private System.Windows.Forms.Label lblVersion;
    }
}