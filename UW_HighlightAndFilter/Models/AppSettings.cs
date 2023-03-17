using Radzen;
using UW_HighlightAndFilter.Enums;

namespace UW_HighlightAndFilter.Models
{
    public class AppSettings
    {
        public int GridPageSize { get; set; } = 20;
        public string DomainsFilePath { get; set; } = string.Empty;
        public int PageNumber { get; set; } = 0;
        public int FavoritesPageNumber { get; set; } = 0;

        public List<DomainItem> FavoriteDomains { get; set; } = new List<DomainItem>();
        public LogicalFilterOperator OperatorType { get; set; }
        public List<FilterCriteria> Criterias { get; set; } = new List<FilterCriteria>();
        private Dictionary<FilterType, Color> _colorMap = new Dictionary<FilterType, Color>();

        public FilterCriteria GetCriteria(FilterType filterType)
        {
            var criteria = Criterias.FirstOrDefault(el => el.Type == filterType);
            if (criteria == null)
            {
                criteria = new FilterCriteria()
                {
                    Type = filterType
                };
                Criterias.Add(criteria);
            }
            return criteria;
        }
        public Color GetColor(FilterType filterType)
        {
            if (!_colorMap.ContainsKey(filterType))
            {
                var criteria = GetCriteria(filterType);
                _colorMap.Add(filterType, criteria.HighlightColor);
            }
            return _colorMap[filterType];
        }
    }
}
