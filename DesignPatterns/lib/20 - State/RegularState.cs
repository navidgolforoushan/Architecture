namespace lib._20___State;

public class RegularState : BankAccountState
{
    private readonly ILogger _logger;

    public RegularState(decimal balance, BankAccount bankAccount, ILogger logger)
    {
        _logger = logger;
        Balance = balance;
        BankAccount = bankAccount ?? throw new ArgumentNullException(nameof(balance));
    }

    public override void Deposit(decimal amount)
    {
        _logger.Information("In {@type}, depositing {@amount}", GetType(), amount);
        Balance += amount;
        if (Balance > 1000)
        {
            BankAccount.BankAccountState = new GoldState(Balance, BankAccount, _logger);
        }
    }

    public override void Withdraw(decimal amount)
    {
        _logger.Information("In {@type}, Withdrawing {@amount}", GetType(), amount);
        Balance -= amount;
        if (Balance < 0)
        {
            BankAccount.BankAccountState = new OverdrawnState(Balance, BankAccount, _logger);
        }
    }
}
