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
    public class NacinPrestankaROService
    {
        private IDbConnection _db = new SqlConnection(DbConnection.ConnectionString());

        public IEnumerable<NacinPrestankaRO> GetAll()
        {
            return _db.GetAll<NacinPrestankaRO>();
        }

        public NacinPrestankaRO GetByID(int Id)
        {
            return _db.Get<NacinPrestankaRO>(Id);
        }

        public void CreateOrUpdate(NacinPrestankaRO nacinPrestankaRO)
        {
            if (GetByID(nacinPrestankaRO.ID) is null)
            {
                _db.Insert<NacinPrestankaRO>(nacinPrestankaRO);
            }
            else
            {
                _db.Update<NacinPrestankaRO>(nacinPrestankaRO);
            }
        }

        public void Create(NacinPrestankaRO nacinPrestankaRO)
        {
            _db.Insert<NacinPrestankaRO>(nacinPrestankaRO);
        }

        public void Update(NacinPrestankaRO nacinPrestankaRO)
        {
            _db.Update<NacinPrestankaRO>(nacinPrestankaRO);
        }

        public void Delete(NacinPrestankaRO nacinPrestankaRO)
        {
            _db.Delete<NacinPrestankaRO>(nacinPrestankaRO);
        }

        public void Delete(int id)
        {
            _db.Execute(@"DELETE FROM [NacinPrestankaRO] WHERE ID = @ID", new { ID = id });
        }
    }
}
