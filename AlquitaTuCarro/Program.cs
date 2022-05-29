using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AlquitaTuCarro.Data;
using AlquitaTuCarro.Services;
using AlquitaTuCarro.Helpers;
using AlquitaTuCarro.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AlquitaTuCarroContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AlquitaTuCarroContext") ?? throw new InvalidOperationException("Connection string 'AlquitaTuCarroContext' not found.")));

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
// configure automapper with all automapper profiles from this assembly
builder.Services.AddAutoMapper(typeof(Program));

// configure strongly typed settings object
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// configure DI for application services
builder.Services.AddScoped<IJwtUtils, JwtUtils>();
builder.Services.AddScoped<IUserService, UserService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
