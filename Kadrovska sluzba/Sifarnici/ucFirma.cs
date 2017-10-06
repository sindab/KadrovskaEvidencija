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

namespace Kadrovska_sluzba.Sifarnici
{
    public partial class ucFirma : DevExpress.XtraEditors.XtraUserControl
    {
        FirmaService fs;
        Firma f;
        public ucFirma()
        {
            InitializeComponent();
            //bool designMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime); ILI !Site.DesignMode
            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime)) //OK
            //if (!(Site.DesignMode)) //NOT OK
            {
                MjestoService os = new MjestoService();
                cbMjesto.Properties.DataSource = os.GetAll();
                fs = new FirmaService();
                LoadData();
            }
        }
        //private void ucFirma_VisibleChanged(object sender, EventArgs e)
        //{
        //    if (Visible && !Disposing) LoadData();
        //}
        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            f = GetDataSource();
            txtNaziv.EditValue = f.Naziv;
            txtPuniNaziv.EditValue = f.PuniNaziv;
            txtMaticni.EditValue = f.Maticni;
            txtPIB.EditValue = f.PIB;
            txtJIB.EditValue = f.JIB;
            txtZiro.EditValue = f.Ziro;
            txtWeb.EditValue = f.Web;
            txtMail.EditValue = f.Mail;
            cbMjesto.EditValue = f.Mjesto;
            txtAdresa.EditValue = f.Adresa;
            txtTelefon.EditValue = f.Telefon;
            txtFax.EditValue = f.Fax;
            txtMobilni.EditValue = f.Mobilni;
        }
        private Firma GetDataSource()
        {
            f = fs.GetData();
            if (f is null)
            {
                f = new Firma()
                {
                    ID = 1,
                    Naziv = "Ime firme"
                };
                fs.CreateOrUpdate(f);
            }
            return f;
        }
        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            f.Naziv = txtNaziv.EditValue.ToString();
            f.PuniNaziv = txtPuniNaziv.EditValue.ToString();
            f.Maticni = txtMaticni.EditValue.ToString();
            f.PIB = txtPIB.EditValue.ToString();
            f.JIB = txtJIB.EditValue.ToString();
            f.Ziro = txtZiro.EditValue.ToString();
            f.Web = txtWeb.EditValue.ToString();
            f.Mail = txtMail.EditValue.ToString();
            if (!(cbMjesto.EditValue is null)) { f.Mjesto = (int)cbMjesto.EditValue; }
            f.Adresa = txtAdresa.EditValue.ToString();
            f.Telefon = txtTelefon.EditValue.ToString();
            f.Fax = txtFax.EditValue.ToString();
            f.Mobilni = txtMobilni.EditValue.ToString();
            fs.CreateOrUpdate(f);
        }
        
    }
}
