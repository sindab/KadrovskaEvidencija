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
    public partial class frmOpstinaEdit : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        OpstinaService os;
        Opstina opstina;
        int opstinaID;

        public frmOpstinaEdit(int Id)
        {
            InitializeComponent();

            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                opstinaID = Id;
                os = new OpstinaService();
                LoadData(Id);
            }
        }
        void LoadData(int Id)
        {
            opstina = GetDataSource(Id);
            txtSifra.EditValue = opstina.Sifra;
            txtNaziv.EditValue = opstina.Naziv;
        }
        public Opstina GetDataSource(int iD)
        {
            Opstina result;
            if (opstinaID == 0)
            {
                result = new Opstina();
                result.Sifra = "000";
                result.Naziv = "";
            }
            else
            {
                result = os.GetByID(opstinaID);
            }
            return result;
        }

        void Snimi()
        {
            opstina.Sifra = txtSifra.EditValue.ToString();
            opstina.Naziv = txtNaziv.EditValue.ToString();
            os.CreateOrUpdate(opstina);
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData(opstinaID);
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
            os.Delete(opstina);
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}
