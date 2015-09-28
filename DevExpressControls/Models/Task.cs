using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DevExpressControls.Models
{
    public class Task
    {
        [HiddenInput(DisplayValue = false)]
        public int TaskID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SummaryBIDDER { get; set; }
        public string SummaryWBS { get; set; }
        public string SummaryCLIN { get; set; }
        public string SummaryPHASE { get; set; }

        public static class TaskProvider
        {
            private static List<Task> TasksList;

            public static IList GetTasks()
            {
                if (TasksList == null) {
                    TasksList = new List<Task>(){
                        new Task() { TaskID = 1, Name = "Task001", Description = "PROGRAM MANAGEMENT", StartDate= DateTime.Now, EndDate = DateTime.Now, SummaryBIDDER= "SHURANCE", SummaryWBS = "11A", SummaryCLIN = "0001AA", SummaryPHASE ="BASIC" },
                        new Task() { TaskID = 2, Name = "Task002", Description = "DESIGN APPROACH", StartDate= DateTime.Now, EndDate = DateTime.Now, SummaryBIDDER= "SILVER", SummaryWBS = "12A", SummaryCLIN = "0001Ab", SummaryPHASE ="BASIC" },
                        new Task() { TaskID = 3, Name = "Task003", Description = "SOFTWARE DESIGN", StartDate= DateTime.Now, EndDate = DateTime.Now, SummaryBIDDER= "BROWN", SummaryWBS = "13A", SummaryCLIN = "0002AA", SummaryPHASE ="BASIC" },
                        new Task() { TaskID = 4, Name = "Task004", Description = "HARDWARE DESIGN", StartDate= DateTime.Now, EndDate = DateTime.Now, SummaryBIDDER= "BROWN", SummaryWBS = "14A", SummaryCLIN = "0003AA", SummaryPHASE ="BASIC" },
                        new Task() { TaskID = 5, Name = "Task005", Description = "INTEGRATION", StartDate= DateTime.Now, EndDate = DateTime.Now, SummaryBIDDER= "SILVER", SummaryWBS = "21A", SummaryCLIN = "0003AB", SummaryPHASE ="BASIC" }
                    };
                }
                return TasksList;
            }

            public static Task FindTask(int taskID)
            {
                return TasksList.Find(x => x.TaskID == taskID);
            }

            public static Task FindTaskbyName(string taskName)
            {
                return TasksList.Find(x => x.Name == taskName);
            }

            public static void DeleteTask(int taskID)
            {
                Task dbEntry = FindTask(taskID);
                if (dbEntry != null)
                    TasksList.Remove(dbEntry);
            }

            public static void UpdateTask(Task item)
            {
                Task dbEntry = FindTask(item.TaskID);
                if (dbEntry != null)
                {
                    dbEntry.Name = item.Name;
                    dbEntry.Description = item.Description;
                    dbEntry.StartDate = item.StartDate;
                    dbEntry.EndDate = item.EndDate;
                    dbEntry.SummaryBIDDER = item.SummaryBIDDER;
                    dbEntry.SummaryCLIN = item.SummaryCLIN;
                    dbEntry.SummaryPHASE = item.SummaryPHASE;
                    dbEntry.SummaryWBS = item.SummaryWBS;
                }
            }

            public static void AddTask(Task item)
            {
                Task dbEntry = new Task();
                dbEntry.TaskID = GetNewTasID();
                dbEntry.Name = item.Name;
                dbEntry.Description = item.Description;
                dbEntry.StartDate = item.StartDate;
                dbEntry.EndDate = item.EndDate;
                dbEntry.SummaryBIDDER = item.SummaryBIDDER;
                dbEntry.SummaryCLIN = item.SummaryCLIN;
                dbEntry.SummaryPHASE = item.SummaryPHASE;
                dbEntry.SummaryWBS = item.SummaryWBS;
                TasksList.Add(dbEntry);
            }

            private static int GetNewTasID()
            {
                return TasksList.Count + 1;
            }
        }
    }
}