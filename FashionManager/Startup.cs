using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FashionManager.Startup))]
namespace FashionManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
