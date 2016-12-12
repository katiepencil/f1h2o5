using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(f1h2o5.Startup))]
namespace f1h2o5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
