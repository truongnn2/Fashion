using System;
using System.Data;
using System.Configuration;
using System.Web;
public class Giamgia
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
    
    private String _Photo;

    public String Photo
    {
        get { return _Photo; }
        set { _Photo = value; }
    }



    public Giamgia()
    {

    }
}

