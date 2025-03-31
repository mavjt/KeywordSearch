    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KeywordSearch.Infrastructure.Services
{
    public  class HTMLParser : IHTMLParser
    {
        public  List<string> GetHtmlElement(string html, string elementName, string className)
        {
            // Regular expression to match <className> tags with the specific class
            string pattern = $"<{elementName}[^>]*class=[\"'][^\"']*{className}[^\"']*[\"'][^>]*>[(\\s\\S)]*?<\\/{elementName}>";

            var matches = Regex.Matches(html, pattern);
            
            return matches.Select(x => x.Value).ToList();
        }

        public  List<string> GetHtmlElement(string html, string elementName)
        {
            // Regular expression to match all <className> tags 
            string pattern = $"<{elementName}[^>]*[^>]*>[(\\s\\S)]*?<\\/{elementName}>";
            var matches = Regex.Matches(html, pattern);

            var cleaned =  matches.Select(x => RemoveTags("strong", x.Value)).ToList(); //some of the elements had weird strong tags inside
            return cleaned;
            
        }

        private string RemoveTags(string tag, string input)
        {
            return Regex.Replace(input, $"</?{tag}[^>]*>", "");
        }
    }
}
