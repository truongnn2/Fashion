using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;

namespace DBBusiness
{
    public class NewsDB
    {
        DBLayer db;
        public NewsDB()
        {
            db = new DBLayer();
        }
        public bool insert(ref string err, News td)
        {
            return db.MyExecuteNonQuery("insert into News (Title,Intro,Content,DateCreate,Status,author) values(@Title,@Intro,@Content,@DateCreate,@Status,@author)", CommandType.Text, ref err,
                new SqlParameter("@Title", td.Title),
                new SqlParameter("@Intro", td.Intro),
                new SqlParameter("@Content", td.Content),
                new SqlParameter("@DateCreate", td.DateCreate),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@author", td.author)
                );
        }
        public bool updatePhoto(ref string err, News td)
        {
            return db.MyExecuteNonQuery("update News set Photo=@Photo where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Photo", td.Photo)
                );
        }
        public bool update(ref string err, News td)
        {
            return db.MyExecuteNonQuery("update News set Title=@Title,Intro=@Intro,Content=@Content,Status=@Status,author=@author where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Title", td.Title),
                new SqlParameter("@Intro", td.Intro),
                new SqlParameter("@Content", td.Content),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@author", td.author)
                );
        }
        public bool updateStatus(ref string err, News td)
        {
            return db.MyExecuteNonQuery("update News set Status=@Status where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Status", td.Status)
                );
        }
        
        public bool delete(ref string err, string id)
        {
            return db.MyExecuteNonQuery("Delete from News where ID=@id", CommandType.Text, ref err, new SqlParameter("@id", id));
        }
        public IList getList(string sql)
        {
            return db.getList(sql);
        }
    }
}
