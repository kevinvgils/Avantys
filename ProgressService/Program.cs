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
    x.AddConsumer<TestCreatedConsumer>();
    x.AddConsumer<StudentCreatedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("Progressservice-queue", e =>
        {
            e.ConfigureConsumer<TestCreatedConsumer>(context);
            e.ConfigureConsumer<StudentCreatedConsumer>(context);
            e.Bind("default-exchange", x =>
            {
                x.ExchangeType = "topic";
                x.RoutingKey = "#";
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
