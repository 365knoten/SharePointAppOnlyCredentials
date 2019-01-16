using OfficeDevPnP.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePointAppOnlyCredentials
{
    class Program
    {
        static void Main(string[] args)
        {

            string siteUrl = ConfigurationManager.AppSettings.Get("SiteUrl");
            string appid = ConfigurationManager.AppSettings.Get("AppID");
            string secret = ConfigurationManager.AppSettings.Get("AppSecret");

            using (var cc = new AuthenticationManager().GetAppOnlyAuthenticatedContext(siteUrl,appid,secret))
            {
                cc.Load(cc.Web, p => p.Title);
                cc.ExecuteQuery();
                Console.WriteLine(cc.Web.Title);
                Console.ReadLine();
            }
            }
        }
}
