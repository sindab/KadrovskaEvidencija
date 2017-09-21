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
    public partial class frmPorodicnoStanjeEdit : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        PorodicnoStanjeService ns;
        PorodicnoStanje porodicnoStanje;
        int porodicnoStanjeID;

        public frmPorodicnoStanjeEdit(int Id)
        {
            InitializeComponent();

            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                porodicnoStanjeID = Id;
                ns = new PorodicnoStanjeService();
                LoadData(Id);
            }
        }
        void LoadData(int Id)
        {
            porodicnoStanje = GetDataSource(Id);
            txtNaziv.EditValue = porodicnoStanje.Naziv;
        }
        public PorodicnoStanje GetDataSource(int iD)
        {
            PorodicnoStanje result;
            if (porodicnoStanjeID == 0)
            {
                result = new PorodicnoStanje();
                result.Naziv = "";
            }
            else
            {
                result = ns.GetByID(porodicnoStanjeID);
            }
            return result;
        }

        void Snimi()
        {
            porodicnoStanje.Naziv = txtNaziv.EditValue.ToString();
            ns.CreateOrUpdate(porodicnoStanje);
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData(porodicnoStanjeID);
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
            ns.Delete(porodicnoStanje);
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}
