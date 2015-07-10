using System.Web.Mvc;

namespace Nop.Brigita
{
    public class BrigitaAreaRegistration : AreaRegistration
    {
        public override string AreaName {
            get { return "Brigita"; }
        }

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute(
                "Brigita_default",
                "brigita/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", area = "Brigita", id = "" },
                new[] { "Nop.Brigita.Controllers" }
            );
        }
    }
}
