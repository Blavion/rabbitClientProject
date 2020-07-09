using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Receive
{
    
    class Receive
    {
        private string queueName;

        private static IModel channel; 

        //A method that opens a channel on RabbitMQ
        public Receive(string RoutingKey){
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.ExchangeDeclare(exchange: "HumanDB", type: "direct");
            
            queueName = channel.QueueDeclare().QueueName;

            channel.QueueBind(queue: queueName, exchange: "HumanDB", routingKey: RoutingKey);
            
        }

        public void GetMessage(){
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) => {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var routingKey = ea.RoutingKey;
                    Console.WriteLine("Message : {0}", message);
                };
            
            channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
