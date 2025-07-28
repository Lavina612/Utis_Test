using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Utis_Test.Interfaces;
using Utis_Test.Models;

namespace Utis_Test.Services
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        //public DbSet<TaskStatus> TaskStatuses { get; set; }

        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5433;Database=postgres;User Id=postgres;Password=***;");
        }

        public IEnumerable<TaskModel> GetAllTasks()
        {
            return Tasks.AsEnumerable();
        }

        public TaskModel? GetTaskById(int id)
        {
            return Tasks.FirstOrDefault(x => x.Id == id);
        }

        public TaskModel AddTask(TaskModel task)
        {
            Tasks.Add(task);
            SaveChanges();
            return task;
        }

        public TaskModel? UpdateTask(int id, TaskModel task)
        {
            var updatingTask = GetTaskById(id);

            if (updatingTask != null)
            {
                updatingTask.UpdateProperties(task);
                SaveChanges();
                return updatingTask;
            }

            return null;
        }

        public void DeleteTask(int id)
        {
            var task = GetTaskById(id);

            if (task != null)
            {
                Tasks.Remove(task);
                SaveChanges();
            }
        }
    }
}
