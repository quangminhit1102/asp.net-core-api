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
