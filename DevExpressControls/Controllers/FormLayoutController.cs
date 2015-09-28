using System;
using System.Web.Mvc;
using DevExpressControls.Models;
using System.Collections;

namespace DevExpressControls.Controllers
{
    public class FormLayoutController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DetailsViewPartial()
        {
            return PartialView("_DetailsViewPartial");
        }
        
        [ValidateInput(false)]
        public ActionResult ResourcesViewPartial()
        {
            var model = TaskResource.TaskResourcesProvider.GetTaskResources();
            return PartialView("_ResourcesViewPartial", model);
        }

        public ActionResult FormulaViewPartial()
        {
            return PartialView("_FormulaViewPartial");
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ResourcesViewPartialAddNew(DevExpressControls.Models.TaskResource item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_ResourcesViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ResourcesViewPartialUpdate(DevExpressControls.Models.TaskResource item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_ResourcesViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ResourcesViewPartialDelete(System.Int32 TaskResID)
        {
            var model = new object[0];
            if (TaskResID >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_ResourcesViewPartial", model);
        }
    }
}