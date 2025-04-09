




using StackExchange.Redis;

ConnectionMultiplexer connect =await ConnectionMultiplexer.ConnectAsync("localhost:1453");

ISubscriber? subscriber =  connect?.GetSubscriber();


while (true)
{
    Console.WriteLine("Message : ");
   string? message =  Console.ReadLine();
  await subscriber?.PublishAsync("mychannel",message);
}
