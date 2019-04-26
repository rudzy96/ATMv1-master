using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// City of Glasgow Bank
/// by Neal Nisbet
/// Summary description for Manager
/// </summary>
public class Manager : Person
{
    //private fields
    private string machinePin;

    //zero augmented constructor
    public Manager() : base()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //overloaded constructor with input parameters including inherited varables from person
    public Manager(string id, string forename, string surname, string homeAddress, string telNo, string email, string machinePin) : base(id, forename, surname, homeAddress, telNo, email)
    {
        this.machinePin = machinePin;
    }

    //getters & setters
    public string MachinePin
    {
        get
        {
            return machinePin;
        }

        set
        {
            machinePin = value;
        }
    }
}