using System;
using System.Data;
using System.Configuration;
using System.Web;


public class Comment
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


    private Int32 _BlogID;

    public Int32 BlogID
    {
        get { return _BlogID; }
        set { _BlogID = value; }
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
    public Comment()
    {

    }
}
