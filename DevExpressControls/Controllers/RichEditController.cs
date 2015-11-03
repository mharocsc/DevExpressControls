using System.Web.Mvc;

namespace DevExpressControls.Controllers
{
    using DevExpressControls.Models;

    public class RichEditController : Controller
    {
        public ActionResult RichEdit()
        {
            return View();
        }

        public ActionResult RichEditPartial()
        {
            return PartialView("RichEditPartial");
        }

        public ActionResult VarListBoxPartial()
        {
            var model = Resource.ResourcesProvider.GetResources();
            return PartialView("VarListBoxPartial", model);
        }

        public ActionResult VarDetailsPartial(string resource)
        {
            var model = Variable.VariableProvider.GetOptions(resource);
            return PartialView("VarDetailsPartial", model);
        }
    }
}