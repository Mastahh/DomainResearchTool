using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainResearchTool.Enums;

namespace DomainResearchTool.Models
{
    public class FilterRule
    {
        public PositionType Position { get; set; } = PositionType.Contains;
        //public FilterCriteria FilterCriteria { get; set; }
        public FilterType Type { get; set; }
        public List<string> Words { get; set; } = new List<string>();
    }
}
