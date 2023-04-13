using System.Text.RegularExpressions;

namespace DomainResearchTool.Modules
{
    public class DomainUtils
    {
        public static bool IsDomainValid(string domainName)
        {
            return Regex.IsMatch(domainName, @"^((?!-)[A-Za-z0-9-]{1,63}(?<!-)\.)+[A-Za-z]{2,6}$");
        }
    }
}
