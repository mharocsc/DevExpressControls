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
        public ActionResult TaskInputExternalEditing()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult TaskInputExternalEditingPartial()
        {
            var model = Task.TaskProvider.GetTasks();
            ViewBag.SummaryFields = SummaryField.SummaryFieldsProvider.GetSummaryFields();
            return PartialView("TaskInputExternalEditingPartial", model);
        }

        [HttpGet]
        public ActionResult ExternalEditFormEdit(int taskID)
        {
            Task editTask = Task.TaskProvider.FindTask(taskID);
            if (editTask == null)
            {
                editTask = new Task();
                editTask.TaskID = -1;
            }
            ViewBag.Title = editTask.TaskID == -1 ? "New Task": "Task Edit";
            ViewBag.SummaryFields = SummaryField.SummaryFieldsProvider.GetSummaryFields();
            return PartialView("TaskEditingForm", editTask);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ExternalEditFormEdit(Task task)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.SummaryFields = SummaryField.SummaryFieldsProvider.GetSummaryFields();
                return PartialView("TaskEditingForm", task);
            }

            if (task.TaskID == -1)
                Task.TaskProvider.AddTask(task);
            else
                Task.TaskProvider.UpdateTask(task);
            return RedirectToAction("TaskInputExternalEditing");
        }
        public ActionResult ExternalEditFormDelete(int taskID)
        {
            Task.TaskProvider.DeleteTask(taskID);
            return RedirectToAction("TaskInputExternalEditing");
        }

        /*
        [HttpPost]
        public JsonResult doesTaskNameExist(string taskName)
        {
            var task = Task.TaskProvider.FindTaskbyName(taskName);
            return Json(task == null);
        }
        */
    }
}