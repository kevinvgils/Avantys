using Domain.Events;
using DomainServices;
using Infrastructure;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client.Exceptions;
using StudentService.Consumers;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IConsumer<IApplicantCreatedEvent>, ApplyConsumer>();

builder.Services.AddDbContext<StudentDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


bool connectionEstablished = false;
int retries = 0;
while (!connectionEstablished && retries < 10)
{
    try
    {
        builder.Services.AddMassTransit(x =>
        {
            x.AddConsumer<ApplyConsumer>();
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("rabbitmq", "/");
                cfg.ConfigureEndpoints(context);
                cfg.ReceiveEndpoint("applicant_created_queue", e =>
                {
                    e.ConfigureConsumer<ApplyConsumer>(context);
                });
            });
        });
        connectionEstablished = true;

    }
    catch (BrokerUnreachableException)
    {
        retries++;
        Console.WriteLine($"Retrying RabbitMQ connection ({retries}/10)...");
        Thread.Sleep(2000); // Wait 2 seconds before retrying
    }
}


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
    var dbContext = scope.ServiceProvider.GetRequiredService<StudentDbContext>();
    dbContext.Database.Migrate();
}

app.Run();
