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
    public class OpstinaService
    {
        private IDbConnection _db = new SqlConnection(DbConnection.ConnectionString());

        public IEnumerable<Opstina> GetAll()
        {
            return _db.GetAll<Opstina>();
        }

        public Opstina GetByID(int Id)
        {
            return _db.Get<Opstina>(Id);
        }

        public void CreateOrUpdate(Opstina opstina)
        {
            if (GetByID(opstina.ID) is null)
            {
                _db.Insert<Opstina>(opstina);
            }
            else
            {
                _db.Update<Opstina>(opstina);
            }
        }

        public void Create(Opstina opstina)
        {
            _db.Insert<Opstina>(opstina);
        }

        public void Update(Opstina opstina)
        {
            _db.Update<Opstina>(opstina);
        }

        public void Delete(Opstina opstina)
        {
            _db.Delete<Opstina>(opstina);
        }

        public void Delete(int id)
        {
            _db.Execute(@"DELETE FROM [Opstina] WHERE ID = @ID", new { ID = id });
        }
    }
}
