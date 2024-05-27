using RabbitMQ.Client.Events;

namespace NitroBoostConsoleService.Shared.Interface.Messaging;

public interface IBaseReceiver
{
    event EventHandler<BasicDeliverEventArgs>? DataReceived;
    
    void StartReceiving(string queueName);
    void StopReceiving();
}