using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TecEcommerce.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var connectionString = builder.Configuration.GetConnectionString("TecEcommerceCs");

builder.Services.AddDbContext<TecEcommerceDbContext>(
    options => options.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TecEcommerce",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Bruno Henrique",
            Email = "brunosoaresfreitas26@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/bruno-henrique-soares-de-freitas-32ab85243/")
        }
    });

    var xmlFile = "TecEcommerce.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    // C:\ProjetosCS\TecEcommerce\TecEcommerce.API\TecEcommerce.API.xml
    c.IncludeXmlComments(xmlPath);
});

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
