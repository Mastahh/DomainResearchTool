using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using Radzen;
using DomainResearchTool.Enums;
using DomainResearchTool.Models;
using DomainResearchTool.Modules;

namespace DomainResearchTool
{
    public partial class MainForm : Form
    {
        private AppSettings _appSettings;
        public MainForm()
        {
            InitializeComponent();
            cbGridPageSize.Items.Add(10);
            cbGridPageSize.Items.Add(20);
            cbGridPageSize.Items.Add(30);
            cbGridPageSize.SelectedIndex = 0;

            LoadAppSettings();

            var services = new ServiceCollection();
            services.AddWindowsFormsBlazorWebView();
            LoadWebView<Components.Domains>(blazorWebViewDomains, services);
            LoadWebView<Components.FavoritesDomains>(blazorWebViewFavorites, services);

            AppEventService.DomainFilteringStarted += OnDomainFilteringStarted;
            AppEventService.DomainFilteringEnded += OnDomainFilteringEnded;

            var apiSetting = ConfigurationService.GetApiSettings();
        }

        private void LoadWebView<TComponent>(BlazorWebView webView, ServiceCollection services)
            where TComponent : IComponent
        {
            webView.HostPage = "wwwroot\\index.html";
            webView.Services = services.BuildServiceProvider();
            webView.RootComponents.Add<TComponent>("#app");
        }

        private async void LoadAppSettings()
        {
            _appSettings = await ConfigurationService.GetAppSettings();

            if (_appSettings != null)
            {
                radioAnd.Checked = (_appSettings.OperatorType == LogicalFilterOperator.And);
                radioOr.Checked = (_appSettings.OperatorType == LogicalFilterOperator.Or);
                foreach (var criteria in _appSettings.Criterias)
                {
                    if (!string.IsNullOrWhiteSpace(criteria.FilePath))
                    {
                        GetCriteriaEnableControl(criteria.Type).Checked = criteria.Enabled;
                    }
                    else
                    {
                        criteria.Enabled = false;
                        await ConfigurationService.SaveFilterSettings(_appSettings);
                    }

                    GetCriteriaEnableControl(criteria.Type).Checked = criteria.Enabled;
                    GetCriteriaColorControl(criteria.Type).BackColor = criteria.HighlightColor;
                }
                if (_appSettings.GridPageSize > 0)
                {
                    cbGridPageSize.SelectedItem = _appSettings.GridPageSize;
                }
            }
        }


        private async void OnLabelColor_Click(object sender, EventArgs e)
        {
            var filterType = GetFilterType((Control)sender);
            var newColor = SelectColor((Label)sender);
            await UpdateColorCriteria(newColor, filterType);
        }

        private async void OnFilterEnable_CheckedChanged(object sender, EventArgs e)
        {
            //Load file if there is not it
            var chk = (CheckBox)sender;
            var filterType = GetFilterType(chk);
            await UpdateCriteriaEnable(chk, filterType);
        }

        private async void OnLogicOrAnd_CheckedChanged(object sender, EventArgs e)
        {
            var operatorType = radioOr.Checked ? LogicalFilterOperator.Or : LogicalFilterOperator.And;
            await UpdateOperatorType(operatorType);
        }

        private Color SelectColor(Label label)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                label.BackColor = colorDialog.Color;
            }
            return label.BackColor;
        }

        private async Task UpdateColorCriteria(Color newColor, FilterType filterType)
        {
            var appSettings = await ConfigurationService.GetAppSettings();
            var currentCriteria = appSettings.GetCriteria(filterType);
            if (currentCriteria.HighlightColor != newColor)
            {
                currentCriteria.HighlightColor = newColor;
                await ConfigurationService.SaveFilterSettings(appSettings);
            }
        }

        private async Task UpdateCriteriaEnable(CheckBox checkBox, FilterType filterType)
        {
            var appSettings = await ConfigurationService.GetAppSettings();
            var currentCriteria = appSettings.GetCriteria(filterType);
            if (currentCriteria.Enabled != checkBox.Checked)
            {
                if (checkBox.Checked)
                {
                    currentCriteria.FilePath = FileService.SelectFile();
                }
                if (string.IsNullOrEmpty(currentCriteria.FilePath))
                {
                    checkBox.Checked = false;
                }
                currentCriteria.Enabled = checkBox.Checked;
                await ConfigurationService.SaveFilterSettings(appSettings);
            }
        }

        private async Task UpdateOperatorType(LogicalFilterOperator operatorType)
        {
            var appSettings = await ConfigurationService.GetAppSettings();
            if (appSettings.OperatorType != operatorType)
            {
                appSettings.OperatorType = operatorType;
                await ConfigurationService.SaveFilterSettings(appSettings);
            }
        }

        private CheckBox GetCriteriaEnableControl(FilterType filterType)
        {
            return filterType switch
            {
                FilterType.FirstName => chkFirstNames,
                FilterType.City => chkCities,
                FilterType.State => chkStates,
                FilterType.Service => chkServices,
                _ => throw new NotImplementedException()
            };
        }

        private Control GetCriteriaColorControl(FilterType filterType)
        {
            return filterType switch
            {
                FilterType.FirstName => lblFirstNameColor,
                FilterType.City => lblCitiesColor,
                FilterType.State => lblStatesColor,
                FilterType.Service => lblServicesColor,
                _ => throw new NotImplementedException()
            };
        }

        private FilterType GetFilterType(Control control)
        {
            if (control == chkFirstNames || control == lblFirstNameColor)
                return FilterType.FirstName;
            else if (control == chkCities || control == lblCitiesColor)
                return FilterType.City;
            else if (control == chkStates || control == lblStatesColor)
                return FilterType.State;
            else if (control == chkServices || control == lblServicesColor)
                return FilterType.Service;
            else
                throw new Exception($"Filter type not found for object {control.GetType().FullName}");
        }

        private void OnDomainFilteringStarted()
        {
            gbHighlight.Enabled = false;
            gbLogicSwitch.Enabled = false;
        }

        private void OnDomainFilteringEnded()
        {
            gbHighlight.Enabled = true;
            gbLogicSwitch.Enabled = true;
        }

        private async void cbGridPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_appSettings != null)
            {
                _appSettings.GridPageSize = (int)cbGridPageSize.SelectedItem;
                await ConfigurationService.SaveFilterSettings(_appSettings, false);
                AppEventService.TriggerGridPageSizeChange(_appSettings.GridPageSize);
            }
        }
    }
}