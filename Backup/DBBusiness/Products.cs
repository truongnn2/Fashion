using System;
using System.Data;
using System.Configuration;
using System.Web;


public class Products
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
    private Int16 _Category;

    public Int16 Category
    {
        get { return _Category; }
        set { _Category = value; }
    }
    private Int16 _CategoryDetail;

    public Int16 CategoryDetail
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
   
    private Int16 _IsHot;

    public Int16 IsHot
    {
        get { return _IsHot; }
        set { _IsHot = value; }
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
    public Products()
    {

    }
}
