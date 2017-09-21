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
    public class PorodicnoStanjeService
    {
        private IDbConnection _db = new SqlConnection(DbConnection.ConnectionString());

        public IEnumerable<PorodicnoStanje> GetAll()
        {
            return _db.GetAll<PorodicnoStanje>();
        }

        public PorodicnoStanje GetByID(int Id)
        {
            return _db.Get<PorodicnoStanje>(Id);
        }

        public void CreateOrUpdate(PorodicnoStanje porodicnoStanje)
        {
            if (GetByID(porodicnoStanje.ID) is null)
            {
                _db.Insert<PorodicnoStanje>(porodicnoStanje);
            }
            else
            {
                _db.Update<PorodicnoStanje>(porodicnoStanje);
            }
        }

        public void Create(PorodicnoStanje porodicnoStanje)
        {
            _db.Insert<PorodicnoStanje>(porodicnoStanje);
        }

        public void Update(PorodicnoStanje porodicnoStanje)
        {
            _db.Update<PorodicnoStanje>(porodicnoStanje);
        }

        public void Delete(PorodicnoStanje porodicnoStanje)
        {
            _db.Delete<PorodicnoStanje>(porodicnoStanje);
        }

        public void Delete(int id)
        {
            _db.Execute(@"DELETE FROM [PorodicnoStanje] WHERE ID = @ID", new { ID = id });
        }
    }
}