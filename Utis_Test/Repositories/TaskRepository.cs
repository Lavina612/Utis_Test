using System.Collections.Generic;
using System.Linq;
using Utis_Test.Interfaces;
using Utis_Test.Models;

namespace Utis_Test.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IApplicationDbContext _context;

        public TaskRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TaskModel> GetAllTasks()
        {
            return _context.Tasks.AsEnumerable();
        }

        public TaskModel? GetTaskById(int id)
        {
            return _context.Tasks.FirstOrDefault(x => x.Id == id);
        }

        public TaskModel AddTask(TaskModel task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return task;
        }

        public TaskModel? UpdateTask(int id, TaskModel task)
        {
            var updatingTask = GetTaskById(id);

            if (updatingTask != null)
            {
                updatingTask.UpdateProperties(task);
                _context.SaveChanges();
                return updatingTask;
            }

            return null;
        }

        public void DeleteTask(int id)
        {
            var task = GetTaskById(id);

            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }
    }
}
