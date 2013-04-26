using System.Web.Mvc;

namespace HipChatCentral.Web.Controllers
{
    public class StatusController : Controller
    {
        //
        // GET: /Status/

        public ActionResult Index()
        {
            return View("~/Views/Status.cshtml");
        }

        //
        // GET: /Status/Details/5
    }
}
