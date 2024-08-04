using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using proyecto_final_prog2.Domain.Entities;

namespace proyecto_final_prog2.Infrastructure
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Domain.Entities.Task> tasks { get; set; }
        public DbSet<Domain.Entities.Tag> tags { get; set; }
        public DbSet<Domain.Entities.Column> columns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Task>()
                .HasMany(t => t.tags).WithMany(t => t.tasks)
                .UsingEntity<Dictionary<string, object>>(
                "TaskTag",
                j => j.HasOne<Tag>().WithMany().HasForeignKey("TagID"),
                j => j.HasOne<Domain.Entities.Task>().WithMany().HasForeignKey("TaskID")
                );
        }
    }
}
