using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPMeta2.VS.CSharp1.Models;
using SPMeta2.VS.CSharp1.Models.SubWebs;
using Microsoft.SharePoint.Client;
using SPMeta2.CSOM.Services;
using SPMeta2.CSOM.Standard.Services;

namespace SPMeta2.VS.CSharp1.Services
{
    public class IntrStandardCSOMProvisionService : StandardCSOMProvisionService
    {
        #region options

        public class Options
        {
            public bool DeploySite { get; set; }
            public bool DeployRootWeb { get; set; }
            public bool DeployHowTosWeb { get; set; }
        }

        #endregion

        #region methods

        public void DeployIntranet(ClientContext context)
        {
            DeployIntranet(context, new Options
            {
                DeploySite = true,
                DeployRootWeb = true,
                DeployHowTosWeb = true
            });
        }

        public void DeployIntranet(ClientContext context, Options options)
        {
            // pushing site model
            if (options.DeploySite)
            {
                var siteModel = new IntrSiteModel();

                this.DeploySiteModel(context, siteModel.GetSiteFeaturesModel());
                this.DeploySiteModel(context, siteModel.GetUserCustomActionModel());
                this.DeploySiteModel(context, siteModel.GetSiteSecurityModel());

                this.DeploySiteModel(context, siteModel.GetFieldsAndContentTypesModel());
                this.DeploySiteModel(context, siteModel.GetSandboxSolutionsModel());
            }

            // pushing root web model
            if (options.DeployRootWeb)
            {
                var rootWebModel = new IntrRootWebModel();

                this.DeployWebModel(context, rootWebModel.GetStyleLibraryModel());
                this.DeployWebModel(context, rootWebModel.GetModel());
            }

            // pushing 'How-tow' sub web
            if (options.DeployHowTosWeb)
            {
                var howTosWebModel = new IntrHowTosWebModel();
                this.DeployWebModel(context, howTosWebModel.GetModel());
            }
        }

        #endregion
    }
}
