using System;
using System.Web.Mvc;

namespace DevExpressControls.Controllers.TaskInput
{
    using DevExpressControls.Models;
    public partial class TaskInputEditingController : Controller
    {
        // GET: GridView
        public ActionResult TaskInputPopupEditing()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult TaskInputPopupEditingPartial()
        {
            var model = Task.TaskProvider.GetTasks();
            ViewBag.SummaryFields = SummaryField.SummaryFieldsProvider.GetSummaryFields();
            return PartialView("TaskInputPopupEditingPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult TaskInputPopupEditingAddNew(Task item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Task.TaskProvider.AddTask(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            ViewBag.SummaryFields = SummaryField.SummaryFieldsProvider.GetSummaryFields();
            return PartialView("TaskInputPopupEditingPartial", Task.TaskProvider.GetTasks());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TaskInputPopupEditingUpdate(Task item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Task.TaskProvider.UpdateTask(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            ViewBag.SummaryFields = SummaryField.SummaryFieldsProvider.GetSummaryFields();
            return PartialView("TaskInputPopupEditingPartial", Task.TaskProvider.GetTasks());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TaskInputPopupEditingDelete(int taskID)
        {
            if (taskID >= 0)
            {
                try
                {
                    Task.TaskProvider.DeleteTask(taskID);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            ViewBag.SummaryFields = SummaryField.SummaryFieldsProvider.GetSummaryFields();
            return PartialView("TaskInputPopupEditingPartial", Task.TaskProvider.GetTasks());
        }
    }
}