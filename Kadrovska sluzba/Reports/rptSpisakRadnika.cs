﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using Kadrovska_sluzba.DB.Models;
using Kadrovska_sluzba.DB.Service;

namespace Kadrovska_sluzba.Reports
{
    public partial class rptSpisakRadnika : DevExpress.XtraReports.UI.XtraReport
    {
        public rptSpisakRadnika()
        {
            InitializeComponent();

            RadnikService rs = new RadnikService();
            IEnumerable<vRadnik> ds = rs.GetAllV();
            this.DataSource = ds;
        }

    }
}
