﻿using Newtonsoft.Json;
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

        public async Task<List<TaskResultItemResponse>> FetchWhoisData(List<string> domains)
        {
            List<TaskResultItemResponse> resultData = new();
            if (domains != null && domains.Any())
            {
                var bodyRequest = new DomainWhoisOverviewRequest();
                foreach (var domain in domains)
                {
                    if (bodyRequest.Filters.Any())
                    {
                        bodyRequest.Filters.Add("or");
                    }
                    bodyRequest.Filters.Add(new string[] { "domain", "=", domain });
                }

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

            return resultData;
        }

        public async Task<Dictionary<string, int>> FetchYoutubeData(List<string> domains)
        {
            Dictionary<string, int> resultData = new Dictionary<string, int>();
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
                            var responseData = JsonConvert.DeserializeObject<DomainWhoisOverviewResponse>(response.Content);
                            if (ValidateResponse(responseData))
                            {
                                resultData.Add(domainName, 0);
                            }
                            else
                            {
                                NotificationMessageService.ShowWarningMessage(responseData.GetErrorMessage());
                                break;
                            }
                        }
                    }
                    break;
                }
            }
            return resultData;
        }

        private bool ValidateResponse(BaseResponse response)
        {
            if (response != null)
            {
                if (response.IsError())
                {
                    NotificationMessageService.ShowWarningMessage(response.GetErrorMessage());
                    return false;
                }
                var task = response.Tasks.FirstOrDefault();
                if (task == null)
                {
                    NotificationMessageService.ShowWarningMessage($"Task not found.");
                    return false;
                }
                var result = task.Result.FirstOrDefault();
                if (result == null)
                {
                    NotificationMessageService.ShowWarningMessage($"Task.Result not found.");
                    return false;
                }
                return true;
            }
            NotificationMessageService.ShowWarningMessage("Response is null");
            return false;
        }
    }
}
