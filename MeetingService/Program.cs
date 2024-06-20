
using EventLibrary;
using Infrastructure;
using MassTransit;
using MeetingService.DomainServices;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using MeetingService.Consumers;



var builder = WebApplication.CreateBuilder(args);



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IMeetingRepository, MeetingRepository>();
builder.Services.AddScoped<IConsumer<MeetingCreated>, MeetingCreatedConsumer>();

builder.Services.AddDbContext<MeetingDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<MeetingCreatedConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.ReceiveEndpoint("meeting-created-queue", e =>
        {
            e.ConfigureConsumer<MeetingCreatedConsumer>(context);
            e.Bind("meeting-created", x =>
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
    var dbContext = scope.ServiceProvider.GetRequiredService<MeetingDbContext>();
    dbContext.Database.Migrate();
}

app.Run();

