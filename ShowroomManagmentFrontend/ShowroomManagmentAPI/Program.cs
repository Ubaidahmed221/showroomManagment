using Microsoft.EntityFrameworkCore;
using ShowroomManagmentAPI.Data;
using ShowroomManagmentAPI.Models;
using ShowroomManagmentAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(x => x.AddPolicy(MyAllowSpecificOrigins, policy =>
{
    policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
}));
builder.Services.AddDbContext<ApplicationDbContext>(x =>
x.UseSqlServer(builder.Configuration.GetConnectionString("default")));

//---------------------------- Model Dependencies -------------------------------------------
builder.Services.AddScoped<IDepartment, DepartmentModel>();
builder.Services.AddScoped<IEmpolyee, EmpolyeeModel>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
