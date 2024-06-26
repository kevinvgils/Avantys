using LectureService.Consumers;
using LectureService.DomainServices;
using LectureService.DomainServices.Interfaces;
using LectureService.Infrastructure;
using EventLibrary;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
var builder = WebApplication.CreateBuilder(args);



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<ILectureService, LectureService.DomainServices.LectureService>();


builder.Services.AddScoped<ILectureRepository, LectureRepository>();
builder.Services.AddScoped<IStudyMaterialRepository, StudyMaterialRepository>();


builder.Services.AddDbContext<LectureDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<LectureCreatedConsumer>();
    x.AddConsumer<StudyMaterialCreatedConsumer>();
    x.AddConsumer<ClassConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.Message<LectureCreated>(e => { e.SetEntityName("default-exchange"); });
        cfg.Publish<LectureCreated>(e => { e.ExchangeType = "topic"; });
        cfg.Message<StudyMaterialCreated>(e => { e.SetEntityName("default-exchange"); });
        cfg.Publish<StudyMaterialCreated>(e => { e.ExchangeType = "topic"; });
        cfg.Message<ClassCreated>(e => { e.SetEntityName("default-exchange"); });
        cfg.Publish<ClassCreated>(e => { e.ExchangeType = "topic"; });

        cfg.ReceiveEndpoint("lecture-created-queue", e =>
        {
            e.ConfigureConsumer<LectureCreatedConsumer>(context);
            e.ConfigureConsumer<StudyMaterialCreatedConsumer>(context);
            e.ConfigureConsumer<ClassConsumer>(context);
            e.Bind("default-exchange", x =>
            {
                x.ExchangeType = "topic";
                x.RoutingKey = "class.created";
            });
            e.Bind("default-exchange", x =>
            {
                x.ExchangeType = "topic";
                x.RoutingKey = "studymaterial.created";
            });
            e.Bind("default-exchange", x =>
            {
                x.ExchangeType = "topic";
                x.RoutingKey = "lecture.created";
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
    var dbContext = scope.ServiceProvider.GetRequiredService<LectureDbContext>();
    dbContext.Database.Migrate();

}

app.Run();
