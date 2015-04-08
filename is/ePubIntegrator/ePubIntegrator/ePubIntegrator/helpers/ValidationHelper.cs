using System;
using System.ServiceModel;
using System.Windows.Forms;
using ePubIntegrator.ServiceePubCloudReference;

namespace ePubIntegrator.Helpers
{
    static class ValidationHelper
    {
        public static readonly ServiceePubCloudClient Service =
            Service ?? new ServiceePubCloudClient();

        public static void ClearTextBox(params TextBox[] textBoxes)
        {
            foreach (var textBox in textBoxes)
            {
                textBox.Text = String.Empty;
            }
        }

        public static bool CheckForEmptyFields(params TextBox[] textBoxes)
        {
            foreach (var textBox in textBoxes)
            {
                if (String.IsNullOrEmpty(textBox.Text))
                {
                    return false;
                }
            }
            return true;
        }

        public static void ChangeServiceUri(Uri uri)
        {
            Service.Endpoint.Address = new EndpointAddress(uri);
        }
    }
}