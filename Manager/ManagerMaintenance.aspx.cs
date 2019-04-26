using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_ManagerMaintenance : System.Web.UI.Page
{
    Bank CoGB;

    protected void Page_Load(object sender, EventArgs e)
    {
        //check there's a bank session running
        if(Session["BankDB"] == null)
        {
            //if not return to home page
            Response.Redirect("ATMv1/Index.aspx");
        }
        else
        {
            //load current exchange rate & fill labels with appropriate data
            CoGB = (Bank)Session["BankDB"];

            exchangeRateLbl.Text = CoGB.ExchangeRate.ToString();
            timesUsedLbl.Text = CoGB.TimesUsed.ToString();
            withdrawalsLbl.Text = CoGB.Withdrawals.ToString();
            totalBalanceLbl.Text = CoGB.TotalBalance.ToString();
            failedLoginsLbl.Text = CoGB.FailedLogins.ToString();
            cardsRetainedLbl.Text = CoGB.CardsRetained.ToString();
        }
    }

    protected void setRateBtn_Click(object sender, EventArgs e)
    {
        //check text box is not empty
        if (!exchangeRateLbl.Text.Equals(""))
        {
            //make sure error label is empty
            errorLbl.Text = "";

            //decimal variable to hold the new exchange rate
            decimal exchRate;
            //make the new variable equal the text in the label 
            exchRate = Convert.ToDecimal(exchangeRateLbl.Text);
            //set the exchange rate for the bank
            CoGB.ExchangeRate = exchRate;
            //save it to the session
            Session["BankDB"] = CoGB;

        }else
        {
            //if no rate has been entered display error message
            errorLbl.Text = "No Please enter a rate";
        }
    }
}