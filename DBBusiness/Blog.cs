using System;
using System.Data;
using System.Configuration;
using System.Web;


public class Blog
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
    private Int16 _Category;

    public Int16 Category
    {
        get { return _Category; }
        set { _Category = value; }
    }
    private Int32 _CategoryDetail;

    public Int32 CategoryDetail
    {
        get { return _CategoryDetail; }
        set { _CategoryDetail = value; }
    }
    
   
    private DateTime _DateCreate;

    public DateTime DateCreate
    {
        get { return _DateCreate; }
        set { _DateCreate = value; }
    }

    private Int16 _DisplayDefault;

    public Int16 DisplayDefault
    {
        get { return _DisplayDefault; }
        set { _DisplayDefault = value; }
    }
    private String _Price;

    public String Price
    {
        get { return _Price; }
        set { _Price = value; }
    }
    private Int16 _IsShowPrice;

    public Int16 IsShowPrice
    {
        get { return _IsShowPrice; }
        set { _IsShowPrice = value; }
    }
   
    private Int32 _Location;

    public Int32 Location
    {
        get { return _Location; }
        set { _Location = value; }
    }
    private String _Intro;

    public String Intro
    {
        get { return _Intro; }
        set { _Intro = value; }
    }
    private Int32 _IsShowDefault;

    public Int32 IsShowDefault
    {
        get { return _IsShowDefault; }
        set { _IsShowDefault = value; }
    }
    public Blog()
    {

    }
}
