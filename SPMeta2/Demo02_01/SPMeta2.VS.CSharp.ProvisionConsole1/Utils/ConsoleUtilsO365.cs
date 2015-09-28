using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using System.Security;

namespace SPMeta2.VS.CSharp.ProvisionConsole1.Utils
{
    public partial class ConsoleUtils
    {
        public virtual void WithO365Context(string siteUrl,
            string userName, string userPassword,
            Action<ClientContext> action)
        {
            // just a little check on URL, saves some typos
            new Uri(siteUrl);

            using (var context = new ClientContext(siteUrl))
            {
                context.Credentials = new SharePointOnlineCredentials(userName, GetSecurePasswordString(userPassword));

                action(context);
            }
        }
        public virtual void WithO365Context(string siteUrl,
            string userName, SecureString userPassword,
            Action<ClientContext> action)
        {
            // just a little check on URL, saves some typos
            new Uri(siteUrl);

            using (var context = new ClientContext(siteUrl))
            {
                context.Credentials = new SharePointOnlineCredentials(userName, userPassword);

                action(context);
            }
        }

    }
}
