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
using DevExpress.XtraBars;
using System.ComponentModel.DataAnnotations;
using Kadrovska_sluzba.DB.Service;
using Kadrovska_sluzba.DB.Models;

namespace Kadrovska_sluzba.RadnikTabele
{
    public partial class ucKursList : DevExpress.XtraEditors.XtraUserControl
    {
        public delegate void KursChangedHandler(object myObject, KursArgs myArgs);
        public event KursChangedHandler IzmjenaKurs;
        RadnikKursService rds;
        public ucKursList()
        {
            InitializeComponent();
        }
        public class KursArgs : EventArgs
        {
            private RadnikKurs kurs;
            public KursArgs(RadnikKurs kurs)
            {
                this.kurs = kurs;
            }
            // This is a straightforward implementation for declaring a public field
            public RadnikKurs Kurs
            {
                get
                {
                    return kurs;
                }
            }
        }
        private Radnik _roditelj;
        public Radnik Roditelj
        {
            get
            {
                return _roditelj;
            }
            set
            {
                if (!(value == null))
                {
                    _roditelj = value;
                    rds = new RadnikKursService();
                    LoadData();
                }
            }
        }

        public void LoadData()
        {
            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                IEnumerable<RadnikKurs> dataSource = GetDataSource();
                gridControl.DataSource = dataSource;
                bsiRecordsCount.Caption = "RECORDS : " + dataSource.ToList().Count;
                gridView.MoveLastVisible();
            }
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }
        public IEnumerable<RadnikKurs> GetDataSource()
        {
            IEnumerable<RadnikKurs> result = rds.GetByRadId(Roditelj.ID);
            return result;
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            RadnikKurs trenutniKurs = new RadnikKurs()
            {
                //ID = 0,
                RadID = Roditelj.ID,
                Datum = DateTime.Today,
                Opis = string.Empty
            };
            KursArgs myArgs = new KursArgs(trenutniKurs);
            IzmjenaKurs(this, myArgs);
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                if (gridView.FocusedRowHandle > -1)
                {
                    rds.Delete((int)gridView.GetFocusedRowCellValue(gcID));
                    LoadData();
                }
            }
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // proslijedi 

            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                RadnikKurs trenutniKurs;
                try
                {
                    trenutniKurs = rds.GetByID((int)gridView.GetFocusedRowCellValue(gcID));
                }
                catch (Exception)
                {
                    trenutniKurs = new RadnikKurs()
                    {
                        ID = 0
                    };
                }
                KursArgs myArgs = new KursArgs(trenutniKurs);
                IzmjenaKurs(this, myArgs);
            }
        }
    }
}
