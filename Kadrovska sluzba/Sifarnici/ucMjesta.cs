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
    public partial class ucMjesta : DevExpress.XtraEditors.XtraUserControl
    {
        MjestoService ms;
        public ucMjesta()
        {
            InitializeComponent();

            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                OpstinaService os = new OpstinaService();
                lkpOpstine.DataSource = os.GetAll();
                ms = new MjestoService();
                LoadData();
            }
        }
        void LoadData()
        {
            IEnumerable<Mjesto> dataSource = GetDataSource();
            gridControl.DataSource = dataSource;
            bsiRecordsCount.Caption = "RECORDS : " + dataSource.ToList().Count;
            gridView.MoveLastVisible();
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }
        public IEnumerable<Mjesto> GetDataSource()
        {
            IEnumerable<Mjesto> result = ms.GetAll();
            return result;
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmMjestoEdit fOE = new frmMjestoEdit(0);
            fOE.ShowDialog();
            LoadData();
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView.FocusedRowHandle > -1)
            {
                frmMjestoEdit fOE = new frmMjestoEdit((int)gridView.GetFocusedRowCellValue(gcID));
                fOE.ShowDialog();
                LoadData();
            }
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView.FocusedRowHandle > -1)
            {
                ms.Delete((int)gridView.GetFocusedRowCellValue(gcID));
                LoadData();
            }
        }
    }
}
