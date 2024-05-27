using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectEF;
using Npgsql;
using System.Formats.Tar;
using projectEF.Models;


var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddDbContext<TaskContext>(p => p.UseInMemoryDatabase("DBTasks"));
builder.Services.AddDbContext<TaskContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DBTasksConection")));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconexion", async ([FromServices] TaskContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de Datos en memoria: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tasks", async ([FromServices] TaskContext dbContext) =>
{
    // return Results.Ok(dbContext.tasks.Include(p => p.Category).Where(p => p.PriorityTask == projectEF.Models.Priority.Baja));
    return Results.Ok(dbContext.tasks.Include(p => p.Category));
});

app.MapPost("/api/tasks", async ([FromServices] TaskContext dbContext, [FromBody] projectEF.Models.Task task) =>
{
    task.Id = Guid.NewGuid();
    task.CreateDate = DateTime.UtcNow;
    await dbContext.AddAsync(task);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});


app.Run();
