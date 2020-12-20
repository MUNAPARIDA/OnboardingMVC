using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnBoardingGIC.Startup))]
namespace OnBoardingGIC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
