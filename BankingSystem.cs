using System;
using System.Collections.Generic;

public abstract class Account
{
    public string AccountNumber { get; set; }
    public double Balance { get; protected set; }
    public string OwnerName { get; set; }
    private List<Transaction> transactions = new List<Transaction>();

    public Account(string accountNumber, double balance, string ownerName)
    {
        AccountNumber = accountNumber;
        Balance = balance;
        OwnerName = ownerName;
    }

    public virtual void Deposit(double amount)
    {
        Balance += amount;
        RecordTransaction(TransactionType.Deposit, amount);
    }

    public virtual bool Withdraw(double amount)
    {
        if (amount > Balance)
            return false; // Withdrawal failed due to insufficient funds

        Balance -= amount;
        RecordTransaction(TransactionType.Withdrawal, amount);
        return true; // Withdrawal successful
    }

    protected void RecordTransaction(TransactionType type, double amount)
    {
        transactions.Add(new Transaction(type, amount));
    }

    public void DisplayAccountInfo()
    {
        Console.WriteLine($"Account: {AccountNumber} Balance: {Balance} OwnerName: {OwnerName}");
    }

    public void DisplayTransactionHistory()
    {
        Console.WriteLine($"Transaction History for Account: {AccountNumber}");
        foreach (var transaction in transactions)
        {
            transaction.DisplayTransaction();
        }
    }
}

public class SavingsAccount : Account
{
    public double InterestRate { get; set; }

    public SavingsAccount(string accountNumber, double balance, string owner, double interestRate)
        : base(accountNumber, balance, owner)
    {
        InterestRate = interestRate;
    }

    public override bool Withdraw(double amount)
    {
        // Add logic for early withdrawal penalty if necessary
        bool isEarlyWithdrawal = amount > Balance;
        if (isEarlyWithdrawal)
        {
            // Apply penalty
            double penaltyAmount = amount * 0.1; // Assuming a penalty of 10%
            amount += penaltyAmount;
        }

        return base.Withdraw(amount);
    }
}

public class CheckingAccount : Account
{
    private double OverdraftLimit { get; set; }

    public CheckingAccount(string accountNumber, double balance, string owner, double overdraftLimit)
        : base(accountNumber, balance, owner)
    {
        OverdraftLimit = overdraftLimit;
    }

    public override bool Withdraw(double amount)
    {
        if (amount > Balance + OverdraftLimit)
            return false; // Withdrawal failed due to insufficient funds including overdraft

        return base.Withdraw(amount);
    }
}

public enum TransactionType
{
    Deposit,
    Withdrawal
}

public class Transaction
{
    public TransactionType Type { get; }
    public double Amount { get; }
    public DateTime Timestamp { get; }

    public Transaction(TransactionType type, double amount)
    {
        Type = type;
        Amount = amount;
        Timestamp = DateTime.Now;
    }

    public void DisplayTransaction()
    {
        Console.WriteLine($"Type: {Type}, Amount: {Amount}, Timestamp: {Timestamp}");
    }
}

class Program
{
    static void Main()
    {
        // Create instances of account types
        SavingsAccount savingsAccount = new SavingsAccount("123456", 1000.0, "John Doe", 0.05);
        CheckingAccount checkingAccount = new CheckingAccount("654321", 500.0, "Jane Doe", 100.0);

        // Perform transactions
        savingsAccount.Deposit(200.0);
        savingsAccount.Withdraw(50.0);

        checkingAccount.Withdraw(600.0);  // This should trigger overdraft protection

        // Display account information and transaction history
        savingsAccount.DisplayAccountInfo();
        savingsAccount.DisplayTransactionHistory();

        checkingAccount.DisplayAccountInfo();
        checkingAccount.DisplayTransactionHistory();
    }
}
