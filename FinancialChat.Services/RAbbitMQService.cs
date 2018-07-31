using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FinancialChat.Store;
using FinancialChat.Common.DTO;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace FinancialChat.Services
{
    public class RabbitMQService
    {
        private static ConnectionFactory factory= new ConnectionFactory() { HostName = "localhost" };
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

        public static string GetMessages()
        {
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue, false, false, false, null);
                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume(queue, true, consumer);
                    var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
                    var body = ea.Body;
                    QueueService.setMessage(Encoding.UTF8.GetString(body));
                    return Encoding.UTF8.GetString(body);
                }
            }
        }

        public static List<string> GetMessagesLoop()
        {
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue, false, false, false, null);
                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume(queue, true, consumer);
                    var i = 0;
                    var array = new List<string>();
                    while (i < 10)
                    {
                        i++;
                        Thread.Sleep(50);
                        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        array.Add(message);
                    }
                    return array;

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
                    channel.BasicConsume(queue:queue,
                                            noAck: true,
                                            consumer: consumer);

                    var i = 0;
                    while (i< 5)
                    {
                        i++;
                        Thread.Sleep(50);
                    }
                }
            }
        }
    }
}
