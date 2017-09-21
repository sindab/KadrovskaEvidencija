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
    public class MjestoService
    {
        private IDbConnection _db = new SqlConnection(DbConnection.ConnectionString());

        public IEnumerable<Mjesto> GetAll()
        {
            return _db.GetAll<Mjesto>();
        }

        public Mjesto GetByID(int Id)
        {
            return _db.Get<Mjesto>(Id);
        }

        public Mjesto GetByPostBr(string postBr)
        {
            return _db.Query<Mjesto>("SELECT [ID],[OpstinaID],[PostBr],[Naziv] FROM [Mjesto] WHERE [PostBr] = @PB", new { PB = postBr }).SingleOrDefault();
        }

        public void CreateOrUpdate(Mjesto mjesto)
        {
            if (GetByID(mjesto.ID) is null)
            {
                _db.Insert<Mjesto>(mjesto);
            }
            else
            {
                _db.Update<Mjesto>(mjesto);
            }
        }

        public void Create(Mjesto mjesto)
        {
            _db.Insert<Mjesto>(mjesto);
        }

        public void Update(Mjesto mjesto)
        {
            _db.Update<Mjesto>(mjesto);
        }

        public void Delete(Mjesto mjesto)
        {
            _db.Delete<Mjesto>(mjesto);
        }

        public void Delete(int id)
        {
            _db.Execute(@"DELETE FROM [Mjesto] WHERE ID = @ID", new { ID = id });
        }
    }
}
