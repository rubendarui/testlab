class BankAccount
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
            Console.WriteLine($"Deposited {amount:C} into account {AccountNumber}. New balance: {Balance:C}");
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
            Console.WriteLine($"Withdrawn {amount:C} from account {AccountNumber}. New balance: {Balance:C}");
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
            Console.WriteLine($"Transferred {amount:C} from account {fromAccount.AccountNumber} to account {toAccount.AccountNumber}.");
        }
        else
        {
            Console.WriteLine("Transfer failed.");
        }
    }
}
