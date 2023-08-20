using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebChat.LCSK.Startup))]

namespace WebChat.LCSK
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
