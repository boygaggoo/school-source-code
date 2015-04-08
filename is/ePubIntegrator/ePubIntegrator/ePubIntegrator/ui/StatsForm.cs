using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using System.Xml;
using ePubIntegrator.Helpers;

namespace ePubIntegrator.ui
{
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public partial class Statistics : Form
    {
        public Statistics(XmlDocument dataFile)
        {
            InitializeComponent();
            var registry = dataFile.DocumentElement.SelectSingleNode("registry");
            lblLastUser.Text = @"Last user: " + registry.SelectSingleNode("last-user").InnerText;
            lblLastLogin.Text = @"Last login: " + registry.SelectSingleNode("last-login").InnerText;
            var lastEbook = registry.SelectSingleNode("last-ebook");
            lblLastBook.Text = @"Last ebook title: " + lastEbook.SelectSingleNode("title").InnerText;
            var chapter = lastEbook.SelectSingleNode("chapter");
            lblLastChapterNumber.Text = @"Last chapter number: " + chapter.SelectSingleNode("index").InnerText;
            lblLastChapterTitle.Text = @"Last chapter title: " + chapter.SelectSingleNode("title").InnerText;
            dataFile.Save(XmlHelper.UserDefinedGalleryDataXmlFilePath);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
