using EventLibrary;
using Infrastructure;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using ClassService.Consumers;
using ClassService.DomainServices.Interfaces;
using DomainServices;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudyProgramRepository, StudyProgramRepository>();
builder.Services.AddScoped<IClassRepository, ClassRepostitory>();

builder.Services.AddScoped<IStudentService, StudentsService>();
builder.Services.AddScoped<IStudyProgramService, StudyProgramService>();
builder.Services.AddScoped<IClassService, ClassesService>();


builder.Services.AddDbContext<ClassDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<StudyProgramConsumer>();
    x.AddConsumer<StudentConsumer>();
    x.AddConsumer<ClassConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.Message<StudentCreated>(e => { e.SetEntityName("default-exchange"); });
        cfg.Publish<StudentCreated>(e => { e.ExchangeType = "topic"; });
        cfg.Message<StudyProgramCreated>(e => { e.SetEntityName("default-exchange"); });
        cfg.Publish<StudyProgramCreated>(e => { e.ExchangeType = "topic"; });
        cfg.Message<ClassCreated>(e => { e.SetEntityName("default-exchange"); });
        cfg.Publish<ClassCreated>(e => { e.ExchangeType = "topic"; });

        cfg.ReceiveEndpoint("classservice-queue", e =>
        {
            e.ConfigureConsumer<StudyProgramConsumer>(context);
            e.ConfigureConsumer<StudentConsumer>(context);
            e.ConfigureConsumer<ClassConsumer>(context);
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
    var dbContext = scope.ServiceProvider.GetRequiredService<ClassDbContext>();
    dbContext.Database.Migrate();
}

app.Run();
