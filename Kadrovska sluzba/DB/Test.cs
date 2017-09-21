using Dapper;
using Kadrovska_sluzba.DB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ecDBLib.DbDapper
{
    public class Test
    {
        private IDbConnection _db = new SqlConnection(DbConnection.connStr);

        public Test()
        {
            //String query = "select * from Par";
            ////object p = (List<Entities.Par>)ecConnection.db.Query<Entities.Par>(query);
            //object p = DbConnection.db.Query<Entities.Par>(query);

            ////using (var sqlConnection =
            ////    new SqlConnection(ecDBLib.DbDapper.DbConnection.connStr))
            ////{
            ////    sqlConnection.Open();

            ////    IEnumerable products =
            ////        sqlConnection.Query("select * from Par");

            ////    foreach (Entities.Par product in products)
            ////    {
            ////        ObjectDumper.Write(product);
            ////    }

            ////    sqlConnection.Close();
            ////}
        }

        //public List<Entities.Par> ReadAll()
        //{
        //    using (IDbConnection db = new SqlConnection(DbConnection.connStr))
        //    {
        //        return db.Query<Entities.Par>
        //            ("Select * From Par").ToList();
        //    }
        //}

        //public Entities.Par Find(int parId)
        //{
        //    using (IDbConnection db = new SqlConnection(DbConnection.connStr))
        //    {
        //        return db.Query<Entities.Par>("Select * From Par WHERE ParID = @parId", new { parId }).SingleOrDefault();
        //    }
        //}

        public List<Par> GetAll()
        {
            return _db.Query<Par>("SELECT [ParID],[Naziv],[Adresa],[PostBr],[JIB],[ecBit],[Valuta],[Komercijalist],[Telefon],[Mobilni],[Fax],[Maticni],[KontaktOsoba],[RabatGrupa],[Ziro],[Mail],[Web],[Polje1],[Opis],[KnjSifra],[OLDSifra],[Parent],[GrupaID],[PIB],[Kredit],[Sjediste],[Kvadratura],[MjeriloBr],[LastEditDate],[CreationDate],[AutoID],[Obezbedjenje],[KontoKupca],[MaxValuta],[KontoTroska],[MinIznos],[KategorijaID] FROM [Par] ").ToList();
        }

        public List<Par> GetAll(int amount, string sort)
        {
            return _db.Query<Par>(string.Format("SELECT TOP {0} [ParID],[Naziv],[Adresa],[PostBr],[JIB],[ecBit],[Valuta],[Komercijalist],[Telefon],[Mobilni],[Fax],[Maticni],[KontaktOsoba],[RabatGrupa],[Ziro],[Mail],[Web],[Polje1],[Opis],[KnjSifra],[OLDSifra],[Parent],[GrupaID],[PIB],[Kredit],[Sjediste],[Kvadratura],[MjeriloBr],[LastEditDate],[CreationDate],[AutoID],[Obezbedjenje],[KontoKupca],[MaxValuta],[KontoTroska],[MinIznos],[KategorijaID] FROM [Par] ORDER BY {1}", amount, sort)).ToList();
        }

        public Par GetByID(int parId)
        {
            return _db.Query<Par>("SELECT [ParID],[Naziv],[Adresa],[PostBr],[JIB],[ecBit],[Valuta],[Komercijalist],[Telefon],[Mobilni],[Fax],[Maticni],[KontaktOsoba],[RabatGrupa],[Ziro],[Mail],[Web],[Polje1],[Opis],[KnjSifra],[OLDSifra],[Parent],[GrupaID],[PIB],[Kredit],[Sjediste],[Kvadratura],[MjeriloBr],[LastEditDate],[CreationDate],[AutoID],[Obezbedjenje],[KontoKupca],[MaxValuta],[KontoTroska],[MinIznos],[KategorijaID] FROM [Par] WHERE ParID = @ParID", new { ParID = parId }).SingleOrDefault();
        }

        public bool Insert(Par par)
        {
            int rowsAffected = _db.Execute(@"INSERT Par([Naziv],[Adresa],[PostBr]) values (@Naziv, @Adresa, @PostBr)", new { Naziv = par.Naziv, Adresa = par.Adresa, PostBr = "78000" });
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool Update(Par par)
        {
            int rowsAffected = _db.Execute("UPDATE [Par] SET [Naziv] = @Naziv ,[Adresa] = @Adresa, [PostBr] = @PostBr WHERE ParID = " + par.ParID, par);
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int parId)
        {
            int rowsAffected = _db.Execute(@"DELETE FROM [Par] WHERE ParID = @ParID", new { ParID = parId });
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }


        //public IEnumerable<Pro> SelectProWithReg(string proId)
        //{
        //        string query = "SELECT p.ProID, p.mID, p.Cena, " +
        //              "s.ProId AS Id, s.JM, s.[Naziv] " +
        //              "FROM Pro p " +
        //              "LEFT OUTER JOIN Reg s ON s.ProId = p.ProID " +
        //              "WHERE p.ProID = '" + proId + "'";
        //        return _db.Query<Pro, Reg, Pro>(query,
        //          (pro, reg) => { pro.Reg = reg; return pro; });
        //}

        //public IEnumerable<UlazIzlazDetalj> SelectUlazIzlazDetaljWithUlazIzlaz(int vId)
        //{
        //    string query = "SELECT d.ProID, d.Cena, d.CSaPor, " +
        //          "g.vID AS Id, g.Datum, g.[Broj] " +
        //          "FROM UlazIzlazDetalj d " +
        //          "LEFT OUTER JOIN UlazIzlaz g ON g.vId = d.vID " +
        //          "WHERE d.vID = '" + vId + "'";
        //    return _db.Query<UlazIzlazDetalj, UlazIzlaz, UlazIzlazDetalj>(query,
        //      (ulazIzlazDetalj, ulazIzlaz) => { ulazIzlazDetalj.UlazIzlaz = ulazIzlaz; return ulazIzlazDetalj; });
        //}

        //public IEnumerable<Product> SelectProductsWithSubCategories()
        //{
        //    using (IDbConnection connection = OpenConnection())
        //    {
        //        const string query = "SELECT p.ProductID, p.Name, p.ProductNumber, " +
        //              "p.MakeFlag, p.FinishedGoodsFlag, p.Color, p.SafetyStockLevel, " +
        //              "p.ReorderPoint, p.StandardCost, p.ListPrice, p.Size, p.SizeUnitMeasureCode, " +
        //              "p.WeightUnitMeasureCode, p.Weight, p.DaysToManufacture, p.ProductLine, " +
        //              "p.Class, p.Style, p.ProductSubcategoryID, p.ProductModelID, " +
        //              "p.SellStartDate, p.SellEndDate, p.DiscontinuedDate,  p.ModifiedDate, " +
        //              "s.ProductSubcategoryId AS Id, s.ProductCategoryID AS CategoryId, " +
        //              "s.[Name], s.ModifiedDate AS ModifiedOn " +
        //              "FROM Production.Product p " +
        //              "LEFT OUTER JOIN Production.ProductSubcategory " +
        //              "s ON s.ProductSubcategoryId = p.ProductSubcategoryID";
        //        return connection.Query<Product, SubCategory, Product>(query,
        //          (product, subCategory) => { product.SubCategory = subCategory; return product; });
        //    }
        //}
        //public int DeleteProduct(Product product)
        //{
        //    using (IDbConnection connection = OpenConnection())
        //    {
        //        const string deleteImageQuery = "DELETE FROM Production.ProductProductPhoto " +
        //                                        "WHERE ProductID = @ProductID";
        //        const string deleteProductQuery = "DELETE FROM Production.Product " +
        //                                          "WHERE ProductID = @ProductID";
        //        IDbTransaction transaction = connection.BeginTransaction();
        //        int rowsAffected = connection.Execute(deleteImageQuery,
        //            new { ProductID = product.ProductID }, transaction);
        //        rowsAffected += connection.Execute(deleteProductQuery,
        //            new { ProductID = product.ProductID }, transaction);
        //        transaction.Commit();
        //        return rowsAffected;
        //    }
        //}
        //public IEnumerable<Manager> SelectManagers(int employeeId)
        //{
        //    using (IDbConnection connection = OpenConnection())
        //    {
        //        const string storedProcedure = "dbo.uspGetEmployeeManagers";
        //        return connection.Query<Manager>(storedProcedure,
        //           new { EmployeeID = employeeId }, commandType: CommandType.StoredProcedure);
        //    }
        //}

        //public int InsertSubCategory(SubCategory subCategory)
        //{
        //    using (IDbConnection connection = OpenConnection())
        //    {
        //        const string query =
        //          "INSERT INTO Production.ProductSubcategory(ProductCategoryID, [Name]) " +
        //          "VALUES (@CategoryId, @Name)";
        //        int rowsAffectd = connection.Execute(query, subCategory);
        //        SetIdentity<int>(connection, id => subCategory.Id = id);
        //        return rowsAffectd;
        //    }
        //}
        //protected static void SetIdentity<T>(IDbConnection connection, Action<T> setId)
        //{
        //    dynamic identity = connection.Query("SELECT @@IDENTITY AS Id").Single();
        //    T newId = (T)identity.Id;
        //    setId(newId);
        //}
        //public int Update(Entities.Par par)
        //{
        //    using (IDbConnection db = new SqlConnection(DbConnection.connStr))
        //    {
        //        string sqlQuery = " UPDATE Par SET Naziv = @Naziv, " +
        //             " Adresa = @Adresa " + 
        //             " WHERE ParID = @ParID ";
        //        int rowsAffected = db.Execute(sqlQuery, par);
        //        return rowsAffected;
        //    }
        //}

        //public int Delete(int parId)
        //{
        //    using (IDbConnection db = new SqlConnection(DbConnection.connStr))
        //    {
        //        string sqlQuery = "DELETE FROM Par WHERE ParID = @parId";
        //        int rowsAffected = db.Execute(sqlQuery, parId);
        //        return rowsAffected;
        //    }
        //}

        //public List<Entities.Par> ExecSProc(string sproc)
        //{
        //    using (IDbConnection db = new SqlConnection(DbConnection.connStr))
        //    {
        //        return db.Query<Entities.Par>(sproc, commandType: CommandType.StoredProcedure).ToList();
        //    }
        //}

    }
}
