using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Kadrovska_sluzba.DB.Service;
using Kadrovska_sluzba.DB.Models;

namespace Kadrovska_sluzba.Settings
{
    public partial class ucKalendarUpis : DevExpress.XtraEditors.XtraUserControl
    {
        RadnikService rs;
        AppointmentsService aS;
        IEnumerable<vRadnik> radnici;
        public ucKalendarUpis()
        {
            InitializeComponent();
            aS = new AppointmentsService();
            rs = new RadnikService();
            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                radnici = rs.GetAllV();
            }
        }

        private void btnUpisiRodj_Click(object sender, EventArgs e)
        {
            aS.DeleteAll(KalendarLabele.Rodjendan);
            foreach (vRadnik radnik in radnici)
            {
                aS.DodajRodjendan(radnik);
            }
        }

        private void btnUpisiIstekUg_Click(object sender, EventArgs e)
        {
            aS.DeleteAll(KalendarLabele.IstekUgovora);
            foreach (vRadnik radnik in radnici)
            {
                aS.DodajIstekUgovora(radnik);
            }
        }

        private void btnUpisiJubilej1_Click(object sender, EventArgs e)
        {
            aS.DeleteAll(KalendarLabele.Godisnjica10);
            foreach (vRadnik radnik in radnici)
            {
                aS.DodajGodisnjicu10(radnik);
            }
        }

        private void btnUpisiJubilej2_Click(object sender, EventArgs e)
        {
            aS.DeleteAll(KalendarLabele.Godisnjica20);
            foreach (vRadnik radnik in radnici)
            {
                aS.DodajGodisnjicu20(radnik);
            }
        }

        private void btnUpisiJubilej25_Click(object sender, EventArgs e)
        {
            aS.DeleteAll(KalendarLabele.Godisnjica25);
            foreach (vRadnik radnik in radnici)
            {
                aS.DodajGodisnjicu25(radnik);
            }
        }

        private void btnUpisiJubilej3_Click(object sender, EventArgs e)
        {
            aS.DeleteAll(KalendarLabele.Godisnjica30);
            foreach (vRadnik radnik in radnici)
            {
                aS.DodajGodisnjicu30(radnik);
            }
        }
    }

    public enum KalendarLabele
    {
        None = 0,
        Godisnjica10,
        Godisnjica20,
        Godisnjica25,
        Godisnjica30,
        IstekUgovora,
        Rodjendan
    }
}
