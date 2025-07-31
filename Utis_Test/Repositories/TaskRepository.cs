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

        public List<TaskEntity> GetAll()
        {
            return _context.Tasks
                .Include(x => x.Status)
                .ToList();
        }

        public List<TaskEntity> GetByStatus(string status)
        {
            return _context.Tasks
                .Where(x => x.Status.StatusName.ToLower() == status.ToLower())
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
            try
            {
                addingTask.Status = _context.TaskStatuses
                    .First(x => x.StatusName.ToLower() == addingTask.Status.StatusName.ToLower());
            }
            catch (InvalidOperationException ex)
            {
                //логирование
                return;
            }

            _context.Tasks.Add(addingTask);
            _context.SaveChanges();
        }

        public bool Update(TaskEntity updatingTask)
        {
            try
            {
                updatingTask.Status = _context.TaskStatuses
                    .First(x => x.StatusName.ToLower() == updatingTask.Status.StatusName.ToLower());
            }
            catch (InvalidOperationException ex)
            {
                //логирование
                return false;
            }

            _context.Tasks.Update(updatingTask);
            _context.SaveChanges();
            return true;
        }

        public void Delete(TaskEntity deletingTask)
        {
            _context.Tasks.Remove(deletingTask);
            _context.SaveChanges();
        }
    }
}
