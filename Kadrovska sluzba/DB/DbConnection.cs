using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Kadrovska_sluzba.DB
{
    public class DbConnection
    {

        //https://github.com/StackExchange/dapper-dot-net/blob/master/Readme.md

        //public static IDbConnection db;
        //public static string connStr;

        /// <summary>
        /// ConnectionString
        /// </summary>
        /// <returns>string</returns>
        public static string ConnectionString()
        {
            string cs = String.Format(
                    "data source={0};initial catalog={1};Trusted_Connection=false;User ID=sa; Password={2}; Connection Timeout = 0",
                    ConfigurationManager.AppSettings["ServerName"] , "Kadrovska", ConfigurationManager.AppSettings["DbPwd"]);
            //db = new SqlConnection(cs);
            return cs;
        }

        //public DbConnection()
        //{
        //    //connStr = cs;
        //    db = new SqlConnection(ConnectionString());
        //}
    }
}
