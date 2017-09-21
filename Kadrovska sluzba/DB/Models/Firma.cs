using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadrovska_sluzba.DB.Models
{
    [Table("Firma")]
    public class Firma
    {
        [Dapper.Contrib.Extensions.Key, Display(AutoGenerateField = false)]
        public virtual int ID { get; set; }
        [Display(Name = "Naziv", GroupName = "<Main>", Order = 1)]
        public virtual string Naziv { get; set; }
        [Display(Name = "Puni naziv", GroupName = "<Main>", Order = 2)]
        public virtual string PuniNaziv { get; set; }
        [Display(Name = "Poštanski broj", GroupName = "<Main>")]
        public virtual string PostBroj { get; set; }
        [Display(Name = "Adresa", GroupName = "<Main>")]
        public virtual string Adresa { get; set; }
        [Display(Name = "Telefon", GroupName = "<Main>")]
        public virtual string Telefon { get; set; }
        [Display(Name = "Fax", GroupName = "<Main>")]
        public virtual string Fax { get; set; }
        [Display(Name = "Mobilni", GroupName = "<Main>")]
        public virtual string Mobilni { get; set; }
        [Display(Name = "Matični broj", GroupName = "<Main>")]
        public virtual string Maticni { get; set; }
        [Display(Name = "PIB", GroupName = "<Main>")]
        public virtual string PIB { get; set; }
        [Display(Name = "JIB", GroupName = "<Main>")]
        public virtual string JIB { get; set; }
        [Display(Name = "Žiro račun", GroupName = "<Main>")]
        public virtual string Ziro { get; set; }
        [Display(Name = "Web", GroupName = "<Main>")]
        public virtual string Web { get; set; }
        [Display(Name = "E-Mail", GroupName = "<Main>")]
        public virtual string Mail { get; set; }
        //public virtual Mjesto Mjesto { get; set; }
    }
}
