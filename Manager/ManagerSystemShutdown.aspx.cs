using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Manager_ManagerSystemShutdown : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BankDataAccess accountUpdate;
        
        //initilise the bank session
        Bank CoGB = (Bank)Session["BankDB"];


        foreach (KeyValuePair<String,Customer>  custEntry in CoGB.CustomerData)
        {
            foreach (KeyValuePair<String, Account> accEntry in custEntry.Value.Accounts)
            {
                //call update account method
                accountUpdate = new BankDataAccess();
                accountUpdate.updateAccount(accEntry.Value);
            }
        }

          //Delete session variables
          Session["BankDB"] = null;
          Session["Login"] = null;
          Session["Pin"] = null;

          //return to homepage
          Response.Redirect("~/index.aspx");
    }
}