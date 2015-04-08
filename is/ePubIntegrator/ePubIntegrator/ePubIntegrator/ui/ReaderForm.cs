using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using System.Xml;
using eBdb.EpubReader;
using ePubIntegrator.Helpers;

namespace ePubIntegrator.ui
{
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public partial class ReaderForm : Form
    {
        private readonly Epub _ePub;
        private Boolean _showIndex;
        private Boolean _showBookMarks;
        private Boolean _showFavorites;
        private ContentData _contentData;
        private readonly string _username;
        private readonly List<NavPoint> _navPoints;
        private readonly List<int> _bookMarksIndexList;
        private readonly List<string> _chaptersNameList;
        private readonly List<int> _favoristsIndexList;
        private int _indexPosition;
        private readonly XmlDocument _dataFile;

        public ReaderForm(Epub eBook, string username, XmlDocument dataFile)
        {
            InitializeComponent();
            _chaptersNameList = new List<string>();
            _bookMarksIndexList = new List<int>();
            _favoristsIndexList = new List<int>();
            _username = username;
            _ePub = eBook;
            Text = _ePub.Title[0];
            lblChapter.Text = _ePub.Title[0];
            wbEbook.DocumentText = eBook.GetContentAsHtml();

            _navPoints = _ePub.TOC;
            IndexEbook();
            _indexPosition = 0;
            _dataFile = dataFile;
            AccessHelper.RegisterLastBookSeen(_dataFile, Text);
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void HidePanel()
        {

            splitContainer1.Panel1.Hide();
            splitContainer1.Panel1Collapsed = true;
        }

        private void ShowPanel()
        {
            splitContainer1.Panel1.Show();
            splitContainer1.Panel1Collapsed = false;
        }

        private void ReaderForm_Load(object sender, EventArgs e)
        {
            HidePanel();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //_indexPosition = lstIndex.SelectedIndex;
            var chaptername = lstIndex.SelectedItem.ToString();
            _indexPosition = _chaptersNameList.IndexOf(chaptername);
            //pelo nome sacar o index


            if (_navPoints.Count > 0)
            {
                wbEbook.DocumentText = _navPoints[_indexPosition].ContentData.Content;
                lblChapter.Text = _navPoints[_indexPosition].Title;

            }
            else
            {
                _contentData = _ePub.Content[_indexPosition] as ContentData;
                if (_contentData == null)
                {
                    return;
                }
                lblChapter.Text = _contentData.FileName;
                wbEbook.DocumentText = _contentData.Content;
            }
            
        }

        private void IndexEbook()
        {
            lstIndex.Items.Clear();

            if (_navPoints.Count > 0)
            {
                foreach (var item in _navPoints)
                {
                    lstIndex.Items.Add(item.Title);
                }
            }

            else
            {
                for (var i = 0; i < _ePub.Content.Count; i++)
                {
                    //_contentData = _ePub.Content[i] as ContentData;
                    _chaptersNameList.Add("chapter "+i);
                    lstIndex.Items.Add("chapter " + i);
                    /*
                    var zip = ZipFile.Read(_filePath);
                    var entry = zip.Entries.FirstOrDefault(x => x.FileName.Contains(_contentData.FileName));
                    var readerChapter = new XmlTextReader(entry.OpenReader());
                    while (readerChapter.Read())
                    {
                        if (readerChapter.NodeType == XmlNodeType.Element)
                        {
                            if (readerChapter.Name == "h1")
                            {
                                _chaptersNameList.Add(readerChapter.ReadElementString());
                                lstIndex.Items.Add(readerChapter.ReadElementString());
                            }
                        }
                    }
                    */
                }

            }

        }

        private void btnNextChapter_Click(object sender, EventArgs e)
        {
            //ChangeChapter(lstIndex.SelectedIndex + 1);
            ChangeChapter(_indexPosition + 1);
        }

        private void btnPreviousChapter_Click(object sender, EventArgs e)
        {
            //ChangeChapter(lstIndex.SelectedIndex - 1);
            ChangeChapter(_indexPosition - 1);
        }


        private void ChangeChapter(int index)
        {
            IndexEbook();
            if (index <= 0)
            {
                index = 0;
            }
            if (_navPoints.Count > 0 && index < lstIndex.Items.Count)
            {      
                wbEbook.DocumentText = _navPoints[index].ContentData.Content;
                lblChapter.Text = _navPoints[index].Title;
                lstIndex.SetSelected(index, true);
            }
            else if (_ePub.Content.Count > 0 && index < lstIndex.Items.Count)
            {
                _contentData = _ePub.Content[index] as ContentData;
                lstIndex.SetSelected(index, true);
            }
            if (_contentData == null)
            {
                return;
            }
            lblChapter.Text = _contentData.FileName;
            wbEbook.DocumentText = _contentData.Content;
            
        }

        private void GetBookMarksFromXml()
        {
            var dataXmlFile = XmlHelper.GetXmlFile(XmlHelper.UserDefinedGalleryDataXmlFilePath);
            var bookmarksTag = dataXmlFile.SelectSingleNode("/data/gallery/bookmarks");
            var bookmarksList = bookmarksTag.SelectNodes("bookmark");

            foreach (XmlNode favourite in bookmarksList)
            {
                _bookMarksIndexList.Add(int.Parse(favourite.SelectSingleNode("chapter/index").InnerText));      
            }
        }

        private void btnBookMark_Click(object sender, EventArgs e)
        {
            //var index = lstIndex.SelectedIndex;
            _bookMarksIndexList.Add(_indexPosition);
            //_indexPosition = index;
            ListBookMark();




            // XML
            var dataXmlFile = XmlHelper.GetXmlFile(XmlHelper.UserDefinedGalleryDataXmlFilePath);
            var bookmarksTag = dataXmlFile.SelectSingleNode("/data/gallery/bookmarks");
            var bookmarksList = bookmarksTag.SelectNodes("bookmark");
            var bookmarkExists = false;


            foreach (XmlNode bookmark in bookmarksList)
            {
                if (_username == bookmark.SelectSingleNode("username").InnerText && _chaptersNameList[_indexPosition] ==
                    bookmark.SelectSingleNode("chapter/title").InnerText && _ePub.Title[0] ==
                    bookmark.SelectSingleNode("chapter/ebook-title").InnerText &&
                    _indexPosition.ToString() == bookmark.SelectSingleNode("chapter/index").InnerText)
                {
                    MessageHelper.ShowNotificationMessage("", "Bookmark removed");
                    bookmarkExists = true;
                    bookmarksTag.RemoveChild(bookmark);
                }
            }

            if (bookmarkExists) return;

            //add
            var bookmarkTag = bookmarksTag.AppendChild(dataXmlFile.CreateElement("bookmark"));
            bookmarkTag.AppendChild(dataXmlFile.CreateElement("username")).InnerText = _username;
            bookmarkTag.AppendChild(dataXmlFile.CreateElement("ebook-title")).InnerText = _chaptersNameList[_indexPosition];
            var bookmarkChapter = bookmarkTag.AppendChild(dataXmlFile.CreateElement("chapter"));
            bookmarkChapter.AppendChild(dataXmlFile.CreateElement("ebook-title")).InnerText = _ePub.Title[0];
            bookmarkChapter.AppendChild(dataXmlFile.CreateElement("index")).InnerText = _indexPosition.ToString();
            bookmarkChapter.AppendChild(dataXmlFile.CreateElement("title")).InnerText =
                _chaptersNameList[_indexPosition];

            dataXmlFile.Save(XmlHelper.UserDefinedGalleryDataXmlFilePath);
        }

        private void btnIndex_Click(object sender, EventArgs e)
        {
            if (_showIndex)
            {
                HidePanel();
                _showIndex = false;
            }
            else
            {
                ShowPanel();
                IndexEbook();
                _showIndex = true;
            }
            
        }

        private void btnListBookMarks_Click(object sender, EventArgs e)
        {
            if (_showBookMarks)
            {
                HidePanel();
                _showBookMarks = false;
            }
            else
            {
                ShowPanel();
                GetBookMarksFromXml();
                ListBookMark();
                _showBookMarks = true;
            }
           
        }
        private void btnListFavorites_Click(object sender, EventArgs e)
        {
            if (_showFavorites)
            {
                HidePanel();
                _showFavorites = false;
            }
            else
            {
                ShowPanel();
                GetFavouritesFromXml();
                ListFavourites();
                _showFavorites = true;
            }
        }
        private void ListBookMark()
        {
            lstIndex.Items.Clear();
            foreach (int indexBookMarks in _bookMarksIndexList)
            {
                lstIndex.Items.Add(_chaptersNameList[indexBookMarks]);
            }
        }
       private void ListFavourites()
        {
            lstIndex.Items.Clear();
            foreach (int indexFavourit in _favoristsIndexList)
            {
                lstIndex.Items.Add(_chaptersNameList[indexFavourit]);
            }
        }

        private void GetFavouritesFromXml()
        {
            var dataXmlFile = XmlHelper.GetXmlFile(XmlHelper.UserDefinedGalleryDataXmlFilePath);
            var favouritesTag = dataXmlFile.SelectSingleNode("/data/gallery/favourites");
            var favouritesList = favouritesTag.SelectNodes("favourite");

            foreach (XmlNode favourite in favouritesList)
            {
                _favoristsIndexList.Add(int.Parse(favourite.SelectSingleNode("chapter/index").InnerText));      
            }
        }
        private void btnFavorite_Click(object sender, EventArgs e)
        {
            //var index = lstIndex.SelectedIndex;
           // _indexPosition = index;

            var dataXmlFile = XmlHelper.GetXmlFile(XmlHelper.UserDefinedGalleryDataXmlFilePath);
            var favouritesTag = dataXmlFile.SelectSingleNode("/data/gallery/favourites");
            var favouritesList = favouritesTag.SelectNodes("favourite");
            var favouriteExists = false;


            foreach (XmlNode favourite in favouritesList)
            {
                if (_username == favourite.SelectSingleNode("username").InnerText && _chaptersNameList[_indexPosition] ==
                    favourite.SelectSingleNode("chapter/title").InnerText && _ePub.Title[0] ==
                    favourite.SelectSingleNode("chapter/ebook-title").InnerText &&
                    _indexPosition.ToString() == favourite.SelectSingleNode("chapter/index").InnerText)
                {
                    MessageHelper.ShowNotificationMessage("", "Favourite removed");
                    favouriteExists = true;
                    favouritesTag.RemoveChild(favourite);
                    _favoristsIndexList.RemoveAt(_indexPosition);
                }
            }

            if (!favouriteExists)
            {

                //add
                var favouriteTag = favouritesTag.AppendChild(dataXmlFile.CreateElement("favourite"));
                favouriteTag.AppendChild(dataXmlFile.CreateElement("username")).InnerText = _username;
                favouriteTag.AppendChild(dataXmlFile.CreateElement("ebook-title")).InnerText = _chaptersNameList[_indexPosition];
                var favouriteChapter = favouriteTag.AppendChild(dataXmlFile.CreateElement("chapter"));
                favouriteChapter.AppendChild(dataXmlFile.CreateElement("ebook-title")).InnerText = _ePub.Title[0];
                favouriteChapter.AppendChild(dataXmlFile.CreateElement("index")).InnerText = _indexPosition.ToString();
                
                favouriteChapter.AppendChild(dataXmlFile.CreateElement("title")).InnerText =
                    _chaptersNameList[_indexPosition];
                _favoristsIndexList.Add(_indexPosition);

            }
            dataXmlFile.Save(XmlHelper.UserDefinedGalleryDataXmlFilePath);

            
            
            ListFavourites();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (_indexPosition != -1)
            {
                AccessHelper.RegisterLastChapterSeen(_dataFile, _indexPosition, _chaptersNameList[_indexPosition]);
            }
            else
            {
                AccessHelper.RegisterLastChapterSeen(_dataFile, 0, "Unavaiable");
            }

        }
    }
}