using EventLibrary;
using InterviewService.Consumers;
using InterviewService.DomainServices;
using InterviewService.DomainServices.Interfaces;
using InterviewService.Infrastructure;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IInterviewService, InterviewsService>();


builder.Services.AddScoped<IInterviewRepository, InterviewRepository>();


builder.Services.AddDbContext<InterviewDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<ApplicantCreatedConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.Message<InterviewUpdated>(e => { e.SetEntityName("default-exchange"); });
        cfg.Publish<InterviewUpdated>(e => { e.ExchangeType = "topic"; });

        cfg.ReceiveEndpoint("interview-applicant-created-queue", e =>
        {
            e.ConfigureConsumer<ApplicantCreatedConsumer>(context);
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

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<InterviewDbContext>();
    dbContext.Database.Migrate();
}

app.Run();
