using ValorantHubAPI.API.Services;
using ValorantHubAPI.Data.Context;
using ValorantHubAPI.Data.Store;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<IAppDbContext, AppDbContext>();
builder.Services.AddSingleton<IAppStore, AppStore>();
builder.Services.AddSingleton<AppDbContext, AppDbContext>();
builder.Services.AddScoped<IAgentService, AgentService>();
builder.Services.AddScoped<IWeaponService, WeaponService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();