namespace DomainResearchTool.Modules
{
    public class NotificationMessageService
    {
        public static void ShowWarningMessage(string messageText) => ShowMessage(messageText, "Warning", MessageBoxIcon.Warning);

        public static void ShowErrorMessage(string messageText) => ShowMessage(messageText, "Error", MessageBoxIcon.Error);

        public static void ShowInformationMessage(string messageText) => ShowMessage(messageText, "Information", MessageBoxIcon.Information);

        private static void ShowMessage(string messageText, string title, MessageBoxIcon messageIcon)
        {
            MessageBox.Show(messageText, title, MessageBoxButtons.OK, messageIcon);
        }
    }
}
