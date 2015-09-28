using System.Web.Mvc;

namespace DevExpressControls.Controllers
{
    public class DockController : Controller
    {
        // GET: Dock
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LockedDock()
        {
            return View();
        }

        public  ActionResult Widgets()
        {
            //ViewData["DateFromDock"] = "View Data from DockController";
            return View();
        }

        public ActionResult PopupWindow()
        {         
            return View();
        }
    }
}