using GeneralskiiProizvPractice.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

string connection =
    "server=DESKTOP-IREDSCJ\\SQLEXPRESS; user=alnix; Password=123;  Database=WholesaleBase;";
builder.Services.AddDbContext<WholesaleBaseContext>(op => op.UseSqlServer(connection));
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
