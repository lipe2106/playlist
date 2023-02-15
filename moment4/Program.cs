using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using moment4.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Db connections
builder.Services.AddDbContext<PlaylistContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("PlaylistDbString"), new MySqlServerVersion(new Version())));

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
