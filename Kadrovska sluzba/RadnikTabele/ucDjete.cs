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
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Kadrovska_sluzba.DB.Service;
using Kadrovska_sluzba.DB.Models;

namespace Kadrovska_sluzba.RadnikTabele
{
    public partial class ucDjete : DevExpress.XtraEditors.XtraUserControl
    {
        public event EventHandler AfterSave;
        RadnikDjecaService ms;
        RadnikDjeca djete;
        //int djeteID;
        //Radnik _roditelj;

        public ucDjete()
        {
            InitializeComponent();
        }
        //public Radnik Roditelj
        //{
        //    get
        //    {
        //        return _roditelj;
        //    }
        //    set
        //    {
        //            _roditelj = value;
        //    }
        //}
        public RadnikDjeca Djete
        {
            get
            {
                return djete;
            }
            set
            {
                if (!(value == null))
                {
                    layoutControlGroup1.Enabled = true;
                    djete = value;
                    if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
                    {
                        ms = new RadnikDjecaService();
                        if (djete.ID == 0)
                        {
                            mainRibbonPage.Text = "";
                            txtJMBG.EditValue = "";
                            txtIme.EditValue = "";
                            dtRodj.EditValue = null;
                        }
                        else
                        {
                            mainRibbonPage.Text = djete.Ime;
                            //djeteID = djete.ID;
                            txtJMBG.EditValue = djete.JMBG;
                            txtIme.EditValue = djete.Ime;
                            dtRodj.EditValue = djete.DatumRodj;
                            //LoadData(value.ID);
                        }
                    }
                }
                else
                {
                    layoutControlGroup1.Enabled = false;
                }
            }
        }
        //void LoadData(int Id)
        //{
        //    djete = GetDataSource(Id);
        //    //txtSifra.EditValue = mjesto.PostBr;
        //    //txtNaziv.EditValue = mjesto.Naziv;
        //    //lkpOpstine.EditValue = mjesto.OpstinaID;
        //}
        //public RadnikDjeca GetDataSource(int iD)
        //{
        //    RadnikDjeca result;
        //    if (djeteID == 0)
        //    {
        //        result = new RadnikDjeca();
        //        //result.PostBr = 0;
        //        //result.Naziv = "";
        //    }
        //    else
        //    {
        //        result = ms.GetByID(djeteID);
        //    }
        //    return result;
        //}

        //void Snimi()
        //{
        //    ////mjesto.PostBr = (int)txtSifra.EditValue;
        //    //if (!(txtSifra.EditValue is null)) { mjesto.PostBr = (int)txtSifra.EditValue; }
        //    //mjesto.Naziv = txtNaziv.EditValue.ToString();
        //    //if (!(lkpOpstine.EditValue is null)) { mjesto.OpstinaID = (int)lkpOpstine.EditValue; }
        //    //ms.CreateOrUpdate(mjesto);
        //}

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtIme.EditValue == null) return; //OBAVEZNO POLJE
            //djete.JMBG = txtJMBG.EditValue.ToString();
            if (txtJMBG.EditValue == null) djete.JMBG = null;
            else djete.JMBG = txtJMBG.EditValue.ToString();
            djete.Ime = txtIme.EditValue.ToString();
            //djete.DatumRodj = dtRodj.EditValue;
            if (dtRodj.EditValue == null) djete.DatumRodj = null;
            else djete.DatumRodj = Convert.ToDateTime(dtRodj.EditValue);
            //djete.Napomena = memoEdit1.EditValue.ToString();
            if (memoEdit1.EditValue == null) djete.Napomena = null;
            else djete.Napomena = memoEdit1.EditValue.ToString();
            ms.CreateOrUpdate(djete);
            this.AfterSave(this, new EventArgs());
        }

    }
}
