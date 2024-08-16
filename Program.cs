using Microsoft.EntityFrameworkCore;
using VehicleAPI.CoreServices.CoreData;
using VehicleAPI.CoreServices.ServiceInterface;
using VehicleAPI.Data;
using VehicleAPI.Infrastructure.DataRepository;
using VehicleAPI.Infrastructure.RepositoryInterface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<VehicleRegistrationContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("VehicleRegistrationConnection")));

builder.Services.AddTransient<IVehicleRepo, VehicleRepo>();
builder.Services.AddTransient<IVehicleService, VehicleService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
