using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserManagement.API.Config;
using UserManagement.Application.Services;
using UserManagement.Application.Services.IService;
using UserManagement.Persistence;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MsSqlContext>(options => options.UseSqlServer(connection));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<ICityService, CityService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<MsSqlContext>();
    dataContext.Database.Migrate();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
