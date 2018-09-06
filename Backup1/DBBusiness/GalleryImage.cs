using System;
using System.Data;
using System.Configuration;
using System.Web;


public class GalleryImage
{
    private int _ID;

    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }

    private String _Photo;

    public String Photo
    {
        get { return _Photo; }
        set { _Photo = value; }
    }
    private String _Description;

    public String Description
    {
        get { return _Description; }
        set { _Description = value; }
    }
    public GalleryImage()
    {

    }
}
