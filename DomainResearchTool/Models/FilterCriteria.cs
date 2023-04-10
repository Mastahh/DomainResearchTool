using System.Text.Json.Serialization;
using DomainResearchTool.Enums;

namespace DomainResearchTool.Models
{
    public class FilterCriteria
    {
        public bool Enabled { get; set; }

        public FilterType Type { get; set; }

        public string HtmlColor { get; set; } = string.Empty;

        public string FilePath { get; set; } = string.Empty;

        [JsonIgnore]
        public Color HighlightColor
        {
            get { return ColorTranslator.FromHtml(HtmlColor); }
            set { HtmlColor = ColorTranslator.ToHtml(value); }
        }
    }
}
