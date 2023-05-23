using Golden.Raspberry.Awards.WebAPI.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetSection("ConnectionString:Sqlite");

if (connection is null)
{
    throw new Exception("The database connection has not been set up.");
}

builder.Services.AddDbContext<SqliteContext>(options =>
    options.UseSqlite(connection.Value)
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var reportScope = app.Services.CreateScope())
{
    var context = reportScope.ServiceProvider.GetService<SqliteContext>();
    if (context is null)
    {
        throw new Exception("Invalid context.");
    }

    context.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
