using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;

namespace DBBusiness
{
    public class CommentDB
    {
        DBLayer db;
        public CommentDB()
        {
            db = new DBLayer();
        }
        public bool insert(ref string err, Comment td)
        {
            return db.MyExecuteNonQuery("insert into Comment (Title,Content,Status,DateCreate,BlogID,Name,Email,GuestID) values(@Title,@Content,@Status,@DateCreate,@BlogID,@Name,@Email,@GuestID)", CommandType.Text, ref err,
                new SqlParameter("@Title", td.Title),
                new SqlParameter("@Content", td.Content),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@DateCreate", td.DateCreate),
                new SqlParameter("@BlogID", td.BlogID),
                new SqlParameter("@Name", td.Name),
                new SqlParameter("@Email", td.Email),
                new SqlParameter("@GuestID", td.GuestID)
                );
        }
       
        public bool updateStatus(ref string err, Comment td)
        {
            return db.MyExecuteNonQuery("update Comment set Status=@Status where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Status", td.Status)
                );
        }
      
        public bool delete(ref string err, string id)
        {
            return db.MyExecuteNonQuery("Delete from Comment where ID=@id", CommandType.Text, ref err, new SqlParameter("@id", id));
        }
        public IList getList(string sql)
        {
            return db.getList(sql);
        }
    }
}
