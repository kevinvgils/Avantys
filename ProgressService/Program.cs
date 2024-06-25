using Eventlibrary;
using Infrastructure;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using ProgressService.Consumer;
using ProgressService.DomainServices.Interfaces;
using ProgressService.Infrastructure;
using RabbitMQ.Client;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//repos
builder.Services.AddScoped<IProgressRepository, ProgressRepository>();
builder.Services.AddScoped<ITestRepository, TestRepository>();
builder.Services.AddScoped<IProgramRepository, ProgramRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
//service
builder.Services.AddScoped<IProgressService, ProgressService.DomainServices.ProgressService>();

builder.Services.AddScoped<IConsumer<Test>, TestCreatedConsumer>(); //TODO: remove TestCreated and replace it with local.

builder.Services.AddDbContext<ProgressDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<TestCreatedConsumer>();
    x.AddConsumer<StudentCreatedConsumer>(); // Add StudentCreatedConsumer

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        // Configure endpoints for consumers
        cfg.ReceiveEndpoint("test-created-queue", e =>
        {
            e.ConfigureConsumer<TestCreatedConsumer>(context);
            e.Bind("test-created", x =>
            {
                x.RoutingKey = "#"; // wildcard to receive all messages
                x.ExchangeType = "topic";
            });
        });

        cfg.ReceiveEndpoint("student-created-queue", e =>
        {
            e.ConfigureConsumer<StudentCreatedConsumer>(context);
            e.Bind("student-created", x =>
            {
                x.RoutingKey = "#"; // wildcard to receive all messages
                x.ExchangeType = "topic";
            });
        });
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Apply pending migrations on startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ProgressDbContext>();
    dbContext.Database.Migrate();
}

app.Run();
