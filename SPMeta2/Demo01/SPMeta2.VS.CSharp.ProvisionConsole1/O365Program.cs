using SPMeta2.VS.CSharp.ProvisionConsole1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPMeta2.CSOM.Services;
using SPMeta2.Models;
using SPMeta2.VS.CSharp.ProvisionConsole;
using SPMeta2.VS.CSharp1.Services;
using System.Security;

namespace SPMeta2.VS.CSharp.ProvisionConsole1
{
    class O365PProgram
    {
        static void Main(string[] args)
        {
            //var siteUrl = "http://portal";
            //var o365UserName = "o365-user-login";
            //var o365UserPassword = "o365-user-password";
            var siteUrl = AppSettings.IntranetUrl;
            var o365UserName = "mbakirov@mbakirov367.onmicrosoft.com";
            var o365UserPassword = "";

            var consoleUtils = new ConsoleUtils();

            SecureString password = GetPassword();


            consoleUtils.WithO365Context(siteUrl, o365UserName, password, context =>
            {

                var options = new IntrStandardCSOMProvisionService.Options();

                options.DeploySite = AppSettings.ShouldDeploySiteFeatures;
                options.DeployRootWeb = AppSettings.ShouldDeployRootWeb;
                options.DeployHowTosWeb = false;

                (new IntrStandardCSOMProvisionService()).DeployIntranet(context, options);

                //// replace it with your M2 models
                //var siteModel = default(ModelNode);
                //var rotWebModel = default(ModelNode);

                //// create a provision service - CSOMProvisionService or StandardCSOMProvisionService
                //var provisionService = new CSOMProvisionService();

                //// little nice thing, tracing the progress
                //consoleUtils.TraceDeploymentProgress(provisionService);

                //// deploy!
                //provisionService.DeploySiteModel(context, siteModel);
                //provisionService.DeployWebModel(context, rotWebModel);
            });
        }


        private static SecureString storedPassword = null;
        private static SecureString GetPassword()
        {
            if (storedPassword == null)
            {
                Console.WriteLine("Please enter your password");
                storedPassword = GetConsoleSecurePassword();
                Console.WriteLine();
            }
            return storedPassword;
        }





        private static SecureString GetConsoleSecurePassword()
        {
            SecureString pwd = new SecureString();
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    pwd.RemoveAt(pwd.Length - 1);
                    Console.Write("\b \b");
                }
                else
                {
                    pwd.AppendChar(i.KeyChar);
                    Console.Write("*");
                }
            }
            return pwd;
        }

    }
}
