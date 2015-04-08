using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using eBdb.EpubReader;
using ePubIntegrator.Helpers;
using ePubIntegrator.ui;

namespace ePubIntegrator
{
    public partial class UserControlEbook : UserControl
    {
        private readonly Epub _ePub;
        private readonly string _filePath;
        private readonly string _userName;
        private readonly XmlDocument _galleryData;
        private Boolean _favourite;
        public UserControlEbook(Epub ebook, string fileLoc, string username, XmlDocument galleryData)
        {
            InitializeComponent();
            _ePub = ebook;
            _filePath = fileLoc;
            _userName = username;
            _favourite = isFavourite();
            _galleryData = galleryData;
            btnFavourite.Visible = _favourite;
            changeNameMenuItem();
        }

        public void changeNameMenuItem()
        {
            if (_favourite)
            {
                addFavouriteToolStripMenuItem.Text = "Remove Favourite";
            }
            else
            {
                addFavouriteToolStripMenuItem.Text = "add Favourite";
            }
            
        }

        public void Title(string title)
        {
            lblTitle.Text = title;
        }

        public void Picture(Image image)
        {
            pbEbookImage.Image = image;
        }

        public void Author(string author)
        {
            lblAuthor.Text = author;
        }

        public void AuthorVisible(Boolean visible)
        {
            lblAuthor.Visible = visible;
        }


        private void pbEbookImage_MouseLeave(object sender, EventArgs e)
        {
            BorderStyle = BorderStyle.None;
            
        }


        private void pbEbookImage_MouseEnter(object sender, EventArgs e)
        {
            BorderStyle = BorderStyle.FixedSingle; 
        }

        private Boolean isFavourite()
        {
            // XML
            var dataXmlFile = XmlHelper.GetXmlFile(XmlHelper.UserDefinedGalleryDataXmlFilePath);
            var favouritesTag = dataXmlFile.SelectSingleNode("/data/gallery/favourites");
            var favouritesList = favouritesTag.SelectNodes("favourite");
            var favouriteExists = false;


            foreach (XmlNode favourite in favouritesList)
            {
                if (_userName == favourite.SelectSingleNode("username").InnerText &&
                    favourite.SelectSingleNode("ebook-title").InnerText == _ePub.Title[0])
                {
                    favouriteExists = true;
                }
            }
            return favouriteExists;
        }

        private void btnFavourite_Click(object sender, EventArgs e)
        {
          
        }


        private void pbEbookImage_DoubleClick(object sender, EventArgs e)
        {
            var form = new ReaderForm(_ePub, _userName, _galleryData);
            form.ShowDialog();
        }

        private void btnFavourite_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void btnFavourite_DragLeave(object sender, EventArgs e)
        {

        }

        private void addFavouriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // XML
            var dataXmlFile = XmlHelper.GetXmlFile(XmlHelper.UserDefinedGalleryDataXmlFilePath);
            var favouritesTag = dataXmlFile.SelectSingleNode("/data/gallery/favourites");
            var favouritesList = favouritesTag.SelectNodes("favourite");
            var favouriteExists = false;


            foreach (XmlNode favourite in favouritesList)
            {
                if (_userName == favourite.SelectSingleNode("username").InnerText &&
                    favourite.SelectSingleNode("ebook-title").InnerText == _ePub.Title[0])
                {
                    MessageHelper.ShowNotificationMessage("", "Favourite removed");
                    favouriteExists = true;
                    favouritesTag.RemoveChild(favourite);
                    btnFavourite.Visible = false;
                    _favourite = false;
                    
                }
            }

            if (!favouriteExists)
            {
                //add
                var favouriteTag = favouritesTag.AppendChild(dataXmlFile.CreateElement("favourite"));
                favouriteTag.AppendChild(dataXmlFile.CreateElement("username")).InnerText = _userName;
                favouriteTag.AppendChild(dataXmlFile.CreateElement("ebook-title")).InnerText = _ePub.Title[0];
                btnFavourite.Visible = true;
                _favourite = true;
            }
            changeNameMenuItem();
            dataXmlFile.Save(XmlHelper.UserDefinedGalleryDataXmlFilePath);
            
        }
    }
}