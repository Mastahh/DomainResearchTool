using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainResearchTool.Models
{
    public class DomainItem
    {
        public DomainItem()
        {
            Particles = new List<Particle>();
        }

        public string DomainId { get; set; } = "";
        public List<Particle> Particles { get; set; }

        public string ToFormatedString()
        {
            return string.Join("", Particles.Select(p => p.Text));
        }
    }
}
