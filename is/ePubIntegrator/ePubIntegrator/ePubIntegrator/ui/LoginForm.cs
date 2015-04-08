using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using ePubIntegrator.Helpers;
using ePubIntegrator.Properties;
using ePubIntegrator.ServiceePubCloudReference;

namespace ePubIntegrator.ui
{
    public partial class LoginForm : Form
    {
        private readonly string _galleryPath = String.Empty;
        private readonly string _endpoint = String.Empty;
        private UserContract _user;

        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        public LoginForm()
        {
            InitializeComponent();
            XmlHelper.LoadUserXmlFilePath();
            var configFile = XmlHelper.LoadConfigurationFile();
            if (configFile == null) return;

            var root = configFile.DocumentElement;
            _galleryPath = String.IsNullOrEmpty(root.SelectSingleNode("gallery-path").InnerText) ?
                root.SelectSingleNode("gallery-default-path").InnerText :
                root.SelectSingleNode("gallery-path").InnerText;
            _endpoint = root.SelectSingleNode("service-url").InnerText == Resources.DefaultEndpoint ?
                _endpoint = Resources.DefaultEndpoint :
                _endpoint = root.SelectSingleNode("service-url").InnerText;

            ValidationHelper.ChangeServiceUri(new Uri(_endpoint));
        }

        public string GalleryPath
        {
            get { return _galleryPath; }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.CheckForEmptyFields(txtUsername, txtPassword))
            {
                MessageHelper.ShowWarningMessage("Warning", Resources.ErrorAuthFieldsRequired);
                ValidationHelper.ClearTextBox(txtUsername, txtPassword);
                return;
            }

            _user = ValidationHelper.Service.Login(txtUsername.Text, txtPassword.Text);
            if (_user == null)
            {
                MessageHelper.ShowErrorMessage("Authentication Error", Resources.ErrorAuthText);
                ValidationHelper.ClearTextBox(txtUsername, txtPassword);
                return;
            }
            Hide();
            AccessHelper.User = _user;
            new MainForm(_user.Username, _galleryPath, _endpoint, _user.LastLogin).ShowDialog();
            Dispose();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            new RegisterForm(this).Show();
        }

        private void lblRecoverPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new PasswordRecoveryForm().Show();
        }
    }
}