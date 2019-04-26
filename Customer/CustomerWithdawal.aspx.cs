using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_CustomerWithdawal : System.Web.UI.Page
{
    //local variables
    Bank CoGB;
    string inputPin;
    string login;
    int amount;
    bool success;
    decimal decimalAmount;

    protected void Page_Load(object sender, EventArgs e)
    {
        //check there's a bank session running
        if (Session["BankDB"] == null)
        {
            //if not return to home page
            Response.Redirect("ATMv1/Index.aspx");
        }else
        {
            CoGB = (Bank)Session["BankDB"];
            inputPin = Session["Pin"].ToString();
            login = Session["Login"].ToString();
        }
    }

    protected void withdrawlbtn_Click(object sender, EventArgs e)
    {
        //check the if the amount textbox is empty
        if (amounttxt.Text.Equals(""))
        {
            //if no amount entered take amount from checkbox
            amount = Convert.ToInt32(amountrbl.SelectedItem.Value);
        }else
        {
            try
            {
                //check if amount entered is a number & can be converted
                amount = Convert.ToInt32(amounttxt.Text);
            }catch (Exception ex)
            {
                //if not display error
                amountErrorlbl.Text = "Please enter a number";
            }
        }

        //check that amount entered is multiple of 10
        if(amount % 10 != 0)
        {
            //if not display error
            amountErrorlbl.Text = "Please enter a multiple of 10";
        }else
        {
            //check if euro selected
            if(currencyrbl.SelectedIndex == 1)
            {
                //get exchange rate & convert selected amount
                decimalAmount = (decimal)amount / CoGB.ExchangeRate;
                //save to session
                Session["Amount"] = decimalAmount;
                //clear any errors
                amountErrorlbl.Text = "";
            }else
            {
                //if sterling save selected amount
                decimalAmount = amount;
                //save to session
                Session["Amount"] = decimalAmount;
                //clear any errors
                amountErrorlbl.Text = "";
            }

            //check withdrawal was successful
            success = CoGB.withdraw(login, inputPin, decimalAmount);
            if (!success)
                //if unsuccessful show error
                withdrawErrorlbl.Text = "Insufficient funds";

            else
            {
                //if successful show confirmation
                withdrawErrorlbl.Text = "Transaction Complete";
                //check if receipt wanted
                if (receiptChkbx.Checked)
                    //go to receipt page
                    Response.Redirect("~/Customer/CustomerWithdrawalReceipt.aspx");
            }
        }
    }

    protected void removelbtn_Click(object sender, EventArgs e)
    {
        //go back to home page
        Response.Redirect("~/index.aspx");
    }
}