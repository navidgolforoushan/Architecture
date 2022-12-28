namespace tests;

internal class SimpleMemoryLogger : ILogger
{
    private readonly List<string> _logger;

    public SimpleMemoryLogger()
    {
        _logger= new List<string>();
    }

    public string LastLog => _logger.Last();

    public void Write(LogEvent logEvent)
    {
        _logger.Add(logEvent.MessageTemplate.Render(logEvent.Properties));
    }
}
