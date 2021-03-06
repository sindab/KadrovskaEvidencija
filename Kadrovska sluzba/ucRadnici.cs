﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.ComponentModel.DataAnnotations;
using Kadrovska_sluzba.DB.Models;
using Kadrovska_sluzba.DB.Service;
using Microsoft.Win32;
using Kadrovska_sluzba.Reports;
using DevExpress.XtraReports.UI;

namespace Kadrovska_sluzba
{
    public partial class ucRadnici : DevExpress.XtraEditors.XtraUserControl
    {
        RadnikService rs;
        IEnumerable<vRadnik> dataSource;
        vRadnik trenutni;
        public delegate void RadnikChangedHandler(object myObject, RadnikArgs myArgs);
        public event RadnikChangedHandler IzmjenaRadnika;
        //RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"Software\Kadrovska\frmRadnikLayout");

        public ucRadnici()
        {
            InitializeComponent();
            //gridView.RestoreLayoutFromXml("frmRadnikLayout.xml");

        }
        //private string PathName
        //{
        //    get
        //    {
        //        //using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"Software\Kadrovska"))
        //        //{
        //            return (string)registryKey.GetValue("frmRadnikLayout");
        //        //}
        //    }
        //}

        private void ucRadnici_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                if (System.IO.File.Exists(openFileDialog1.FileName))
                    gridView.RestoreLayoutFromXml(openFileDialog1.FileName);

                LoadData(0);

                //gridView1.RestoreLayoutFromRegistry("frmRadnikLayout");

                MjestoService ms = new MjestoService();
                IEnumerable<Mjesto> mj = ms.GetAll();
                lkpMjestoRodjenja.DataSource = mj.ToList();
                lkpMjestoStan.DataSource = mj.ToList();

                DrzavljanstvoService ds = new DrzavljanstvoService();
                lkpDrzavljanstvoID.DataSource = ds.GetAll().ToList();
                NacinPrestankaROService nps = new NacinPrestankaROService();
                lkpNacinPrestankaRoID.DataSource = nps.GetAll().ToList();
                NacionalnostService ns = new NacionalnostService();
                lkpNacionalnostID.DataSource= ns.GetAll().ToList();
                OpstinaService os = new OpstinaService();
                lkpOpstinaIzdavanjaRK.DataSource= os.GetAll().ToList();
                PorodicnoStanjeService  pss = new PorodicnoStanjeService();
                lkpPorodicnoStanjeID.DataSource = pss.GetAll().ToList();
                PoslovnaJedinicaService pjs = new PoslovnaJedinicaService();
                lkpPoslovnaJedinicaID.DataSource = pjs.GetAll().ToList();
                RadnoMjestoService rms = new RadnoMjestoService();
                lkpRadnoMjestoID.DataSource = rms.GetAll().ToList();
                StrucnaSpremaService sss = new StrucnaSpremaService();
                lkpStrucnaSpremaID.DataSource = sss.GetAll().ToList();
                TipRadnogOdnosaService trs = new TipRadnogOdnosaService();
                lkpTipRadnogOdnosaID.DataSource = trs.GetAll().ToList();
            }
        }

        public void LoadData(int focusID)
        {
            if (!this.DesignMode)
            {
                dataSource = GetDataSource();
                gridControl.DataSource = dataSource;
                gridView.ExpandAllGroups();
                bsiRecordsCount.Caption = "RECORDS : " + dataSource.ToList().Count;
                if (focusID > 0)
                {
                    TrenutniRadnik = dataSource.Where(x => x.ID == focusID).FirstOrDefault(); // dt.Rows.IndexOf(dt.Rows.Find(< key_value >));
                    gridView.FocusedRowHandle = gridView.FindRow(TrenutniRadnik);
                }
            }
        }

        public vRadnik TrenutniRadnik
        {
            get
            {
                return trenutni;
            }
            set
            {
                trenutni = value;
            }
        }

        public class RadnikArgs : EventArgs
        {
            private Radnik radnik;
            public RadnikArgs(Radnik radnik)
            {
                this.radnik = radnik;
            }
            // This is a straightforward implementation for declaring a public field
            public Radnik Radnik
            {
                get
                {
                    return radnik;
                }
            }
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }
        public IEnumerable<vRadnik> GetDataSource()
        {
            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                rs = new RadnikService();
                IEnumerable<vRadnik> result = rs.GetAllV();
                return result;
            }
            else { return null; }
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView.FocusedRowHandle > -1)
            {
                trenutni = dataSource.First(x => x.ID == (int)gridView.GetFocusedRowCellValue("ID"));
            }
            else
            {
                trenutni = new vRadnik();
            }
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TrenutniRadnik.ID > 0)
            {
                RadnikArgs myArgs = new RadnikArgs(rs.GetByID(TrenutniRadnik.ID));
                IzmjenaRadnika(this, myArgs);
            }
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            Radnik newR = new Radnik()
            {
                AdresaStan = string.Empty,
                Bitovi = 0,
                BrLK = string.Empty,
                BrRadneKnj = string.Empty,
                DjevPrezime = string.Empty,
                eMail = string.Empty,
                Funkcija = string.Empty,
                Ime = string.Empty,
                ImeOca = string.Empty,
                JMBG = string.Empty,
                LicniBrOsiguranja = string.Empty,
                Napomena = string.Empty,
                Pol = "Muški",
                Prezime = string.Empty,
                TelefonMob = string.Empty,
                TelefonPosao = string.Empty,
                TelefonStan = string.Empty,
                Titula = string.Empty,
                Zanimanje = string.Empty,
                ZavrsenaSkola = string.Empty
            };
            RadnikArgs myArgs = new RadnikArgs(newR);
            IzmjenaRadnika(this, myArgs);
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView.FocusedRowHandle > -1)
                LoadData((int)gridView.GetFocusedRowCellValue("ID"));
        }

        private void ucRadnici_VisibleChanged(object sender, EventArgs e)
        {
            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                if ((gridView.FocusedRowHandle > -1) && (int)gridView.GetFocusedRowCellValue("ID") > 0)
                {
                    LoadData((int)gridView.GetFocusedRowCellValue("ID"));
                }
                else { LoadData(0); }
            }
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TrenutniRadnik.ID > 0)
            {
                if (MessageBox.Show("Da li ste sigurni u brisanje radnika iz evidencije?", "Potvrda brisanja", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    rs.Delete(TrenutniRadnik.ID);
                    LoadData(0);
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            saveFileDialog1.ShowDialog();
            gridView.SaveLayoutToXml(openFileDialog1.FileName);
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            openFileDialog1.ShowDialog();
            gridView.RestoreLayoutFromXml(openFileDialog1.FileName);
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            //rptSpisakRadnika
            rptSpisakRadnika r = new rptSpisakRadnika();
            r.ShowPreview();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            //rptSpisakRadnikaPoPolu
            rptSpisakRadnikaPoPolu r = new rptSpisakRadnikaPoPolu();
            r.ShowPreview();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            //rptSpisakRadnikaPoTipuRO
            rptSpisakRadnikaPoTipuRO r = new rptSpisakRadnikaPoTipuRO();
            r.ShowPreview();
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            //rptGodisnjiOdmori
            rptGodisnjiOdmori r = new rptGodisnjiOdmori();
            r.ShowPreview();
        }

        private void gridControl_DoubleClick(object sender, EventArgs e)
        {
            if (TrenutniRadnik.ID > 0)
            {
                RadnikArgs myArgs = new RadnikArgs(rs.GetByID(TrenutniRadnik.ID));
                IzmjenaRadnika(this, myArgs);
            }
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            rptSpisakRadnikaPoStarosti r = new rptSpisakRadnikaPoStarosti();
            r.ShowPreview();
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            rptSpisakRadnikaPoRadnomMjestu r = new rptSpisakRadnikaPoRadnomMjestu();
            r.ShowPreview();
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            rptSpisakRadnikaDetaljni r = new rptSpisakRadnikaDetaljni();
            r.ShowPreview();
        }
    }
}
