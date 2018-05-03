using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MediumBlogv3.Startup))]
namespace MediumBlogv3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
