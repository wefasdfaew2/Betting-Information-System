using Microsoft.Owin;

[assembly: OwinStartup(typeof(BettingInformationSystem.Web.Startup))]

namespace BettingInformationSystem.Web
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}