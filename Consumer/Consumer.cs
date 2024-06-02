using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory();

var endpoints = new List<AmqpTcpEndpoint> {
  new AmqpTcpEndpoint("localhost", 5673),
  new AmqpTcpEndpoint("localhost",5674),
  new AmqpTcpEndpoint("localhost",5675)
};

using var connection = factory.CreateConnection(endpoints);
using var channel = connection.CreateModel();

// channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);

// var queueName = channel.QueueDeclare("q.user.created");

channel.QueueBind(queue: "q.user.created",
                  exchange: "e.user.created",
                  routingKey: "user.created");

Console.WriteLine(" [*] Waiting for logs.");

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    byte[] body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($" [Received] {message}");
};
channel.BasicConsume(queue: "q.user.created",
                     autoAck: true,
                     consumer: consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();