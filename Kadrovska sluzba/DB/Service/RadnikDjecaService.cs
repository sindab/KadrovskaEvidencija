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
    public class RadnikDjecaService
    {
        private IDbConnection _db = new SqlConnection(DbConnection.ConnectionString());

        public IEnumerable<RadnikDjeca> GetAll()
        {
            return _db.GetAll<RadnikDjeca>();
        }

        public RadnikDjeca GetByID(int Id)
        {
            return _db.Get<RadnikDjeca>(Id);
        }

        public IEnumerable<RadnikDjeca> GetByRadId(int radId)
        {
            return _db.Query<RadnikDjeca>("SELECT * FROM [RadnikDjeca] WHERE [RadID] = @RadId", new { RadId = radId });
        }

        public void CreateOrUpdate(RadnikDjeca radnikDjeca)
        {
            if (GetByID(radnikDjeca.ID) is null)
            {
                _db.Insert<RadnikDjeca>(radnikDjeca);
            }
            else
            {
                _db.Update<RadnikDjeca>(radnikDjeca);
            }
        }

        public void Create(RadnikDjeca radnikDjeca)
        {
            _db.Insert<RadnikDjeca>(radnikDjeca);
        }

        public void Update(RadnikDjeca radnikDjeca)
        {
            _db.Update<RadnikDjeca>(radnikDjeca);
        }

        public void Delete(RadnikDjeca radnikDjeca)
        {
            _db.Delete<RadnikDjeca>(radnikDjeca);
        }

        public void Delete(int id)
        {
            _db.Execute(@"DELETE FROM [RadnikDjeca] WHERE ID = @ID", new { ID = id });
        }
    }
}
