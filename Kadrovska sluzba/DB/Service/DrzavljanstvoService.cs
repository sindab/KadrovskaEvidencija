using Dapper;
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
    public class DrzavljanstvoService
    {
        private IDbConnection _db = new SqlConnection(DbConnection.ConnectionString());

        public IEnumerable<Drzavljanstvo> GetAll()
        {
            return _db.GetAll<Drzavljanstvo>();
        }

        public Drzavljanstvo GetByID(int Id)
        {
            return _db.Get<Drzavljanstvo>(Id);
        }

        public void CreateOrUpdate(Drzavljanstvo drzavljanstvo)
        {
            if (GetByID(drzavljanstvo.ID) is null)
            {
                _db.Insert<Drzavljanstvo>(drzavljanstvo);
            }
            else
            {
                _db.Update<Drzavljanstvo>(drzavljanstvo);
            }
        }

        public void Create(Drzavljanstvo drzavljanstvo)
        {
            _db.Insert<Drzavljanstvo>(drzavljanstvo);
        }

        public void Update(Drzavljanstvo drzavljanstvo)
        {
            _db.Update<Drzavljanstvo>(drzavljanstvo);
        }

        public void Delete(Drzavljanstvo drzavljanstvo)
        {
            _db.Delete<Drzavljanstvo>(drzavljanstvo);
        }

        public void Delete(int id)
        {
            _db.Execute(@"DELETE FROM [Drzavljanstvo] WHERE ID = @ID", new { ID = id });
        }
    }
}
