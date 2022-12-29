namespace lib._16___Strategy;

public class TextMessageSenderService : ISendMessage
{
    private readonly ILogger logger;

    public TextMessageSenderService(ILogger logger)
    {
        this.logger = logger;
    }
    public void SendMessage(string msg)
    {
        logger.Information("Message sent as SMS [{@msg}]", msg);
    }
}
