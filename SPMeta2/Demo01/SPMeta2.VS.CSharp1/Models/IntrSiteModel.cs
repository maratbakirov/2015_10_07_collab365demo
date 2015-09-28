using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPMeta2.VS.CSharp1.Definitions.Features;
using SPMeta2.VS.CSharp1.Definitions.IA;
using SPMeta2.VS.CSharp1.Definitions.Security;
using SPMeta2.VS.CSharp1.Definitions.Solutions;
using SPMeta2.VS.CSharp1.Definitions.UI;
using SPMeta2.Extensions;
using SPMeta2.Models;
using SPMeta2.Syntax.Default;

namespace SPMeta2.VS.CSharp1.Models
{
    /// <summary>
    /// Describes the site collection.
    /// 
    /// The main responcibility is to describe and separate what needs to be deployed on the site collection level:
    /// - sandbox solutions
    /// - site features
    /// - security group and roles
    /// - fields
    /// - content types
    /// - user custom actions
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
    public class IntrSiteModel
    {
        public ModelNode GetSandboxSolutionsModel()
        {
            var model = SPMeta2Model.NewSiteModel(site =>
            {
                // either use AddXXX() or just import everything with .AddDefinitionsFromStaticClassType() 
                // !!! commented out as there is no *.wsp package out there !!!

                //site.AddSandboxSolution(IntrSandboxSolutions.WebsiteBranding);
                //site.AddDefinitionsFromStaticClassType(typeof(IntrSandboxSolutions));
            });

            return model;
        }

        public ModelNode GetSiteSecurityModel()
        {
            var model = SPMeta2Model.NewSiteModel(site =>
            {
                site.AddDefinitionsFromStaticClassType(typeof(IntrSecurityGroups));
                site.AddDefinitionsFromStaticClassType(typeof(IntrSecurityRoles));
            });

            return model;
        }

        public ModelNode GetSiteFeaturesModel()
        {
            var model = SPMeta2Model.NewSiteModel(site =>
            {
                // either use AddXXX() or just import everything with .AddDefinitionsFromStaticClassType() 

                site.AddSiteFeature(IntrSiteFeatures.BasicWebParts);
                //site.AddDefinitionsFromStaticClassType(typeof(IntrSiteFeatures));
            });

            return model;
        }

        public ModelNode GetFieldsAndContentTypesModel()
        {
            var model = SPMeta2Model.NewSiteModel(site =>
            {
                // adding all fields from IntrFields class
                site.AddDefinitionsFromStaticClassType(typeof(IntrFields));

                // building up content types
                site
                    .AddContentType(IntrContentTypes.CompanyDocument, contentType =>
                    {
                        contentType
                            .AddContentTypeFieldLink(IntrFields.DocumentHighlights)
                            .AddContentTypeFieldLink(IntrFields.DocumentDescription);
                    })
                    .AddContentType(IntrContentTypes.SalesProposal, contentType =>
                    {

                    })
                    .AddContentType(IntrContentTypes.ProductDocument, contentType =>
                    {

                    })
                    .AddContentType(IntrContentTypes.OrderDocument, contentType =>
                    {
                        contentType
                            .AddContentTypeFieldLink(IntrFields.OrderDate)
                            .AddContentTypeFieldLink(IntrFields.OrderAddressState)
                            .AddContentTypeFieldLink(IntrFields.OrderPrice)
                            .AddContentTypeFieldLink(IntrFields.OrderSalePercentage)
                            .AddContentTypeFieldLink(IntrFields.OrderTrackingUrl);
                    })
                    .AddContentType(IntrContentTypes.ProductOrService, contentType =>
                    {
                        contentType
                            .AddContentTypeFieldLink(IntrFields.ProductDescription)
                            .AddContentTypeFieldLink(IntrFields.ProductType)
                            .AddContentTypeFieldLink(IntrFields.IsProductActive);
                    })
                    .AddContentType(IntrContentTypes.SaleEvents, contentType =>
                    {

                    });
            });

            return model;
        }

        public ModelNode GetTaxonomyModel()
        {
            var model = SPMeta2Model.NewSiteModel(site =>
            {
                // skipped, it it might be a foundation project setup
                // refer to Taxonomy provision scenarios here:

                // http://docs.subpointsolutions.com/spmeta2/scenarios/
                // http://docs.subpointsolutions.com/spmeta2/definitions/sharepoint-standard/taxonomy/taxonomytermdefinition/
            });

            return model;
        }

        public ModelNode GetUserCustomActionModel()
        {
            var model = SPMeta2Model.NewSiteModel(site =>
            {
                site.AddUserCustomAction(IntrUserCustomActions.jQuery);
                site.AddUserCustomAction(IntrUserCustomActions.IntrJs);
            });

            return model;
        }
    }
}
