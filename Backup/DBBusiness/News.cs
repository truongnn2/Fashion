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
   
    private String _Intro;

    public String Intro
    {
        get { return _Intro; }
        set { _Intro = value; }
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
   
    private Int16 _Status;

    public Int16 Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
    
    private String _author;

    public String author
    {
        get { return _author; }
        set { _author = value; }
    }
   
    private DateTime _DateCreate;

    public DateTime DateCreate
    {
        get { return _DateCreate; }
        set { _DateCreate = value; }
    }
    
    private Int16 _IsHot;

    public Int16 IsHot
    {
        get { return _IsHot; }
        set { _IsHot = value; }
    }
    public News()
    {

    }
}
