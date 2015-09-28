using System.Web.Mvc;
using DevExpressControls.Models;

namespace DevExpressControls.Controllers
{
    public partial class MenuController : Controller
    {
        [HttpGet]
        public ActionResult DevExpressMenu()
        {
            ViewData["Options"] = new MenuFeaturesDemoOptions();
            return View();
        }

        [HttpPost]
        public ActionResult DevExpressMenu([Bind]MenuFeaturesDemoOptions options)
        {
            if (!ModelState.IsValid)
            {
                if (!ModelState.IsValidField("AppearAfter"))
                    options.AppearAfter = MenuFeaturesDemoOptions.DefaultAppearAfter;
                if (!ModelState.IsValidField("DisappearAfter"))
                    options.DisappearAfter = MenuFeaturesDemoOptions.DefaultDisappearAfter;
                if (!ModelState.IsValidField("MaximumDisplayLevels"))
                    options.MaximumDisplayLevels = MenuFeaturesDemoOptions.DefaultMaximumDisplayLevels;
            }
            ViewData["Options"] = options;
            return View("DevExpressMenu");
        }

        public ActionResult DevExpressBindingToXML()
        {
            ViewData["XPath"] = "/Menu/*";
            return PartialView();
        }
    }
}