using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPMeta2.VS.CSharp1.Definitions.IA;
using SPMeta2.VS.CSharp1.Definitions.Pages;
using SPMeta2.Definitions;
using SPMeta2.Utils;

namespace SPMeta2.VS.CSharp1.Definitions.Navigation
{
    public static class IntrQuickNavigationNodes
    {
        // use ~sitecollection or ~site tokens, they are suppoerted by M2
        // use UrlUtility.CombineUrl() to construct URL in a safely manner
        // refer your definition, reuse them - enable refactoring

        public static QuickLaunchNavigationNodeDefinition CompanyDocuments = new QuickLaunchNavigationNodeDefinition
        {
            Title = "Company Documents",
            Url = "~site/CompanyDocuments",
            IsExternal = true
        };

        public static QuickLaunchNavigationNodeDefinition Services = new QuickLaunchNavigationNodeDefinition
        {
            Title = "Services",
            Url = UrlUtility.CombineUrl("~site", IntrLists.Services.CustomUrl),
            IsExternal = true
        };

        public static QuickLaunchNavigationNodeDefinition Orders = new QuickLaunchNavigationNodeDefinition
        {
            Title = "Orders",
            Url = UrlUtility.CombineUrl("~site", IntrLists.Orders.CustomUrl),
            IsExternal = true
        };

        public static QuickLaunchNavigationNodeDefinition SaleTasks = new QuickLaunchNavigationNodeDefinition
        {
            Title = "Sales Tasks",
            Url = UrlUtility.CombineUrl("~site", IntrLists.SalesTasks.CustomUrl),
            IsExternal = true
        };

        public static QuickLaunchNavigationNodeDefinition SaleEvents = new QuickLaunchNavigationNodeDefinition
        {
            Title = "Sales Events",
            Url = UrlUtility.CombineUrl("~site", IntrLists.SalesEvents.CustomUrl),
            IsExternal = true
        };

        public static QuickLaunchNavigationNodeDefinition AboutThisSite = new QuickLaunchNavigationNodeDefinition
        {
            Title = "About",
            Url = UrlUtility.CombineUrl("~site/SitePages/", IntrWebPartPages.AboutThisSite.FileName),
            IsExternal = true
        };
    }
}
