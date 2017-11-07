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

        public IEnumerable<vRadnikGO> GetAllV()
        {
            return _db.GetAll<vRadnikGO>();
        }
        public IEnumerable<vRadnikGO> GetVByGodina(int godina)
        {
            return _db.Query<vRadnikGO>("SELECT * FROM [vRadnikGO] WHERE [Godina] = @godina", new { godina = godina });
        }

        public RadnikGO GetByID(int Id)
        {
            return _db.Get<RadnikGO>(Id);
        }

        public IEnumerable<RadnikGO> GetByRadId(int radId)
        {
            return _db.Query<RadnikGO>("SELECT * FROM [RadnikGO] WHERE [RadID] = @RadId", new { RadId = radId });
        }

        public int GetBrojNeiskoristenihDana(int radId = 0)
        {
            try
            {
                return (int)_db.ExecuteScalar("SELECT SUM(Zaduzio - Razduzio) FROM [RadnikGO] WHERE [RadID] = CASE @RadId WHEN 0 THEN RadID ELSE @RadId END", new { RadId = radId });
            }
            catch (Exception)
            {
                return 0;
            }
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

        public void PSGodisnjiOdmor(int dana, int zatvori)
        {
            var result = _db.Execute("DodajGodisnjiOdmor", new { dana, zatvori }, commandType: CommandType.StoredProcedure);
        }
    }
}
