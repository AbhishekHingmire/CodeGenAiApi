using CodeGeneratorApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()
    ));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Listen on 0.0.0.0:<PORT> from env (Railway compatible)
var port = Environment.GetEnvironmentVariable("PORT") ?? "5020"; // instead of 5000 or 8080

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5020); // Bind to the port Railway expects
});

var app = builder.Build();

// ✅ Simple root test
app.MapGet("/", () => "🚀 CodeGenerator API is running!");

// Swagger in dev
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
