using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Xml;
using ePubIntegrator.ServiceePubCloudReference;

namespace ePubIntegrator.Helpers
{
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public static class AccessHelper
    {
        public static UserContract User;


        public static void PunchTimeCard(XmlDocument dataFile, string username, double timeMillis)
        {
            var registry = dataFile.DocumentElement.SelectSingleNode("registry");
            registry.SelectSingleNode("last-user").InnerText = username;
            registry.SelectSingleNode("last-login").InnerText = timeMillis.ToString(CultureInfo.InvariantCulture);
            dataFile.Save(XmlHelper.UserDefinedGalleryDataXmlFilePath);
        }

        public static void RegisterLastBookSeen(XmlDocument dataFile, string title)
        {
            var registry = dataFile.DocumentElement.SelectSingleNode("registry");
            var lastEbook = registry.SelectSingleNode("last-ebook");
            lastEbook.SelectSingleNode("title").InnerText = title;
            dataFile.Save(XmlHelper.UserDefinedGalleryDataXmlFilePath);
        }

        public static void RegisterLastChapterSeen(XmlDocument dataFile, int chapterIndex, string chapterTitle)
        {
            var registry = dataFile.DocumentElement.SelectSingleNode("registry");
            var lastEbook = registry.SelectSingleNode("last-ebook");
            var chapter = lastEbook.SelectSingleNode("chapter");
            chapter.SelectSingleNode("index").InnerText = chapterIndex.ToString();
            chapter.SelectSingleNode("title").InnerText = chapterTitle;
            dataFile.Save(XmlHelper.UserDefinedGalleryDataXmlFilePath);
        }
    }
}
