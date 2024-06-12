using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var factory = new ConnectionFactory()
{
    HostName = "rabbitmq"
};

bool connectionEstablished = false;
int retries = 0;
while (!connectionEstablished && retries < 10)
{
    try
    {
        var connection = factory.CreateConnection();
        var model = connection.CreateModel();
        builder.Services.AddSingleton<IModel>(model);

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
