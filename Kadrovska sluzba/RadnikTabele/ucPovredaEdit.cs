using System;
using System.ComponentModel;
using Kadrovska_sluzba.DB.Service;
using Kadrovska_sluzba.DB.Models;

namespace Kadrovska_sluzba.RadnikTabele
{
    public partial class ucPovredaEdit : DevExpress.XtraEditors.XtraUserControl
    {
        public event EventHandler AfterSave;
        RadnikPovredaROService ms;
        RadnikPovredaRO povreda;

        public ucPovredaEdit()
        {
            InitializeComponent();
        }

        public RadnikPovredaRO Povreda
        {
            get
            {
                return povreda;
            }
            set
            {
                if (!(value == null))
                {
                    layoutControlGroup1.Enabled = true;
                    povreda = value;
                    if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
                    {
                        ms = new RadnikPovredaROService();
                        if (povreda.ID == 0)
                        {
                            mainRibbonPage.Text = "";
                            dtOd.EditValue = null;
                            txtNapomena.EditValue = "";
                        }
                        else
                        {
                            dtOd.EditValue = povreda.Datum;
                            txtNapomena.EditValue = povreda.Opis;
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
            if (dtOd.EditValue == null) povreda.Datum = null;
            else povreda.Datum = Convert.ToDateTime(dtOd.EditValue);
            
            if (txtNapomena.EditValue == null) povreda.Opis = null;
            else povreda.Opis = txtNapomena.EditValue.ToString();
            ms.CreateOrUpdate(povreda);
            this.AfterSave(this, new EventArgs());
        }
    }
}
