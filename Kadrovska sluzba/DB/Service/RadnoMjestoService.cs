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
    public class RadnoMjestoService
    {
        private IDbConnection _db = new SqlConnection(DbConnection.ConnectionString());

        public IEnumerable<RadnoMjesto> GetAll()
        {
            return _db.GetAll<RadnoMjesto>();
        }

        public RadnoMjesto GetByID(int Id)
        {
            return _db.Get<RadnoMjesto>(Id);
        }

        public void CreateOrUpdate(RadnoMjesto radnoMjesto)
        {
            if (GetByID(radnoMjesto.ID) is null)
            {
                _db.Insert<RadnoMjesto>(radnoMjesto);
            }
            else
            {
                _db.Update<RadnoMjesto>(radnoMjesto);
            }
        }

        public void Create(RadnoMjesto radnoMjesto)
        {
            _db.Insert<RadnoMjesto>(radnoMjesto);
        }

        public void Update(RadnoMjesto radnoMjesto)
        {
            _db.Update<RadnoMjesto>(radnoMjesto);
        }

        public void Delete(RadnoMjesto radnoMjesto)
        {
            _db.Delete<RadnoMjesto>(radnoMjesto);
        }

        public void Delete(int id)
        {
            _db.Execute(@"DELETE FROM [RadnoMjesto] WHERE ID = @ID", new { ID = id });
        }
    }
}
