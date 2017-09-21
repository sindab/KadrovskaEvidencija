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
    public class TipRadnogOdnosaService
    {
        private IDbConnection _db = new SqlConnection(DbConnection.ConnectionString());

        public IEnumerable<TipRadnogOdnosa> GetAll()
        {
            return _db.GetAll<TipRadnogOdnosa>();
        }

        public TipRadnogOdnosa GetByID(int Id)
        {
            return _db.Get<TipRadnogOdnosa>(Id);
        }

        public void CreateOrUpdate(TipRadnogOdnosa tipRadnogOdnosa)
        {
            if (GetByID(tipRadnogOdnosa.ID) is null)
            {
                _db.Insert<TipRadnogOdnosa>(tipRadnogOdnosa);
            }
            else
            {
                _db.Update<TipRadnogOdnosa>(tipRadnogOdnosa);
            }
        }

        public void Create(TipRadnogOdnosa tipRadnogOdnosa)
        {
            _db.Insert<TipRadnogOdnosa>(tipRadnogOdnosa);
        }

        public void Update(TipRadnogOdnosa tipRadnogOdnosa)
        {
            _db.Update<TipRadnogOdnosa>(tipRadnogOdnosa);
        }

        public void Delete(TipRadnogOdnosa tipRadnogOdnosa)
        {
            _db.Delete<TipRadnogOdnosa>(tipRadnogOdnosa);
        }

        public void Delete(int id)
        {
            _db.Execute(@"DELETE FROM [TipRadnogOdnosa] WHERE ID = @ID", new { ID = id });
        }
    }
}
