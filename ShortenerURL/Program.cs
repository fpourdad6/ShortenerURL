using Microsoft.EntityFrameworkCore;
using ShortenerURL.Infra.Data.Sql;
using ShortenerURL.Models;

var builder = WebApplication.CreateBuilder(args);
var cnnString = builder.Configuration.GetConnectionString("ShortenerConnection");
builder.Services.AddDbContext<ShortenerDbContext>(options => options.UseSqlServer(cnnString));

// Add services to the container.
builder.Services.AddScoped<IShortenerUrl, ShortenerUrlRepository>();

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();


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
