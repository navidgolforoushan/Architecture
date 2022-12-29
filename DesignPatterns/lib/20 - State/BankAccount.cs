using System.Diagnostics;

namespace lib._20___State;

[DebuggerDisplay("Balance={Balance}, State={BankAccountState.GetType().Name}")]
public class BankAccount
{
    public BankAccountState BankAccountState { get; set; } = null!;

    public decimal Balance { get { return BankAccountState.Balance; } }

    public BankAccount(decimal initialBalance, ILogger logger)
    {
        BankAccountState = new RegularState(initialBalance, this, logger);
    }

    public void Deposit(decimal amount) { 
        BankAccountState.Deposit(amount);
    }

    public void Withdraw(decimal amount) {
        BankAccountState.Withdraw(amount);
    }
}
