using Microsoft.AspNetCore.Mvc;
using XyAuto.It.Web.Controllers;

namespace XyAuto.It.Web.Public.Controllers
{
    public class HomeController : AbpZeroTemplateControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
