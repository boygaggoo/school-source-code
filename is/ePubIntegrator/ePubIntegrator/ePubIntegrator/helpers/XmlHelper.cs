using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using ePubIntegrator.Properties;

namespace ePubIntegrator.Helpers
{
    public static class XmlHelper
    {
        public static string UserDefinedConfigXmlFilePath { get; set; }
        public static string UserDefinedGalleryDataXmlFilePath { get; set; }

        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        public static void LoadUserXmlFilePath()
        {
            var document = new XmlDocument();
            document.Load(Resources.AppConfigPath);

            var root = document.DocumentElement;
            if (String.IsNullOrEmpty(UserDefinedConfigXmlFilePath = root.SelectSingleNode("xml-path-config").InnerText))
            {
                UserDefinedConfigXmlFilePath = Resources.DefaultConfigXmlFilePath;
            }
            if (String.IsNullOrEmpty(UserDefinedGalleryDataXmlFilePath = root.SelectSingleNode("xml-path-gallery").InnerText))
            {
                UserDefinedGalleryDataXmlFilePath = Resources.DefaultGalleryDataXmlFilePath;
            }
        }

        private static bool LoadAndValidateXmlFile(string xmlFilePath, string xsdFilePath, string xmlFileType)
        {
            var document = new XmlDocument();
            try
            {
                document.Load(xmlFilePath);
            }
            catch (Exception)
            {
                MessageHelper.ShowErrorMessage("Error", "Could not find " + xmlFileType + " file.");
                return false;
            }
            document.Schemas.Add(null, xsdFilePath);
            document.Validate(ValidationEvent);
            return true;
        }


        private static void ValidationEvent(object sender, ValidationEventArgs args)
        {
            switch (args.Severity)
            {
                case XmlSeverityType.Error:
                    MessageHelper.ShowErrorMessage("Error",
                        "XML validation error: " + string.Format("[Error] {0}", args.Message));
                    break;

                case XmlSeverityType.Warning:
                    MessageHelper.ShowWarningMessage("Warning",
                        "XML validation warning: " + string.Format("[Warning] {0}", args.Message));
                    break;
            }
        }

        public static XmlDocument GetXmlFile(string xmlFilePath)
        {
            var document = new XmlDocument();
            document.Load(xmlFilePath);
            return document;
        }

        public static XmlDocument LoadConfigurationFile()
        {
            if (!LoadAndValidateXmlFile(UserDefinedConfigXmlFilePath, Resources.DefaultConfigXsdFilePath, Resources.FileTypeConfig))
            {
                if (MessageHelper.ShowYesNoPrompt("Warning",
                    Resources.UserDefinedCfgNotFound) == DialogResult.No)
                {
                    return null;
                }

                if (!LoadAndValidateXmlFile(Resources.DefaultConfigXmlFilePath, Resources.DefaultConfigXsdFilePath, Resources.DefaultFileTypeConfig))
                {
                    MessageHelper.ShowNotificationMessage("Information", Resources.DefaultCfgNotFound);
                    GenerateDefaultConfigurationFile();
                    UserDefinedConfigXmlFilePath = Resources.DefaultConfigXmlFilePath;
                    return GetXmlFile(Resources.DefaultConfigXmlFilePath);
                }
                return GetXmlFile(Resources.DefaultConfigXmlFilePath);
            }
            return GetXmlFile(UserDefinedConfigXmlFilePath);
        }

        public static XmlDocument LoadGalleryDataFile()
        {
            if (!LoadAndValidateXmlFile(UserDefinedGalleryDataXmlFilePath, Resources.DefaultGalleryDataXsdFilePath, Resources.FileTypeData))
            {
                if (MessageHelper.ShowYesNoPrompt("Warning",
                    Resources.UserDefinedGalleryDataNotFound) == DialogResult.No)
                {
                    return null;
                }

                if (!LoadAndValidateXmlFile(Resources.DefaultGalleryDataXmlFilePath, Resources.DefaultGalleryDataXsdFilePath, Resources.FileTypeData))
                {
                    MessageHelper.ShowNotificationMessage("Information", Resources.DefaultGalleryDataNotFound);
                    GenerateDefaultGalleryFile();
                    UserDefinedGalleryDataXmlFilePath = Resources.DefaultGalleryDataXmlFilePath;
                    return GetXmlFile(Resources.DefaultGalleryDataXmlFilePath);
                }
                return GetXmlFile(Resources.DefaultGalleryDataXmlFilePath);
            }
            return GetXmlFile(UserDefinedGalleryDataXmlFilePath);
        }

        private static void GenerateDefaultConfigurationFile()
        {
            var epubConfigs = new XmlDocument();
            epubConfigs.AppendChild(epubConfigs.CreateXmlDeclaration("1.0", "utf-8", ""));

            var settings = (XmlElement)epubConfigs.AppendChild(epubConfigs.CreateElement("settings"));
            settings.AppendChild(epubConfigs.CreateElement("gallery-default-path"))
                .InnerText = Resources.DefaultGalleryPath;
            settings.AppendChild(epubConfigs.CreateElement("gallery-path"))
                .InnerText = "";
            settings.AppendChild(epubConfigs.CreateElement("service-url"))
                .InnerText = Resources.DefaultEndpoint;

            epubConfigs.Save(Resources.DefaultConfigXmlFilePath);
        }

        private static void GenerateDefaultGalleryFile()
        {
            var epubGalleryData = new XmlDocument();
            epubGalleryData.AppendChild(epubGalleryData.CreateXmlDeclaration("1.0", "utf-8", ""));

            var data = (XmlElement)epubGalleryData.AppendChild(epubGalleryData.CreateElement("data"));

            var registry = (XmlElement)data.AppendChild(epubGalleryData.CreateElement("registry"));
            registry.AppendChild(epubGalleryData.CreateElement("last-user")).InnerText = "";
            registry.AppendChild(epubGalleryData.CreateElement("last-login")).InnerText = "0";

            var lastEbook = (XmlElement)registry.AppendChild(epubGalleryData.CreateElement("last-ebook"));
            lastEbook.AppendChild(epubGalleryData.CreateElement("title")).InnerText = "";

            var chapter = (XmlElement)lastEbook.AppendChild(epubGalleryData.CreateElement("chapter"));
            chapter.AppendChild(epubGalleryData.CreateElement("index")).InnerText = "0";
            chapter.AppendChild(epubGalleryData.CreateElement("title")).InnerText = "";

            var gallery = (XmlElement)data.AppendChild(epubGalleryData.CreateElement("gallery"));
            gallery.AppendChild(epubGalleryData.CreateElement("ebooks")).InnerText = "";
            gallery.AppendChild(epubGalleryData.CreateElement("bookmarks")).InnerText = "";
            gallery.AppendChild(epubGalleryData.CreateElement("favourites")).InnerText = "";

            epubGalleryData.Save(Resources.DefaultGalleryDataXmlFilePath);
        }
    }
}