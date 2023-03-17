using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UW_HighlightAndFilter.Enums;

namespace UW_HighlightAndFilter.Models
{
    public class FilterRule
    {
        public PositionType Position { get; set; } = PositionType.Contains;
        //public FilterCriteria FilterCriteria { get; set; }
        public FilterType Type { get; set; }
        public List<string> Words { get; set; } = new List<string>();
    }
}
