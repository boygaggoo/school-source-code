using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using ePubIntegrator.Helpers;
using ePubIntegrator.Properties;

namespace ePubIntegrator.ui
{
    public partial class SettingsForm : Form
    {
        public SettingsForm(string datafilePath, string configFilePath, string galleryFolderPath, string endPoint)
        {
            InitializeComponent();
            txtDataPath.Text = datafilePath;
            txtSettingsPath.Text = configFilePath;
            txtGalleryFoldePath.Text = galleryFolderPath;
            txtEndPoint.Text = endPoint;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnDataPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "c:\\Users";
            open.Filter = "epub files (*.xml)|*.xml";
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtDataPath.Text = open.FileName;
            }
            XmlHelper.UserDefinedGalleryDataXmlFilePath = open.FileName;


            var configFile = XmlHelper.GetXmlFile(Resources.AppConfigPath);

            var galleryXmlTag = configFile.SelectSingleNode("/paths/xml-path-gallery");
            galleryXmlTag.InnerText = txtDataPath.Text;

            configFile.Save(Resources.AppConfigPath);


            MessageHelper.ShowNotificationMessage("","Changed Application data file path.");
            
        }

        private void btnSettingsPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "c:\\Users";
            open.Filter = "epub files (*.xml)|*.xml";
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtSettingsPath.Text = open.FileName;
            }
            XmlHelper.UserDefinedConfigXmlFilePath = open.FileName;

            var configFile = XmlHelper.GetXmlFile(Resources.AppConfigPath);

            var configXmlTag = configFile.SelectSingleNode("/paths/xml-path-config");
            configXmlTag.InnerText = txtSettingsPath.Text;

            configFile.Save(Resources.AppConfigPath);


            MessageHelper.ShowNotificationMessage("", "Changed Application configuration file path.");
        }

        private void btnGalleryPath_Click(object sender, EventArgs e)
        {

            
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            txtGalleryFoldePath.Text = fbd.SelectedPath;

            var configFile = XmlHelper.GetXmlFile(XmlHelper.UserDefinedConfigXmlFilePath);

            var galleryTag = configFile.SelectSingleNode("/settings/gallery-path");
            galleryTag.InnerText = txtGalleryFoldePath.Text;

            configFile.Save(XmlHelper.UserDefinedConfigXmlFilePath);

            MessageHelper.ShowNotificationMessage("", "Changed Ebooks folder.");
        }

        private void btnEndPoint_Click(object sender, EventArgs e)
        {

            var configFile = XmlHelper.GetXmlFile(XmlHelper.UserDefinedConfigXmlFilePath);

            var endpointTag = configFile.SelectSingleNode("/settings/service-url");
            endpointTag.InnerText = txtEndPoint.Text;

            configFile.Save(XmlHelper.UserDefinedConfigXmlFilePath);
            MessageHelper.ShowNotificationMessage("", "Changed Endpoint WebService.");
        }
    }
}
