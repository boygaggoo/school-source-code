using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using ePubIntegrator.helpers;
using ePubIntegrator.Helpers;

namespace ePubIntegrator.ui
{
    public partial class MainForm : Form
    {
        private readonly string _galleryFolderPath;
        private readonly XmlDocument _galleryFile;
        private readonly string _endPoint;
        private readonly string _username;
        private readonly double _lastLogin;

        public MainForm(string username, string galleryPath, string endpoint, double lastLogin)
        {
            InitializeComponent();
            _endPoint = endpoint;
            _galleryFolderPath = galleryPath;
            _galleryFile = XmlHelper.LoadGalleryDataFile();
            lblName.Text = username;
            _username = username;
            _lastLogin = lastLogin;
            EpubFileHelper.OpenEpubsFromPath(flowLayoutPanelEbook, _galleryFolderPath, _galleryFile, _username);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            HidePanel();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            HidePanel();
        }

        private void btnAuthors_Click(object sender, EventArgs e)
        {
            ShowPanel();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            ShowPanel();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            HidePanel();
        }

        private void HidePanel()
        {
            splitContainer2.Panel1.Hide();
            splitContainer2.Panel1Collapsed = true;
        }

        private void ShowPanel()
        {
            splitContainer1.Panel1.Show();
            splitContainer2.Panel1Collapsed = false;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            AccessHelper.PunchTimeCard(_galleryFile, _username, _lastLogin);
            Hide();
            new LoginForm().ShowDialog();
            Dispose();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanelEbook_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanelEbook_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                return;
            }
            e.Effect = DragDropEffects.None;
        }

        private void flowLayoutPanelEbook_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;
            EpubFileHelper.AddEpubFiles(flowLayoutPanelEbook, _galleryFolderPath, 
                (string[]) (e.Data.GetData(DataFormats.FileDrop, false)), _galleryFile, _username);
        }


        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingsForm(XmlHelper.UserDefinedGalleryDataXmlFilePath, XmlHelper.UserDefinedConfigXmlFilePath, Path.GetFullPath(_galleryFolderPath), _endPoint).Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().Show();
        }

        private void viewStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Statistics(_galleryFile).Show();
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var local = "local";
            var global = "global";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            var folderPath = fbd.SelectedPath;

            ExcelHelper.writeTopChaptersEbookBookMarksExcelFile(folderPath, local);
            ExcelHelper.writeTopChaptersEbookFavoriteExcelFile(folderPath, local);
            ExcelHelper.writeTopChaptersEbookViewsExcelFile(folderPath, local);
            ExcelHelper.writeTopEbookBookMarksExcelFile(folderPath, local);
            ExcelHelper.writeTopEbookFavoriteExcelFile(folderPath, local);
            ExcelHelper.writeTopEbookViewsExcelFile(folderPath, local);

            ExcelHelper.writeTopChaptersEbookBookMarksExcelFile(folderPath, global);
            ExcelHelper.writeTopChaptersEbookFavoriteExcelFile(folderPath, global);
            ExcelHelper.writeTopChaptersEbookViewsExcelFile(folderPath, global);
            ExcelHelper.writeTopEbookBookMarksExcelFile(folderPath, global);
            ExcelHelper.writeTopEbookFavoriteExcelFile(folderPath, global);
            ExcelHelper.writeTopEbookViewsExcelFile(folderPath, global);
        }
    }
}
