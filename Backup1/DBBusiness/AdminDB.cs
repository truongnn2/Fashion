using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;
namespace DBBusiness
{
    public class AdminDB
    {
        DBLayer db;
        public AdminDB()
        {
            db = new DBLayer();
        }
        public bool insert(ref string err, Admin td)
        {
            return db.MyExecuteNonQuery("insert into Admin (Username,Password) values(@Username,@Password)", CommandType.Text, ref err,
                new SqlParameter("@Username", td.Username),
                new SqlParameter("@Password", td.Password)
                );
        }

        public bool update(ref string err, Admin td)
        {
            return db.MyExecuteNonQuery("update Admin set Password=@Password where AdminID=@AdminID", CommandType.Text, ref err,
                new SqlParameter("@AdminID", td.AdminID),
                new SqlParameter("@Password", td.Password)
                );
        }
      
       
        public IList getList(string sql)
        {
            return db.getList(sql);
        }
    }
}
