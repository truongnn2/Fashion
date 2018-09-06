using System;
using System.Data;
using System.Configuration;
using System.Web;

public class LinkWebsite
{
    private int _ID;

    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }
    private String _Website;

    public String Website
    {
        get { return _Website; }
        set { _Website = value; }
    }

    private String _Url;

    public String Url
    {
        get { return _Url; }
        set { _Url = value; }
    }
    
    private Int16 _Status;

    public Int16 Status
    {
        get { return _Status; }
        set { _Status = value; }
    }

    public LinkWebsite()
    {

    }
}
