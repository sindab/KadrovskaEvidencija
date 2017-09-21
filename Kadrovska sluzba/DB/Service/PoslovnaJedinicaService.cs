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
    public class PoslovnaJedinicaService
    {
        private IDbConnection _db = new SqlConnection(DbConnection.ConnectionString());

        public IEnumerable<PoslovnaJedinica> GetAll()
        {
            return _db.GetAll<PoslovnaJedinica>();
        }

        public PoslovnaJedinica GetByID(int Id)
        {
            return _db.Get<PoslovnaJedinica>(Id);
        }

        public void CreateOrUpdate(PoslovnaJedinica poslovnaJedinica)
        {
            if (GetByID(poslovnaJedinica.ID) is null)
            {
                _db.Insert<PoslovnaJedinica>(poslovnaJedinica);
            }
            else
            {
                _db.Update<PoslovnaJedinica>(poslovnaJedinica);
            }
        }

        public void Create(PoslovnaJedinica poslovnaJedinica)
        {
            _db.Insert<PoslovnaJedinica>(poslovnaJedinica);
        }

        public void Update(PoslovnaJedinica poslovnaJedinica)
        {
            _db.Update<PoslovnaJedinica>(poslovnaJedinica);
        }

        public void Delete(PoslovnaJedinica poslovnaJedinica)
        {
            _db.Delete<PoslovnaJedinica>(poslovnaJedinica);
        }

        public void Delete(int id)
        {
            _db.Execute(@"DELETE FROM [PoslovnaJedinica] WHERE ID = @ID", new { ID = id });
        }
    }
}
