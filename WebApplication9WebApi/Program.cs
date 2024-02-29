using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApplication9WebApi.Models.DB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FormazioneDbContext>(options => options.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Initial Catalog=FormazioneDb;Persist Security Info=False;MultipleActiveResultSets=False;Connection Timeout=30;"));
builder.Services.AddHttpClient().AddEndpointsApiExplorer();
builder.Services.AddMediatR(configuration => 
    configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
