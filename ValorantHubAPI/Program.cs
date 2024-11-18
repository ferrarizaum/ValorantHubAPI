using Microsoft.EntityFrameworkCore;
using ValorantHubAPI.API.Services;
using ValorantHubAPI.Data.Context;
using ValorantHubAPI.Data.Store;

var builder = WebApplication.CreateBuilder(args);

// Configure DbContext as a scoped service (don't use Singleton)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add other services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register services with correct lifetimes
builder.Services.AddSingleton<IAppStore, AppStore>();  // Singleton is fine for a store
builder.Services.AddScoped<IAgentService, AgentService>();
builder.Services.AddScoped<IWeaponService, WeaponService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();