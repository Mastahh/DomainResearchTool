using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UW_HighlightAndFilter.Extension
{
    public static class StringExtension
    {
        public static string ToPrettyCase(this string str)
        {
            if (!string.IsNullOrWhiteSpace(str) && str.Length > 1)
            {
                return char.ToUpper(str[0]) + str.Substring(1);
            }
            return str;
        }
    }
}
