using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;
namespace DBBusiness
{
    public class ContactusDB
    {
        DBLayer db;
        public ContactusDB()
        {
            db = new DBLayer();
        }

        public bool insert(ref string err, Contactus td)
        {
            return db.MyExecuteNonQuery("insert into Contactus (Name,Phone,Email,Address,Content,DatePost,Status,Donhang) values(@Name,@Phone,@Email,@Address,@Content,@DatePost,@Status,@Donhang)", CommandType.Text, ref err,
                new SqlParameter("@Name", td.Name),
                new SqlParameter("@Phone", td.Phone),
                new SqlParameter("@Email", td.Email),
                new SqlParameter("@Address", td.Address),
                new SqlParameter("@Content", td.Content),
                new SqlParameter("@DatePost", td.DatePost),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@Donhang", td.Donhang)
                );
        }
        public bool updateStatus(ref string err, Contactus td)
        {
            return db.MyExecuteNonQuery("update Contactus set Status=@Status where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Status", td.Status)
                );
        }
        public bool delete(ref string err, string id)
        {
            return db.MyExecuteNonQuery("Delete from Contactus where ID=@id", CommandType.Text, ref err, new SqlParameter("@id", id));
        }
        public IList getList(string sql)
        {
            return db.getList(sql);
        }

    }
}
