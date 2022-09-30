using Microsoft.EntityFrameworkCore;
using ToDoList.Infrastructure.Models;

namespace ToDoList.Infrastructure;

public class ToDoContext : DbContext
{
    public ToDoContext()
    {
    }

    public ToDoContext(DbContextOptions<ToDoContext> options)
        : base(options)
    {
    }

    public DbSet<ToDo> ToDo { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            throw new ArgumentException("ConnectionString is ;not configured properly", nameof(optionsBuilder));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDo>(entity =>
        {
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(x => x.DateTime).IsRequired();
        });
    }

}