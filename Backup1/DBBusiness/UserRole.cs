using System;
using System.Data;
using System.Configuration;
using System.Web;
public class UserRole
{
    private int _ID;

    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }

    private int _IDuser;

    public int IDuser
    {
        get { return _IDuser; }
        set { _IDuser = value; }
    }
    private int _Status;

    public int Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
    private int _IDRole;

    public int IDRole
    {
        get { return _IDRole; }
        set { _IDRole = value; }
    }
    private int _CategoryNews;

    public int CategoryNews
    {
        get { return _CategoryNews; }
        set { _CategoryNews = value; }
    }
    public UserRole()
    {

    }
}

