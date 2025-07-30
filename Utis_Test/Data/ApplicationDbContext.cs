using Microsoft.EntityFrameworkCore;
using System;
using Utis_Test.Data.Entities;
using Utis_Test.Interfaces;
using Utis_Test.Models;

namespace Utis_Test.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<TaskStatusEntity> TaskStatuses { get; set; }

        public DbSet<TaskEntity> Tasks { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<TaskModel>()
            //.Property(x => x.Status)
            //.HasConversion(new EnumToStringConverter<TaskStatus>());

            foreach (TaskStatusEnum status in Enum.GetValues(typeof(TaskStatusEnum)))
            {
                modelBuilder.Entity<TaskStatusEntity>().HasData(new TaskStatusEntity((int)status, status.ToString()));
            }
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
