using System.Text.Json;
using DomainResearchTool.Models;

namespace DomainResearchTool.Modules
{
    public static class ConfigurationService
    {
        private static AppSettings _appSettings = null;
        public static async Task SaveFilterSettings(AppSettings updatedAppSettings, bool triggerEvent = true)
        {
            _appSettings = updatedAppSettings;
            Properties.Settings.Default.AppSettings = JsonSerializer.Serialize(_appSettings);
            await Task.Run(() => { Properties.Settings.Default.Save(); });
            if (triggerEvent)
            {
                AppEventService.TriggerAppSettingsChanged();
            }
        }
        public static async Task<AppSettings> GetAppSettings()
        {
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.AppSettings))
            {
                _appSettings = new AppSettings();
                await SaveFilterSettings(_appSettings);
            }
            _appSettings = JsonSerializer.Deserialize<AppSettings>(Properties.Settings.Default.AppSettings) ?? new AppSettings();
            return _appSettings;
        }
    }
}
