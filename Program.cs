using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectEF;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddDbContext<TaskContext>(p => p.UseInMemoryDatabase("DBTasks"));
builder.Services.AddDbContext<TaskContext>(options => options.UseNpgsql("Server=localhost;Database=DBTasks;Port=5432;User Id=postgres;Password=postgres;"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconexion", async ([FromServices] TaskContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de Datos en memoria: " + dbContext.Database.IsInMemory());
});

app.Run();
