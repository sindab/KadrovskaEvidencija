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
    public partial class frmMjestoEdit : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        MjestoService ms;
        Mjesto mjesto;
        int mjestoID;

        public frmMjestoEdit(int Id)
        {
            InitializeComponent();

            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                OpstinaService os = new OpstinaService();
                lkpOpstine.Properties.DataSource = os.GetAll();
                mjestoID = Id;
                ms = new MjestoService();
                LoadData(Id);
            }
        }
        void LoadData(int Id)
        {
            mjesto = GetDataSource(Id);
            txtSifra.EditValue = mjesto.PostBr;
            txtNaziv.EditValue = mjesto.Naziv;
            lkpOpstine.EditValue = mjesto.OpstinaID;
        }
        public Mjesto GetDataSource(int iD)
        {
            Mjesto result;
            if (mjestoID == 0)
            {
                result = new Mjesto();
                result.PostBr = "00000";
                result.Naziv = "";
            }
            else
            {
                result = ms.GetByID(mjestoID);
            }
            return result;
        }

        void Snimi()
        {
            mjesto.PostBr = txtSifra.EditValue.ToString();
            mjesto.Naziv = txtNaziv.EditValue.ToString();
            if (!(lkpOpstine.EditValue is null)) { mjesto.OpstinaID = (int)lkpOpstine.EditValue; }
            ms.CreateOrUpdate(mjesto);
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData(mjestoID);
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
            ms.Delete(mjesto);
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}
