using EventLibrary;
using Infrastructure;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using StudentService.Consumers;
using StudentService.DomainServices.Interfaces;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddDbContext<StudentDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<ApplicantUpdatedConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.Message<StudentCreated>(e => { e.SetEntityName("default-exchange"); });
        cfg.Publish<StudentCreated>(e => { e.ExchangeType = "topic"; });

        cfg.ReceiveEndpoint("student-applicant-created-queue", e =>
        {
            e.ConfigureConsumer<ApplicantUpdatedConsumer>(context);
            e.Bind("default-exchange", x =>
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
    var dbContext = scope.ServiceProvider.GetRequiredService<StudentDbContext>();
    dbContext.Database.Migrate();
}

app.Run();
