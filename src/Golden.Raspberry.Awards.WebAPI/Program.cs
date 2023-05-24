using Golden.Raspberry.Awards.WebAPI.Commands;
using Golden.Raspberry.Awards.WebAPI.Configurations;
using Golden.Raspberry.Awards.WebAPI.Infra.Management;
using Golden.Raspberry.Awards.WebAPI.Infra.Seeding;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureDatabaseDepenency(builder.Configuration);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ISeedDatabase, MovieSeed>();
builder.Services.AddTransient<AwardRangeCommandHandler>();

var app = builder.Build();
app.ApplyMigrations();
await app.SeedDataAsync();

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
