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
    public partial class ucGOList : DevExpress.XtraEditors.XtraUserControl
    {
        public delegate void GOChangedHandler(object myObject, GOArgs myArgs);
        public event GOChangedHandler IzmjenaGO;
        RadnikGOService rds;
        public ucGOList()
        {
            InitializeComponent();
        }
        public class GOArgs : EventArgs
        {
            private RadnikGO gOd;
            public GOArgs(RadnikGO gOd)
            {
                this.gOd = gOd;
            }
            // This is a straightforward implementation for declaring a public field
            public RadnikGO GOdmor
            {
                get
                {
                    return gOd;
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
                        rds = new RadnikGOService();
                        LoadData();
                }
            }
        }

        public void LoadData()
        {
            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                IEnumerable<RadnikGO> dataSource = GetDataSource();
                gridControl.DataSource = dataSource;
                bsiRecordsCount.Caption = "RECORDS : " + dataSource.ToList().Count;
                gridView.MoveLastVisible();
            }
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }
        public IEnumerable<RadnikGO> GetDataSource()
        {
                IEnumerable<RadnikGO> result = rds.GetByRadId(Roditelj.ID);
                return result;
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            RadnikGO trenutniGO = new RadnikGO()
            {
                ID = 0,
                RadID = Roditelj.ID
            };
            GOArgs myArgs = new GOArgs(trenutniGO);
            IzmjenaGO(this, myArgs);
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
                RadnikGO trenutniGO;
                try
                {
                    trenutniGO = rds.GetByID((int)gridView.GetFocusedRowCellValue(gcID));
                }
                catch (Exception)
                {
                    trenutniGO = new RadnikGO()
                    {
                        ID = 0
                    };
                }
                GOArgs myArgs = new GOArgs(trenutniGO);
                IzmjenaGO(this, myArgs);
            }
        }
    }
}
