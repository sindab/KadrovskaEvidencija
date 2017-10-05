using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadrovska_sluzba.DB.Models
{
    /// <summary>
    /// A class which represents the Radnik table.
    /// </summary>
	[Dapper.Contrib.Extensions.Table("Radnik")]
    public partial class Radnik
    {
        [Key]
        public virtual int ID { get; set; }
        public virtual string JMBG { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string DjevPrezime { get; set; }
        public virtual string Ime { get; set; }
        public virtual string ImeOca { get; set; }
        public virtual int Bitovi { get; set; }
        public virtual string Titula { get; set; }
        public virtual string Funkcija { get; set; }
        public virtual int? MjestoRodjenja { get; set; }
        public virtual DateTime? DatumRodjenja { get; set; }
        public virtual int? DrzavljanstvoID { get; set; }
        public virtual int? NacionalnostID { get; set; }
        public virtual int? PorodicnoStanjeID { get; set; }
        public virtual int? MjestoStan { get; set; }
        public virtual string AdresaStan { get; set; }
        public virtual string TelefonStan { get; set; }
        public virtual string TelefonMob { get; set; }
        public virtual string TelefonPosao { get; set; }
        public virtual string Zanimanje { get; set; }
        public virtual int? StrucnaSpremaID { get; set; }
        public virtual string ZavrsenaSkola { get; set; }
        public virtual int? RadnoMjestoID { get; set; }
        public virtual string BrLK { get; set; }
        public virtual string BrRadneKnj { get; set; }
        public virtual int? OpstinaIzdavanjaRK { get; set; }
        public virtual string LicniBrOsiguranja { get; set; }
        public virtual DateTime? DatumPrvogZapos { get; set; }
        public virtual int? PrethodniStazMj { get; set; }
        public virtual int? PrethodniStazDan { get; set; }
        public virtual int? PrethodniStazUFirmiMj { get; set; }
        public virtual int? PrethodniStazUFirmiDan { get; set; }
        public virtual DateTime? DatumZapos { get; set; }
        public virtual int? TipRadnogOdnosaID { get; set; }
        public virtual int? NacinPrestankaRoID { get; set; }
        public virtual DateTime? DatumPrestankaRO { get; set; }
        public virtual string Napomena { get; set; }
        [Computed]
        public virtual string FindStr { get; set; }
        public virtual string Lozinka { get; set; }
        public virtual byte[] Slika { get; set; }
        [Computed]
        public virtual string Naziv { get; set; }
        public virtual string eMail { get; set; }
        public virtual int? PoslovnaJedinicaID { get; set; }
        public virtual string Pol { get; set; }
        
    }
}
