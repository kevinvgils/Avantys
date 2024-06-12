using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections.Concurrent;
using System.Text;

namespace ProgressService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgressController : ControllerBase
    {
        private static readonly ConcurrentQueue<string> messages = new ConcurrentQueue<string>();
        private readonly IModel _channel;

        public ProgressController(IModel channel)
        {
            _channel = channel;
            _channel.ExchangeDeclare(exchange: "order_exchange", type: "direct");
            var queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: queueName,
                              exchange: "order_exchange",
                              routingKey: "order_created");

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                messages.Enqueue(message);
                Console.WriteLine($"[x] Received {message}");
            };

            _channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);
        }

        [HttpGet]
        public IActionResult GetMessages()
        {
            return Ok(messages.ToArray());
        }
    }
}
