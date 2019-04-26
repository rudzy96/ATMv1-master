using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_CustomerViewBalance : System.Web.UI.Page
{
    private Bank CoGB;
    string inputPin;
    string login;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if session is empty
        if(Session["BankDB"] == null)
        {
            //return to home page
            Response.Redirect("ATMv1/Index.aspx");
        }
        else
        {
            //retrieve session, pin & login for current user
            CoGB = (Bank)Session["BankDB"];
            inputPin = Session["pin"].ToString();
            login = Session["login"].ToString();
        }

        //create new Dictionary of Customers called ‘allCustomers’, and retrieve all Customers from CoGB
        Dictionary<string, Customer> allCustomers;
        allCustomers = CoGB.CustomerData;

        foreach(KeyValuePair<string, Customer> customer in allCustomers)
        {
            //if the login key matches a customer
            if (customer.Value.Id.Equals(login))
            {
                //store the customers details
                Customer aCustomer = customer.Value;
                //display the saved details in a label
                customerNameLbl.Text = aCustomer.Forename + " " + aCustomer.Surname;
                //get the customer account details
                Account anAccount = aCustomer.getAccount(inputPin);
                //display account details in label
                customerAccountLbl.Text = anAccount.AccountNumber;
                //display customer account balance
                customerBalanceLbl.Text = anAccount.Balance.ToString("C");
            }

        }
    }

    protected void removelbtn_Click(object sender, EventArgs e)
    {
        //go back to home page
        Response.Redirect("~/index.aspx");
    }
}