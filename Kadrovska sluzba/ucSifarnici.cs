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

namespace Kadrovska_sluzba
{
    public partial class ucSifarnici : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSifarnici()
        {
            InitializeComponent();
        }
        void navBarControl_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            navigationFrame.SelectedPageIndex = navBarControl.Groups.IndexOf(e.Group);
        }
        //void barButtonNavigation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    int barItemIndex = barSubItemNavigation.ItemLinks.IndexOf(e.Link);
        //    navBarControl.ActiveGroup = navBarControl.Groups[barItemIndex];
        //}
    }
}
