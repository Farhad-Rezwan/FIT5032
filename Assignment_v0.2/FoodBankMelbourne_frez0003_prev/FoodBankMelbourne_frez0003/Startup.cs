using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoodBankMelbourne_frez0003.Startup))]
namespace FoodBankMelbourne_frez0003
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
