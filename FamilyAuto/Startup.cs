using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FamilyAuto.Startup))]
namespace FamilyAuto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
