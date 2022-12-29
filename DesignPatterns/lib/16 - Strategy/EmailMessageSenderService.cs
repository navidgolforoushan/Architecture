namespace lib._16___Strategy;

public  class EmailMessageSenderService : ISendMessage
{
    private readonly ILogger logger;

    public EmailMessageSenderService(ILogger logger)
    {
        this.logger = logger;
    }
    public void SendMessage(string msg)
    {
        logger.Information("Message sent as Email [{@msg}]", msg);
    }
}
