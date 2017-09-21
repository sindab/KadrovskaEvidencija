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
using Kadrovska_sluzba.DB.Models;
using Kadrovska_sluzba.DB.Service;

namespace Kadrovska_sluzba.Sifarnici
{
    public partial class ucTipRadnogOdnosa : DevExpress.XtraEditors.XtraUserControl
    {
        TipRadnogOdnosaService rms;
        public ucTipRadnogOdnosa()
        {
            InitializeComponent();

            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                rms = new TipRadnogOdnosaService();
                LoadData();
            }
        }
        void LoadData()
        {
            IEnumerable<TipRadnogOdnosa> dataSource = GetDataSource();
            gridControl.DataSource = dataSource;
            bsiRecordsCount.Caption = "RECORDS : " + dataSource.ToList().Count;
            gridView.MoveLastVisible();
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }
        public IEnumerable<TipRadnogOdnosa> GetDataSource()
        {
            IEnumerable<TipRadnogOdnosa> result = rms.GetAll();
            return result;
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTipRadnogOdnosaEdit fOE = new frmTipRadnogOdnosaEdit(0);
            fOE.ShowDialog();
            LoadData();
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView.FocusedRowHandle > -1)
            {
                frmTipRadnogOdnosaEdit fOE = new frmTipRadnogOdnosaEdit((int)gridView.GetFocusedRowCellValue(gcID));
                fOE.ShowDialog();
                LoadData();
            }
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView.FocusedRowHandle > -1)
            {
                rms.Delete((int)gridView.GetFocusedRowCellValue(gcID));
                LoadData();
            }
        }
    }
}
