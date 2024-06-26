using EventLibrary;

using MassTransit;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using CustomerDataService.Domain;
using CustomerDataService.DomainServices;
;




var builder = WebApplication.CreateBuilder(args);



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddHttpClient();

builder.Services.AddScoped<CustomerDataService.DomainServices.Interfaces.ICustomerService, CustomerDataService.DomainServices.CustomerDataService>();






builder.Services.AddMassTransit(x =>
{
   
  
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.Message<ApplicantCreated>(e => { e.SetEntityName("default-exchange"); });
        cfg.Publish<ApplicantCreated>(e => { e.ExchangeType = "topic"; });
      

     

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



app.Run();
