
using Confluent.Kafka;

namespace AuthZero.NotificationService.WebApi.Services
{
    public class NotificationService(IConsumer<string, string> consumer) : BackgroundService
    {

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            consumer.Subscribe("account-messages");

            while (!stoppingToken.IsCancellationRequested)
            {
                var consumeResult = consumer.Consume(stoppingToken);
                if (consumeResult != null)
                {
                    // Process the message
                    Console.WriteLine($"Consumed message '{consumeResult.Message.Value}' at: '{consumeResult.TopicPartitionOffset}'.");

                    // Commit the message
                    consumer.Commit(consumeResult);

                    // Do something with the message
                    // For example, send a notification

                }
                else 
                {
                    Console.WriteLine("No message consumed");
                    await Task.Delay(1000, stoppingToken);
                }
            }
        }
    }
}