using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace Triage.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : TriageControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}