using System.Windows.Forms;

namespace ePubIntegrator.Helpers
{
    public static class MessageHelper
    {
        public static void ShowErrorMessage(string title, string message)
        {
            MessageBox.Show(@message, @title,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowWarningMessage(string title, string message)
        {
            MessageBox.Show(@message, @title,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult ShowYesNoPrompt(string title, string message)
        {
            return MessageBox.Show(@message, @title,
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public static void ShowNotificationMessage(string title, string message)
        {
            MessageBox.Show(@message, @title,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}