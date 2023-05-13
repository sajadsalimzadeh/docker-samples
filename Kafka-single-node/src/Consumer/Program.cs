// See https://aka.ms/new-console-template for more information

using Confluent.Kafka;

Console.WriteLine("Hello, Consumer!");


var config = new ConsumerConfig()
{
    BootstrapServers = "localhost:29092",
    GroupId = "foo",
    EnableAutoCommit = true,
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();

Console.Write("Enter Topic: ");
var topic = Console.ReadLine();

consumer.Subscribe(topic);

var cancellationToken = new CancellationToken();
var cancelled = false; 
while (!cancelled)
{
    var consumeResult = consumer.Consume(cancellationToken);
    Console.WriteLine(consumeResult.Message.Value);
}

consumer.Close();