using ASPNETCORE_API.Database;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var CorsPolicy = "_corsPolicy";

// Cors (Cross-Origin Resource Sharing)
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsPolicy, policy =>
     {
         policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
     });
});

builder.Services.AddEntityFrameworkNpgsql()

builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("sqlConnection"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
