using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPMeta2.BuiltInDefinitions;
using SPMeta2.Definitions;
using SPMeta2.Utils;

namespace SPMeta2.VS.CSharp1.Definitions.Pages
{
    public static class IntrWelcomePages
    {
        // use UrlUtility.CombineUrl() to construct URL in a safely manner
        // refer your definition, reuse them - enable refactoring

        public static WelcomePageDefinition HomeLandingPage = new WelcomePageDefinition
        {
            Url = UrlUtility.CombineUrl("SitePages", IntrWebPartPages.LandingPage.FileName)
        };
    }
}
