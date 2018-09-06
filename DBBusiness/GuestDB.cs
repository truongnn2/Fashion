using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;

namespace DBBusiness
{
    public class GuestDB
    {
        DBLayer db;
        public GuestDB()
        {
            db = new DBLayer();
        }

        public bool updateStatus(ref string err, Guest td)
        {
            return db.MyExecuteNonQuery("update Guest set Status=@Status where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Status", td.Status)
                );
        }
        public bool UpdateChangPass(ref string err, Guest td)
        {
            return db.MyExecuteNonQuery("update Guest set Password=@Password where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Password", td.Password)
                );
        }
        public bool update(ref string err, Guest td)
        {
            return db.MyExecuteNonQuery("update Guest set Name=@Name,Phone=@Phone,MobilePhone=@MobilePhone,Email=@Email where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Name", td.Name),
                new SqlParameter("@Phone", td.Phone),
                new SqlParameter("@MobilePhone", td.MobilePhone),
                new SqlParameter("@Email", td.Email)
                );
        }
        public bool delete(ref string err, string id)
        {
            return db.MyExecuteNonQuery("Delete from Guest where ID=@id", CommandType.Text, ref err, new SqlParameter("@id", id));
        }
        public IList getList(string sql)
        {
            return db.getList(sql);
        }
        public bool insert(ref string err, Guest td)
        {
            return db.MyExecuteNonQuery("insert into Guest (Name,Password,Phone,MobilePhone,Email,Status,Date) values(@Name,@Password,@Phone,@MobilePhone,@Email,@Status,@Date)", CommandType.Text, ref err,
                new SqlParameter("@Name", td.Name),
                new SqlParameter("@Password", td.Password),
                new SqlParameter("@Phone", td.Phone),
                new SqlParameter("@MobilePhone", td.MobilePhone),
                new SqlParameter("@Email", td.Email),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@Date", td.Date)
                );
        }
    }
}
