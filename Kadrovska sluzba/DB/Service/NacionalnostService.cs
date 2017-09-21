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
    public class NacionalnostService
    {
        private IDbConnection _db = new SqlConnection(DbConnection.ConnectionString());

        public IEnumerable<Nacionalnost> GetAll()
        {
            return _db.GetAll<Nacionalnost>();
        }

        public Nacionalnost GetByID(int Id)
        {
            return _db.Get<Nacionalnost>(Id);
        }

        public void CreateOrUpdate(Nacionalnost nacionalnost)
        {
            if (GetByID(nacionalnost.ID) is null)
            {
                _db.Insert<Nacionalnost>(nacionalnost);
            }
            else
            {
                _db.Update<Nacionalnost>(nacionalnost);
            }
        }

        public void Create(Nacionalnost nacionalnost)
        {
            _db.Insert<Nacionalnost>(nacionalnost);
        }

        public void Update(Nacionalnost nacionalnost)
        {
            _db.Update<Nacionalnost>(nacionalnost);
        }

        public void Delete(Nacionalnost nacionalnost)
        {
            _db.Delete<Nacionalnost>(nacionalnost);
        }

        public void Delete(int id)
        {
            _db.Execute(@"DELETE FROM [Nacionalnost] WHERE ID = @ID", new { ID = id });
        }
    }
}
