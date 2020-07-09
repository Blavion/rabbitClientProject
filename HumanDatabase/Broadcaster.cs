using RabbitMQ.Client;
using System.Text;
using System.Threading;
namespace HumanDatabase
{
    public class Broadcaster
    {

        private IModel channel;
        private string Exchange = "HumanDB";
        
        //connects to RabbitMQ, makes it's own temporary exchange. 
        public Broadcaster(){
            var factory = new ConnectionFactory();
            var connection = factory.CreateConnection();
            
            channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: Exchange, type: "direct");
        }
            
        public void SendMessage(string RoutingKey, string message){
            channel.BasicPublish(exchange: Exchange, routingKey: RoutingKey, basicProperties: null , body :  Encoding.UTF8.GetBytes(message));
            // if the thread dosen't sleep the messages isn't sent for some reason.
            Thread.Sleep(1000);
        }

        public void CloseConnection(){
            channel.Close();
        }
    }
}