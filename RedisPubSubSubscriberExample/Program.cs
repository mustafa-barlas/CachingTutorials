using StackExchange.Redis;

ConnectionMultiplexer connect =await ConnectionMultiplexer.ConnectAsync("localhost:1453");

ISubscriber? subscriber =  connect?.GetSubscriber();

subscriber.SubscribeAsync("mychannel", (channel, message) =>
{
    Console.WriteLine(message);
});

Console.Read();
