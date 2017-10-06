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
    public class RadnikBolovanjeService
    {
        private IDbConnection _db = new SqlConnection(DbConnection.ConnectionString());

        public IEnumerable<RadnikBolovanje> GetAll()
        {
            return _db.GetAll<RadnikBolovanje>();
        }

        public RadnikBolovanje GetByID(int Id)
        {
            return _db.Get<RadnikBolovanje>(Id);
        }

        public IEnumerable<RadnikBolovanje> GetByRadId(int radId)
        {
            return _db.Query<RadnikBolovanje>("SELECT * FROM [RadnikBolovanje] WHERE [RadID] = @RadId", new { RadId = radId });
        }

        public void CreateOrUpdate(RadnikBolovanje radnikBolovanje)
        {
            if (GetByID(radnikBolovanje.ID) is null)
            {
                _db.Insert<RadnikBolovanje>(radnikBolovanje);
            }
            else
            {
                _db.Update<RadnikBolovanje>(radnikBolovanje);
            }
        }

        public void Create(RadnikBolovanje radnikBolovanje)
        {
            _db.Insert<RadnikBolovanje>(radnikBolovanje);
        }

        public void Update(RadnikBolovanje radnikBolovanje)
        {
            _db.Update<RadnikBolovanje>(radnikBolovanje);
        }

        public void Delete(RadnikBolovanje radnikBolovanje)
        {
            _db.Delete<RadnikBolovanje>(radnikBolovanje);
        }

        public void Delete(int id)
        {
            _db.Execute(@"DELETE FROM [RadnikBolovanje] WHERE ID = @ID", new { ID = id });
        }
    }
}
