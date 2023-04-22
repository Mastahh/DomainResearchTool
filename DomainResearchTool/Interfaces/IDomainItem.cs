namespace DomainResearchTool.Interfaces
{
    public interface IDomainItem
    {
        string GetColumns(string separator = ",");
        string ToFormatedString(string separator = ",");
    }
}
