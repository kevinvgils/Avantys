using Infrastructure;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using ProgressService.Consumer;
using ProgressService.Consumer.TestConsumers;
using ProgressService.DomainServices.Interfaces;
using ProgressService.Infrastructure;
using EventLibrary;
using RabbitMQ.Client;
using static ProgressService.Consumer.ProgramCreatedConsumer;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//====================Injection=========================
//repos
builder.Services.AddScoped<IProgressRepository, ProgressRepository>();
builder.Services.AddScoped<ITestRepository, TestRepository>();
builder.Services.AddScoped<IProgramRepository, ProgramRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

//service
builder.Services.AddScoped<IProgressService, ProgressService.DomainServices.ProgressService>();

//consumers
builder.Services.AddScoped<IConsumer<TestCreated>, TestCreatedConsumer>();

//dbContext
builder.Services.AddDbContext<ProgressDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//=====================================================


builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<StudyProgramCreatedConsumer>();
    x.AddConsumer<StudentCreatedConsumer>();
    x.AddConsumer<TestCreatedConsumer>();
    x.AddConsumer<TestUpdatedConsumer>();
    x.AddConsumer<TestDeletedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("Progressservice-queue", e =>
        {
            // Configure consumers to handle specific routing keys
            e.ConfigureConsumer<TestCreatedConsumer>(context);
            e.ConfigureConsumer<TestUpdatedConsumer>(context);
            e.ConfigureConsumer<TestDeletedConsumer>(context);
            e.ConfigureConsumer<StudentCreatedConsumer>(context);
            e.ConfigureConsumer<StudyProgramCreatedConsumer>(context);

            // Bind the queue to the exchange with specific routing keys
            e.Bind("default-exchange", x =>
            {
                x.ExchangeType = "topic";
                x.RoutingKey = "test.created";
            });

            e.Bind("default-exchange", x =>
            {
                x.ExchangeType = "topic";
                x.RoutingKey = "test.updated";
            });

            e.Bind("default-exchange", x =>
            {
                x.ExchangeType = "topic";
                x.RoutingKey = "test.deleted";
            });

            // You can add more bindings for other routing keys as needed
            e.Bind("default-exchange", x =>
            {
                x.ExchangeType = "topic";
                x.RoutingKey = "student.created";
            });

            e.Bind("default-exchange", x =>
            {
                x.ExchangeType = "topic";
                x.RoutingKey = "studyprogram.created";
            });


        });

        cfg.ConfigureEndpoints(context);
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

Console.WriteLine("Test startup!");
app.Run();
