using RMV.DriverExaminer.Service.Interfaces;
using RMV.Infrastructure;
using RMV.DriverExaminer.Infrastructure.Logging;
using RMV.DriverExaminer.WebApi.Middleware;
using RMV.DriverExaminer.Infrastructure.Common;

var builder = WebApplication.CreateBuilder(args);

//Register Global Custom Logging
builder.Services.AddSingleton(typeof(ICustomLogger<>), typeof(CustomLogger<>));

// Add services to the container.

builder.Logging.ClearProviders().AddConsole();

builder.Services
    .AddConfigaration(builder.Configuration)
    .RegisterServices();

builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IRMV3AppClient, RMV3AppClient>();

//Register Custom Exception Middleware
//builder.Services.AddTransient<ExceptionMiddleware>();

//Register the IExceptionHandler service with dependency injection
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();


builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

//app.UseMiddleware<ExceptionMiddleware>();

//call UseExceptionHandler to add the ExceptionHandlerMiddleware to the request pipeline
app.UseExceptionHandler();

app.MapControllers();

app.Run();
