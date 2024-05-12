using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory { Uri = new Uri("amqp://guest:guest@localhost:5672/") };

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

// channel.ExchangeDeclare(exchange: "e.user.created", type: ExchangeType.Topic);

var routingKey = (args.Length > 0) ? args[0] : "user.created";

for(int i=0; i<=10000; i++){
    var message ="Hello World - " + i.ToString();
    var body = Encoding.UTF8.GetBytes(message);
    channel.BasicPublish(exchange: "e.user.created",
                     routingKey: routingKey,
                     basicProperties: null,
                     body: body);
    Console.WriteLine($" [x] Sent '{routingKey}':'{message}'");
}


