using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// City of Glasgow Bank
/// by Neal Nisbet
/// Summary description for Account
/// </summary>
public class Account
{
    //private fields
    private string accountNumber;
    private string inputPin;
    private decimal balance;

    //zero augmented constructor
    public Account()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //overloaded constructor with input parameters
    public Account(string accountNumber, string inputPin, decimal balance)
    {
        this.accountNumber = accountNumber;
        this.inputPin = inputPin;
        this.balance = balance;
    }

    public string AccountNumber
    {
        get
        {
            return accountNumber;
        }

        set
        {
            accountNumber = value;
        }
    }

    public string Pin
    {
        get
        {
            return inputPin;
        }

        set
        {
            inputPin = value;
        }
    }

    public decimal Balance
    {
        get
        {
            return (decimal)balance;
        }

        set
        {
            balance = value;
        }
    }

    //Credits the receiver account with the amount passed as input parameter
    public void credit(decimal amount)
    {
        //amount credited is added to the balance of the account
        balance = balance + amount;
    }

    //Debits the receiver account by the amount passed as input parameter. Report success or failure
    public bool debit(decimal amount)
    {
        bool sufficientFunds = true;

        //if sufficient funds in account
        if (balance >= amount)
        {
            //update balance
            balance = balance - amount;

            return sufficientFunds;
        
        //else fail
        }else{
            return false;
        }
    }
}