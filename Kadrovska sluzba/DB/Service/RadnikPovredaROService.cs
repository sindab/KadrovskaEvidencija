using Dapper;
using Dapper.Contrib.Extensions;
using Kadrovska_sluzba.DB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Kadrovska_sluzba.DB.Service
{
    public class RadnikPovredaROService
    {
        private IDbConnection _db = new SqlConnection(DbConnection.ConnectionString());

        public IEnumerable<RadnikPovredaRO> GetAll()
        {
            return _db.GetAll<RadnikPovredaRO>();
        }

        public RadnikPovredaRO GetByID(int Id)
        {
            return _db.Get<RadnikPovredaRO>(Id);
        }

        public IEnumerable<RadnikPovredaRO> GetByRadId(int radId)
        {
            return _db.Query<RadnikPovredaRO>("SELECT * FROM [RadnikPovredaRO] WHERE [RadID] = @RadId", new { RadId = radId });
        }

        public void CreateOrUpdate(RadnikPovredaRO radnikPovredaRO)
        {
            if (GetByID(radnikPovredaRO.ID) is null)
            {
                _db.Insert<RadnikPovredaRO>(radnikPovredaRO);
            }
            else
            {
                _db.Update<RadnikPovredaRO>(radnikPovredaRO);
            }
        }

        public void Create(RadnikPovredaRO radnikPovredaRO)
        {
            _db.Insert<RadnikPovredaRO>(radnikPovredaRO);
        }

        public void Update(RadnikPovredaRO radnikPovredaRO)
        {
            _db.Update<RadnikPovredaRO>(radnikPovredaRO);
        }

        public void Delete(RadnikPovredaRO radnikPovredaRO)
        {
            _db.Delete<RadnikPovredaRO>(radnikPovredaRO);
        }

        public void Delete(int id)
        {
            _db.Execute(@"DELETE FROM [RadnikPovredaRO] WHERE ID = @ID", new { ID = id });
        }
    }
}
