using System;
using System.ComponentModel.DataAnnotations.Schema;
using Utis_Test.Models;

namespace Utis_Test.Data.Entities
{
    public class TaskEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public int StatusId { get; set; }

        [ForeignKey(nameof(StatusId))]
        public TaskStatusEntity Status { get; set; }

        public TaskEntity(int id, string title, string description, DateTime dueDate, int statusId)
        {
            Id = id;
            Title = title;
            Description = description;
            DueDate = dueDate;
            StatusId = statusId;
        }

        public TaskEntity(int id, string title, string description, DateTime dueDate, string statusName)
        {
            Id = id;
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = new TaskStatusEntity(-1, statusName);
        }

        public void UpdateProperties(TaskModel newTask)
        {
            Title = newTask.Title;
            Description = newTask.Description;
            DueDate = newTask.DueDate;
            Status.StatusName = newTask.StatusName;
        }

        public TaskModel ToTaskModel()
        {
            return new TaskModel(Id, Title, Description, DueDate, Status.StatusName);
        }
    }
}
