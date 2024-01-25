using System;

public class BankAccount
{
    public string AccountNumber { get; }
    public string OwnerName { get; set; }
    public decimal Balance { get; private set; }

    public BankAccount(string accountNumber, string ownerName, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        OwnerName = ownerName;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
        }
        else
        {
            Console.WriteLine("Deposit amount must be greater than zero.");
        }
    }

    public bool Withdraw(decimal amount)
    {
        if (amount > 0 && Balance >= amount)
        {
            Balance -= amount;
            return true;
        }
        else
        {
            Console.WriteLine("Insufficient funds or invalid withdrawal amount.");
            return false;
        }
    }

    public static void Transfer(BankAccount fromAccount, BankAccount toAccount, decimal amount)
    {
        if (fromAccount.Withdraw(amount))
        {
            toAccount.Deposit(amount);
        }
        else
        {
            Console.WriteLine("Transfer failed.");
        }
    }
}
