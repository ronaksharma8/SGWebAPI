using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SGWebAPI.Models.Helper
{
    public static class StringHelper
    {
        public static string SeparateWordsByTitleCase(this string text)
        {
            var separated = Regex.Replace(text, "(\\B[A-Z])", " $1");

            return separated;
        }
    }
}
