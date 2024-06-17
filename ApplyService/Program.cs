using DomainServices;
using Infrastructure;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client.Exceptions;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IApplyRepository, ApplyRepository>();


builder.Services.AddDbContext<ApplyDbContext>(options =>
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
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("rabbitmq", "/");
                cfg.ConfigureEndpoints(context);
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
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplyDbContext>();
    dbContext.Database.Migrate();
}

app.Run();
