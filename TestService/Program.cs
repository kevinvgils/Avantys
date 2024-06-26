using EventLibrary;
using Infrastructure;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using TestService.DomainServices.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//repo
builder.Services.AddScoped<ITestRepository, TestRepository>();

//service
builder.Services.AddScoped<ITestService, ProgressService.DomainServices.TestService>();

//dbContext
builder.Services.AddDbContext<TestDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    );
});

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.Message<TestCreated>(e => { e.SetEntityName("default-exchange"); });
        cfg.Publish<TestCreated>(e => { e.ExchangeType = "topic"; });
        cfg.Message<TestUpdated>(e => { e.SetEntityName("default-exchange"); });
        cfg.Publish<TestUpdated>(e => { e.ExchangeType = "topic"; });
        cfg.Message<TestDeleted>(e => { e.SetEntityName("default-exchange"); });
        cfg.Publish<TestDeleted>(e => { e.ExchangeType = "topic"; });
    });
});

// Add logging
builder.Logging.ClearProviders(); // Optional: Clears default logging providers
builder.Logging.AddConsole(); // Adds console logging
builder.Logging.AddDebug(); // Adds debug logging

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply pending migrations on startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TestDbContext>();
    dbContext.Database.Migrate();
}

app.UseRouting();
app.UseAuthentication();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
