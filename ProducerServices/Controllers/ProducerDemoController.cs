using Confluent.Kafka;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProducerServices.Entities;
using ProducerServices.Services;
using System;
using System.Diagnostics;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
namespace ProducerServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerDemoController : ControllerBase
    {

        private readonly IProducer<string, OrderRequest> _producer;
        public readonly IOrderRequestService orderRequestService;
        private readonly string bootstrapServers = "localhost:9092";
        private readonly string topic = "test";
        public ProducerDemoController()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "broker.address"
            };

        _producer= new ProducerBuilder<string,OrderRequest>(config).Build();

        }

        [HttpPost]
        public async Task<IActionResult>
        Post([FromBody] OrderRequest orderRequest)
        {
            string message = JsonSerializer.Serialize(orderRequest);
            return Ok(await SendOrderRequest(topic, message));
        }

        private async Task<bool> SendOrderRequest
     (string topic, string message)
        {
            ProducerConfig config = new ProducerConfig
            {
                BootstrapServers = bootstrapServers,
                ClientId = Dns.GetHostName()
            };

            try
            {
                using (var producer = new ProducerBuilder
                <Null, string>(config).Build())
                {
                    var result = await producer.ProduceAsync
                    (topic, new Message<Null, string>
                    {
                        Value = message
                    });

                    Debug.WriteLine($"Delivery Timestamp: { result.Timestamp.UtcDateTime}");
                return await Task.FromResult(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }

            return await Task.FromResult(false);
        }

    }
}
