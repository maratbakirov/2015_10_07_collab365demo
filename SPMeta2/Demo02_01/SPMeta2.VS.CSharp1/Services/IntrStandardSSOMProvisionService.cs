using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPMeta2.VS.CSharp1.Models;
using SPMeta2.VS.CSharp1.Models.SubWebs;
using Microsoft.SharePoint;
using SPMeta2.SSOM.Services;
using SPMeta2.SSOM.Standard.Services;

namespace SPMeta2.VS.CSharp1.Services
{
    public class IntrStandardSSOMProvisionService : StandardSSOMProvisionService
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

        public void DeployIntranet(SPSite site)
        {
            DeployIntranet(site, new Options
            {
                DeploySite = true,
                DeployRootWeb = true,
                DeployHowTosWeb = true
            });
        }

        public void DeployIntranet(SPSite site, Options options)
        {
            // pushing site model
            if (options.DeploySite)
            {
                var siteModel = new IntrSiteModel();

                this.DeploySiteModel(site, siteModel.GetSandboxSolutionsModel());
                this.DeploySiteModel(site, siteModel.GetSiteFeaturesModel());
                this.DeploySiteModel(site, siteModel.GetSiteSecurityModel());
                this.DeploySiteModel(site, siteModel.GetFieldsAndContentTypesModel());
            }

            // pushing root web model
            if (options.DeployRootWeb)
            {
                var rootWebModel = new IntrRootWebModel();

                this.DeployWebModel(site.RootWeb, rootWebModel.GetStyleLibraryModel());
                this.DeployWebModel(site.RootWeb, rootWebModel.GetModel());
            }

            // pushing 'How-tow' sub web
            if (options.DeployHowTosWeb)
            {
                var howTosWebModel = new IntrHowTosWebModel();

                this.DeployWebModel(site.RootWeb, howTosWebModel.GetModel());
            }
        }

        #endregion
    }
}
