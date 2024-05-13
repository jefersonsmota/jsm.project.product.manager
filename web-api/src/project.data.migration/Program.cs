using jsm.product.manager.aspnetcore.infrastructure.ServiceCollections.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

SuperMarketRepositoryServiceCollection.AddRepository(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.Run();