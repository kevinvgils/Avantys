
using EventLibrary;
using Infrastructure;
using MassTransit;
using DomainServices;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using TeacherService.Consumers;



var builder = WebApplication.CreateBuilder(args);



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IConsumer<TeacherCreated>, TeacherCreatedConsumer>();

builder.Services.AddDbContext<TeacherDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<TeacherCreatedConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.ReceiveEndpoint("teacher-created-queue", e =>
        {
            e.ConfigureConsumer<TeacherCreatedConsumer>(context);
            e.Bind("teacher-created", x =>
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
    var dbContext = scope.ServiceProvider.GetRequiredService<TeacherDbContext>();
    dbContext.Database.Migrate();
}

app.Run();

