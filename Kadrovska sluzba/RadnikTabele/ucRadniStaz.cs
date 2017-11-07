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

namespace Kadrovska_sluzba.RadnikTabele
{
    public partial class ucRadniStaz : DevExpress.XtraEditors.XtraUserControl
    {
        public ucRadniStaz()
        {
            InitializeComponent();
        }

        private Radnik _radnik;
        public Radnik Radnik
        {
            get
            {
                return _radnik;
            }
            set
            {
                _radnik = value;

                LoadData();
            }
        }

        private void LoadData()
        {
            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                if (!(Radnik == null) && (Radnik.ID != 0))
                {
                    RadnikService rs = new RadnikService();
                    RadnikStaz rst = rs.GetStaz(Radnik.ID);
                    txtGF.EditValue = rst.Godina;
                    txtGP.EditValue = rst.StazGPrethodni;
                    txtGPF.EditValue = rst.StazGPrethodniUFirmi;
                    txtGU.EditValue = rst.G;

                    txtMF.EditValue = rst.Mjeseci;
                    txtMP.EditValue = rst.StazMjPrethodni;
                    txtMPF.EditValue = rst.StazMjPrethodniUFirmi;
                    txtMU.EditValue = rst.M;

                    txtDF.EditValue = rst.Dana;
                    txtDP.EditValue = rst.StazDanaPrethodni;
                    txtDPF.EditValue = rst.StazDanaPrethodniUFirmi;
                    txtDU.EditValue = rst.D;
                }
                else
                {
                    txtGF.EditValue = 0;
                    txtGP.EditValue = 0;
                    txtGPF.EditValue = 0;
                    txtGU.EditValue = 0;

                    txtMF.EditValue = 0;
                    txtMP.EditValue = 0;
                    txtMPF.EditValue = 0;
                    txtMU.EditValue = 0;

                    txtDF.EditValue = 0;
                    txtDP.EditValue = 0;
                    txtDPF.EditValue = 0;
                    txtDU.EditValue = 0;
                }
            }
        }
    }
}
