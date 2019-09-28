using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(frez0003_FoodBankMelbourne.Startup))]
namespace frez0003_FoodBankMelbourne
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
