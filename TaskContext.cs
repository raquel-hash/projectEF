using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using projectEF.Models;

namespace projectEF;

public class TaskContext : DbContext
{

    public DbSet<Category> categories { get; set; }

    public DbSet<Models.Task> tasks { get; set; }

    public TaskContext(DbContextOptions<TaskContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Category> categoriesInit = new List<Category>();
        categoriesInit.Add(new Category() { Id = Guid.Parse("989c5a75-4667-464b-b0da-9f63e7b0c1c7"), Name = "Actividades pendientes", Weight = 20 });
        categoriesInit.Add(new Category() { Id = Guid.Parse("989c5a75-4667-464b-b0da-9f63e7b0c102"), Name = "Actividades Personales", Weight = 50 });

        modelBuilder.Entity<Category>(category =>
        {
            category.ToTable("Category");
            category.HasKey(p => p.Id);
            category.Property(p => p.Name).IsRequired().HasMaxLength(150);
            category.Property(p => p.Description).IsRequired(false);
            category.Property(p => p.Weight);

            category.HasData(categoriesInit);
        });

        List<Models.Task> tasksInit = new List<Models.Task>();

        tasksInit.Add(new Models.Task() { Id = Guid.Parse("989c5a75-4667-464b-b0da-9f63e7b0c110"), CategoriaId = Guid.Parse("989c5a75-4667-464b-b0da-9f63e7b0c1c7"), PriorityTask = Priority.Media, Title = "Pago de servicios publicos", CreateDate = DateTime.UtcNow });
        tasksInit.Add(new Models.Task() { Id = Guid.Parse("989c5a75-4667-464b-b0da-9f63e7b0c111"), CategoriaId = Guid.Parse("989c5a75-4667-464b-b0da-9f63e7b0c102"), PriorityTask = Priority.Baja, Title = "Terminar de ver pelicula en Netflix", CreateDate = DateTime.UtcNow });

        modelBuilder.Entity<Models.Task>(task =>
        {
            task.ToTable("Task");
            task.HasKey(p => p.Id);
            task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoriaId);
            task.Property(p => p.Title).IsRequired().HasMaxLength(200);
            task.Property(p => p.Description).IsRequired(false);
            task.Property(p => p.PriorityTask);
            task.Property(p => p.CreateDate).HasColumnType("timestamp with time zonee");
            task.Ignore(p => p.Resume);

            task.HasData(tasksInit);
        });
    }
}
