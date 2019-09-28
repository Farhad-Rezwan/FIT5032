using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(frez0003_FoodBank_Melb.Startup))]
namespace frez0003_FoodBank_Melb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
