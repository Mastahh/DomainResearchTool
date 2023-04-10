using DomainResearchTool.Enums;
using DomainResearchTool.Extension;

namespace DomainResearchTool.Models
{
    public class Particle
    {
        private string _text = string.Empty;
        public string Text
        {
            get { return _text.ToPrettyCase(); }
            set { _text = value; }
        }
        public FilterType ParticleType { get; set; } = FilterType.None;
    }
}
