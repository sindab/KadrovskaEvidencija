using System;
using System.ComponentModel;
using Kadrovska_sluzba.DB.Service;
using Kadrovska_sluzba.DB.Models;

namespace Kadrovska_sluzba.RadnikTabele
{
    public partial class ucKursEdit : DevExpress.XtraEditors.XtraUserControl
    {
        public event EventHandler AfterSave;
        RadnikKursService ms;
        RadnikKurs kurs;

        public ucKursEdit()
        {
            InitializeComponent();
        }

        public RadnikKurs Kurs
        {
            get
            {
                return kurs;
            }
            set
            {
                if (!(value == null))
                {
                    layoutControlGroup1.Enabled = true;
                    kurs = value;
                    if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
                    {
                        ms = new RadnikKursService();
                        if (kurs.ID == 0)
                        {
                            mainRibbonPage.Text = "";
                            dtOd.EditValue = null;
                            dtDo.EditValue = null;
                            txtNapomena.EditValue = "";
                        }
                        else
                        {
                            dtOd.EditValue = kurs.Datum;
                            dtDo.EditValue = kurs.DatumDo;
                            txtNapomena.EditValue = kurs.Opis;
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
            if (dtOd.EditValue == null) kurs.Datum = null;
            else kurs.Datum = Convert.ToDateTime(dtOd.EditValue);
            if (dtDo.EditValue == null) kurs.DatumDo = null;
            else kurs.DatumDo = Convert.ToDateTime(dtDo.EditValue);

            if (txtNapomena.EditValue == null) kurs.Opis = null;
            else kurs.Opis = txtNapomena.EditValue.ToString();
            ms.CreateOrUpdate(kurs);
            this.AfterSave(this, new EventArgs());
        }
    }
}
