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
    public partial class frmStrucnaSpremaEdit : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        StrucnaSpremaService ss;
        StrucnaSprema strucnaSprema;
        int strucnaSpremaID;

        public frmStrucnaSpremaEdit(int Id)
        {
            InitializeComponent();

            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                strucnaSpremaID = Id;
                ss = new StrucnaSpremaService();
                LoadData(Id);
            }
        }
        void LoadData(int Id)
        {
            strucnaSprema = GetDataSource(Id);
            txtOpis.EditValue = strucnaSprema.Opis;
            txtNaziv.EditValue = strucnaSprema.Naziv;
        }
        public StrucnaSprema GetDataSource(int iD)
        {
            StrucnaSprema result;
            if (strucnaSpremaID == 0)
            {
                result = new StrucnaSprema();
                result.Opis = "";
                result.Naziv = "";
            }
            else
            {
                result = ss.GetByID(strucnaSpremaID);
            }
            return result;
        }

        void Snimi()
        {
            strucnaSprema.Opis = txtOpis.EditValue.ToString();
            strucnaSprema.Naziv = txtNaziv.EditValue.ToString();
            ss.CreateOrUpdate(strucnaSprema);
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData(strucnaSpremaID);
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
            ss.Delete(strucnaSprema);
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}
