using System.Collections.Generic;
using Utis_Test.Models;

namespace Utis_Test.Interfaces
{
    public interface ITaskService
    {
        public IEnumerable<TaskModel> GetAllTasks();

        public TaskModel? GetTaskById(int id);

        public TaskModel AddTask(TaskModel task);

        public TaskModel? UpdateTask(int id, TaskModel task); 
        
        public void DeleteTask(int id);
    }
}
