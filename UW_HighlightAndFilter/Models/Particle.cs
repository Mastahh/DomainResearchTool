using UW_HighlightAndFilter.Enums;
using UW_HighlightAndFilter.Extension;

namespace UW_HighlightAndFilter.Models
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
