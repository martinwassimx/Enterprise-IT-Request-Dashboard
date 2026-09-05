using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(MartinTest.Startup))]

namespace MartinTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Enable CORS for ALL origins (must be BEFORE ConfigureAuth)
            // This allows http://localhost:8080 to call https://localhost:44372/token
            app.UseCors(CorsOptions.AllowAll);

            ConfigureAuth(app);
        }
    }
}
