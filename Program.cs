using Microsoft.EntityFrameworkCore;
using RealtimePokerBackend.Data;
using RealtimePokerBackend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data source=poker.db"));

Console.WriteLine("Controllers registered");
builder.Services.AddScoped<PlayerService>();
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 테스트 API
app.MapGet("/", () => "RealtimePokerBackend Running!");
app.MapControllers();
Console.WriteLine("MapControllers executed");

app.Run();