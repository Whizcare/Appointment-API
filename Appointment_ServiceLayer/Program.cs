using BussinessLogic;
using DataEntities;
using Appointment_DataEntities.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = builder.Configuration.GetConnectionString("AppointmentDB");
builder.Services.AddDbContext<AppointmentDbContext>(options => options.UseSqlServer(config));

builder.Services.AddScoped<IAppointment, AppointmentLogic>();
builder.Services.AddScoped<IAppointmentRepo, AppointmentRepo>();

builder.Services.AddScoped<IPatientCheckUP,PatientCheckUpLogic>();
builder.Services.AddScoped<IPatientCheckUpRepo, PatientCheckUpRepo>();

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        }
        )
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
