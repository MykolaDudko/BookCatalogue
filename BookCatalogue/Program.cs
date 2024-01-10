using Library.Context;
using Library.Profiles;
using Library.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var connectionStringName = "DefaultConnection";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString(connectionStringName)));
builder.Services.Scan(scan =>
        scan.FromAssembliesOf(typeof(BaseRepository<>)).AddClasses(classSelector =>
        classSelector.AssignableTo(typeof(BaseRepository<>))));
builder.Services.AddAutoMapper(new Assembly[] { typeof(BookProfile).Assembly});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
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
