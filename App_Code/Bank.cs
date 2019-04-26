using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// City of Glasgow Bank
/// by Neal Nisbet
/// Summary description for Bank
/// </summary>
public class Bank
{
    //global vaiables
    private string atmId;
    private Dictionary<string, Manager> managerData;
    private Dictionary<string, Customer> customerData;
    private int cardsRetained;
    private int failedLogins;
    private int timesUsed;
    private decimal exchangeRate;
    private decimal totalBalance;
    private decimal withdrawals;
    private Dictionary<string, Account> customerAccountData;

    //constructor initialises instance variables
    public Bank()
    {
        managerData = new Dictionary<string, Manager>();
        customerData = new Dictionary<string, Customer>();

        BankDataAccess db = new BankDataAccess();
        db.LoadAllPersonData();
        managerData = db.GetManagers();
        customerData = db.GetCustomers();

        atmId = "CoGB";
        exchangeRate = 1.12m;
        timesUsed = 0;//there were zero additions
        withdrawals = 0;
        totalBalance = 10000m;
        failedLogins = 0;
        cardsRetained = 0;
    }

   

    //getters & setters
    public string AtmId
    {
        get
        {
            return atmId;
        }

        set
        {
            atmId = value;
        }
    }

    public Dictionary<string, Manager> ManagerData
    {
        get
        {
            return managerData;
        }

        set
        {
            managerData = value;
        }
    }

    public Dictionary<string, Customer> CustomerData
    {
        get
        {
            return customerData;
        }

        set
        {
            customerData = value;
        }
    }

    public int CardsRetained
    {
        get
        {
            return cardsRetained;
        }

        set
        {
            cardsRetained = value;
        }
    }

    public int FailedLogins
    {
        get
        {
            return failedLogins;
        }

        set
        {
            failedLogins = value;
        }
    }

    public int TimesUsed
    {
        get
        {
            return timesUsed;
        }

        set
        {
            timesUsed = value;
        }
    }

    public decimal ExchangeRate
    {
        get
        {
            return exchangeRate;
        }

        set
        {
            exchangeRate = value;
        }
    }

    public decimal TotalBalance
    {
        get
        {
            return totalBalance;
        }

        set
        {
            totalBalance = value;
        }
    }

    public decimal Withdrawals
    {
        get
        {
            return withdrawals;
        }

        set
        {
            withdrawals = value;
        }
    }

    public Dictionary<string, Account> CustomerAccountData
    {
        get
        {
            return customerAccountData;
        }

        set
        {
            customerAccountData = value;
        }
    }

    //additional methods

    //Add a customer to the Bank’s collection of customers
    public void addCustomer(Customer newCustomer)
    {
        //check if customer id exists
        if (!customerData.ContainsKey(newCustomer.Id))
        {
            //add account to customer dictionary of accounts
            customerData.Add(newCustomer.Id, newCustomer);
        }
    }

    public bool getManager(string login, string inputPin)
    {
        bool aManager = false;

        //check for each account in dictionary of accounts
        foreach (KeyValuePair<string, Manager> kval in managerData)
        {
            //if the account pin is equal to inputPin
            if (inputPin.Equals(inputPin))
            {
                aManager = true;
            }
        }
        return aManager;
    }

    public bool isValidAccountLogin(string login, string inputPin)
    {
        bool validLogin = false;

        //for each element in dictionary of customers
        foreach (KeyValuePair<string, Customer> kval in customerData)
        {
            Customer c = kval.Value;
            //if the element key = login and and the element value checkPin(inputPin ) = true
            if (c.checkPin(inputPin))
            {
                validLogin = true;
            }
        }
        return validLogin;
    }

    //Check that manager unsername & input pin is valid
    public bool isValidManagerLogin(string login, string inputPin)
    {
        bool validLogin = false;

        foreach (KeyValuePair<string, Manager> kval in managerData)

            //check if the managers username exists
            if (managerData.ContainsKey(login))
            {
                //if the managers username exists
                Manager m = managerData[login];
                //check the machine pin matched the password
                if (m.MachinePin.Equals(inputPin))
                {
                    validLogin = true;
                }
            }
        return validLogin;

    }

    public decimal getBalance(string id, string inputPin)
    {
        //declare a local variables for customer & balance
        Customer aCustomer = null;
        decimal balance = 0;

        //loop through the dictionary to find the customer
        foreach (KeyValuePair<string, Customer> customer in CustomerData)
        {
            //if the id matches save in aCustomer
            if (customer.Value.Id.Equals(id))
                aCustomer = customer.Value;
        }
        //get the account balance for the customer
        balance = aCustomer.getAccount(inputPin).Balance;

        //return the balance
        return balance;
    }

    //withdraw money from account
    public bool withdraw(string login, string inputpin, decimal amount)
    {
        //local variable to hold customer & account details
        Customer aCustomer;
        Account anAccount;
        Boolean success = false;

        //check each customer for correct details
        foreach (KeyValuePair<string, Customer> customer in customerData)
        {
            //if a customer is found with the matching id
            if (customer.Value.Id.Equals(login))
            {
                //store the customer & account
                aCustomer = customer.Value;
                anAccount = aCustomer.getAccount(inputpin);

                //attempt to debit the account
                success = anAccount.debit(amount);
            }
            //if successful updat the total
            if (success)
            {
                this.Withdrawals += amount;
                this.TotalBalance -= amount;
            }
        }
        //return the result of the transaction
        return success;
    }
}
