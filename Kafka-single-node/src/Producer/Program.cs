// See https://aka.ms/new-console-template for more information

using Confluent.Kafka;

Console.WriteLine("Hello, Producer!");


var config = new ProducerConfig()
{
    BootstrapServers = "localhost:29092",
};

using var producer = new ProducerBuilder<Null, string>(config).Build();

Console.Write("Enter Topic: ");
var topic = Console.ReadLine();

var input = "";
while (input != "Exit")
{
    Console.Write("Enter any input to produce it: ");
    input = Console.ReadLine();

    var result = await producer.ProduceAsync(topic, new Message<Null, string> { Value = input });
    producer.Flush();
}