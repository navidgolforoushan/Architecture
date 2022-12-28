
namespace lib._20___State;

public class GoldState : BankAccountState
{
    private readonly ILogger _logger;

    public GoldState(decimal balance, BankAccount bankAccount, ILogger logger)
    {
        _logger = logger;
        Balance = balance;
        BankAccount = bankAccount;
    }

    public override void Deposit(decimal amount)
    {
        _logger.Information("In {@type}, depositing {@amount} - 20% Bouns for beign a valuable customer!", GetType(), amount);
        Balance += amount * 1.02m;
    }

    public override void Withdraw(decimal amount)
    {
        _logger.Information("In {@type}, withdrawing {@amount}", GetType(), amount);
        Balance -= amount;

        if (Balance < 0)
        {
            BankAccount.BankAccountState = new OverdrawnState(Balance, BankAccount, _logger);
        }
        else if (Balance < 1000)
        {
            BankAccount.BankAccountState = new RegularState(Balance, BankAccount, _logger);
        }
    }
}
