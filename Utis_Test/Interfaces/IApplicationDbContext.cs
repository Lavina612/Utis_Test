using Microsoft.EntityFrameworkCore;
using Utis_Test.Data.Entities;

namespace Utis_Test.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<TaskStatusEntity> TaskStatuses { get; set; }

        public DbSet<TaskEntity> Tasks { get; set; }

        public int SaveChanges();
    }
}
