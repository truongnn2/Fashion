using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;

namespace DBBusiness
{
    public class ServicesDB
    {
        DBLayer db;
        public ServicesDB()
        {
            db = new DBLayer();
        }
        public bool insert(ref string err, Services td)
        {
            return db.MyExecuteNonQuery("insert into Services (Title,TitleE,Content,ContentE,Category,CategorySub,DateCreate,Status,Location,IsHot) values(@Title,@TitleE,@Content,@ContentE,@Category,@CategorySub,@DateCreate,@Status,@Location,@IsHot)", CommandType.Text, ref err,
                new SqlParameter("@Title", td.Title),
                new SqlParameter("@TitleE", td.TitleE),
                new SqlParameter("@Content", td.Content),
                new SqlParameter("@ContentE", td.ContentE),
                new SqlParameter("@Category", td.Category),
                new SqlParameter("@CategorySub", td.CategoryDetail),
                new SqlParameter("@DateCreate", td.DateCreate),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@Location", td.Location),
                new SqlParameter("@IsHot", td.IsHot)
                );
        }
        public bool updatePhoto(ref string err, Services td)
        {
            return db.MyExecuteNonQuery("update Services set Photo=@Photo where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Photo", td.Photo)
                );
        }
        public bool updateFile(ref string err, Services td)
        {
            return db.MyExecuteNonQuery("update Services set FileAttach=@FileAttach where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@FileAttach", td.FileAttach)
                );
        }
        public bool update(ref string err, Services td)
        {
            return db.MyExecuteNonQuery("update Services set Title=@Title,TitleE=@TitleE,Content=@Content,ContentE=@ContentE,Category=@Category,CategorySub=@CategorySub,Status=@Status,Location=@Location,IsHot=@IsHot where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Title", td.Title),
                new SqlParameter("@TitleE", td.TitleE),
                new SqlParameter("@Content", td.Content),
                new SqlParameter("@ContentE", td.ContentE),
                new SqlParameter("@Category", td.Category),
                new SqlParameter("@CategorySub", td.CategoryDetail),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@Location", td.Location),
                new SqlParameter("@IsHot", td.IsHot)
                );
        }
        public bool updateStatus(ref string err, Services td)
        {
            return db.MyExecuteNonQuery("update Services set Status=@Status where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Status", td.Status)
                );
        }
        
        public bool delete(ref string err, string id)
        {
            return db.MyExecuteNonQuery("Delete from Services where ID=@id", CommandType.Text, ref err, new SqlParameter("@id", id));
        }
        public IList getList(string sql)
        {
            return db.getList(sql);
        }
    }
}
