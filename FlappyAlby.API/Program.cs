using FlappyAlby.API.Abstract;
using FlappyAlby.API.Data;
using FlappyAlby.API.Options;
using FlappyAlby.API.Readers;
using FlappyAlby.API.Repository;
using FlappyAlby.API.Writers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services
    .AddOptions<ConnectionStringOptions>()
    .Bind(builder.Configuration.GetSection("ConnectionStrings"))
    .ValidateDataAnnotations();

builder.Services.AddSingleton<IReader, SQLReader>();
builder.Services.AddSingleton<IWriter, SQLWriter>();
builder.Services.AddSingleton<IRankingRepository, RankingRepository>();
builder.Services.AddDbContext<FlappyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDatabase")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(b => b.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();