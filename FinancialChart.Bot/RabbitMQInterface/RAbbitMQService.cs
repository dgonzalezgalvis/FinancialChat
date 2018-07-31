using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Util;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace FinancialChat.Bot.RabbitMQInterface
{
    public class RabbitMQService
    {
        private static ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
        private static String queue = "chat1";

        public static void PublishMessage(string message)
        {
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue, false, false, false, null);
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("", queue, null, body);
                }
            }
        }

        public static void GetMessages()
        {
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue, false, false, false, null);
                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume(queue, true, consumer);
                }
            }
        }

        public static void GetMessagesLoop()
        {
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue, false, false, false, null);
                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume(queue, true, consumer);
                }
            }

        }

        public static void GetMessagesAsync(EventHandler<BasicDeliverEventArgs> method)
        {
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: queue,
                                durable: false,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);

                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += method;
                    channel.BasicConsume(queue: queue,
                                            noAck: true,
                                            consumer: consumer);
                    
                }
            }
        }
    }
}
