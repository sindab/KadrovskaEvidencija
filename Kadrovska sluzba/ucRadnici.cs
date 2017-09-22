using System;
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

namespace Kadrovska_sluzba
{
    public partial class ucRadnici : DevExpress.XtraEditors.XtraUserControl
    {
        IEnumerable<Radnik> dataSource;
        Radnik trenutni;
        public delegate void RadnikChangedHandler(object myObject, RadnikArgs myArgs);
        public event RadnikChangedHandler IzmjenaRadnika;

        public ucRadnici()
        {
            InitializeComponent();
        }

        private void ucRadnici_Load(object sender, EventArgs e)
        {
            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                dataSource = GetDataSource();
                gridControl.DataSource = dataSource;
                bsiRecordsCount.Caption = "RECORDS : " + dataSource.ToList().Count;

                MjestoService ms = new MjestoService();
                IEnumerable<Mjesto> mj = ms.GetAll();
                lkpMjestoRodjenja.DataSource = mj.ToList();
                lkpMjestoStan.DataSource = mj.ToList();
            }
        }

        public Radnik TrenutniRadnik
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
        public IEnumerable<Radnik> GetDataSource()
        {
            RadnikService rs = new RadnikService();
            IEnumerable<Radnik> result = rs.GetAll();
            return result;
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            RadnikArgs myArgs = new RadnikArgs(TrenutniRadnik);
            IzmjenaRadnika(this, myArgs);
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView.FocusedRowHandle > -1)
            {
                trenutni = dataSource.First(x => x.ID == (int)gridView.GetFocusedRowCellValue("ID"));
            }
            else
            {
                trenutni = new Radnik();
            }
        }

    }
}
