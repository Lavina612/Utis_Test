using System;
using System.Collections.Generic;
using System.Linq;
using Utis_Test.Data.Entities;
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

        public List<TaskEntity> GetAll()
        {
            return _context.Tasks.ToList();
        }

        public List<TaskEntity> GetByStatus(string status)
        {
            return _context.Tasks.Where(x => x.Status.StatusName.ToLower() == status.ToLower()).ToList();
        }

        public TaskEntity? GetById(int id)
        {
            return _context.Tasks.FirstOrDefault(x => x.Id == id);
        }

        public void Add(TaskEntity addingTask)
        {
            _context.Tasks.Add(addingTask);
            _context.SaveChanges();
        }

        public void Update(TaskEntity updatingTask)
        {
            _context.Tasks.Update(updatingTask);
            _context.SaveChanges();
        }

        public void Delete(TaskEntity deletingTask)
        {
            _context.Tasks.Remove(deletingTask);
            _context.SaveChanges();
        }
    }
}
