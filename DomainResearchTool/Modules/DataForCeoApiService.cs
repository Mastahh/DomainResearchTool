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

        public async Task<DomainWhoisOverviewResponse> FetchWhoisData(List<string> domains)
        {
            DomainWhoisOverviewResponse resultData = null;
            var bodyRequest = new DomainWhoisOverviewRequest();
            foreach (var domain in domains)
            {
                if (bodyRequest.Filters.Any())
                {
                    bodyRequest.Filters.Add("or");
                }
                bodyRequest.Filters.Add(new string[] { "domain", "=", domain });
            }

            using (var client = CreateRestClient())
            {
                var request = CreateRequest(ApiMethods.DomainAnalytics_Whois_Overview_Live);
                request.AddJsonBody(new object[] { bodyRequest }, ContentType.Json);
                var response = await client.ExecuteAsync(request);
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    resultData = JsonConvert.DeserializeObject<DomainWhoisOverviewResponse>(response.Content);
                }
            }
            return resultData;
        }
    }
}
