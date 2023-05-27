using ShoppingMall.DataBase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();
/*builder.Services.AddCors(cors =>
{
    cors.AddPolicy("any", corsPolicy =>
    {
        corsPolicy.AllowAnyMethod().AllowAnyOrigin();
    });
});*/
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(cors =>
{
    /*cors.WithOrigins("http://localhost:1026/")*/;
    cors.WithMethods("POST");
});

app.UseAuthorization();

app.MapControllers();

app.Run();
