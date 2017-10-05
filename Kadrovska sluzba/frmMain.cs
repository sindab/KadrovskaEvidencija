using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Kadrovska_sluzba
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        void navBarControl_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            //ucRadnik1.Radnik = ucRadnici1.TrenutniRadnik;
            navigationFrame.SelectedPageIndex = navBarControl.Groups.IndexOf(e.Group);
        }
        void barButtonNavigation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ucRadnik1.Radnik = ucRadnici1.TrenutniRadnik;
            int barItemIndex = barSubItemNavigation.ItemLinks.IndexOf(e.Link);
            navBarControl.ActiveGroup = navBarControl.Groups[barItemIndex];
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //radnici
            navBarControl.ActiveGroup = navBarControl.Groups[0];
        }

        private void ucRadnici1_IzmjenaRadnika(object myObject, ucRadnici.RadnikArgs myArgs)
        {
            //radnik
            ucRadnik1.Radnik = myArgs.Radnik;
            navBarControl.ActiveGroup = navBarControl.Groups[1];
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //sifarnici
            navBarControl.ActiveGroup = navBarControl.Groups[2];
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //PodsjetiMe();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //PodsjetiMe();
        }

        private void PodsjetiMe()
        {
            //DevExpress.XtraBars.Alerter.AlertInfo a = new DevExpress.XtraBars.Alerter.AlertInfo("Podsjetnik", "Imate sastanak!");
            //a.HotTrackedText = "VAZAN SASTANAK";
            //alertControl1.Show(this, a);
        }

        private void alertControl1_ButtonClick(object sender, DevExpress.XtraBars.Alerter.AlertButtonClickEventArgs e)
        {
           if (e.ButtonName == "Open")
            {
                ////TEST
                //frmLogin fl = new frmLogin();
                //fl.Show();
            }
        }
        
    }
}