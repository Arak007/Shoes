using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assignment_1_Shoes_200364251.Startup))]
namespace Assignment_1_Shoes_200364251
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
