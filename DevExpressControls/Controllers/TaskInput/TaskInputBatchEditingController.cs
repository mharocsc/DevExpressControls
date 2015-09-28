using System;
using System.Web.Mvc;
using DevExpress.Web;
using DevExpress.Web.Mvc;

namespace DevExpressControls.Controllers.TaskInput
{
    using DevExpressControls.Helpers;
    using DevExpressControls.Models;

    public partial class TaskInputEditingController : Controller
    {
        public ActionResult TaskInputBatchEditing()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult TaskInputBatchEditingPartial()
        {
            var model = Task.TaskProvider.GetTasks();
            ViewBag.SummaryFields = SummaryField.SummaryFieldsProvider.GetSummaryFields();
            return PartialView("TaskInputBatchEditingPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult BatchEditingUpdateModel(MVCxGridViewBatchUpdateValues<Task, int> updateValues)
        {
            foreach (var task in updateValues.Insert)
            {
                if (updateValues.IsValid(task))
                    AddTask(task, updateValues);
            }
            foreach (var task in updateValues.Update)
            {
                if (updateValues.IsValid(task))
                    UpdateProduct(task, updateValues);
            }
            foreach (var taskID in updateValues.DeleteKeys)
            {
                DeleteProduct(taskID, updateValues);
            }
            ViewBag.SummaryFields = SummaryField.SummaryFieldsProvider.GetSummaryFields();
            return PartialView("TaskInputBatchEditingPartial", Task.TaskProvider.GetTasks());
        }

        protected void AddTask(Task item, MVCxGridViewBatchUpdateValues<Task, int> updateValues)
        {
            try
            {
                Task.TaskProvider.AddTask(item);
            }
            catch (Exception e)
            {
                updateValues.SetErrorText(item, e.Message);
            }
        }
        protected void UpdateProduct(Task item, MVCxGridViewBatchUpdateValues<Task, int> updateValues)
        {
            try
            {
                Task.TaskProvider.UpdateTask(item);
            }
            catch (Exception e)
            {
                updateValues.SetErrorText(item, e.Message);
            }
        }
        protected void DeleteProduct(int taskID, MVCxGridViewBatchUpdateValues<Task, int> updateValues)
        {
            try
            {
                Task.TaskProvider.DeleteTask(taskID);
            }
            catch (Exception e)
            {
                updateValues.SetErrorText(taskID, e.Message);
            }
        }
    }
}