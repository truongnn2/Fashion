using System;
using System.Data;
using System.Configuration;
using System.Web;


public class SupportOnline
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
    private String _NickName;

    public String NickName
    {
        get { return _NickName; }
        set { _NickName = value; }
    }
    private String _NickSkype;

    public String NickSkype
    {
        get { return _NickSkype; }
        set { _NickSkype = value; }
    }
    private String _Phone;

    public String Phone
    {
        get { return _Phone; }
        set { _Phone = value; }
    }

    private Int16 _Status;

    public Int16 Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
   
    public SupportOnline()
    {

    }
}
