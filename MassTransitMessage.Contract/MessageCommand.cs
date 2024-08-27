namespace MassTransitMessage.Contract
{
    public interface IMessageCommand
    {
        public string TraceId { get; set; }
    }

    public class MessageCommand : IMessageCommand
    {
        public string TraceId { get; set; }
    }
}
