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

namespace Kadrovska_sluzba.Settings
{
    public partial class ucGodisnjiOdmori : DevExpress.XtraEditors.XtraUserControl
    {
        RadnikGOService rgs;
        public ucGodisnjiOdmori()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //TODO provjeri zaduzio za ovu godinu...
            int dana = 0;
            int zatvori = 0;
            if (cbZatvori.Checked) { zatvori = 1; }
            int.TryParse(txtUpisiDana.EditValue.ToString(), out dana);
            //dana = (int)txtUpisiDana.EditValue;
            rgs.PSGodisnjiOdmor(dana, zatvori);
            simpleButton1.Enabled = false;//do ponovnog ulaska u program
        }

        private void ucGodisnjiOdmori_Load(object sender, EventArgs e)
        {
            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                DateTime d1 = DateTime.Today;
                txtPrethodnaGodina.EditValue = d1.Year - 1;
                txtNovaGodina.EditValue = d1.Year;
                rgs = new RadnikGOService();

                int brojNeiskoristenihDana = rgs.GetBrojNeiskoristenihDana();
                txtZatvoriDana.EditValue = brojNeiskoristenihDana;
                cbZatvori.Checked = (brojNeiskoristenihDana > 0);
                cbZatvori.Enabled = (brojNeiskoristenihDana > 0);
            }
        }
    }
}
