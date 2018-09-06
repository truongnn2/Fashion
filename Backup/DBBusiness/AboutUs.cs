using System;
using System.Data;
using System.Configuration;
using System.Web;
public class AboutUs
{
    private int _ID;

    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }
    private String _Intro;

    public String Intro
    {
        get { return _Intro; }
        set { _Intro = value; }
    }
    private String _Content;

    public String Content
    {
        get { return _Content; }
        set { _Content = value; }
    }
    private String _Email;

    public String Email
    {
        get { return _Email; }
        set { _Email = value; }
    }
    private String _Address;

    public String Address
    {
        get { return _Address; }
        set { _Address = value; }
    }
    private String _Phone;

    public String Phone
    {
        get { return _Phone; }
        set { _Phone = value; }
    }
    private String _Fax;

    public String Fax
    {
        get { return _Fax; }
        set { _Fax = value; }
    }
    private String _Website;

    public String Website
    {
        get { return _Website; }
        set { _Website = value; }
    }
    private String _Photo;

    public String Photo
    {
        get { return _Photo; }
        set { _Photo = value; }
    }
    private String _IntroE;

    public String IntroE
    {
        get { return _IntroE; }
        set { _IntroE = value; }
    }
    private String _ContentE;

    public String ContentE
    {
        get { return _ContentE; }
        set { _ContentE = value; }
    }
    private String _AddressE;

    public String AddressE
    {
        get { return _AddressE; }
        set { _AddressE = value; }
    }
    public AboutUs()
    {

    }
}

