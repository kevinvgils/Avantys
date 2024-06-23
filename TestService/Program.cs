using Eventlibrary;
using Infrastructure;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using TestService.DomainServices.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<ITestRepository, TestRepository>();

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

        cfg.Message<TestCreated>(e => e.SetEntityName("test-created")); // specify exchange name
        cfg.Publish<TestCreated>(e => e.ExchangeType = "topic");
    });
});

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
