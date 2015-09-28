using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPMeta2.Definitions;
using SPMeta2.Enumerations;

namespace SPMeta2.VS.CSharp1.Definitions.Pages
{
    public static class IntrWikiPages
    {
        public static WikiPageDefinition FAQ = new WikiPageDefinition
        {
            Title = "FAQ",
            FileName = "FAQ.aspx",
        };

        public static WikiPageDefinition HowTos = new WikiPageDefinition
        {
            Title = "HowTos",
            FileName = "HowTos.aspx",
            Content = "Some fascinating how-tows here..."
        };
    }
}
