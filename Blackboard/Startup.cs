using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Blackboard.Startup))]
namespace Blackboard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
