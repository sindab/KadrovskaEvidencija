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
    public partial class ucPovredaList : DevExpress.XtraEditors.XtraUserControl
    {
        public delegate void PovredaChangedHandler(object myObject, PovredaArgs myArgs);
        public event PovredaChangedHandler IzmjenaPovreda;
        RadnikPovredaROService rds;
        public ucPovredaList()
        {
            InitializeComponent();
        }
        public class PovredaArgs : EventArgs
        {
            private RadnikPovredaRO povreda;
            public PovredaArgs(RadnikPovredaRO povreda)
            {
                this.povreda = povreda;
            }
            // This is a straightforward implementation for declaring a public field
            public RadnikPovredaRO Povreda
            {
                get
                {
                    return povreda;
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
                    rds = new RadnikPovredaROService();
                    LoadData();
                }
            }
        }

        public void LoadData()
        {
            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                IEnumerable<RadnikPovredaRO> dataSource = GetDataSource();
                gridControl.DataSource = dataSource;
                bsiRecordsCount.Caption = "RECORDS : " + dataSource.ToList().Count;
                gridView.MoveLastVisible();
            }
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }
        public IEnumerable<RadnikPovredaRO> GetDataSource()
        {
            IEnumerable<RadnikPovredaRO> result = rds.GetByRadId(Roditelj.ID);
            return result;
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            RadnikPovredaRO trenutniPovreda = new RadnikPovredaRO()
            {
                //ID = 0,
                RadID = Roditelj.ID,
                Datum = DateTime.Today,
                Opis = string.Empty
            };
            PovredaArgs myArgs = new PovredaArgs(trenutniPovreda);
            IzmjenaPovreda(this, myArgs);
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
                RadnikPovredaRO trenutniPovreda;
                try
                {
                    trenutniPovreda = rds.GetByID((int)gridView.GetFocusedRowCellValue(gcID));
                }
                catch (Exception)
                {
                    trenutniPovreda = new RadnikPovredaRO()
                    {
                        ID = 0
                    };
                }
                PovredaArgs myArgs = new PovredaArgs(trenutniPovreda);
                IzmjenaPovreda(this, myArgs);
            }
        }
    }
}
