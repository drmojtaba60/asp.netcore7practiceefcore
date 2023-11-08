using EfCorePractice.Persistence;
using EfCorePractice.Persistence.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Register the MyDbContextAppTesting
builder.Services.AddDbContext<PracticeDbContext>(options =>
{
    var UseInMemoryDatabase = builder.Configuration.GetValue<bool>("ConnectionStrings:UseInMemoryDatabase");
    if (UseInMemoryDatabase)
        options.UseInMemoryDatabase("MyDbContextAppTesting");
    else
        options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbContext"));

});
              

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("api/students", async (PracticeDbContext dbContext) =>
{
    return Results.Ok(dbContext.Students.AsNoTracking().ToList());
});

app.MapGet("api/class-rooms", async (PracticeDbContext dbContext) =>Results.Ok(dbContext.Set<ClassRoom>().AsNoTracking().ToList()));

// error 500 Cannot create a DbSet for 'ClassRoomAsTestNoMapped' because this type is not included in the model for the context.
//for slove problem add Property DbSet :DbSet<ClassRoomAsTestNoMapped> or Apply Configuration on class ClassRoomAsTestNot Mapped
app.MapGet("api/class-rooms/entity-nomapped-tested", async (PracticeDbContext dbContext) => Results.Ok(dbContext.Set<ClassRoomAsTestNoMapped>().AsNoTracking().ToList()));


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
