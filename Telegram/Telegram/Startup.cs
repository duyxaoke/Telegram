using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Telegram.Startup))]
namespace Telegram
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
