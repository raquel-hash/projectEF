using Microsoft.EntityFrameworkCore;
using projectEF.Models;

namespace projectEF;

public class TaskContext : DbContext
{

    public DbSet<Category> categories { get; set; }

    public DbSet<Models.Task> tasks { get; set; }

    public TaskContext(DbContextOptions<TaskContext> options) {}
}
