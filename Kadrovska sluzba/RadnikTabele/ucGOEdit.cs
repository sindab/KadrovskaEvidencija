using System;
using System.ComponentModel;
using Kadrovska_sluzba.DB.Service;
using Kadrovska_sluzba.DB.Models;

namespace Kadrovska_sluzba.RadnikTabele
{
    public partial class ucGOEdit : DevExpress.XtraEditors.XtraUserControl
    {
        public event EventHandler AfterSave;
        RadnikGOService ms;
        RadnikGO gOd;

        public ucGOEdit()
        {
            InitializeComponent();
        }

        public RadnikGO GOdmor
        {
            get
            {
                return gOd;
            }
            set
            {
                if (!(value == null))
                {
                    layoutControlGroup1.Enabled = true;
                    gOd = value;
                    if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
                    {
                        ms = new RadnikGOService();
                        if (gOd.ID == 0)
                        {
                            mainRibbonPage.Text = "";
                            txtZaduzio.EditValue = "0";
                            txtRazduzio.EditValue = "0";
                            dtOd.EditValue = null;
                            dtDo.EditValue = null;
                            txtNapomena.EditValue = "";
                        }
                        else
                        {
                            txtZaduzio.EditValue = gOd.Zaduzio;
                            txtRazduzio.EditValue = gOd.Razduzio;
                            dtOd.EditValue = gOd.DatumOd;
                            dtDo.EditValue = gOd.DatumDo;
                            txtNapomena.EditValue = gOd.Napomena;
                        }
                    }
                }
                else
                {
                    layoutControlGroup1.Enabled = false;
                }
            }
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(txtZaduzio.EditValue.ToString()) || string.IsNullOrEmpty(txtRazduzio.EditValue.ToString())) return; //OBAVEZNO POLJE
            if (string.IsNullOrEmpty(txtZaduzio.EditValue.ToString())) gOd.Zaduzio = 0;
            else gOd.Zaduzio = Int32.Parse(txtZaduzio.EditValue.ToString());
            if (string.IsNullOrEmpty(txtRazduzio.EditValue.ToString())) gOd.Razduzio = 0;
            else gOd.Razduzio = Int32.Parse(txtRazduzio.EditValue.ToString());

            if (dtOd.EditValue == null) gOd.DatumOd = null;
            else gOd.DatumOd = Convert.ToDateTime(dtOd.EditValue);
            if (dtDo.EditValue == null) gOd.DatumDo = null;
            else gOd.DatumDo = Convert.ToDateTime(dtDo.EditValue);

            if (txtNapomena.EditValue == null) gOd.Napomena = null;
            else gOd.Napomena = txtNapomena.EditValue.ToString();
            ms.CreateOrUpdate(gOd);
            this.AfterSave(this, new EventArgs());
        }
    }
}
