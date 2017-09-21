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
    public partial class frmRadnoMjestoEdit : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        RadnoMjestoService rms;
        RadnoMjesto radnoMjesto;
        int radnoMjestoID;

        public frmRadnoMjestoEdit(int Id)
        {
            InitializeComponent();

            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                radnoMjestoID = Id;
                rms = new RadnoMjestoService();
                LoadData(Id);
            }
        }
        void LoadData(int Id)
        {
            radnoMjesto = GetDataSource(Id);
            txtOpis.EditValue = radnoMjesto.Opis;
            txtNaziv.EditValue = radnoMjesto.Naziv;
        }
        public RadnoMjesto GetDataSource(int iD)
        {
            RadnoMjesto result;
            if (radnoMjestoID == 0)
            {
                result = new RadnoMjesto();
                result.Opis = "";
                result.Naziv = "";
            }
            else
            {
                result = rms.GetByID(radnoMjestoID);
            }
            return result;
        }

        void Snimi()
        {
            radnoMjesto.Opis = txtOpis.EditValue.ToString();
            radnoMjesto.Naziv = txtNaziv.EditValue.ToString();
            rms.CreateOrUpdate(radnoMjesto);
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData(radnoMjestoID);
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
            rms.Delete(radnoMjesto);
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}
