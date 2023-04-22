using Newtonsoft.Json;
using DomainResearchTool.Models;
using DomainResearchTool.Models.DataForSeo;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace DomainResearchTool.Modules
{
    public class ApiMethods
    {
        public const string DomainAnalytics_Whois_Overview_Live = "/v3/domain_analytics/whois/overview/live";
        public const string SERP_Youtube = "/v3/serp/youtube/organic/live/advanced";
    }

    public class DataForCeoApiService
    {
        public ApiSettings GetApiSettings { get { return ConfigurationService.GetApiSettings(); } }

        private RestClient CreateRestClient()
        {
            return new RestClient(GetApiSettings.ApiUrl, configureSerialization: s => s.UseNewtonsoftJson());
        }

        private RestRequest CreateRequest(string resourse)
        {
            var request = new RestRequest(resourse, Method.Post);
            request.AddHeader(KnownHeaders.Authorization, $"Basic {GetApiSettings.GetBase64EncodedCredentials()}");
            request.AddHeader(KnownHeaders.ContentType, ContentType.Json);
            return request;
        }

        public async Task<List<WhoisTaskResultItemResponse>> FetchWhoisData(List<string> domains)
        {
            List<WhoisTaskResultItemResponse> resultData = new();
            try
            {
                if (domains != null && domains.Any())
                {
                    var bodyRequest = new DomainWhoisOverviewRequest();
                    List<object> filters = new List<object>();
                    foreach (var domain in domains)
                    {
                        if (filters.Any())
                        {
                            filters.Add("or");
                        }
                        filters.Add(new string[] { "domain", "=", domain });
                    }

                    bodyRequest.SetFilters(filters);

                    DomainWhoisOverviewResponse responseData = null;
                    using (var client = CreateRestClient())
                    {
                        var request = CreateRequest(ApiMethods.DomainAnalytics_Whois_Overview_Live);
                        request.AddJsonBody(new object[] { bodyRequest }, ContentType.Json);
                        var response = await client.ExecuteAsync(request);
                        if (!string.IsNullOrWhiteSpace(response.Content))
                        {
                            responseData = JsonConvert.DeserializeObject<DomainWhoisOverviewResponse>(response.Content);
                        }
                    }
                    if (ValidateResponse(responseData))
                    {
                        resultData = responseData.Tasks.FirstOrDefault().Result.FirstOrDefault().Items;
                    }
                }
            }
            catch (Exception ex)
            {
                NotificationMessageService.ShowErrorMessage(ex.Message);
            }

            return resultData;
        }

        public async Task<Dictionary<string, int>> FetchYoutubeData(List<string> domains)
        {
            Dictionary<string, int> resultData = new Dictionary<string, int>();
            try
            {
                if (domains != null && domains.Any())
                {
                    var bodyRequest = new SERPRequest()
                    {
                        LocationCode = 2840,//United Stated, See CSV for more https://docs.dataforseo.com/v3/serp/youtube/locations/
                        LanguageCode = "en",
                        Device = "desktop",
                        Os = "Windows",
                        BlockDepth = 10
                    };
                    foreach (var domainName in domains)
                    {
                        bodyRequest.Keyword = $"\"{domainName}\"";

                        using (var client = CreateRestClient())
                        {
                            var request = CreateRequest(ApiMethods.SERP_Youtube);
                            request.AddJsonBody(new object[] { bodyRequest }, ContentType.Json);
                            var response = await client.ExecuteAsync(request);
                            if (!string.IsNullOrWhiteSpace(response.Content))
                            {
                                var responseData = JsonConvert.DeserializeObject<SERPResponse>(response.Content);
                                if (ValidateResponse(responseData))
                                {
                                    resultData.Add(domainName, responseData.Tasks.FirstOrDefault().Result.FirstOrDefault().SeResultsCount);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                NotificationMessageService.ShowErrorMessage(ex.Message);
            }
            return resultData;
        }

        private bool ValidateResponse(IBaseResponse response)
        {
            if (response == null)
            {
                NotificationMessageService.ShowWarningMessage("Response is null");
                return false;
            }
            if (response.IsError())
            {
                NotificationMessageService.ShowWarningMessage(response.GetErrorMessage());
                return false;
            }
            if (!response.HasAnyTasks())
            {
                NotificationMessageService.ShowWarningMessage($"Task not found.");
                return false;
            }
            if (!response.HasAnyResultInTask())
            {
                NotificationMessageService.ShowWarningMessage($"Task.Result not found.");
                return false;
            }
            return true;

        }
    }
}
