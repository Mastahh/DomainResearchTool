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

        public string ToFormatedString()
        {
            return string.Join("", Particles.Select(p => p.Text));
        }
    }
}
