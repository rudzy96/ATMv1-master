using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Customer : Person
{
    //private global fields
    //dictionary to hold the accounts for a customer
    private Dictionary<string, Account> accounts;

    //constructors
    public Customer() : base()
    {
        //initialise the account dictionary
        accounts = new Dictionary<string, Account>();
    }

    //overloaded constructor with input parameters including inherited varables from person
    public Customer(string id, string forename, string surname, string homeAddress, string telNo, string email) : base (id, forename, surname, homeAddress, telNo, email)
    {
        //initialise the account dictionary
        accounts = new Dictionary<string, Account>();
    }

    //ReadOnly Property Returns Dictionary of Accounts
    public Dictionary<string, Account> Accounts
    {
        get
        {
            return accounts;
        }
    }

    //add an account to the customer collection of accounts
    public void addAccount(Account newAccount)
    {
        //check is account number exists
        if (!accounts.ContainsKey(newAccount.AccountNumber))
        {
            //add account to customer dictionary of accounts
            accounts.Add(newAccount.AccountNumber, newAccount);
        }
    }

    //check the customer input pin is valid
    public bool checkPin(string inputPin)
    {
        bool validPin = false;// if pin is not valid

        //check the pin for each element in the dictionary of accounts
        foreach (KeyValuePair<string, Account> kval in accounts)
        {
            //if the account pin matches
            if (kval.Value.Pin.Equals(inputPin))
            {
                //valid pin is true
                validPin = true;
            }
        }return validPin;

    }

    //return customer account given pin number
    public Account getAccount(string inputPin)
    {
        Account validAccount = null;
        string key = inputPin;

        //check for each account in dictionary of accounts
        foreach (KeyValuePair<string,Account>account in accounts)
        {
            //if the account pin is equal to the key
            if (account.Value.Pin.Equals(key))
            {
                validAccount = accounts[account.Value.AccountNumber];
            }
        }return validAccount; 
    }
}
