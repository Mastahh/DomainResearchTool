namespace DomainResearchTool.Modules
{
    public class NotificationMessageService
    {
        public static void ShowWarningMessage(string messageText) => ShowMessage(messageText, MessageBoxIcon.Warning);

        public static void ShowErrorMessage(string messageText) => ShowMessage(messageText, MessageBoxIcon.Error);

        public static void ShowInformationMessage(string messageText) => ShowMessage(messageText, MessageBoxIcon.Information);

        private static void ShowMessage(string messageText, MessageBoxIcon messageIcon)
        {
            MessageBox.Show(messageText, nameof(messageIcon), MessageBoxButtons.OK, messageIcon);
        }
    }
}
