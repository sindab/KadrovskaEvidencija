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
            // TODO: This line of code loads data into the 'schedulerTestDataSet.Resources' table. You can move, or remove it, as needed.
            this.resourcesTableAdapter.Fill(this.kadrovskaDataSet.Resources);
            // TODO: This line of code loads data into the 'schedulerTestDataSet.Appointments' table. You can move, or remove it, as needed.
            this.appointmentsTableAdapter.Fill(this.kadrovskaDataSet.Appointments);
            schedulerControl1.Start = System.DateTime.Now;
        }

        private void schedulerStorage1_AppointmentsChanged(object sender, PersistentObjectsEventArgs e)
        {
            appointmentsTableAdapter.Update(kadrovskaDataSet);
            kadrovskaDataSet.AcceptChanges();
        }
    }
}