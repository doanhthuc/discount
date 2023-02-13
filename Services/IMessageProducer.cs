namespace DiscountAPI.Services;

public interface IMessageProducer
{
  void SendingMessage<T>(T message);
}