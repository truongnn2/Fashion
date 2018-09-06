using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;
namespace DBBusiness
{
    public class getList
    {
        DBLayer db;
        public getList()
        {
            db = new DBLayer();
        }
        public IList getlist(string sql)
        {
            return db.getList(sql);
        }
    }
}
