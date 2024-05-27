namespace NitroBoostConsoleService.Shared.Interface.Messaging;

public interface IBaseSender
{
    void Send<TType>(string queueName, TType body) where TType : class;
}