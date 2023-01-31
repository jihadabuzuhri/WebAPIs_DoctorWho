using DoctorWho.Db;
using DoctorWho.Db.Repository;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<DoctorWhoCoreDbContext>(
    dbContextOptionsBuilder => dbContextOptionsBuilder.UseSqlServer(
        builder.Configuration["ConnectionStrings:DoctorWhoCoreDbConnectionString"]));


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IDoctorRepository,DoctorRepository>();
builder.Services.AddScoped<IEpisodeRepository,EpisodeRepository>();


builder.Services.AddControllers()
    .AddFluentValidation(
    fv => fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));


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

app.UseAuthorization();

app.MapControllers();

app.Run();
