using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HireMeCodeFirst.Startup))]
namespace HireMeCodeFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
