using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ePubIntegrator.Helpers;

namespace ePubIntegrator.ui
{
    public partial class PasswordRecoveryForm : Form
    {
        public PasswordRecoveryForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxEmail.Text))
            {
                MessageHelper.ShowErrorMessage("Error", "Please insert your email for password recovery.");
                return;
            }
            MessageHelper.ShowNotificationMessage("Email sent", "Feature not yet implemented.");
            Dispose();
        }
    }
}
