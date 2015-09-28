using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevExpressControls.Models
{
    using DevExpressControls.Helpers;

    public class TaskResource
    {
        public int TaskResID { get; set; }
        [Required(ErrorMessage = "Resource is required")]
        public string Resource { get; set; }
        [Required(ErrorMessage = "CalculationSource is required")]
        public string CalculationSource { get; set; }
        public float Quantity { get; set; }
        public float UnitCost { get; set; }
        public DateTime CalculationStartDate { get; set; }
        public DateTime? CalculationEndDate { get; set; }
        public float? TotalCost { get; set; }

        public static class TaskResourcesProvider
        {
            private static List<TaskResource> TaskResList;

            public static IList GetTaskResources()
            {
                if (TaskResList == null) {
                    TaskResList = new List<TaskResource>(){
                        new TaskResource() {TaskResID = 1, Resource = "ENG01", CalculationSource ="A1", Quantity = 50, UnitCost = 50, CalculationStartDate= DateTime.Now, CalculationEndDate = DateTime.Now, TotalCost= 2500 },
                        new TaskResource() {TaskResID = 2, Resource = "ENG02", CalculationSource ="B1", Quantity = 20, UnitCost = 50, CalculationStartDate= DateTime.Now, CalculationEndDate = DateTime.Now, TotalCost= 1000 },
                        new TaskResource() {TaskResID = 3, Resource = "ENG03", CalculationSource ="C1", Quantity = 30, UnitCost = 50, CalculationStartDate= DateTime.Now, CalculationEndDate = DateTime.Now, TotalCost= 1500 },
                        new TaskResource() {TaskResID = 4, Resource = "ENG04", CalculationSource ="A1", Quantity = 50, UnitCost = 50, CalculationStartDate= DateTime.Now, CalculationEndDate = DateTime.Now, TotalCost= 2500 },
                        new TaskResource() {TaskResID = 5, Resource = "ENG05", CalculationSource ="B1", Quantity = 20, UnitCost = 50, CalculationStartDate= DateTime.Now, CalculationEndDate = DateTime.Now, TotalCost= 1000 },
                        new TaskResource() {TaskResID = 6, Resource = "ENG01", CalculationSource ="C1", Quantity = 30, UnitCost = 50, CalculationStartDate= DateTime.Now, CalculationEndDate = DateTime.Now, TotalCost= 1500 },
                        new TaskResource() {TaskResID = 7, Resource = "ENG01", CalculationSource ="A1", Quantity = 50, UnitCost = 50, CalculationStartDate= DateTime.Now, CalculationEndDate = DateTime.Now, TotalCost= 2500 },
                        new TaskResource() {TaskResID = 8, Resource = "ENG02", CalculationSource ="B1", Quantity = 20, UnitCost = 50, CalculationStartDate= DateTime.Now, CalculationEndDate = DateTime.Now, TotalCost= 1000 },
                        new TaskResource() {TaskResID = 9, Resource = "ENG01", CalculationSource ="C1", Quantity = 30, UnitCost = 50, CalculationStartDate= DateTime.Now, CalculationEndDate = DateTime.Now, TotalCost= 1500 },
                        new TaskResource() {TaskResID = 10, Resource = "ENG01", CalculationSource ="A1", Quantity = 50, UnitCost = 50, CalculationStartDate= DateTime.Now, CalculationEndDate = DateTime.Now, TotalCost= 2500 },
                        new TaskResource() {TaskResID = 11, Resource = "ENG02", CalculationSource ="B1", Quantity = 20, UnitCost = 50, CalculationStartDate= DateTime.Now, CalculationEndDate = DateTime.Now, TotalCost= 1000 },
                        new TaskResource() {TaskResID = 12, Resource = "ENG01", CalculationSource ="C1", Quantity = 30, UnitCost = 50, CalculationStartDate= DateTime.Now, CalculationEndDate = DateTime.Now, TotalCost= 1500 },
                        new TaskResource() {TaskResID = 12, Resource = "ENG01", CalculationSource ="A1", Quantity = 50, UnitCost = 50, CalculationStartDate= DateTime.Now, CalculationEndDate = DateTime.Now, TotalCost= 2500 },
                        new TaskResource() {TaskResID = 14, Resource = "ASSEM", CalculationSource ="B1", Quantity = 20, UnitCost = 50, CalculationStartDate= DateTime.Now, CalculationEndDate = DateTime.Now, TotalCost= 1000 },
                    };
                }
                return TaskResList;
            }

            public static TaskResource FindTaskRes(int taskResID)
            {
                return TaskResList.Find(x => x.TaskResID == taskResID);
            }

            public static void DeleteTaskResource(int taskResID)
            {
                TaskResource dbEntry = FindTaskRes(taskResID);
                if (dbEntry != null)
                    TaskResList.Remove(dbEntry);
            }

            public static void UpdateTaskResource(TaskResource item)
            {
                TaskResource dbEntry = FindTaskRes(item.TaskResID);
                if (dbEntry != null)
                {
                    dbEntry.Resource = item.Resource;
                    dbEntry.CalculationEndDate = item.CalculationEndDate;
                    dbEntry.CalculationStartDate = item.CalculationStartDate;
                    dbEntry.CalculationSource = item.CalculationSource;
                    dbEntry.UnitCost = item.UnitCost;
                    dbEntry.Quantity = item.Quantity;
                    dbEntry.TotalCost = CalculateTotalCost(item);
                }
            }

            public static void AddTaskResource(TaskResource item)
            {
                TaskResource dbEntry = new TaskResource();
                dbEntry.TaskResID = GetNewTaskResID();
                dbEntry.Resource = item.Resource;
                dbEntry.CalculationEndDate = item.CalculationEndDate;
                dbEntry.CalculationStartDate = item.CalculationStartDate;
                dbEntry.CalculationSource = item.CalculationSource;
                dbEntry.UnitCost = item.UnitCost;
                dbEntry.Quantity = item.Quantity;
                dbEntry.TotalCost = CalculateTotalCost(item);
                TaskResList.Add(dbEntry);
            }

            private static int GetNewTaskResID()
            {
                return TaskResList.Count + 1;
            }
            private static float CalculateTotalCost(TaskResource item)
            {
                var CellValue = SpreadsheetFormulaHelper.GetCellValue(item.CalculationSource);
                return (item.UnitCost * item.Quantity);
            }
        }

    }
}