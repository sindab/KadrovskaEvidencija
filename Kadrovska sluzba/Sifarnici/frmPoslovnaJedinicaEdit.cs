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
    public partial class frmPoslovnaJedinicaEdit : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        PoslovnaJedinicaService ds;
        PoslovnaJedinica poslovnaJedinica;
        int poslovnaJedinicaID;

        public frmPoslovnaJedinicaEdit(int Id)
        {
            InitializeComponent();

            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                MjestoService os = new MjestoService();
                cbMjesto.Properties.DataSource = os.GetAll();
                poslovnaJedinicaID = Id;
                ds = new PoslovnaJedinicaService();
                LoadData(Id);
            }
        }
        void LoadData(int Id)
        {
            poslovnaJedinica = GetDataSource(Id);
            txtNaziv.EditValue = poslovnaJedinica.Naziv;
            txtPuniNaziv.EditValue = poslovnaJedinica.PuniNaziv;
            txtMaticni.EditValue = poslovnaJedinica.Maticni;
            txtPIB.EditValue = poslovnaJedinica.PIB;
            txtJIB.EditValue = poslovnaJedinica.JIB;
            txtZiro.EditValue = poslovnaJedinica.Ziro;
            txtWeb.EditValue = poslovnaJedinica.Web;
            txtMail.EditValue = poslovnaJedinica.Mail;
            cbMjesto.EditValue = poslovnaJedinica.PostBroj;
            txtAdresa.EditValue = poslovnaJedinica.Adresa;
            txtTelefon.EditValue = poslovnaJedinica.Telefon;
            txtFax.EditValue = poslovnaJedinica.Fax;
            txtMobilni.EditValue = poslovnaJedinica.Mobilni;
        }
        public PoslovnaJedinica GetDataSource(int iD)
        {
            PoslovnaJedinica result;
            if (poslovnaJedinicaID == 0)
            {
                result = new PoslovnaJedinica();
                result.Naziv = "";
                result.PuniNaziv = "";
                result.Maticni = "";
                result.PIB = "";
                result.JIB = "";
                result.Ziro = "";
                result.Web = "";
                result.Mail = "";
                result.Adresa = "";
                result.Telefon = "";
                result.Fax = "";
                result.Mobilni = "";
            }
            else
            {
                result = ds.GetByID(poslovnaJedinicaID);
            }
            return result;
        }

        void Snimi()
        {
            poslovnaJedinica.Naziv = txtNaziv.EditValue.ToString();
            poslovnaJedinica.PuniNaziv = txtPuniNaziv.EditValue.ToString();
            poslovnaJedinica.Maticni = txtMaticni.EditValue.ToString();
            poslovnaJedinica.PIB = txtPIB.EditValue.ToString();
            poslovnaJedinica.JIB = txtJIB.EditValue.ToString();
            poslovnaJedinica.Ziro = txtZiro.EditValue.ToString();
            poslovnaJedinica.Web = txtWeb.EditValue.ToString();
            poslovnaJedinica.Mail = txtMail.EditValue.ToString();
            if (!(cbMjesto.EditValue is null)) { poslovnaJedinica.PostBroj = cbMjesto.EditValue.ToString(); }
            poslovnaJedinica.Adresa = txtAdresa.EditValue.ToString();
            poslovnaJedinica.Telefon = txtTelefon.EditValue.ToString();
            poslovnaJedinica.Fax = txtFax.EditValue.ToString();
            poslovnaJedinica.Mobilni = txtMobilni.EditValue.ToString();
            ds.CreateOrUpdate(poslovnaJedinica);
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData(poslovnaJedinicaID);
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
            ds.Delete(poslovnaJedinica);
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
        
    }
}
