using System;
using Utis_Test.Data.Entities;

namespace Utis_Test.Models
{
    public class TaskModel
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public int StatusId { get; set; }

        public TaskModel(int? id, string title, string description, DateTime dueDate, int statusId)
        {
            Id = id;
            Title = title;
            Description = description;
            DueDate = dueDate;
            StatusId = statusId;
        }

        public TaskEntity ToTaskEntity()
        {
            return new TaskEntity(Id ?? 0, Title, Description, DueDate, StatusId);
        }
    }
}
