using System;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;

using Owin;
using TwitterProxy.Models;

namespace TwitterProxy
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");
        }
    }
}