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
    public class StrucnaSpremaService
    {
        private IDbConnection _db = new SqlConnection(DbConnection.ConnectionString());

        public IEnumerable<StrucnaSprema> GetAll()
        {
            return _db.GetAll<StrucnaSprema>();
        }

        public StrucnaSprema GetByID(int Id)
        {
            return _db.Get<StrucnaSprema>(Id);
        }

        public void CreateOrUpdate(StrucnaSprema strucnaSprema)
        {
            if (GetByID(strucnaSprema.ID) is null)
            {
                _db.Insert<StrucnaSprema>(strucnaSprema);
            }
            else
            {
                _db.Update<StrucnaSprema>(strucnaSprema);
            }
        }

        public void Create(StrucnaSprema strucnaSprema)
        {
            _db.Insert<StrucnaSprema>(strucnaSprema);
        }

        public void Update(StrucnaSprema strucnaSprema)
        {
            _db.Update<StrucnaSprema>(strucnaSprema);
        }

        public void Delete(StrucnaSprema strucnaSprema)
        {
            _db.Delete<StrucnaSprema>(strucnaSprema);
        }

        public void Delete(int id)
        {
            _db.Execute(@"DELETE FROM [StrucnaSprema] WHERE ID = @ID", new { ID = id });
        }
    }
}
