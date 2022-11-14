using ApiMakeUpStore.Extensions;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("SqlServer");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDatabaseService(connectionString);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger(configuration);
builder.Services.AddSwaggerGen(a =>
{
    a.SwaggerDoc("v1.0", new OpenApiInfo
    {
        Title = "API Logs Reader",
        Version = "v1.0",
        Description = "APIs de leitura de Logs "
    });

    // Set the comments path for the Swagger JSON and UI.**
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    a.IncludeXmlComments(xmlPath);
});

builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();



app.UseCors((builder) =>
{
    builder.SetIsOriginAllowed((_) => true);
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
    builder.AllowCredentials();
});

app.UseAuthorization();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseStaticFiles();

app.MapControllers();

app.Run();
