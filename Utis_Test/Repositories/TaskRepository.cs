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

        public List<TaskModel> GetAll()
        {
            return _context.Tasks.ToList();
        }

        public TaskModel? GetById(int id)
        {
            return _context.Tasks.FirstOrDefault(x => x.Id == id);
        }

        public void Add(TaskModel addingTask)
        {
            _context.Tasks.Add(addingTask);
            _context.SaveChanges();
        }

        public void Update(TaskModel updatingTask)
        {
            _context.Tasks.Update(updatingTask);
            _context.SaveChanges();
        }

        public void Delete(TaskModel deletingTask)
        {
            _context.Tasks.Remove(deletingTask);
            _context.SaveChanges();
        }
    }
}
