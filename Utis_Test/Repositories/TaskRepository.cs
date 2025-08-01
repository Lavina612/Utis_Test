using Microsoft.EntityFrameworkCore;
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

        public List<TaskEntity> GetAll(int page, int pageSize)
        {
            return _context.Tasks
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(x => x.Status)
                .ToList();
        }

        public List<TaskEntity> GetByStatus(string status, int page, int pageSize)
        {
            return _context.Tasks
                .Where(x => x.Status.Name.ToLower() == status.ToLower())
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(x => x.Status)
                .ToList();
        }

        public TaskEntity? GetById(int id)
        {
            return _context.Tasks
                .Include(x => x.Status)
                .FirstOrDefault(x => x.Id == id);
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

        public int? GetStatusIdByStatusName(string statusName)
        {
            var status = _context.TaskStatuses.FirstOrDefault(x => x.Name.ToLower() == statusName.ToLower());
            return status?.Id;
        }
    }
}
