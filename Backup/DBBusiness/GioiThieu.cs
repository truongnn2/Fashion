using System;
using System.Data;
using System.Configuration;
using System.Web;


public class GioiThieu
{
    private int _ID;

    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }
    private String _Title;

    public String Title
    {
        get { return _Title; }
        set { _Title = value; }
    }

    private String _Content;

    public String Content
    {
        get { return _Content; }
        set { _Content = value; }
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
    public GioiThieu()
    {

    }
}
