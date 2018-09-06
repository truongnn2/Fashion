using System;
using System.Data;
using System.Configuration;
using System.Web;
public class Guest
{
    private int _ID;

    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }
    private String _Name;

    public String Name
    {
        get { return _Name; }
        set { _Name = value; }
    }
    private String _Username;

    public String Username
    {
        get { return _Username; }
        set { _Username = value; }
    }
    private String _Email;

    public String Email
    {
        get { return _Email; }
        set { _Email = value; }
    }
    private String _Password;

    public String Password
    {
        get { return _Password; }
        set { _Password = value; }
    }
    private String _Phone;

    public String Phone
    {
        get { return _Phone; }
        set { _Phone = value; }
    }
    private String _MobilePhone;

    public String MobilePhone
    {
        get { return _MobilePhone; }
        set { _MobilePhone = value; }
    }
    private Int16 _Status;

    public Int16 Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
    private DateTime _Date;

    public DateTime Date
    {
        get { return _Date; }
        set { _Date = value; }
    }
    public Guest()
    {

    }
}

