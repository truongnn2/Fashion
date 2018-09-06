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
            return db.MyExecuteNonQuery("insert into News (Title,TitleE,Content,ContentE,DateCreate,Status,Location) values(@Title,@TitleE,@Content,@ContentE,@DateCreate,@Status,@Location)", CommandType.Text, ref err,
                new SqlParameter("@Title", td.Title),
                new SqlParameter("@TitleE", td.TitleE),
                new SqlParameter("@Content", td.Content),
                new SqlParameter("@ContentE", td.ContentE),
                new SqlParameter("@DateCreate", td.DateCreate),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@Location", td.Location)
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
            return db.MyExecuteNonQuery("update News set Title=@Title,TitleE=@TitleE,Content=@Content,ContentE=@ContentE,Status=@Status,Location=@Location where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Title", td.Title),
                new SqlParameter("@TitleE", td.TitleE),
                new SqlParameter("@Content", td.Content),
                new SqlParameter("@ContentE", td.ContentE),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@Location", td.Location)
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
