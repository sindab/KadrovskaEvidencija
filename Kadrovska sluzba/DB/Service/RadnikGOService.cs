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
    public class RadnikGOService
    {
        private IDbConnection _db = new SqlConnection(DbConnection.ConnectionString());

        public IEnumerable<RadnikGO> GetAll()
        {
            return _db.GetAll<RadnikGO>();
        }

        public RadnikGO GetByID(int Id)
        {
            return _db.Get<RadnikGO>(Id);
        }

        public IEnumerable<RadnikGO> GetByRadId(int radId)
        {
            return _db.Query<RadnikGO>("SELECT * FROM [RadnikGO] WHERE [RadID] = @RadId", new { RadId = radId });
        }

        public void CreateOrUpdate(RadnikGO radnikGO)
        {
            if (GetByID(radnikGO.ID) is null)
            {
                _db.Insert<RadnikGO>(radnikGO);
            }
            else
            {
                _db.Update<RadnikGO>(radnikGO);
            }
        }

        public void Create(RadnikGO radnikGO)
        {
            _db.Insert<RadnikGO>(radnikGO);
        }

        public void Update(RadnikGO radnikGO)
        {
            _db.Update<RadnikGO>(radnikGO);
        }

        public void Delete(RadnikGO radnikGO)
        {
            _db.Delete<RadnikGO>(radnikGO);
        }

        public void Delete(int id)
        {
            _db.Execute(@"DELETE FROM [RadnikGO] WHERE ID = @ID", new { ID = id });
        }
    }
}
