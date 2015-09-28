using System;
using System.Web.Mvc;
using DevExpressControls.Models;
using DevExpressControls.Helpers;

namespace DevExpressControls.Controllers
{
    public class EstimatorController : Controller
    {
        // GET: Estimator
        public ActionResult Home()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult ResourcesViewPartial()
        {
            var model = TaskResource.TaskResourcesProvider.GetTaskResources();
            return PartialView("ResourcesViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ResourcesViewPartialAddNew(TaskResource item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TaskResource.TaskResourcesProvider.AddTaskResource(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("ResourcesViewPartial", TaskResource.TaskResourcesProvider.GetTaskResources());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ResourcesViewPartialUpdate(TaskResource item)
        {
            if (ModelState.IsValid)
            {
                try {
                    TaskResource.TaskResourcesProvider.UpdateTaskResource(item);
                    ViewBag.Source= SpreadsheetFormulaHelper.GetCellValue(item.CalculationSource);
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("ResourcesViewPartial", TaskResource.TaskResourcesProvider.GetTaskResources());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ResourcesViewPartialDelete(int TaskResID)
        {
            if (TaskResID >= 0)
            {
                try {
                    TaskResource.TaskResourcesProvider.DeleteTaskResource(TaskResID);
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("ResourcesViewPartial", TaskResource.TaskResourcesProvider.GetTaskResources());
        }
    }
}