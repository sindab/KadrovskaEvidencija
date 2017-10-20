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
using DevExpress.XtraScheduler;
using Kadrovska_sluzba.DB;

namespace Kadrovska_sluzba
{
    public partial class ucNotifikacije : DevExpress.XtraEditors.XtraUserControl
    {
        public ucNotifikacije()
        {
            InitializeComponent();
        }

        private void frmNotifikacije_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                resourcesTableAdapter.Connection = new System.Data.SqlClient.SqlConnection(DbConnection.ConnectionString());
                appointmentsTableAdapter.Connection = new System.Data.SqlClient.SqlConnection(DbConnection.ConnectionString());
                //LoadData();
                schedulerControl1.Start = System.DateTime.Now;
            }
        }

        private void LoadData()
        {

            // TODO: This line of code loads data into the 'schedulerTestDataSet.Resources' table. You can move, or remove it, as needed.
            this.resourcesTableAdapter.Fill(this.kadrovskaDataSet.Resources);
            // TODO: This line of code loads data into the 'schedulerTestDataSet.Appointments' table. You can move, or remove it, as needed.
            this.appointmentsTableAdapter.Fill(this.kadrovskaDataSet.Appointments);
        }

        private void schedulerStorage1_AppointmentsChanged(object sender, PersistentObjectsEventArgs e)
        {
            appointmentsTableAdapter.Update(kadrovskaDataSet);
            kadrovskaDataSet.AcceptChanges();
        }

        private void ucNotifikacije_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.DesignMode)
                LoadData();
        }
    }
}