using System;
using System.Data;
using System.Configuration;
using System.Web;
public class QA
{
    private int _ID;

    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }
    private String _Question;

    public String Question
    {
        get { return _Question; }
        set { _Question = value; }
    }
    private String _Answer;

    public String Answer
    {
        get { return _Answer; }
        set { _Answer = value; }
    }
    private DateTime _DatePost;

    public DateTime DatePost
    {
        get { return _DatePost; }
        set { _DatePost = value; }
    }
    private DateTime _DateAnswer;

    public DateTime DateAnswer
    {
        get { return _DateAnswer; }
        set { _DateAnswer = value; }
    }
    private Int16 _Status;

    public Int16 Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
    private String _Title;

    public String Title
    {
        get { return _Title; }
        set { _Title = value; }
    }
    private String _Name;

    public String Name
    {
        get { return _Name; }
        set { _Name = value; }
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
    private String _Email;

    public String Email
    {
        get { return _Email; }
        set { _Email = value; }
    }
    public QA()
    {

    }
}