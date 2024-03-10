using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<FakultetContext>(options => 
{
    options/*.UseLazyLoadingProxies()*/.UseSqlServer(builder.Configuration.GetConnectionString("FakultetCS"));
});


/* builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS", builder =>
    {
        builder.AllowAnyHeader()
                .AllowAnyMethod()
                .WithOrigins(
                    "http:localhost:8080",
                    "https:localhost:8080",
                    "http:127.0.0.1:8080",
                    "https:127.0.0.1:8080",
                    "http://127.0.0.1:5500",
                    "http://localhost:5500",
                    "https://127.0.0.1:5500",
                    "https://localhost:5500"
                );
    });

}); */

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CORS", builder =>
                {
                    builder.WithOrigins(new string[]
                    {
                        "http://localhost:8080",
                        "https://localhost:8080",
                        "http://127.0.0.1:8080",
                        "https://127.0.0.1:8080",
                        "http://127.0.0.1:5500",
                        "http://localhost:5500",
                        "https://127.0.0.1:5500",
                        "https://localhost:5500"
                    })
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

        
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "vezbe3", Version = "v1" });
            });


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CORS");

app.UseAuthorization();

app.MapControllers();

app.Run();
