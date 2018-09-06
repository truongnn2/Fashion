using System;
using System.Data;
using System.Configuration;
using System.Web;

public class Download
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

    private String _Namefile;

    public String Namefile
    {
        get { return _Namefile; }
        set { _Namefile = value; }
    }
    private Int16 _Status;

    public Int16 Status
    {
        get { return _Status; }
        set { _Status = value; }
    }

    public Download()
    {

    }
}
