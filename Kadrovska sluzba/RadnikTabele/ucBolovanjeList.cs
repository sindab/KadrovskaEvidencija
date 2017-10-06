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
    public partial class ucBolovanjeList : DevExpress.XtraEditors.XtraUserControl
    {
        public delegate void BolovanjeChangedHandler(object myObject, BolovanjeArgs myArgs);
        public event BolovanjeChangedHandler IzmjenaBolovanje;
        RadnikBolovanjeService rds;
        public ucBolovanjeList()
        {
            InitializeComponent();
        }
        public class BolovanjeArgs : EventArgs
        {
            private RadnikBolovanje bolovanje;
            public BolovanjeArgs(RadnikBolovanje bolovanje)
            {
                this.bolovanje = bolovanje;
            }
            // This is a straightforward implementation for declaring a public field
            public RadnikBolovanje Bolovanje
            {
                get
                {
                    return bolovanje;
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
                    rds = new RadnikBolovanjeService();
                    LoadData();
                }
            }
        }

        public void LoadData()
        {
            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                IEnumerable<RadnikBolovanje> dataSource = GetDataSource();
                gridControl.DataSource = dataSource;
                bsiRecordsCount.Caption = "RECORDS : " + dataSource.ToList().Count;
                gridView.MoveLastVisible();
            }
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }
        public IEnumerable<RadnikBolovanje> GetDataSource()
        {
            IEnumerable<RadnikBolovanje> result = rds.GetByRadId(Roditelj.ID);
            return result;
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            RadnikBolovanje trenutniBolovanje = new RadnikBolovanje()
            {
                //ID = 0,
                RadID = Roditelj.ID,
                DatumOd = DateTime.Today,
                Opis = string.Empty
            };
            BolovanjeArgs myArgs = new BolovanjeArgs(trenutniBolovanje);
            IzmjenaBolovanje(this, myArgs);
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
                RadnikBolovanje trenutniBolovanje;
                try
                {
                    trenutniBolovanje = rds.GetByID((int)gridView.GetFocusedRowCellValue(gcID));
                }
                catch (Exception)
                {
                    trenutniBolovanje = new RadnikBolovanje()
                    {
                        ID = 0
                    };
                }
                BolovanjeArgs myArgs = new BolovanjeArgs(trenutniBolovanje);
                IzmjenaBolovanje(this, myArgs);
            }
        }
    }
}
