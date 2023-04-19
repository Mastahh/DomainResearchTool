namespace DomainResearchTool.Extension
{
    public static class StringExtension
    {
        public static string ToPrettyCase(this string str)
        {
            if (!string.IsNullOrWhiteSpace(str) && str.Length > 1)
            {
                return char.ToUpper(str[0]) + str.Substring(1);
            }
            return str;
        }
    }
}
