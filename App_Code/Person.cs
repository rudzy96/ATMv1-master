using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// City of Glasgow Bank
/// by Neal Nisbet
/// Summary description for User
/// </summary>
public class Person
{
    //private fields
    private string id;
    private string forename;
    private string surname;
    private string homeAddress;
    private string telNo;
    private string email;

    //zero augmented constructor
    public Person()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //overloaded constructor with input parameters
    public Person(string id, string forename, string surname, string homeAddress, string telNo, string email)
    {
        this.Id = id;
        this.Forename = forename;
        this.Surname = surname;
        this.HomeAddress = homeAddress;
        this.TelNo = telNo;
        this.Email = email;
    }

    //getters & setters
    public string Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public string Forename
    {
        get
        {
            return forename;
        }

        set
        {
            forename = value;
        }
    }

    public string Surname
    {
        get
        {
            return surname;
        }

        set
        {
            surname = value;
        }
    }

    public string HomeAddress
    {
        get
        {
            return homeAddress;
        }

        set
        {
            homeAddress = value;
        }
    }

    public string TelNo
    {
        get
        {
            return telNo;
        }

        set
        {
            telNo = value;
        }
    }

    public string Email
    {
        get
        {
            return email;
        }

        set
        {
            email = value;
        }
    } 
}