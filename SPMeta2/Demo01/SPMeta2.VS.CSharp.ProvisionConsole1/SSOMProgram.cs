using SPMeta2.VS.CSharp.ProvisionConsole1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPMeta2.Models;
using SPMeta2.SSOM.Services;

namespace SPMeta2.VS.CSharp.ProvisionConsole1
{
    class SSOMProgram
    {
        static void Main(string[] args)
        {
            var siteUrl = "http://portal";
            var consoleUtils = new ConsoleUtils();

            consoleUtils.WithSSOMContext(siteUrl, (site, web) =>
            {
                // replace it with your M2 models
                var siteModel = default(ModelNode);
                var rotWebModel = default(ModelNode);

                // create a provision service - SSOMProvisionService or StandardSSOMProvisionService
                var provisionService = new SSOMProvisionService();

                // little nice thing, tracing the progress
                consoleUtils.TraceDeploymentProgress(provisionService);

                // deploy!
                provisionService.DeploySiteModel(site, siteModel);
                provisionService.DeployWebModel(web, rotWebModel);
            });
        }
    }
}
