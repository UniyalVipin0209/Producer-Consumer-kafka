
using Confluent.Kafka;
using System;

// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

var config = new ConsumerConfig
{
    BootstrapServers = "your_kafka_broker_address:port",
    GroupId = "consumer-group-id",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
{
    consumer.Subscribe("your_topic_name");

    while (true)
    {
        try
        {
            var message = consumer.Consume();
            Console.WriteLine($"Consumed message: {message.Value}");
            // Process the consumed message as needed
        }
        catch (ConsumeException e)
        {
            Console.WriteLine($"Error while consuming message: {e.Error.Reason}");
        }
    }
}