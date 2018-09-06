using System;
using System.Data;
using System.Configuration;
using System.Web;


public class CommentFont
{
    private int _ID;

    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }
    private int _GuestID;

    public int GuestID
    {
        get { return _GuestID; }
        set { _GuestID = value; }
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
   
    private DateTime _DateCreate;

    public DateTime DateCreate
    {
        get { return _DateCreate; }
        set { _DateCreate = value; }
    }


    private Int32 _FontID;

    public Int32 FontID
    {
        get { return _FontID; }
        set { _FontID = value; }
    }

    private String _Name;

    public String Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    private String _Email;

    public String Email
    {
        get { return _Email; }
        set { _Email = value; }
    }
    public CommentFont()
    {

    }
}
