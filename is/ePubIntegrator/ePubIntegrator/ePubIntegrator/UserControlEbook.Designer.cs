namespace ePubIntegrator
{
    partial class UserControlEbook
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlEbook));
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbEbookImage = new System.Windows.Forms.PictureBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.btnFavourite = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addFavouriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbEbookImage)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Name = "lblTitle";
            // 
            // pbEbookImage
            // 
            this.pbEbookImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbEbookImage.ContextMenuStrip = this.contextMenuStrip1;
            resources.ApplyResources(this.pbEbookImage, "pbEbookImage");
            this.pbEbookImage.Name = "pbEbookImage";
            this.pbEbookImage.TabStop = false;
            this.pbEbookImage.DoubleClick += new System.EventHandler(this.pbEbookImage_DoubleClick);
            this.pbEbookImage.MouseEnter += new System.EventHandler(this.pbEbookImage_MouseEnter);
            this.pbEbookImage.MouseLeave += new System.EventHandler(this.pbEbookImage_MouseLeave);
            // 
            // lblAuthor
            // 
            resources.ApplyResources(this.lblAuthor, "lblAuthor");
            this.lblAuthor.Name = "lblAuthor";
            // 
            // btnFavourite
            // 
            this.btnFavourite.BackColor = System.Drawing.Color.Transparent;
            this.btnFavourite.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnFavourite, "btnFavourite");
            this.btnFavourite.Image = global::ePubIntegrator.Properties.Resources.ico_fav;
            this.btnFavourite.Name = "btnFavourite";
            this.btnFavourite.UseVisualStyleBackColor = false;
            this.btnFavourite.Click += new System.EventHandler(this.btnFavourite_Click);
            this.btnFavourite.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnFavourite_DragEnter);
            this.btnFavourite.DragLeave += new System.EventHandler(this.btnFavourite_DragLeave);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFavouriteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // addFavouriteToolStripMenuItem
            // 
            this.addFavouriteToolStripMenuItem.Name = "addFavouriteToolStripMenuItem";
            resources.ApplyResources(this.addFavouriteToolStripMenuItem, "addFavouriteToolStripMenuItem");
            this.addFavouriteToolStripMenuItem.Click += new System.EventHandler(this.addFavouriteToolStripMenuItem_Click);
            // 
            // UserControlEbook
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFavourite);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbEbookImage);
            this.Name = "UserControlEbook";
            ((System.ComponentModel.ISupportInitialize)(this.pbEbookImage)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbEbookImage;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Button btnFavourite;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addFavouriteToolStripMenuItem;
    }
}
