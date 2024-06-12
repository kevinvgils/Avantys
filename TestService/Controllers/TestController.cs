using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace TestService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateOrder()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "order_exchange", type: "direct");

                var message = "Order Created";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "order_exchange",
                                     routingKey: "order_created",
                                     basicProperties: null,
                                     body: body);

                Console.WriteLine($"[x] Sent {message}");
            }

            return Ok("Order created and message sent to RabbitMQ.");
        }
    }
}