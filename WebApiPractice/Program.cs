using EfCorePractice.Persistence;
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
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
