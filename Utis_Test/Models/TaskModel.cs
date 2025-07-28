using System;

namespace Utis_Test.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public TaskStatus Status { get; set; }

        public TaskModel(string title, string description, DateTime dueDate, TaskStatus status) { 
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = status;
        }

        public void UpdateProperties(TaskModel task)
        {
            Title = task.Title;
            Description = task.Description;
            DueDate = task.DueDate;
            Status = task.Status;
        }
    }
}
