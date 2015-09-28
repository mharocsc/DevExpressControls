using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevExpressControls.Controllers.TaskInput
{
    using DevExpressControls.Models;

    public partial class TaskInputEditingController : Controller
    {

        // GET: TaskInputTemplateEdit
        public ActionResult TaskInputTemplateEditing()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult TaskInputTemplateEditingPartial()
        {
            var model = Task.TaskProvider.GetTasks();
            ViewBag.SummaryFields = SummaryField.SummaryFieldsProvider.GetSummaryFields();
            return PartialView("TaskInputTemplateEditingPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult TaskInputTemplateEditingAddNew(Task item)
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
            {
                ViewData["EditError"] = "Please, correct all errors.";
                ViewData["EditableTask"] = item;
            }
            ViewBag.SummaryFields = SummaryField.SummaryFieldsProvider.GetSummaryFields();
            return PartialView("TaskInputTemplateEditingPartial", Task.TaskProvider.GetTasks());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TaskInputTemplateEditingUpdate(Task item)
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
            {
                ViewData["EditError"] = "Please, correct all errors.";
                ViewData["EditableTask"] = item;
            }
            ViewBag.SummaryFields = SummaryField.SummaryFieldsProvider.GetSummaryFields();
            return PartialView("TaskInputTemplateEditingPartial", Task.TaskProvider.GetTasks());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TaskInputTemplateEditingDelete(int taskID)
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
            return PartialView("TaskInputTemplateEditingPartial", Task.TaskProvider.GetTasks());
        }

    }
}