using ApplyService.Consumers;
using ApplyService.DomainServices;
using ApplyService.DomainServices.Interfaces;
using ApplyService.Infrastructure;
using EventLibrary;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
var builder = WebApplication.CreateBuilder(args);



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IApplyService, ApplicantService>();


builder.Services.AddScoped<IApplyRepository, ApplyRepository>();
builder.Services.AddScoped<IEventStoreRepository, EventStoreRepository>();


builder.Services.AddDbContext<ApplyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDbContext<EventStoreDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EventStoreConnection"));
});
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<ApplicantCreatedConsumer>();
    x.AddConsumer<ApplicantUpdatedConsumer>();
    x.AddConsumer<InterviewUpdatedConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.Message<ApplicantCreated>(e => { e.SetEntityName("default-exchange");  });
        cfg.Publish<ApplicantCreated>(e => { e.ExchangeType = "topic"; });
        cfg.Message<ApplicantUpdated>(e => { e.SetEntityName("default-exchange"); });
        cfg.Publish<ApplicantUpdated>(e => { e.ExchangeType = "topic"; });

        cfg.ReceiveEndpoint("apply-applicant-created-queue", e =>
        {
            e.ConfigureConsumer<ApplicantCreatedConsumer>(context);
            e.ConfigureConsumer<ApplicantUpdatedConsumer>(context);
            e.ConfigureConsumer<InterviewUpdatedConsumer>(context);
            e.Bind("default-exchange", x =>
            {
                x.ExchangeType = "topic";
                x.RoutingKey = "applicant.created";
            });
            e.Bind("default-exchange", x =>
            {
                x.ExchangeType = "topic";
                x.RoutingKey = "applicant.updated";
            });
            e.Bind("default-exchange", x =>
            {
                x.ExchangeType = "topic";
                x.RoutingKey = "interview.updated";
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
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplyDbContext>();
    dbContext.Database.Migrate();
    var eventDbContext = scope.ServiceProvider.GetRequiredService<EventStoreDbContext>();
    eventDbContext.Database.Migrate();
}

app.Run();
