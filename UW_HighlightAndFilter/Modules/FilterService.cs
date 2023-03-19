using System.Text.RegularExpressions;
using Radzen;
using UW_HighlightAndFilter.Enums;
using UW_HighlightAndFilter.Models;

namespace UW_HighlightAndFilter.Modules
{
    public class FilterService
    {
        private static object _locker = new object();
        private char _marker = '^';
        private char _markerEnd = '$';
        private List<FilterRule> _filterRules = new List<FilterRule>();
        private List<string> _toSkip = new List<string>();
        private string _regExToRemove = @"[-\s\/\\\(\)\&]";

        public void ClearCriterias()
        {
            _filterRules.Clear();
        }
        public void AddFilterCriteria(FilterType filterType, PositionType type, List<string> data)
        {
            if (data != null && data.Count() > 0)
            {
                if (type == PositionType.StartsWith
                    && _filterRules.Any(el => el.Position == PositionType.StartsWith))
                {
                    throw new Exception($"Only one criteria with type '{type}' allowed");
                }
                Regex regex = new Regex(_regExToRemove, RegexOptions.IgnoreCase);
                var filterWords = data.Where(el => !string.IsNullOrWhiteSpace(el)).Select(el => regex.Replace(el, "").ToLower()).OrderByDescending(el => el.Length).ToList();
                if (filterType == FilterType.Favorite)
                {
                    _toSkip.AddRange(filterWords);
                }
                else
                {
                    _filterRules.Add(new() { Type = filterType, Position = type, Words = filterWords });
                }
            }
        }

        public List<Particle> FilterDomain(string domain, LogicalFilterOperator logicalOperator)
        {
            if (_toSkip.Contains(domain))
            {
                return null;
            }
            lock (_locker)
            {
                Dictionary<string, Particle> foundWords = new Dictionary<string, Particle>();
                int wordCount = 0;
                var tempDomain = domain.ToLower();
                var charsLeft = domain.LastIndexOf(".");
                foreach (var filterRule in _filterRules.Where(el => el.Type != FilterType.Favorite))
                {
                    if (!filterRule.Words.Any())
                    {
                        continue;
                    }
                    var found = false;
                    foreach (var word in filterRule.Words)
                    {
                        if (filterRule.Position == PositionType.StartsWith)
                        {
                            if (tempDomain.StartsWith(word))
                            {
                                found = true;
                                var key = GetMarker(wordCount);
                                foundWords.Add(key, new Particle()
                                {
                                    ParticleType = filterRule.Type,
                                    Text = word
                                });
                                tempDomain = tempDomain.Replace(word, key);
                                charsLeft -= word.Length;
                                wordCount++;
                                break;
                            }
                        }
                        else if (filterRule.Position == PositionType.Contains)
                        {
                            if (tempDomain.Contains(word))
                            {
                                found = true;
                                var key = GetMarker(wordCount);
                                foundWords.Add(key, new Particle()
                                {
                                    ParticleType = filterRule.Type,
                                    Text = word
                                });
                                tempDomain = tempDomain.Replace(word, key);
                                charsLeft -= word.Length;
                                wordCount++;
                            }
                        }
                    }
                    if (logicalOperator == LogicalFilterOperator.And && !found)
                    {
                        //Do not continue search, of of criterias fails.
                        return null;
                    }
                    if (charsLeft <= 1)
                    {
                        //All Found
                        break;
                    }
                }
                if (logicalOperator == LogicalFilterOperator.And)
                {
                    var totalCriteriasMeet = foundWords.Select(x => x.Value.ParticleType).Distinct().Count();
                    if (totalCriteriasMeet != _filterRules.Count())
                    { return null; }
                }
                if (foundWords.Count > 0)
                {
                    List<Particle> particles = new List<Particle>();
                    var pos = tempDomain.IndexOf($"{_marker}");
                    do
                    {
                        if (pos != 0)
                        {
                            particles.Add(new Particle() { Text = tempDomain.Substring(0, pos), ParticleType = FilterType.None });
                            tempDomain = tempDomain.Substring(pos);
                        }
                        pos = tempDomain.IndexOf($"{_marker}");
                        var posEnd = tempDomain.IndexOf($"{_markerEnd}") + 1;

                        var key = tempDomain.Substring(pos, posEnd - pos);
                        tempDomain = tempDomain.Substring(posEnd);
                        particles.Add(foundWords[key]);

                        pos = tempDomain.IndexOf($"{_marker}");
                    }
                    while (pos >= 0);
                    //BuildResult
                    particles.Add(new Particle() { Text = tempDomain, ParticleType = FilterType.None });
                    return particles;
                }
                return null;
            }
            
        }

        private string GetMarker(int wordNum)
        {
            return $"{_marker}{wordNum}{_markerEnd}";
        }
    }
}
