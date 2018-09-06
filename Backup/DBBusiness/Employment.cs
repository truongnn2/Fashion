using System;
using System.Data;
using System.Configuration;
using System.Web;
public class Employment
{
    private int _ID;

    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }
   
    private String _Content;

    public String Content
    {
        get { return _Content; }
        set { _Content = value; }
    }

    public Employment()
    {

    }
}

