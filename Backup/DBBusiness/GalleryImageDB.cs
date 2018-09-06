using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;

namespace DBBusiness
{
    public class GalleryImageDB
    {
        DBLayer db;
        public GalleryImageDB()
        {
            db = new DBLayer();
        }
        public bool insert(ref string err, GalleryImage td)
        {
            return db.MyExecuteNonQuery("insert into GalleryImage (Photo) values(@Photo)", CommandType.Text, ref err,
                new SqlParameter("@Photo", td.Photo)
                );
        }
        public bool delete(ref string err, string Photo)
        {
            return db.MyExecuteNonQuery("Delete from GalleryImage where Photo=@Photo", CommandType.Text, ref err, new SqlParameter("@Photo", Photo));
        }
        public bool deleteAlbum(ref string err, string AlbumID)
        {
            return db.MyExecuteNonQuery("Delete from GalleryImage where AlbumID=@AlbumID", CommandType.Text, ref err, new SqlParameter("@AlbumID", AlbumID));
        }
        public IList getList(string sql)
        {
            return db.getList(sql);
        }
    }
}
