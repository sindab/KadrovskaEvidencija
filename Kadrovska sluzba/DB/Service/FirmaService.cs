using Dapper.Contrib.Extensions;
using Kadrovska_sluzba.DB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadrovska_sluzba.DB.Service
{
    public class FirmaService
    {
        private IDbConnection _db = new SqlConnection(DbConnection.ConnectionString());
        public Firma GetData()
        {
            return _db.GetAll<Firma>().FirstOrDefault();
        }

        public void CreateOrUpdate(Firma firma)
        {
            if (GetData() is null)
            {
                _db.Insert<Firma>(firma);
            }
            else
            {
                _db.Update<Firma>(firma);
            }
        }
        
    }
}
