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
    public partial class ucStrucnaSprema : DevExpress.XtraEditors.XtraUserControl
    {
        StrucnaSpremaService ss;
        public ucStrucnaSprema()
        {
            InitializeComponent();

            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                ss = new StrucnaSpremaService();
                LoadData();
            }
        }
        void LoadData()
        {
            IEnumerable<StrucnaSprema> dataSource = GetDataSource();
            gridControl.DataSource = dataSource;
            bsiRecordsCount.Caption = "RECORDS : " + dataSource.ToList().Count;
            gridView.MoveLastVisible();
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }
        public IEnumerable<StrucnaSprema> GetDataSource()
        {
            IEnumerable<StrucnaSprema> result = ss.GetAll();
            return result;
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmStrucnaSpremaEdit fOE = new frmStrucnaSpremaEdit(0);
            fOE.ShowDialog();
            LoadData();
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView.FocusedRowHandle > -1)
            {
                frmStrucnaSpremaEdit fOE = new frmStrucnaSpremaEdit((int)gridView.GetFocusedRowCellValue(gcID));
                fOE.ShowDialog();
                LoadData();
            }
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView.FocusedRowHandle > -1)
            {
                ss.Delete((int)gridView.GetFocusedRowCellValue(gcID));
                LoadData();
            }
        }
    }
}
