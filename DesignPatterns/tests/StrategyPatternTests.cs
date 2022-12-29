using lib._16___Strategy;

namespace tests;

[TestClass]
public class StrategyPatternTests
{
    [TestMethod]
    public void Order_Should_SendMessage_ByEmail()
    {
        var sut = new Order();
        sut.AddOrder("pen");
        sut.AddOrder("paper");
        var logger = new SimpleMemoryLogger();
        sut.SendReceipt(new EmailMessageSenderService(logger)) ;

        Assert.IsTrue(logger.LastLog.Contains("Message sent as Email"));
    }

    [TestMethod]
    public void Order_Should_SendMessage_BySMS()
    {
        var sut = new Order();
        sut.AddOrder("pen");
        sut.AddOrder("paper");
        var logger = new SimpleMemoryLogger();
        sut.SendReceipt(new TextMessageSenderService(logger));

        Assert.IsTrue(logger.LastLog.Contains("Message sent as SMS"));
    }

}
