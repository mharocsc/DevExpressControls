using System;
using System.Web.Mvc;

namespace DevExpressControls.Controllers.TaskInput
{
    using DevExpressControls.Models; 
    public partial class TaskInputEditingController : Controller
    {
        // GET: GridView
        public ActionResult TaskInputDefaultEdit()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult TaskInputDefaultEditPartial()
        {
            var model = Task.TaskProvider.GetTasks();
            ViewBag.SummaryFields = SummaryField.SummaryFieldsProvider.GetSummaryFields();
            return PartialView("TaskInputDefaultEditPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult TaskInputDefaultEditAddNew(Task item)
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
            return PartialView("TaskInputDefaultEditPartial", Task.TaskProvider.GetTasks());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TaskInputDefaultEditUpdate(Task item)
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
            return PartialView("TaskInputDefaultEditPartial", Task.TaskProvider.GetTasks());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TaskInputDefaultEditDelete(int taskID)
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
            return PartialView("TaskInputDefaultEditPartial", Task.TaskProvider.GetTasks());
        }
    }
}