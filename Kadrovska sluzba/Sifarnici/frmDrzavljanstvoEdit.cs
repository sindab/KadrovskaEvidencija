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
    public partial class frmDrzavljanstvoEdit : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DrzavljanstvoService ds;
        Drzavljanstvo drzavljanstvo;
        int drzavljanstvoID;

        public frmDrzavljanstvoEdit(int Id)
        {
            InitializeComponent();

            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                drzavljanstvoID = Id;
                ds = new DrzavljanstvoService();
                LoadData(Id);
            }
        }
        void LoadData(int Id)
        {
            drzavljanstvo = GetDataSource(Id);
            txtNaziv.EditValue = drzavljanstvo.Naziv;
        }
        public Drzavljanstvo GetDataSource(int iD)
        {
            Drzavljanstvo result;
            if (drzavljanstvoID == 0)
            {
                result = new Drzavljanstvo();
                result.Naziv = "";
            }
            else
            {
                result = ds.GetByID(drzavljanstvoID);
            }
            return result;
        }

        void Snimi()
        {
            drzavljanstvo.Naziv = txtNaziv.EditValue.ToString();
            ds.CreateOrUpdate(drzavljanstvo);
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData(drzavljanstvoID);
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
            ds.Delete(drzavljanstvo);
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}
