using System;
using System.Data;
using System.Configuration;
using System.Web;
public class AccountTTNB
{
    private int _ID;

    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
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

    public AccountTTNB()
    {

    }
}

