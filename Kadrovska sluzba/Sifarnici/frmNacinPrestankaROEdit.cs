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
    public partial class frmNacinPrestankaROEdit : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        NacinPrestankaROService ss;
        NacinPrestankaRO nacinPrestankaRO;
        int nacinPrestankaROID;

        public frmNacinPrestankaROEdit(int Id)
        {
            InitializeComponent();

            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                nacinPrestankaROID = Id;
                ss = new NacinPrestankaROService();
                LoadData(Id);
            }
        }
        void LoadData(int Id)
        {
            nacinPrestankaRO = GetDataSource(Id);
            txtOpis.EditValue = nacinPrestankaRO.Opis;
            txtNaziv.EditValue = nacinPrestankaRO.Naziv;
        }
        public NacinPrestankaRO GetDataSource(int iD)
        {
            NacinPrestankaRO result;
            if (nacinPrestankaROID == 0)
            {
                result = new NacinPrestankaRO();
                result.Opis = "";
                result.Naziv = "";
            }
            else
            {
                result = ss.GetByID(nacinPrestankaROID);
            }
            return result;
        }

        void Snimi()
        {
            nacinPrestankaRO.Opis = txtOpis.EditValue.ToString();
            nacinPrestankaRO.Naziv = txtNaziv.EditValue.ToString();
            ss.CreateOrUpdate(nacinPrestankaRO);
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData(nacinPrestankaROID);
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
            ss.Delete(nacinPrestankaRO);
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}
