using System;
using System.Data;
using System.Configuration;
using System.Web;


public class News
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
    private String _TitleE;

    public String TitleE
    {
        get { return _TitleE; }
        set { _TitleE = value; }
    }
    private String _Photo;

    public String Photo
    {
        get { return _Photo; }
        set { _Photo = value; }
    }

    private String _Content;

    public String Content
    {
        get { return _Content; }
        set { _Content = value; }
    }
    private String _ContentE;

    public String ContentE
    {
        get { return _ContentE; }
        set { _ContentE = value; }
    }

    private Int16 _Status;

    public Int16 Status
    {
        get { return _Status; }
        set { _Status = value; }
    }


    private DateTime _DateCreate;

    public DateTime DateCreate
    {
        get { return _DateCreate; }
        set { _DateCreate = value; }
    }


    private Int32 _Location;

    public Int32 Location
    {
        get { return _Location; }
        set { _Location = value; }
    }
    public News()
    {

    }
}
