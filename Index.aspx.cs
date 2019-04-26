using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    Bank CoGB;
    string login;
    string inputPin;
    int attempts;

    protected void Page_Load(object sender, EventArgs e)
    {
        //disable customer login if bank not started
        if (Session["BankDB"] == null)
        {
            rblChoose.Items[1].Enabled = false;
        }
        else
        {
            rblChoose.Items[1].Enabled = true;
        }
        

    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        //If current session variable exists
        if (Session["BankDB"] == null)
        {
            //if not create one
            CoGB = new Bank();
        }
        else
        {
            //if there is store in variable
            CoGB = (Bank)Session["BankDB"];
        }

        login = Login1.UserName;
        inputPin = Login1.Password;

        //If Manager selected
        if (rblChoose.SelectedValue.Equals("Manager")) {
            //If login and  pin are valid for a manager
            if (CoGB.isValidManagerLogin(login, inputPin))
            {
                //if login successful reset attempts
                attempts = 0;
                //Store CoGB, login & pin in Session
                Session["BankDB"] = CoGB;
                Session["login"] = login;
                Session["pin"] = inputPin;

                //Go to Manager Home Page
                Response.Redirect("~/Manager/ManagerHome.aspx");
            }
            else
            {
                //if login fails check previous attaempts
                if (Session["Attempts"] != null)
                    attempts = (int)Session["Attempts"];
                //show error message
                Login1.FailureText = "incorrect Manager details";

                //increase number of failed attempts
                attempts++;
                CoGB.FailedLogins++;

                //if failed 3 times
                if (attempts == 3)
                {
                    //display account locked error
                    Login1.FailureText = "Invalid login. Your account has been locked";
                    //disable check boxes
                    Login1.Enabled = false;
                }

                Session["BankDB"] = CoGB;
                Session["Attempts"] = attempts;
            }

        }
        //else if Customer selected
        else if (rblChoose.SelectedValue.Equals("Customer"))
        {
            if (CoGB.isValidAccountLogin(login, inputPin))
            {
                //if login successful reset attempts
                attempts = 0;
                //update the number of successful logins
                CoGB.TimesUsed++;
                //Store CoGB, login & pin in Session
                Session["BankDB"] = CoGB;
                Session["Login"] = login;
                Session["Pin"] = inputPin;

                //Go to Customer Home Page
                Response.Redirect("~/Customer/CustomerHome.aspx");
            }else
            {
                //if login fails check previous attaempts
                if (Session["Attempts"] != null)
                    attempts = (int)Session["Attempts"];
                //show error message
                Login1.FailureText = "Invalid login - try again!";

                //increase number of failed attempts
                attempts++;
                CoGB.FailedLogins++;

                //if failed 3 times
                if (attempts == 3)
                {
                    //display account locked error
                    Login1.FailureText = "Invalid login. Your account has been locked";
                    //update number of locked customer accounts
                    CoGB.CardsRetained++;
                    //reset attempts for next customer
                    attempts = 0;
                }

                Session["BankDB"] = CoGB;
                Session["Attempts"] = attempts;
            }


        }
    }
    protected void rblChoose_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}