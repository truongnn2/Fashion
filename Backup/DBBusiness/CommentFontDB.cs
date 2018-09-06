using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;

namespace DBBusiness
{
    public class CommentFontDB
    {
        DBLayer db;
        public CommentFontDB()
        {
            db = new DBLayer();
        }
        public bool insert(ref string err, CommentFont td)
        {
            return db.MyExecuteNonQuery("insert into CommentFont (Title,Content,Status,DateCreate,FontID,Name,Email,GuestID) values(@Title,@Content,@Status,@DateCreate,@FontID,@Name,@Email,@GuestID)", CommandType.Text, ref err,
                new SqlParameter("@Title", td.Title),
                new SqlParameter("@Content", td.Content),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@DateCreate", td.DateCreate),
                new SqlParameter("@FontID", td.FontID),
                new SqlParameter("@Name", td.Name),
                new SqlParameter("@Email", td.Email),
                new SqlParameter("@GuestID", td.GuestID)
                );
        }

        public bool updateStatus(ref string err, CommentFont td)
        {
            return db.MyExecuteNonQuery("update CommentFont set Status=@Status where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Status", td.Status)
                );
        }
      
        public bool delete(ref string err, string id)
        {
            return db.MyExecuteNonQuery("Delete from CommentFont where ID=@id", CommandType.Text, ref err, new SqlParameter("@id", id));
        }
        public IList getList(string sql)
        {
            return db.getList(sql);
        }
    }
}
