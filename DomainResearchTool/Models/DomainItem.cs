using DomainResearchTool.Interfaces;

namespace DomainResearchTool.Models
{
    public class DomainItem : IDomainItem
    {
        public DomainItem()
        {
            Particles = new List<Particle>();
        }

        public bool ManuallyAdded { get; set; } = false;

        public string DomainId { get; set; } = "";
        public List<Particle> Particles { get; set; }

        public string GetColumns(string separator = ",")
        {
            return string.Join(separator, nameof(Particles));
        }

        public string ToFormatedString(string separator = ",")
        {
            return string.Join(separator, Particles.Select(p => p.Text));
        }
    }
}
