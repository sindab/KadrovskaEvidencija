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

namespace Kadrovska_sluzba.Sifarnici
{
    public partial class ucPoslovneJedinice : DevExpress.XtraEditors.XtraUserControl
    {
        PoslovnaJedinicaService os;
        public ucPoslovneJedinice()
        {
            InitializeComponent();

            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                os = new PoslovnaJedinicaService();
                LoadData();
            }
        }
        void LoadData()
        {
            IEnumerable<PoslovnaJedinica> dataSource = GetDataSource();
            gridControl.DataSource = dataSource;
            bsiRecordsCount.Caption = "RECORDS : " + dataSource.ToList().Count;
            gridView.MoveLastVisible();
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }
        public IEnumerable<PoslovnaJedinica> GetDataSource()
        {
            IEnumerable<PoslovnaJedinica> result = os.GetAll();
            return result;
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPoslovnaJedinicaEdit fOE = new frmPoslovnaJedinicaEdit(0);
            fOE.ShowDialog();
            LoadData();
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView.FocusedRowHandle > -1)
            {
                frmPoslovnaJedinicaEdit fOE = new frmPoslovnaJedinicaEdit((int)gridView.GetFocusedRowCellValue(gcID));
                fOE.ShowDialog();
                LoadData();
            }
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView.FocusedRowHandle > -1)
            {
                os.Delete((int)gridView.GetFocusedRowCellValue(gcID));
                LoadData();
            }
        }
    }
}
