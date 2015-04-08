namespace ePubIntegrator.ui
{
    partial class ReaderForm
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
            this.btnIndex = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstIndex = new System.Windows.Forms.ListBox();
            this.lblChapter = new System.Windows.Forms.Label();
            this.btnNextChapter = new System.Windows.Forms.Button();
            this.btnPreviousChapter = new System.Windows.Forms.Button();
            this.wbEbook = new System.Windows.Forms.WebBrowser();
            this.btnBookMark = new System.Windows.Forms.Button();
            this.btnListBookMarks = new System.Windows.Forms.Button();
            this.btnListFavourites = new System.Windows.Forms.Button();
            this.btnFavorite = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIndex
            // 
            this.btnIndex.Location = new System.Drawing.Point(12, 12);
            this.btnIndex.Name = "btnIndex";
            this.btnIndex.Size = new System.Drawing.Size(75, 23);
            this.btnIndex.TabIndex = 0;
            this.btnIndex.Text = "Index";
            this.btnIndex.UseVisualStyleBackColor = true;
            this.btnIndex.Click += new System.EventHandler(this.btnIndex_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 41);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstIndex);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel2.Controls.Add(this.lblChapter);
            this.splitContainer1.Panel2.Controls.Add(this.btnNextChapter);
            this.splitContainer1.Panel2.Controls.Add(this.btnPreviousChapter);
            this.splitContainer1.Panel2.Controls.Add(this.wbEbook);
            this.splitContainer1.Size = new System.Drawing.Size(879, 692);
            this.splitContainer1.SplitterDistance = 145;
            this.splitContainer1.TabIndex = 1;
            // 
            // lstIndex
            // 
            this.lstIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstIndex.FormattingEnabled = true;
            this.lstIndex.Location = new System.Drawing.Point(0, 0);
            this.lstIndex.Name = "lstIndex";
            this.lstIndex.Size = new System.Drawing.Size(145, 692);
            this.lstIndex.TabIndex = 0;
            this.lstIndex.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // lblChapter
            // 
            this.lblChapter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblChapter.AutoSize = true;
            this.lblChapter.Location = new System.Drawing.Point(346, 5);
            this.lblChapter.Name = "lblChapter";
            this.lblChapter.Size = new System.Drawing.Size(35, 13);
            this.lblChapter.TabIndex = 2;
            this.lblChapter.Text = "label1";
            // 
            // btnNextChapter
            // 
            this.btnNextChapter.BackColor = System.Drawing.Color.White;
            this.btnNextChapter.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNextChapter.FlatAppearance.BorderSize = 0;
            this.btnNextChapter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextChapter.Image = global::ePubIntegrator.Properties.Resources.ico_right_arrow;
            this.btnNextChapter.Location = new System.Drawing.Point(671, 0);
            this.btnNextChapter.Name = "btnNextChapter";
            this.btnNextChapter.Size = new System.Drawing.Size(59, 692);
            this.btnNextChapter.TabIndex = 2;
            this.btnNextChapter.UseVisualStyleBackColor = false;
            this.btnNextChapter.Click += new System.EventHandler(this.btnNextChapter_Click);
            // 
            // btnPreviousChapter
            // 
            this.btnPreviousChapter.BackColor = System.Drawing.Color.Transparent;
            this.btnPreviousChapter.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPreviousChapter.FlatAppearance.BorderSize = 0;
            this.btnPreviousChapter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviousChapter.Image = global::ePubIntegrator.Properties.Resources.ico_left_arrow;
            this.btnPreviousChapter.Location = new System.Drawing.Point(0, 0);
            this.btnPreviousChapter.Name = "btnPreviousChapter";
            this.btnPreviousChapter.Size = new System.Drawing.Size(64, 692);
            this.btnPreviousChapter.TabIndex = 1;
            this.btnPreviousChapter.UseVisualStyleBackColor = false;
            this.btnPreviousChapter.Click += new System.EventHandler(this.btnPreviousChapter_Click);
            // 
            // wbEbook
            // 
            this.wbEbook.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbEbook.Location = new System.Drawing.Point(70, 0);
            this.wbEbook.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbEbook.Name = "wbEbook";
            this.wbEbook.Size = new System.Drawing.Size(595, 684);
            this.wbEbook.TabIndex = 0;
            // 
            // btnBookMark
            // 
            this.btnBookMark.FlatAppearance.BorderSize = 0;
            this.btnBookMark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookMark.Image = global::ePubIntegrator.Properties.Resources.ico_book;
            this.btnBookMark.Location = new System.Drawing.Point(789, 10);
            this.btnBookMark.Name = "btnBookMark";
            this.btnBookMark.Size = new System.Drawing.Size(25, 25);
            this.btnBookMark.TabIndex = 2;
            this.btnBookMark.UseVisualStyleBackColor = true;
            this.btnBookMark.Click += new System.EventHandler(this.btnBookMark_Click);
            // 
            // btnListBookMarks
            // 
            this.btnListBookMarks.Location = new System.Drawing.Point(93, 12);
            this.btnListBookMarks.Name = "btnListBookMarks";
            this.btnListBookMarks.Size = new System.Drawing.Size(75, 23);
            this.btnListBookMarks.TabIndex = 3;
            this.btnListBookMarks.Text = "BookMarks";
            this.btnListBookMarks.UseVisualStyleBackColor = true;
            this.btnListBookMarks.Click += new System.EventHandler(this.btnListBookMarks_Click);
            // 
            // btnListFavourites
            // 
            this.btnListFavourites.Location = new System.Drawing.Point(174, 12);
            this.btnListFavourites.Name = "btnListFavourites";
            this.btnListFavourites.Size = new System.Drawing.Size(75, 23);
            this.btnListFavourites.TabIndex = 4;
            this.btnListFavourites.Text = "Favourites";
            this.btnListFavourites.UseVisualStyleBackColor = true;
            this.btnListFavourites.Click += new System.EventHandler(this.btnListFavorites_Click);
            // 
            // btnFavorite
            // 
            this.btnFavorite.FlatAppearance.BorderSize = 0;
            this.btnFavorite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFavorite.Image = global::ePubIntegrator.Properties.Resources.ico_fav;
            this.btnFavorite.Location = new System.Drawing.Point(746, 10);
            this.btnFavorite.Name = "btnFavorite";
            this.btnFavorite.Size = new System.Drawing.Size(37, 25);
            this.btnFavorite.TabIndex = 5;
            this.btnFavorite.UseVisualStyleBackColor = true;
            this.btnFavorite.Click += new System.EventHandler(this.btnFavorite_Click);
            // 
            // ReaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(879, 733);
            this.Controls.Add(this.btnFavorite);
            this.Controls.Add(this.btnListFavourites);
            this.Controls.Add(this.btnListBookMarks);
            this.Controls.Add(this.btnBookMark);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnIndex);
            this.Name = "ReaderForm";
            this.Text = "ReaderForm";
            this.Load += new System.EventHandler(this.ReaderForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIndex;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lstIndex;
        private System.Windows.Forms.WebBrowser wbEbook;
        private System.Windows.Forms.Button btnNextChapter;
        private System.Windows.Forms.Button btnPreviousChapter;
        private System.Windows.Forms.Label lblChapter;
        private System.Windows.Forms.Button btnBookMark;
        private System.Windows.Forms.Button btnListBookMarks;
        private System.Windows.Forms.Button btnListFavourites;
        private System.Windows.Forms.Button btnFavorite;
    }
}