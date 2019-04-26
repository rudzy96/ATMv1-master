using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


public class BankDataAccess
{
    //Connection attributes
    private SqlCommand comm;
    private string connStr;
    private SqlConnection conn;

    //Dictionaries for customers and managers
    private Dictionary<string, Manager> bankManagers;
    private Dictionary<string, Customer> BankCustomers;

    public Dictionary<string, Manager> GetManagers()
    { return bankManagers; }
    public Dictionary<string, Customer> GetCustomers()
    { return BankCustomers; }


    //BankDataAccess method that connects with external Database
    public BankDataAccess()
    {
        connStr = ConfigurationManager.ConnectionStrings["BankDB"].ConnectionString;
        conn = new SqlConnection(connStr);

        bankManagers = new Dictionary<string, Manager>();
        BankCustomers = new Dictionary<string, Customer>();
    }

    //retrieveAllPersonalData method from the "Person" seciont of the external database
    public DataTable retrieveAllPersonData()
    {
        string myQuery = "SELECT * FROM PERSON";
        var myConnection = new SqlConnection(connStr);
        var myCommand = new SqlCommand(myQuery, myConnection);
        SqlDataReader myResults;
        DataTable myDataTable = new DataTable();

     
        try
        {
            myConnection.Open();
            myResults = myCommand.ExecuteReader();

            if (myResults.HasRows == true)
            {
                myDataTable.Load(myResults);
            }

            return myDataTable;
        }

        //Catch Exception
        catch (Exception e)
        {
            return myDataTable;
        }

 
        finally
        {
            myConnection.Close();
            myCommand.Dispose();
        }
    }

    //retrieveAllAccountData method from the "Account" seciont of the external database

    public DataTable retrieveAllAccountData()
    {
        string myQuery = "SELECT * FROM ACCOUNT";
        var myConnection = new SqlConnection(connStr);
        var myCommand = new SqlCommand(myQuery, myConnection);
        SqlDataReader myResults;
        DataTable myDataTable = new DataTable();

        //Returns data table if successful
        try
        {
            myConnection.Open();
            myResults = myCommand.ExecuteReader();

            if (myResults.HasRows == true)
            {
                myDataTable.Load(myResults);
            }

            return myDataTable;
        }

        //Catch Exception
        catch (Exception e)
        {
            return myDataTable;
        }

        //Connection is closed
        finally
        {
            myConnection.Close();
            myCommand.Dispose();
        }
    }


    //LoadAllPersonData method which takes the retrieved data from the Person and Account
    //database and assigns it to the Account and Person Classes

    public void LoadAllPersonData()
    {
        string accountNo;
        decimal balance;
        string pin;
        BankDataAccess myDB;
        DataTable PersonTable;
        DataTable AccountTable;

        myDB = new BankDataAccess();
        PersonTable = myDB.retrieveAllPersonData();
        AccountTable = myDB.retrieveAllAccountData();

        for (int i = 0; i <= PersonTable.Rows.Count - 1; i++)
        {
            string id = Convert.ToString(PersonTable.Rows[i][0]);
            string fname = Convert.ToString(PersonTable.Rows[i][1]);
            string sname = Convert.ToString(PersonTable.Rows[i][2]);
            string homeAddress = Convert.ToString(PersonTable.Rows[i][3]);
            string telNo = Convert.ToString(PersonTable.Rows[i][4]);
            string email = Convert.ToString(PersonTable.Rows[i][5]);
            string role = Convert.ToString(PersonTable.Rows[i][6]);
            string mpin = Convert.ToString(PersonTable.Rows[i][7]);

            //If the data is for a manager it is loaded into the Manager class
            if (role.Equals("M"))
            {
                Manager newmanager = new Manager(id, fname, sname, homeAddress, telNo, email, mpin);
                bankManagers.Add(id, newmanager);
            }

            //If the data is for a customer it is loaded into the Customer class
            else if (role.Equals("C"))
            {
                Customer newcustomer = new Customer(id, fname, sname, homeAddress, telNo, email);
                BankCustomers.Add(id, newcustomer);

                //Adds account information to Account Class
                for (int j = 0; j <= AccountTable.Rows.Count - 1; j++)
                {
                    accountNo = Convert.ToString(AccountTable.Rows[j][0]);
                    balance = Convert.ToDecimal(AccountTable.Rows[j][1]);
                    pin = Convert.ToString(AccountTable.Rows[j][2]);
                    id = Convert.ToString(AccountTable.Rows[j][3]);

                    if (newcustomer.Id.Trim() == id.Trim())
                    {
                        newcustomer.addAccount(new Account(accountNo, pin, balance));
                    }
                }
            }
        }
    }

    public bool updateAccount(Account acc)
    {
        bool successfulUpdate = false;
        string sql = "UPDATE Account SET Balance=@Balance WHERE AccountNumber=@accno";

      
        SqlCommand cmd = new SqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("@Balance", acc.Balance);
        cmd.Parameters.AddWithValue("@accno", acc.AccountNumber);

        try
        {
           conn.Open();
            int rows = cmd.ExecuteNonQuery();
            //check what rows returned & set successfullUpdate
            if (rows == 1)
            {
                successfulUpdate = true;
            }
        }
        catch (SqlException ex)
        {
            String err = ex.Message;
        }
        finally
        {
            conn.Close();
        }
        return successfulUpdate;
    }
}
