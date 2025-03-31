using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordSearch.Core.Interfaces
{
    public interface IHTMLParser
    {
        List<string> GetHtmlElement(string html, string elementName, string className);
        List<string> GetHtmlElement(string html, string elementName);
    }
}
