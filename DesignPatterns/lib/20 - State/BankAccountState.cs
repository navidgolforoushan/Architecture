namespace lib._20___State;

public abstract class BankAccountState
{
    public BankAccount BankAccount { get; protected set; } = null!;
    public decimal Balance { get; protected set; }

    public abstract void Deposit(decimal amount);
    public abstract void Withdraw(decimal amount);

}
