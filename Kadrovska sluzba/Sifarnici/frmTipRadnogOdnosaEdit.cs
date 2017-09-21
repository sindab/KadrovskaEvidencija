using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.ComponentModel.DataAnnotations;
using System.IO;
using DevExpress.XtraLayout.Helpers;
using DevExpress.XtraLayout;
using Kadrovska_sluzba.DB.Service;
using Kadrovska_sluzba.DB.Models;
using DevExpress.XtraBars;

namespace Kadrovska_sluzba.Sifarnici
{
    public partial class frmTipRadnogOdnosaEdit : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        TipRadnogOdnosaService rms;
        TipRadnogOdnosa tipRadnogOdnosa;
        int tipRadnogOdnosaID;

        public frmTipRadnogOdnosaEdit(int Id)
        {
            InitializeComponent();

            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                tipRadnogOdnosaID = Id;
                rms = new TipRadnogOdnosaService();
                LoadData(Id);
            }
        }
        void LoadData(int Id)
        {
            tipRadnogOdnosa = GetDataSource(Id);
            txtOpis.EditValue = tipRadnogOdnosa.Opis;
            txtNaziv.EditValue = tipRadnogOdnosa.Naziv;
        }
        public TipRadnogOdnosa GetDataSource(int iD)
        {
            TipRadnogOdnosa result;
            if (tipRadnogOdnosaID == 0)
            {
                result = new TipRadnogOdnosa();
                result.Opis = "";
                result.Naziv = "";
                result.Bitovi = 0;
            }
            else
            {
                result = rms.GetByID(tipRadnogOdnosaID);
            }
            return result;
        }

        void Snimi()
        {
            tipRadnogOdnosa.Opis = txtOpis.EditValue.ToString();
            tipRadnogOdnosa.Naziv = txtNaziv.EditValue.ToString();
            rms.CreateOrUpdate(tipRadnogOdnosa);
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData(tipRadnogOdnosaID);
        }

        private void bbiSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            Snimi();
        }

        private void bbiSaveAndClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Snimi();
            Close();
        }

        private void bbiSaveAndNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            Snimi();
            LoadData(0);
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            rms.Delete(tipRadnogOdnosa);
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}
