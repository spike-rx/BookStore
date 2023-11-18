using BookStore.Data.Contexts;
using BookStore.Infrastructure.Extensions.Logging;
using BookStore.Infrastructure.Extensions.ProblemDetails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// add logging
builder.Host.UseSerilog((hostBuilderContext, services, configuration) =>
{
    configuration.ConfigureBaseLogging("BookStore");
    configuration.AddApplicationInsightsLogging(services, hostBuilderContext.Configuration);
});

// setup database connection (used for in memory SQLite).
#pragma warning disable s125
// const string filename = "../bookstore.db";
#pragma warning restore S124
// const string connectionString = "Filename=:memory:";
var connectionString = builder.Configuration.GetConnectionString("BookStore") ?? "Data Source=BookStore.db";
var connection = new SqliteConnection(connectionString);
connection.Open();

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SupportNonNullableReferenceTypes();
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookStore", Version = "v1" });
});

builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressInferBindingSourcesForParameters = true; });

// for SQLite in memory a connection is provide rather than a connection string
builder.Services.AddDbContext<ConduitContext>(options => { options.UseSqlite(connection); });
builder.Services.AddProblemDetails();
builder.Services.ConfigureOptions<ProblemDetailsLogging>();


var app = builder.Build();


app.Run();