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
    public class RadnikKursService
    {
        private IDbConnection _db = new SqlConnection(DbConnection.ConnectionString());

        public IEnumerable<RadnikKurs> GetAll()
        {
            return _db.GetAll<RadnikKurs>();
        }

        public RadnikKurs GetByID(int Id)
        {
            return _db.Get<RadnikKurs>(Id);
        }

        public IEnumerable<RadnikKurs> GetByRadId(int radId)
        {
            return _db.Query<RadnikKurs>("SELECT * FROM [RadnikKurs] WHERE [RadID] = @RadId", new { RadId = radId });
        }

        public void CreateOrUpdate(RadnikKurs radnikKurs)
        {
            if (GetByID(radnikKurs.ID) is null)
            {
                _db.Insert<RadnikKurs>(radnikKurs);
            }
            else
            {
                _db.Update<RadnikKurs>(radnikKurs);
            }
        }

        public void Create(RadnikKurs radnikKurs)
        {
            _db.Insert<RadnikKurs>(radnikKurs);
        }

        public void Update(RadnikKurs radnikKurs)
        {
            _db.Update<RadnikKurs>(radnikKurs);
        }

        public void Delete(RadnikKurs radnikKurs)
        {
            _db.Delete<RadnikKurs>(radnikKurs);
        }

        public void Delete(int id)
        {
            _db.Execute(@"DELETE FROM [RadnikKurs] WHERE ID = @ID", new { ID = id });
        }
    }
}
