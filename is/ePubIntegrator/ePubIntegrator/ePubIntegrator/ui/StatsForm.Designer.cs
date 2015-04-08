namespace ePubIntegrator.ui
{
    partial class Statistics
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
            this.gpLocalStats = new System.Windows.Forms.GroupBox();
            this.gbGlobalStats = new System.Windows.Forms.GroupBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblLastUser = new System.Windows.Forms.Label();
            this.lblLastLogin = new System.Windows.Forms.Label();
            this.lblLastBook = new System.Windows.Forms.Label();
            this.lblLastChapterNumber = new System.Windows.Forms.Label();
            this.lblLastChapterTitle = new System.Windows.Forms.Label();
            this.gpLocalStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpLocalStats
            // 
            this.gpLocalStats.Controls.Add(this.lblLastChapterTitle);
            this.gpLocalStats.Controls.Add(this.lblLastChapterNumber);
            this.gpLocalStats.Controls.Add(this.lblLastBook);
            this.gpLocalStats.Controls.Add(this.lblLastLogin);
            this.gpLocalStats.Controls.Add(this.lblLastUser);
            this.gpLocalStats.Location = new System.Drawing.Point(28, 12);
            this.gpLocalStats.Name = "gpLocalStats";
            this.gpLocalStats.Size = new System.Drawing.Size(227, 93);
            this.gpLocalStats.TabIndex = 0;
            this.gpLocalStats.TabStop = false;
            this.gpLocalStats.Text = "Local statistics";
            // 
            // gbGlobalStats
            // 
            this.gbGlobalStats.Location = new System.Drawing.Point(28, 123);
            this.gbGlobalStats.Name = "gbGlobalStats";
            this.gbGlobalStats.Size = new System.Drawing.Size(227, 98);
            this.gbGlobalStats.TabIndex = 1;
            this.gbGlobalStats.TabStop = false;
            this.gbGlobalStats.Text = "Global statistics";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(101, 257);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblLastUser
            // 
            this.lblLastUser.AutoSize = true;
            this.lblLastUser.Location = new System.Drawing.Point(10, 16);
            this.lblLastUser.Name = "lblLastUser";
            this.lblLastUser.Size = new System.Drawing.Size(0, 13);
            this.lblLastUser.TabIndex = 0;
            // 
            // lblLastLogin
            // 
            this.lblLastLogin.AutoSize = true;
            this.lblLastLogin.Location = new System.Drawing.Point(10, 29);
            this.lblLastLogin.Name = "lblLastLogin";
            this.lblLastLogin.Size = new System.Drawing.Size(0, 13);
            this.lblLastLogin.TabIndex = 1;
            // 
            // lblLastBook
            // 
            this.lblLastBook.AutoSize = true;
            this.lblLastBook.Location = new System.Drawing.Point(10, 42);
            this.lblLastBook.Name = "lblLastBook";
            this.lblLastBook.Size = new System.Drawing.Size(0, 13);
            this.lblLastBook.TabIndex = 2;
            // 
            // lblLastChapterNumber
            // 
            this.lblLastChapterNumber.AutoSize = true;
            this.lblLastChapterNumber.Location = new System.Drawing.Point(10, 55);
            this.lblLastChapterNumber.Name = "lblLastChapterNumber";
            this.lblLastChapterNumber.Size = new System.Drawing.Size(0, 13);
            this.lblLastChapterNumber.TabIndex = 3;
            // 
            // lblLastChapterTitle
            // 
            this.lblLastChapterTitle.AutoSize = true;
            this.lblLastChapterTitle.Location = new System.Drawing.Point(13, 74);
            this.lblLastChapterTitle.Name = "lblLastChapterTitle";
            this.lblLastChapterTitle.Size = new System.Drawing.Size(0, 13);
            this.lblLastChapterTitle.TabIndex = 4;
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 292);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.gbGlobalStats);
            this.Controls.Add(this.gpLocalStats);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Statistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StatsForm";
            this.gpLocalStats.ResumeLayout(false);
            this.gpLocalStats.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpLocalStats;
        private System.Windows.Forms.GroupBox gbGlobalStats;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblLastChapterNumber;
        private System.Windows.Forms.Label lblLastBook;
        private System.Windows.Forms.Label lblLastLogin;
        private System.Windows.Forms.Label lblLastUser;
        private System.Windows.Forms.Label lblLastChapterTitle;
    }
}