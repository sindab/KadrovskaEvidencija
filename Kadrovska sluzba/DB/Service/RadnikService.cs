﻿using Dapper;
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
            return _db.GetAll<Radnik>();
            //return _db.Query<Radnik>("SELECT [ID],[JMBG],[Prezime],[DjevPrezime],[Ime],[ImeOca],[Bitovi],[Titula],[Funkcija]," +
            //    "[MjestoRodjenja],[OpstinaRodjenja],[DatumRodjenja],[Drzavljanstvo],[Nacionalnost],[PorodicnoStanje]," +
            //    "[MjestoStan],[AdresaStan],[OpstinaStan],[TelefonStan],[TelefonMob],[TelefonPosao],[Zanimanje],[StrucnaSprema],[ZavrsenaSkola]," +
            //    "[PoslovnaJedinica],[RadnoMjesto],[BrLK],[BrRadneKnj],[OpstinaIzdavanjaRK],[LicniBrOsiguranja],[NacinIsplate],[BrTekucegRn]," +
            //    "[Banka],[DatumPrvogZapos],[PrethodniStazMj],[PrethodniStazDan],[PrethodniStazUFirmiMj],[PrethodniStazUFirmiDan],[DatumZapos]," +
            //    "[TipRadnogOdnosa],[NacinPrestankaRO],[DatumPrestankaRO],[Napomena],[FindStr],[Lozinka],[Slika] FROM [dbo].[Radnik] ").ToList();
        }

        public List<Radnik> GetUsers()
        {
            return _db.Query<Radnik>("SELECT * FROM [dbo].[Radnik] WHERE ISNULL(Lozinka,'') <> '' ").ToList();
        }

        public Radnik GetByID(int Id)
        {
            return _db.Get<Radnik>(Id);
            //return _db.Query<Radnik>("SELECT [ID],[JMBG],[Prezime],[DjevPrezime],[Ime],[ImeOca],Naziv,[Bitovi],[Titula],[Funkcija]," +
            //    "[MjestoRodjenja],[OpstinaRodjenja],[DatumRodjenja],[Drzavljanstvo],[Nacionalnost],[PorodicnoStanje]," +
            //    "[MjestoStan],[AdresaStan],[OpstinaStan],[TelefonStan],[TelefonMob],[TelefonPosao],[Zanimanje],[StrucnaSprema],[ZavrsenaSkola]," +
            //    "[PoslovnaJedinica],[RadnoMjesto],[BrLK],[BrRadneKnj],[OpstinaIzdavanjaRK],[LicniBrOsiguranja],[NacinIsplate],[BrTekucegRn]," +
            //    "[Banka],[DatumPrvogZapos],[PrethodniStazMj],[PrethodniStazDan],[PrethodniStazUFirmiMj],[PrethodniStazUFirmiDan],[DatumZapos]," +
            //    "[TipRadnogOdnosa],[NacinPrestankaRO],[DatumPrestankaRO],[Napomena],[FindStr],[Lozinka],[Slika],eMail FROM [dbo].[Radnik] WHERE ID = @ID", new { ID = Id }).SingleOrDefault();
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

        public void Create(Radnik radnik)
        {
            _db.Insert<Radnik>(radnik);
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
            _db.Update<Radnik>(radnik);
            //int rowsAffected = _db.Execute("UPDATE [Par] SET [Naziv] = @Naziv ,[Adresa] = @Adresa, [PostBr] = @PostBr " +
            //    "WHERE ParID = " + par.ParID, par);
            //if (rowsAffected > 0)
            //{
            //    return true;
            //}
            //return false;
        }

        public void Delete(Radnik radnik)
        {
            _db.Delete<Radnik>(radnik);
            //int rowsAffected = _db.Execute(@"DELETE FROM [Radnik] WHERE RadID = @RadID", new { ParID = Id });
            //if (rowsAffected > 0)
            //{
            //    return true;
            //}
            //return false;
        }
    }
}
