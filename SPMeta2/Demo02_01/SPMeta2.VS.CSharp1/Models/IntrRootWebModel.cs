using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPMeta2.VS.CSharp1.Consts;
using SPMeta2.VS.CSharp1.Definitions.Features;
using SPMeta2.VS.CSharp1.Definitions.IA;
using SPMeta2.VS.CSharp1.Definitions.Navigation;
using SPMeta2.VS.CSharp1.Definitions.Pages;
using SPMeta2.VS.CSharp1.Definitions.UI;
using SPMeta2.BuiltInDefinitions;
using SPMeta2.Extensions;
using SPMeta2.Models;
using SPMeta2.Syntax.Default;
using SPMeta2.Syntax.Default.Utils;
using SPMeta2.VS.CSharp.Extensions;

namespace SPMeta2.VS.CSharp1.Models
{
    /// <summary>
    /// Describes the root web.
    /// 
    /// The main responcibility is to describe and separate what needs to be deployed on the root web level:
    /// - web features
    /// - style library provision
    /// - anything else
    /// 
    /// Construct your model using AddXXX() or AddHostXXX() syntax.
    /// If you have bunch of the 'plain' things to push, then use .AddDefinitionsFromStaticClassType() method.
    /// 
    /// It is a good idea to avoid big model preferring small model per every reasonable operation.
    /// The final artifact separation and grouping is tootally up to you and your prpoject needs.
    /// 
    /// 
    /// Read more here - http://docs.subpointsolutions.com/spmeta2/models/
    /// </summary>
    public class IntrRootWebModel
    {
        public ModelNode GetModel()
        {
            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                    .AddWebFeature(IntrWebFeatures.DisableMinimalDownloadStrategy)
                    .AddWebFeature(IntrWebFeatures.EnableTeamCollabirationLists)
                    .AddWebFeature(IntrWebFeatures.WikiPageHomePage)

                    .AddTopNavigationNode(IntrTopNavigationNodes.CompanyDocuments)
                    .AddTopNavigationNode(IntrTopNavigationNodes.SaleTasks)
                    .AddTopNavigationNode(IntrTopNavigationNodes.SaleEvents)
                    .AddTopNavigationNode(IntrTopNavigationNodes.AboutThisSite)

                    .AddQuickLaunchNavigationNode(IntrQuickNavigationNodes.CompanyDocuments)
                    .AddQuickLaunchNavigationNode(IntrQuickNavigationNodes.Services)
                    .AddQuickLaunchNavigationNode(IntrQuickNavigationNodes.Orders)
                    .AddQuickLaunchNavigationNode(IntrQuickNavigationNodes.SaleTasks)
                    .AddQuickLaunchNavigationNode(IntrQuickNavigationNodes.SaleEvents)
                    .AddQuickLaunchNavigationNode(IntrQuickNavigationNodes.AboutThisSite)

                    .AddList(IntrLists.CompanyDocuments, list =>
                    {
                        list
                            .AddContentTypeLink(IntrContentTypes.CompanyDocument)
                            .AddContentTypeLink(IntrContentTypes.SalesProposal)
                            .AddContentTypeLink(IntrContentTypes.ProductDocument)

                            .AddListView(IntrListViews.LastTenDocuments)
                            .AddListView(IntrListViews.LastTenDocumentsMainPage)

                            .IntrSetDefaultListContentType(IntrContentTypes.CompanyDocument);
                    })
                    .AddList(IntrLists.Orders, list =>
                    {
                        list
                            .AddContentTypeLink(IntrContentTypes.OrderDocument)
                            .AddListView(IntrListViews.Last25Orders)
                            .AddListView(IntrListViews.Last10OrdersMainPage)

                            .IntrSetDefaultListContentType(IntrContentTypes.OrderDocument);
                    })
                    .AddList(IntrLists.Services, list =>
                    {
                        list
                            .AddContentTypeLink(IntrContentTypes.ProductOrService)
                            .AddListView(IntrListViews.AllProducts)
                            .AddListView(IntrListViews.LastTenServices)

                            .IntrSetDefaultListContentType(IntrContentTypes.ProductOrService);
                    })
                    .AddList(IntrLists.SalesTasks, list =>
                    {

                    })
                    .AddList(IntrLists.SalesEvents, list =>
                    {
                        list
                            .AddContentTypeLink(IntrContentTypes.SaleEvents)

                            .IntrSetDefaultListContentType(IntrContentTypes.SaleEvents);
                    })
                    .AddHostList(BuiltInListDefinitions.SitePages, list =>
                    {
                        list.AddWebPartPage(IntrWebPartPages.LandingPage, page =>
                        {
                            page
                                .AddWebPart(IntrWebparts.NewServices)
                                .AddWebPart(IntrWebparts.SalesTasks)
                                .AddWebPart(IntrWebparts.LastDocuments)
                                .AddWebPart(IntrWebparts.LastOrders)
                                .AddWebPart(IntrWebparts.SalesEvents);
                        });

                        list.AddWebPartPage(IntrWebPartPages.AboutThisSite, page =>
                        {
                            page
                                .AddWebPart(IntrWebparts.M2YammerFeed)
                                .AddWebPart(IntrWebparts.AboutThisSite);
                        });
                    })

                    .AddWelcomePage(IntrWelcomePages.HomeLandingPage);
            });

            return model;
        }

        public ModelNode GetStyleLibraryModel()
        {
            var webModel = SPMeta2Model.NewWebModel(rootWeb =>
            {
                // AddHostList() to indicate that we don't provision list, but just look it up
                rootWeb.AddHostList(BuiltInListDefinitions.StyleLibrary, list =>
                {
                    //LoadModuleFilesFromLocalFolder() helper gets everything from the local folder
                    //and creates a new M2 model full of folders/module files

                    //everything you have in IntrConsts.DefaultStyleLibraryPath
                    //will be pushed to 'Style Library' back to back

                    if (Directory.Exists(IntrConsts.DefaultStyleLibraryPath))
                        ModuleFileUtils.LoadModuleFilesFromLocalFolder(list, IntrConsts.DefaultStyleLibraryPath);
                });
            });

            return webModel;
        }
    }
}
