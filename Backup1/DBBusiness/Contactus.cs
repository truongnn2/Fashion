using System;
using System.Data;
using System.Configuration;
using System.Web;
public class Contactus
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
    
    private String _Content;

    public String Content
    {
        get { return _Content; }
        set { _Content = value; }
    }
    private String _Address;

    public String Address
    {
        get { return _Address; }
        set { _Address = value; }
    }
    private DateTime _DatePost;

    public DateTime DatePost
    {
        get { return _DatePost; }
        set { _DatePost = value; }
    }
    private Int16 _Status;

    public Int16 Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
    private String _Donhang;

    public String Donhang
    {
        get { return _Donhang; }
        set { _Donhang = value; }
    }
    public Contactus()
    {

    }
}

