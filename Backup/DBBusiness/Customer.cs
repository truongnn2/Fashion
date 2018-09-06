using System;
using System.Data;
using System.Configuration;
using System.Web;


public class Customer
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

    private String _Phone;

    public String Phone
    {
        get { return _Phone; }
        set { _Phone = value; }
    }
    private String _Email;

    public String Email
    {
        get { return _Email; }
        set { _Email = value; }
    }
    private String _Address;

    public String Address
    {
        get { return _Address; }
        set { _Address = value; }
    }
    private Int16 _Status;

    public Int16 Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
    private Int16 _Type;

    public Int16 Type
    {
        get { return _Type; }
        set { _Type = value; }
    }
    private Int16 _Location;

    public Int16 Location
    {
        get { return _Location; }
        set { _Location = value; }
    }
    public Customer()
    {

    }
}
