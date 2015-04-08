using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using eBdb.EpubReader;
using ePubIntegrator.Properties;
using Ionic.Zip;

namespace ePubIntegrator.Helpers
{
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public static class EpubFileHelper
    {
        public static void AddEpubFiles(Control flowLayoutPanelEbook, string folderPath, string[] filePaths,
            XmlDocument galleryData, string username)
        {

        foreach (var fileLoc in filePaths)
            {
                // Code to read the contents of the text file
                if (!File.Exists(fileLoc) || File.Exists(folderPath + Path.GetFileName(fileLoc)) 
                    || !String.Equals(Path.GetExtension(fileLoc), Resources.epubFileExtenstion))
                {
                    continue;
                }
                OpenEpub(flowLayoutPanelEbook, fileLoc, galleryData, username);
                File.Copy(fileLoc, folderPath + Path.GetFileName(fileLoc));      
            }
        }

        public static void OpenEpubsFromPath(Control flowLayoutPanelEbook, string initialFolderPath, XmlDocument galleryData, string username)
        {

            var fileEntries = Directory.GetFiles(initialFolderPath);
            foreach (var fileName in fileEntries)
            {
                OpenEpub(flowLayoutPanelEbook, fileName, galleryData, username);
            }
        }

        private static void OpenEpub(Control flowLayoutPanelEbook, string fileLoc, XmlDocument galleryData, string username)
        {
            var epub = new Epub(fileLoc);
            var ebookDisplay = new UserControlEbook(epub, fileLoc, username, galleryData);
            ebookDisplay.Title(epub.Title[0]);

            var ebooksTag = galleryData.SelectSingleNode("/data/gallery/ebooks");
            var ebookList = ebooksTag.SelectNodes("ebook");
            var ebookExists = false;

            foreach (XmlNode ebook in ebookList)
            {
                var filename = ebook.SelectSingleNode("filename").InnerText;
                if (filename == Path.GetFileName(fileLoc))
                {
                    ebookExists = true;
                }
            }

            if (!ebookExists)
            {
                var ebookTag = ebooksTag.AppendChild(galleryData.CreateElement("ebook"));
                ebookTag.AppendChild(galleryData.CreateElement("author")).InnerText = epub.Creator.Count > 0 ?
                epub.Creator[0] :
                "";

                ebookTag.AppendChild(galleryData.CreateElement("filename")).InnerText = Path.GetFileName(fileLoc);
                ebookTag.AppendChild(galleryData.CreateElement("title")).InnerText = epub.Title[0];
                if (epub.Subject.Count > 0)
                {
                    ebookTag.AppendChild(galleryData.CreateElement("genre")).InnerText = epub.Subject[0];
                }
                ebookTag.AppendChild(galleryData.CreateElement("genre")).InnerText = "";

                ebookTag.AppendChild(galleryData.CreateElement("publisher")).InnerText = epub.Publisher.Count > 0 ?
                    epub.Publisher[0] :
                    "";

                ebookTag.AppendChild(galleryData.CreateElement("language")).InnerText = epub.Language.Count > 0 ?
                    epub.Language[0] :
                    "";

                var chapterList = ebookTag.AppendChild(galleryData.CreateElement("chapters"));
                var navPoints = epub.TOC;
                if (navPoints.Count > 0)
                {
                    foreach (var item in navPoints)
                    {
                        var chapter = chapterList.AppendChild(galleryData.CreateElement("chapter"));
                        chapter.AppendChild(galleryData.CreateElement("index")).InnerText = item.ID;
                        chapter.AppendChild(galleryData.CreateElement("title")).InnerText = item.Title;
                    }
                }
                else
                {
                    for (var i = 0; i < epub.Content.Count; i++)
                    {
                        var chapter = chapterList.AppendChild(galleryData.CreateElement("chapter"));
                        chapter.AppendChild(galleryData.CreateElement("index")).InnerText = i.ToString();
                        chapter.AppendChild(galleryData.CreateElement("title")).InnerText = "Chapter " + i;
                    }
                }
            }

            if (epub.Creator.Count > 0)
            {
                ebookDisplay.Author(epub.Creator[0]);
            }
            else
            {
                ebookDisplay.AuthorVisible(false);
            }

            flowLayoutPanelEbook.Controls.Add(ebookDisplay);

            var atributeFullPath = String.Empty;
            var entryContainer = ZipFile.Read(fileLoc).Entries.FirstOrDefault(i => i.FileName == @"META-INF/container.xml");
            if (entryContainer == null)
            {
                return;
            }

             //  Loop over the XHTML 
            var reader = new XmlTextReader(entryContainer.OpenReader());
            while (reader.Read())
            {
                if (reader.NodeType != XmlNodeType.Element) continue;

                if (reader.Name == "rootfile")
                {
                    atributeFullPath = reader.GetAttribute("full-path");
                }
            }

            var entryImagePath = ZipFile.Read(fileLoc).Entries.FirstOrDefault(i => i.FileName == atributeFullPath);
             if (entryImagePath == null)
             {
                 return;
             }
            var readerFullPath = new XmlTextReader(entryImagePath.OpenReader());     
            var imagePath = String.Empty;
            while (readerFullPath.Read())
            {
                if (readerFullPath.NodeType != XmlNodeType.Element) continue;
                if (readerFullPath.Name != "item") continue;

                if (readerFullPath.GetAttribute("properties") == "cover-image" || readerFullPath.GetAttribute("id") == "coverpage")
                {
                    imagePath = readerFullPath.GetAttribute("href");
                }
            }
            
            var entryImage = ZipFile.Read(fileLoc).Entries.FirstOrDefault(i =>  i.FileName.Contains(imagePath));
            if (entryImage == null)
            {
                // TODO - Put deafult image
                return;
            }
            ebookDisplay.Picture(new Bitmap(entryImage.OpenReader()));
            reader.Close();

            galleryData.Save(XmlHelper.UserDefinedGalleryDataXmlFilePath);
        }
    }
}