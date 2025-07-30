using System.Collections.Generic;
using Utis_Test.Models;

namespace Utis_Test.Interfaces
{
    public interface ITaskService
    {
        public List<TaskModel> GetAllTasks();

        public List<TaskModel> GetTasksByStatus(string status);

        public TaskModel? GetTaskById(int id);

        public int AddTask(TaskModel task);

        public bool UpdateTask(int id, TaskModel task); 
        
        public void DeleteTask(int id);
    }
}
