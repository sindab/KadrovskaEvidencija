using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Kadrovska_sluzba.DB.Service;
using Kadrovska_sluzba.DB.Models;
using System.Collections.Generic;

namespace Kadrovska_sluzba.Reports
{
    public partial class rptGodisnjiOdmori : DevExpress.XtraReports.UI.XtraReport
    {
        public rptGodisnjiOdmori()
        {
            InitializeComponent();
            RadnikGOService rs = new RadnikGOService();
            IEnumerable<vRadnikGO> ds = rs.GetVByGodina(DateTime.Today.Year);
            this.DataSource = ds;
        }

    }
}
