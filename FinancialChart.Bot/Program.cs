using FinancialChat.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialChart.Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            string queue = "chat1";
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue, false, false, false, null);
                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume(queue, true, consumer);
                    Console.WriteLine("esperando por los mensajes (ctrl + c para salir)");
                    while (true)
                    {
                        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
                        var body = ea.Body;
                        var receivedMessage = Encoding.UTF8.GetString(body);
                        Console.WriteLine("Received {0}", receivedMessage);

                        var stringToCompare = "/stock=";
                        var response = "";
                        if (String.Compare(receivedMessage, 0, stringToCompare, 0, 7) == 0)
                        {
                            var textToSearch = receivedMessage.Substring(7, receivedMessage.Length - 7);
                            response = StookRequest.makeStookCall(textToSearch);
                            
                        }
                        else
                        {
                            stringToCompare = "/day_range=";
                            if (String.Compare(receivedMessage, 0, stringToCompare, 0, 11) == 0)
                            {
                                var textToSearch = receivedMessage.Substring(11, receivedMessage.Length - 11);
                                response = YahooApiService.makeYahooApiCall(textToSearch);

                            } else
                            {
                                stringToCompare = "/help";
                                if (String.Compare(receivedMessage, 0, stringToCompare, 0, 5) == 0)
                                {
                                    response = "type /stock=company_symbol to check last market value (ie. /stock=MSFT); " +
                                        "type /day_range=company_symbol to check day ranges (ie. /day_range=APPL=";

                                }
                                else if(receivedMessage[0].Equals('/'))
                                {
                                    response = "type /help for help";
                                }
                            }
                        }

                        if(response != "")
                        {
                            Console.WriteLine("BOT Response:  {0}", response);
                            channel.QueueDeclare(queue, false, false, false, null);
                            var body2 = Encoding.UTF8.GetBytes(response);
                            channel.BasicPublish("", queue, null, body2);
                            Thread.Sleep(2000);
                        }
                    }

                }
            }
        }
    }
}
