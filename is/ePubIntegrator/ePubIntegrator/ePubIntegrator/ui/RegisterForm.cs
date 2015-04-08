using System;
using System.Windows.Forms;
using ePubIntegrator.Helpers;
using ePubIntegrator.Properties;
using ePubIntegrator.ServiceePubCloudReference;

namespace ePubIntegrator.ui
{
    public partial class RegisterForm : Form
    {
        private readonly LoginForm _parentForm;

        public RegisterForm(LoginForm parentForm)
        {
            InitializeComponent();
            cbGender.SelectedIndex = 0;
            ActiveControl = txtFirstName;
            _parentForm = parentForm;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.CheckForEmptyFields(txtFirstName, txtLastName,
                txtEmail, txtUsername, txtPassword))
            {
                MessageHelper.ShowWarningMessage("Warning", Resources.ErrorRegisterFields);
            }

            var user = new UserContract
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                Gender = cbGender.SelectedText,
                Username = txtUsername.Text,
                Password = txtPassword.Text
                //LastLogin property set server-side
            };

            if (!ValidationHelper.Service.RegisterUser(user))
            {
                MessageHelper.ShowErrorMessage("Registration Failed", 
                    Resources.ErrorRegistration);
                ValidationHelper.ClearTextBox(txtUsername, txtPassword);
                return;
            }

            MessageHelper.ShowNotificationMessage("Registration", 
                "Registration successful!");
            _parentForm.Hide();
            Hide();
            new MainForm(txtUsername.Text, _parentForm.GalleryPath,
                ValidationHelper.Service.Endpoint.Address.ToString(), 
                ValidationHelper.Service.GetServiceCurrentTime()).ShowDialog();
            _parentForm.Dispose();
            Dispose();
        }
    }
}