using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPMeta2.Definitions;

namespace SPMeta2.VS.CSharp1.Definitions.UI
{
    public static class IntrUserCustomActions
    {
        // use ~sitecollection or ~site tokens, they are suppoerted by M2
        // use UrlUtility.CombineUrl() to construct URL in a safely manner

        public static UserCustomActionDefinition jQuery = new UserCustomActionDefinition
        {
            Name = "IntrjQuery",
            Location = "ScriptLink",
            ScriptSrc = "~sitecollection/Style Library/Intr.Intranet/3rd part/jQuery/jquery-1.11.3.min.js",
            Sequence = 15000
        };

        public static UserCustomActionDefinition IntrJs = new UserCustomActionDefinition
        {
            Name = "Intrjs",
            Location = "ScriptLink",
            ScriptSrc = "~sitecollection/Style Library/Intr.Intranet/js/Intr.Intranet.js",
            Sequence = 17000
        };
    }
}
