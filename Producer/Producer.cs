using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory();
factory.UserName = "guest";
factory.Password = "guest";

var endpoints = new List<AmqpTcpEndpoint> {
  new AmqpTcpEndpoint("localhost",5673),
  new AmqpTcpEndpoint("localhost",5674)
};

using var connection = factory.CreateConnection(endpoints);
using var channel = connection.CreateModel();

// channel.ExchangeDeclare(exchange: "e.user.created", type: ExchangeType.Topic);

var routingKey = (args.Length > 0) ? args[0] : "user.created";

for(int i=0; i<=100000; i++){
    var message ="Hello World - " + i.ToString();
    var body = Encoding.UTF8.GetBytes(message);
    channel.BasicPublish(exchange: "e.user.created",
                     routingKey: routingKey,
                     basicProperties: null,
                     body: body);
    Console.WriteLine($" [x] Sent '{routingKey}':'{message}'");
}

