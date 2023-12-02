using CAE.Domain.Interfaces;
using CAE.Domain.Service;
using CAE.Infrastructure.Interfaces;
using CAE.Infrastructure.Repositories;
using CAE.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/// IoC \/
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();


/// Database \/
builder.Services.AddDbContext<AppDbContext>();


/// Application (HTTP) \/
builder.Services.AddControllers();
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
