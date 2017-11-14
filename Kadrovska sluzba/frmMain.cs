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
using DevExpress.LookAndFeel;

namespace Kadrovska_sluzba
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            //Helpers.RegionalSettings.SetRegionalSettings();
            InitializeComponent();
            UserLookAndFeel.Default.SkinName = Properties.Settings.Default["ApplicationSkinName"].ToString();
        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default["ApplicationSkinName"] = UserLookAndFeel.Default.SkinName;
            Properties.Settings.Default.Save();
            Application.Exit();
        }

        //private void LoadTheme()
        //{
        //    string themeName = Properties.Settings.Default["ThemeName"] as string;
        //    ThemeManager.ApplicationThemeName = themeName;
        //    comboBoxEdit1.EditValue = Theme.FindTheme(themeName);
        //}

        //private void SaveTheme()
        //{
        //    Properties.Settings.Default["ThemeName"] = ThemeManager.ApplicationThemeName;
        //    Properties.Settings.Default.Save();
        //}


        void navBarControl_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            navigationFrame.SelectedPageIndex = navBarControl.Groups.IndexOf(e.Group);
        }
        void barButtonNavigation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
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
            // ucRadnik ucRadnik1 = new ucRadnik();
            //// 
            //// ucRadnik1
            //// 
            //ucRadnik1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            //ucRadnik1.Dock = System.Windows.Forms.DockStyle.Fill;
            //ucRadnik1.Location = new System.Drawing.Point(0, 0);
            //ucRadnik1.Name = "ucRadnik1";
            ////ucRadnik1.Radnik = null;
            ucRadnik1.Radnik = myArgs.Radnik;
            //ucRadnik1.Size = new System.Drawing.Size(756, 380);
            //ucRadnik1.TabIndex = 2;
            //employeeNavigationPage.Controls.Add(ucRadnik1);
            navBarControl.ActiveGroup = navBarControl.Groups[1];
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //sifarnici
            navBarControl.ActiveGroup = navBarControl.Groups[2];
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            navBarControl.ActiveGroup = navBarControl.Groups[3];
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            navBarControl.ActiveGroup = navBarControl.Groups[4];
        }
    }
}