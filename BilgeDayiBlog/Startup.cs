using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BilgeDayiBlog.Startup))]
namespace BilgeDayiBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
