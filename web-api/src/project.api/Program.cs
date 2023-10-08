using project.api.Filters;
using project.aspnetcore.infrastructure.FilterExceptions;
using project.aspnetcore.infrastructure.ServiceCollections.Application;
using project.aspnetcore.infrastructure.ServiceCollections.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(builder.Configuration);

builder.Services.AddMvc(options =>
{
    options.Filters.Add(new ApiExceptionFilterAttribute(new ApiFilterException()));
});


builder.Services
    .AddControllers()
    .AddJsonOptions(opts => { opts.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull; });


// Data Services
SuperMarketRepositoryServiceCollection.AddRepository(builder.Services, builder.Configuration);

// Application Services
ApplicationServiceCollection.AddApplication(builder.Services, builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseCors(x => x
   .AllowAnyOrigin()
   .AllowAnyMethod()
   .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
