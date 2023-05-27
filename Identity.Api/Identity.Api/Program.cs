using Identity.Api.DataBase;
using Identity.Api.Extentions;
using Identity.Api.Middleware;
using Identity.Api.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration().WriteTo.File("smth.txt", LogEventLevel.Error,rollingInterval:RollingInterval.Day).CreateLogger();

builder.Logging.AddSerilog(logger);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<TokenService>();
builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
{

    optionsBuilder.UseSqlServer("Server=sql.bsite.net\\MSSQL2016;" +
                                "Database=educations_ ; User Id = educations_ ; Password=asd12345; TrustServerCertificate=True");
});
builder.Services.AddJwt(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c => c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

/*app.UseMiddleware()*/
app.UseMiddleware();

app.MapControllers();

app.Run();
