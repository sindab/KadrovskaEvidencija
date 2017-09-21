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
    public partial class frmNacionalnostEdit : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        NacionalnostService ns;
        Nacionalnost nacionalnost;
        int nacionalnostID;

        public frmNacionalnostEdit(int Id)
        {
            InitializeComponent();

            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                nacionalnostID = Id;
                ns = new NacionalnostService();
                LoadData(Id);
            }
        }
        void LoadData(int Id)
        {
            nacionalnost = GetDataSource(Id);
            txtNaziv.EditValue = nacionalnost.Naziv;
        }
        public Nacionalnost GetDataSource(int iD)
        {
            Nacionalnost result;
            if (nacionalnostID == 0)
            {
                result = new Nacionalnost();
                result.Naziv = "";
            }
            else
            {
                result = ns.GetByID(nacionalnostID);
            }
            return result;
        }

        void Snimi()
        {
            nacionalnost.Naziv = txtNaziv.EditValue.ToString();
            ns.CreateOrUpdate(nacionalnost);
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData(nacionalnostID);
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
            ns.Delete(nacionalnost);
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}
