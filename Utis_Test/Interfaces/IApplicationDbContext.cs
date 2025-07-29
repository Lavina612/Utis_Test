using Microsoft.EntityFrameworkCore;
using Utis_Test.Models;

namespace Utis_Test.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<TaskModel> Tasks { get; set; }

        public int SaveChanges();
    }
}
