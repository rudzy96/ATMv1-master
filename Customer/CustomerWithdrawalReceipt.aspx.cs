using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_CustomerWithdrawalReceipt : System.Web.UI.Page
{
    Bank CoGB;
    string login;
    string inputPin;

    protected void Page_Load(object sender, EventArgs e)
    {
        //check for valid session
        if (Session["BankDB"] == null)
            Response.Redirect("~/index.aspx");
        else
        {
            CoGB = (Bank)Session["BankDB"];
            inputPin = Session["Pin"].ToString();
            login = Session["Login"].ToString();
        }

        //get customer data & strore in session
        Dictionary<string, Customer> allCustomers;
        allCustomers = CoGB.CustomerData;

        //search customer directory
        foreach (KeyValuePair<string, Customer> customer in allCustomers)
        {
            //if login matches
            if (customer.Value.Id.Equals(login))
            {
                //store the details for matched id
                Customer loggedInCustomer = customer.Value;
                //find account for mached id
                Account anAccount = loggedInCustomer.getAccount(inputPin);
                //fill the labels with stored data
                customerNamelbl.Text = loggedInCustomer.Forename + " " + loggedInCustomer.Surname;
                accountNolbl.Text = anAccount.AccountNumber;
                balancelbl.Text = anAccount.Balance.ToString("C");
                //Retrieve amount just withdrawn from Session variable and store in ‘amountWithdrawn’
                decimal amountWithdrawn = (decimal)Session["Amount"];
                //display stored amount in label
                amountlbl.Text = amountWithdrawn.ToString("C");
            }
        }
    }

    protected void exitbtn_Click(object sender, EventArgs e)
    {
        //go back to home page
        Response.Redirect("~/index.aspx");
    }
}