using Microsoft.EntityFrameworkCore;
using UserManagerAPI.db;
using UserManagerAPI.EndPoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmployeeDb>(opt => opt.UseInMemoryDatabase("employee db"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

EmployeeEndPoints.Map(app);

app.CreateDbIfNotExist();

app.Run();


