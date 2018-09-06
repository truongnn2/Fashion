using System;
using System.Data;
using System.Configuration;
using System.Web;


public class CatServices
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
    private String _NameE;

    public String NameE
    {
        get { return _NameE; }
        set { _NameE = value; }
    }

    private Int16 _Status;

    public Int16 Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
    private Int16 _Location;

    public Int16 Location
    {
        get { return _Location; }
        set { _Location = value; }
    }
    public CatServices()
    {

    }
}
