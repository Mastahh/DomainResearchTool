using System.Text;

namespace DomainResearchTool.Models
{
    public class ApiSettings
    {
        public string ApiUrl { get; set; } = string.Empty;
        public string ApiLogin { get; set; } = string.Empty;
        public string ApiPassword { get; set; } = string.Empty;

        public string GetBase64EncodedCredentials()
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes($"{ApiLogin}:{ApiPassword}"));
        }
    }
}
