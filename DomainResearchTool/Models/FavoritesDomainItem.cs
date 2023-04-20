﻿using DomainResearchTool.Interfaces;

namespace DomainResearchTool.Models
{
    public class FavoritesDomainItem : DomainItem, IDomainItem
    {
        public Dictionary<string, string> ExtraColumns = new Dictionary<string, string>();

        
        public FavoritesDomainItem()
        {
            this.Particles = new List<Particle>();
        }

        public FavoritesDomainItem(DomainItem domainItem)
        {
            this.DomainId = domainItem.DomainId;
            this.Particles = domainItem.Particles;
        }
        
        public new string ToFormatedString()
        {
            return string.Join(",", new List<string>() { DomainId }.Concat(ExtraColumns.Values));
        }

        public void SetExtraColumnValue(string key, string value)
        {
            if (!ExtraColumns.ContainsKey(key))
            {
                ExtraColumns.Add(key, value);
            }
            else
            {
                ExtraColumns[key] = value;
            }
        }
    }
}
