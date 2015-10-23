using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}