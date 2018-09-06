using System;
using System.Data;
using System.Configuration;
using System.Web;
public class Admin
{
    private int _AdminID;

    public int AdminID
    {
        get { return _AdminID; }
        set { _AdminID = value; }
    }
    private String _Username;

    public String Username
    {
        get { return _Username; }
        set { _Username = value; }
    }
    private String _Password;

    public String Password
    {
        get { return _Password; }
        set { _Password = value; }
    }

    public Admin()
    {

    }
}

