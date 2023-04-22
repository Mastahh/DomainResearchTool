using Newtonsoft.Json;
using DomainResearchTool.Models;
using DomainResearchTool.Models.DataForSeo;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System.Collections.Concurrent;
using System.Linq;

namespace DomainResearchTool.Modules
{
    public class ApiMethods
    {
        public const string DomainAnalytics_Whois_Overview_Live = "/v3/domain_analytics/whois/overview/live";
        public const string SERP_Youtube = "/v3/serp/youtube/organic/live/advanced";
    }

    public class DataForCeoApiService
    {
        private const int _whois_max_domains = 8;
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
            ConcurrentBag<WhoisTaskResultItemResponse> resultData = new ConcurrentBag<WhoisTaskResultItemResponse>();

            if (domains != null && domains.Any())
            {
                int page = 0;
                var domainsBatch = domains.Skip(_whois_max_domains * page).Take(_whois_max_domains);
                do
                {
                    page++;
                    var bodyRequest = new DomainWhoisOverviewRequest();
                    List<object> filters = new List<object>();
                    foreach (var domain in domainsBatch)
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
                    if (IsValidatResponse(responseData))
                    {
                        responseData.Tasks.FirstOrDefault().Result.FirstOrDefault().Items.ForEach(resultData.Add);
                    }
                    domainsBatch = domains.Skip(_whois_max_domains * page).Take(_whois_max_domains);
                }
                while (domainsBatch.Any());
               
            }

            return resultData.ToList();
        }

        public async Task<Dictionary<string, int>> FetchYoutubeData(List<string> domains)
        {
            ConcurrentDictionary<string, int> resultData = new ConcurrentDictionary<string, int>();

            if (domains != null && domains.Any())
            {
                await Parallel.ForEachAsync(domains, new ParallelOptions() { MaxDegreeOfParallelism = 10 }, async (domainName, _) =>
                {
                    var bodyRequest = new SERPRequest()
                    {
                        LocationCode = 2840,//United Stated, See CSV for more https://docs.dataforseo.com/v3/serp/youtube/locations/
                        LanguageCode = "en",
                        Device = "desktop",
                        Os = "Windows",
                        BlockDepth = 10
                    };
                    bodyRequest.Keyword = $"\"{domainName}\"";

                    using (var client = CreateRestClient())
                    {
                        var request = CreateRequest(ApiMethods.SERP_Youtube);
                        request.AddJsonBody(new object[] { bodyRequest }, ContentType.Json);
                        var response = await client.ExecuteAsync(request);
                        if (!string.IsNullOrWhiteSpace(response.Content))
                        {
                            var responseData = JsonConvert.DeserializeObject<SERPResponse>(response.Content);
                            if (IsValidatResponse(responseData))
                            {
                                resultData.TryAdd(domainName, responseData.Tasks.FirstOrDefault().Result.FirstOrDefault().SeResultsCount);
                            }
                        }
                    }

                });
            }

            return resultData.ToDictionary(entry => entry.Key, entry => entry.Value);
        }

        private bool IsValidatResponse(IBaseResponse response)
        {
            if (response == null || response.IsError() || !response.HasAnyTasks() || !response.HasAnyResultInTask())
            {
                return false;
            }
            return true;
        }
    }
}
