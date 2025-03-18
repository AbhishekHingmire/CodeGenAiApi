using CodeGeneratorApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()
    ));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🟢 Configure Kestrel to listen to Railway's injected PORT
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(int.Parse(port));
});

var app = builder.Build();

// 🟢 Show simple message on root "/"
app.MapGet("/", () => "🚀 CodeGenerator API is running!");

// Swagger only in dev (optional)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
