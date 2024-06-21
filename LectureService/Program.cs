using LectureService.DomainServices;
using EventLibrary;
using LectureService.Infrastructure;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
//using LectureService.Consumers;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<ILectureRepository, LectureRepository>();
//builder.Services.AddScoped<IConsumer<ApplicantCreated>, ApplicantCreatedConsumer>();

builder.Services.AddDbContext<LectureDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



//builder.Services.AddMassTransit(x =>
//{
//    x.AddConsumer<ApplicantCreatedConsumer>();
//    x.UsingRabbitMq((context, cfg) =>
//    {
//        cfg.Host("rabbitmq", "/", h =>
//        {
//            h.Username("guest");
//            h.Password("guest");
//        });
//        cfg.ReceiveEndpoint("Progress-applicant-created-queue", e =>
//        {
//            e.ConfigureConsumer<ApplicantCreatedConsumer>(context);
//            e.Bind("applicant-created", x =>
//            {
//                x.RoutingKey = "#"; // wildcard to receive all messages
//                x.ExchangeType = "topic";
//            });
//        });

//    });
//});


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
    var dbContext = scope.ServiceProvider.GetRequiredService<LectureDbContext>();
    dbContext.Database.Migrate();
}

app.Run();