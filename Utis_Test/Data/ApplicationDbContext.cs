using Microsoft.EntityFrameworkCore;
using Utis_Test.Interfaces;
using Utis_Test.Models;

namespace Utis_Test.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        //public DbSet<TaskStatus> TaskStatuses { get; set; }

        public DbSet<TaskModel> Tasks { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
