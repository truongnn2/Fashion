using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;
namespace DBBusiness
{
    public class UserRoleDB
    {
        DBLayer db;
        public UserRoleDB()
        {
            db = new DBLayer();
        }
        public bool insert(ref string err, UserRole td)
        {
            return db.MyExecuteNonQuery("insert into UserRole (IDuser,IDRole,Status,CategoryNews) values(@IDuser,@IDRole,@Status,@CategoryNews)", CommandType.Text, ref err,
                new SqlParameter("@IDuser", td.IDuser),
                new SqlParameter("@IDRole", td.IDRole),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@CategoryNews", td.CategoryNews)
                );
        }
        public bool updateStatus(ref string err, UserRole td)
        {
            return db.MyExecuteNonQuery("update UserRole set Status=@Status where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Status", td.Status)
                );
        }
        public bool delete(ref string err, string id)
        {
            return db.MyExecuteNonQuery("Delete from UserRole where ID=@id", CommandType.Text, ref err, new SqlParameter("@id", id));
        }
        public bool deleteIDUser(ref string err, string idUser)
        {
            return db.MyExecuteNonQuery("Delete from UserRole where IDuser=@IDuser", CommandType.Text, ref err, new SqlParameter("@IDuser", idUser));
        }
        public IList getList(string sql)
        {
            return db.getList(sql);
        }
    }
}
