using System;
using System.Data;
using System.Configuration;
using System.Web;
public class BoxAd
{
    private int _ID;

    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }
   
    private String _Photo;

    public String Photo
    {
        get { return _Photo; }
        set { _Photo = value; }
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
    private Int16 _Category;

    public Int16 Category
    {
        get { return _Category; }
        set { _Category = value; }
    }
    private Int16 _Location;

    public Int16 Location
    {
        get { return _Location; }
        set { _Location = value; }
    }
    public BoxAd()
    {

    }
}

