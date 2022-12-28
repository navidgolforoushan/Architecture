namespace lib._20___State;

public class OverdrawnState : BankAccountState
{
    private readonly ILogger _logger;

    public OverdrawnState(decimal balance, BankAccount bankAccount, ILogger logger)
    {
        _logger= logger;
        Balance = balance;
        BankAccount = bankAccount ?? throw new ArgumentNullException(nameof(bankAccount));
    }

    public override void Deposit(decimal amount)
    {
        _logger.Information("In {@type}, Depositing {@amount}", GetType(), amount);
        Balance += amount;
        if(Balance > 0)
        {
            BankAccount.BankAccountState = new RegularState(Balance, BankAccount, _logger);
        }
    }

    public override void Withdraw(decimal amount)
    {
        _logger.Information("In {@type}, Withdrawing {@amount} -not allowed!", GetType(), amount);
    }
}
