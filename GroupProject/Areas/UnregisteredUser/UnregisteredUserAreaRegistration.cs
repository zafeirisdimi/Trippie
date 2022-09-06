using System.Web.Mvc;

namespace GroupProject.Areas.UnregisteredUser
{
    public class UnregisteredUserAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "UnregisteredUser";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "UnregisteredUser_default",
                "UnregisteredUser/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}