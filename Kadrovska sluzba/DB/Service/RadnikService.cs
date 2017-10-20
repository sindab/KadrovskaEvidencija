using Dapper;
using Dapper.Contrib.Extensions;
using Kadrovska_sluzba.DB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Kadrovska_sluzba.DB.Service
{
    public class RadnikService
    {
        private IDbConnection _db = new SqlConnection(DbConnection.ConnectionString());

        public IEnumerable<Radnik> GetAll()
        {
            //try
            //{
            return _db.GetAll<Radnik>();
            //}
            //catch (Exception)
            //{
            //    List<Radnik> er = new List<Radnik>();
            //    er.Add(new Radnik { ID = 0 });
            //    return er;
            //}
            ////return _db.Query<Radnik>("SELECT [ID],[JMBG],[Prezime],[DjevPrezime],[Ime],[ImeOca],[Bitovi],[Titula],[Funkcija]," +
            ////    "[MjestoRodjenja],[OpstinaRodjenja],[DatumRodjenja],[Drzavljanstvo],[Nacionalnost],[PorodicnoStanje]," +
            ////    "[MjestoStan],[AdresaStan],[OpstinaStan],[TelefonStan],[TelefonMob],[TelefonPosao],[Zanimanje],[StrucnaSprema],[ZavrsenaSkola]," +
            ////    "[PoslovnaJedinica],[RadnoMjesto],[BrLK],[BrRadneKnj],[OpstinaIzdavanjaRK],[LicniBrOsiguranja],[NacinIsplate],[BrTekucegRn]," +
            ////    "[Banka],[DatumPrvogZapos],[PrethodniStazMj],[PrethodniStazDan],[PrethodniStazUFirmiMj],[PrethodniStazUFirmiDan],[DatumZapos]," +
            ////    "[TipRadnogOdnosa],[NacinPrestankaRO],[DatumPrestankaRO],[Napomena],[FindStr],[Lozinka],[Slika] FROM [dbo].[Radnik] ").ToList();
        }

        public IEnumerable<vRadnik> GetAllV()
        {
            return _db.GetAll<vRadnik>();
        }

        public List<Radnik> GetUsers()
        {
            return _db.Query<Radnik>("SELECT * FROM [dbo].[Radnik] WHERE ISNULL(Lozinka,'') <> '' ").ToList();
        }

        public Radnik GetByID(int Id)
        {
            try
            {
                return _db.Get<Radnik>(Id);

            }
            catch (Exception)
            {
                Radnik er = new Radnik() { ID = 0 };
                return er;
            }
            //return _db.Query<Radnik>("SELECT [ID],[JMBG],[Prezime],[DjevPrezime],[Ime],[ImeOca],Naziv,[Bitovi],[Titula],[Funkcija]," +
            //    "[MjestoRodjenja],[OpstinaRodjenja],[DatumRodjenja],[Drzavljanstvo],[Nacionalnost],[PorodicnoStanje]," +
            //    "[MjestoStan],[AdresaStan],[OpstinaStan],[TelefonStan],[TelefonMob],[TelefonPosao],[Zanimanje],[StrucnaSprema],[ZavrsenaSkola]," +
            //    "[PoslovnaJedinica],[RadnoMjesto],[BrLK],[BrRadneKnj],[OpstinaIzdavanjaRK],[LicniBrOsiguranja],[NacinIsplate],[BrTekucegRn]," +
            //    "[Banka],[DatumPrvogZapos],[PrethodniStazMj],[PrethodniStazDan],[PrethodniStazUFirmiMj],[PrethodniStazUFirmiDan],[DatumZapos]," +
            //    "[TipRadnogOdnosa],[NacinPrestankaRO],[DatumPrestankaRO],[Napomena],[FindStr],[Lozinka],[Slika],eMail FROM [dbo].[Radnik] WHERE ID = @ID", new { ID = Id }).SingleOrDefault();
        }

        public RadnikStaz GetStaz(int Id)
        {
            //return _db.Get<Radnik>(Id);
            return _db.Query<RadnikStaz>("SELECT * FROM [dbo].[RadnikStaz] WHERE RadID = @ID", new { ID = Id }).SingleOrDefault();
        }

        ////public vPar GetByWhere(string where)
        ////{
        ////    try
        ////    {
        ////        return _db.QuerySingle<vPar>(string.Format("SELECT ParID, AutoID, Naziv, Adresa, PostBr, Grad, Drzava, DomaciStrani, Komercijalist, JIB, PIB, ecBit, " +
        ////            "Dobavljac, Kupac, Domaci, Strani, IsKomercijalist, IsProizvodac, IsDiler, IsVIP, IsPravno, IsNeaktivan, IsPDV, Valuta, Find, " +
        ////            "Telefon, Fax, Maticni, KontaktOsoba, RabatGrupa, Rabat, Mobilni, Ziro, Mail, Web, KnjSifra, Parent, GrupaID, Opis, Kredit, Sjediste, " +
        ////            "Kvadratura, MjeriloBR, MZ FROM vPar {0}", where));
        ////    }
        ////    catch (Exception)
        ////    {
        ////        return _db.QuerySingle<vPar>("SELECT ParID, AutoID, Naziv, Adresa, PostBr, Grad, Drzava, DomaciStrani, Komercijalist, JIB, PIB, ecBit, " +
        ////                        "Dobavljac, Kupac, Domaci, Strani, IsKomercijalist, IsProizvodac, IsDiler, IsVIP, IsPravno, IsNeaktivan, IsPDV, Valuta, Find, " +
        ////                        "Telefon, Fax, Maticni, KontaktOsoba, RabatGrupa, Rabat, Mobilni, Ziro, Mail, Web, KnjSifra, Parent, GrupaID, Opis, Kredit, Sjediste, " +
        ////                        "Kvadratura, MjeriloBR, MZ FROM vPar Where ParID = 0");
        ////    }
        ////}

        //public string GetNazivByParID(int parId)
        //{
        //    Par p = GetByID(parId);
        //    return p.Naziv;
        //}

        public int Create(Radnik radnik)
        {
            return (int)_db.Insert<Radnik>(radnik);
            //int rowsAffected = _db.Execute(@"INSERT INTO [dbo].[Radnik]([JMBG],[Prezime],[DjevPrezime],[Ime],[ImeOca],[Bitovi],[Titula],[Funkcija],[MjestoRodjenja],[OpstinaRodjenja],[DatumRodjenja],[Drzavljanstvo],[Nacionalnost],[PorodicnoStanje],[MjestoStan],[AdresaStan],[OpstinaStan],[TelefonStan],[TelefonMob],[TelefonPosao],[Zanimanje],[StrucnaSprema],[ZavrsenaSkola],[PoslovnaJedinica],[RadnoMjesto],[BrLK],[BrRadneKnj],[OpstinaIzdavanjaRK],[LicniBrOsiguranja],[NacinIsplate],[BrTekucegRn],[Banka],[DatumPrvogZapos],[PrethodniStazMj],[PrethodniStazDan],[PrethodniStazUFirmiMj],[PrethodniStazUFirmiDan],[DatumZapos],[TipRadnogOdnosa],[NacinPrestankaRO],[DatumPrestankaRO],[Napomena],[Lozinka],[Slika]) " +
            //    "VALUES(@JMBG,@Prezime,@DjevPrezime,@Ime,@ImeOca,@Bitovi,@Titula,@Funkcija,@MjestoRodjenja,@OpstinaRodjenja,@DatumRodjenja,@Drzavljanstvo,@Nacionalnost,@PorodicnoStanje,@MjestoStan,@AdresaStan,@OpstinaStan,@TelefonStan,@TelefonMob,@TelefonPosao,@Zanimanje,@StrucnaSprema,@ZavrsenaSkola,@PoslovnaJedinica,@RadnoMjesto,@BrLK,@BrRadneKnj,@OpstinaIzdavanjaRK,@LicniBrOsiguranja,@NacinIsplate,@BrTekucegRn,@Banka,@DatumPrvogZapos,@PrethodniStazMj,@PrethodniStazDan,@PrethodniStazUFirmiMj,@PrethodniStazUFirmiDan,@DatumZapos,@TipRadnogOdnosa,@NacinPrestankaRO,@DatumPrestankaRO,@Napomena,@Lozinka,@Slika)", 
            //    new
            //    {
            //        JMBG = radnik.JMBG,
            //        Prezime = radnik.Prezime,
            //        DjevPrezime = radnik.DjevPrezime,
            //        Ime = radnik.Ime,
            //        ImeOca = radnik.ImeOca,
            //        Bitovi = radnik.Bitovi,
            //        Titula = radnik.Titula,
            //        Funkcija = radnik.Funkcija, ...
            //    });
            //if (rowsAffected > 0)
            //{
            //    return true;
            //}
            //return false;
        }

        public void Update(Radnik radnik)
        {
            //radnik.FindStr
            //radnik.Naziv
            _db.Update<Radnik>(radnik);
            //int rowsAffected = _db.Execute("UPDATE [Par] SET [Naziv] = @Naziv ,[Adresa] = @Adresa, [PostBr] = @PostBr " +
            //    "WHERE ParID = " + par.ParID, par);
            //if (rowsAffected > 0)
            //{
            //    return true;
            //}
            //return false;
        }

        public int CreateOrUpdate(Radnik radnik)
        {
            int result = radnik.ID;
            if (!(string.IsNullOrEmpty(radnik.Prezime)) && !(string.IsNullOrEmpty(radnik.Ime)))
            {
                if (radnik.ID == 0 || GetByID(radnik.ID) is null)
                {
                    result = Create(radnik);
                }
                else
                {
                    Update(radnik);
                }
            }
            return result;
        }

        public void Delete(int radID)
        {
            //_db.Delete<Radnik>(radnik);
            _db.Execute(@"DELETE FROM [Radnik] WHERE ID = @RadID", new { RadID = radID });
            //int rowsAffected = _db.Execute(@"DELETE FROM [Radnik] WHERE RadID = @RadID", new { ParID = Id });
            //if (rowsAffected > 0)
            //{
            //    return true;
            //}
            //return false;
        }
    }
}
