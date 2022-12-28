
using lib._20___State;

namespace tests;

[TestClass]
public class StatePatternTests
{
    [TestMethod]
    [DataRow(2, 100, -20, -60)]
    [DataRow(1, 100, -20, -60, -50)]
    [DataRow(2, 100, 20, -60, -50, 80)]
    [DataRow(1, 100, 20, -60, -50, 80, -200)]
    [DataRow(1, 100, 20, -60, -50, 80, -200, -20)]
    [DataRow(2, 100, -200, -60, 550, -880, 20000, -20)]
    [DataRow(3, 100, -200, 1000, 1000)]
    [DataRow(2, 100, -200, 9000)]
    public void Should_Reuturn_CorrectState(int expected, int initialBalance, params int[] amounts)
    {
        var expectedState = GetState(expected);
        var sut = new BankAccount(initialBalance, new SimpleMemoryLogger());

        for (int i = 0; i < amounts.Length; i++)
        {
            if (amounts[i] > 0)
            {
                sut.Deposit(amounts[i]);
            }
            else
            {
                sut.Withdraw(amounts[i] * -1);
            }
        }

        Assert.AreEqual(expectedState, sut.BankAccountState.GetType());
    }


    [TestMethod]
    [DataRow(3, 100, 1000, 1000)]
    public void Should_Return_GoldStateWithBouns(int expected, int initialBalance, params int[] amounts)
    {
        var expectedState = GetState(expected);
        var logger = new SimpleMemoryLogger();
        var sut = new BankAccount(initialBalance, logger);

        for (int i = 0; i < amounts.Length; i++)
        {
            if (amounts[i] > 0)
            {
                sut.Deposit(amounts[i]);
            }
            else
            {
                sut.Withdraw(amounts[i] * -1);
            }
        }

        Assert.AreEqual(expectedState, sut.BankAccountState.GetType());
        Assert.IsTrue(logger.LastLog.Contains("20%"));
    }

    private static Type GetState(int expected)
    {
        Type expectedState;
        switch (expected)
        {
            case 1:
                expectedState = typeof(OverdrawnState);
                break;
            case 2:
                expectedState = typeof(RegularState);
                break;
            case 3:
                expectedState = typeof(GoldState);
                break;
            default:
                throw new Exception("Invalid State!");
        }

        return expectedState;
    }

}
