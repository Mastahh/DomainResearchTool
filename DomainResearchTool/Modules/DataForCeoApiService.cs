using System.Text.Json;
using DomainResearchTool.Models;
using DomainResearchTool.Models.DataForSeo;
using RestSharp;

namespace DomainResearchTool.Modules
{
    public class ApiMethods
    {
        public const string DomainAnalytics_Whois_Overview_Live = "/v3/domain_analytics/whois/overview/live";
    }

    public class DataForCeoApiService
    {
        public ApiSettings GetApiSettings { get { return ConfigurationService.GetApiSettings(); } }

        private RestRequest CreateRequest(string resourse)
        {
            var request = new RestRequest(resourse, Method.Post);
            request.AddHeader("Authorization", $"Basic {GetApiSettings.GetBase64EncodedCredentials()}");
            request.AddHeader("Content-Type", "application/json");
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

            using (var client = new RestClient(GetApiSettings.ApiUrl))
            {
                var request = CreateRequest(ApiMethods.DomainAnalytics_Whois_Overview_Live);
                request.AddJsonBody(new object[] { bodyRequest }, ContentType.Json);
                var testData = "{\r\n    \"version\": \"0.1.20221214\",\r\n    \"status_code\": 20000,\r\n    \"status_message\": \"Ok.\",\r\n    \"time\": \"0 sec.\",\r\n    \"cost\": 0,\r\n    \"tasks_count\": 1,\r\n    \"tasks_error\": 1,\r\n    \"tasks\": [\r\n        {\r\n            \"id\": \"04172335-5902-0481-0000-baf497c0ccd9\",\r\n            \"status_code\": 40201,\r\n            \"status_message\": \"Our algorithms found suspicious activity in your DataForSEO account. It has been temporarily blocked. For further details please contact our support team.\",\r\n            \"time\": \"0 sec.\",\r\n            \"cost\": 0,\r\n            \"result_count\": 0,\r\n            \"path\": [\r\n                \"v3\",\r\n                \"domain_analytics\",\r\n                \"whois\",\r\n                \"overview\",\r\n                \"live\"\r\n            ],\r\n            \"data\": {\r\n                \"api\": \"domain_analytics\",\r\n                \"function\": \"overview\",\r\n                \"se\": \"whois\",\r\n                \"limit\": 100,\r\n                \"offset\": 0,\r\n                \"filters\": [\r\n                    [\r\n                        \"domain\",\r\n                        \"=\",\r\n                        \"RachelbNailS.com\"\r\n                    ]\r\n                ]\r\n            },\r\n            \"result\": null\r\n        }\r\n    ]\r\n}";
                resultData = JsonSerializer.Deserialize<DomainWhoisOverviewResponse>(testData);
                //return resultData;
                var response = await client.ExecuteAsync(request);
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    resultData = JsonSerializer.Deserialize<DomainWhoisOverviewResponse>(response.Content);
                }
                
            }
            return resultData;
        }
    }
}
