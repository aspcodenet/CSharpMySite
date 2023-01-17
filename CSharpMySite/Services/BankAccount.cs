namespace CSharpMySite.Services;


public enum BankAccountStatus {
    Ok,
    NotEnoughBalance,
    TooBigAmount,
}

public class BankAccount
{
    public string AccountNo { get; set; }
    public int Balance { get; set; }

    public BankAccountStatus Withdraw(int amount)
    {
        if (amount > 4000) return BankAccountStatus.TooBigAmount;
        if (Balance < amount) return BankAccountStatus.NotEnoughBalance;
        Balance -= amount;
        return BankAccountStatus.Ok;
    }

    public BankAccountStatus Deposit(int amount)
    {
        Balance += amount;
        return BankAccountStatus.Ok;
    }

}