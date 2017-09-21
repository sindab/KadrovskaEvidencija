using Kadrovska_sluzba.DB;
using Kadrovska_sluzba.DB.Models;
using Kadrovska_sluzba.DB.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kadrovska_sluzba
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        List<Radnik> user;
        public frmLogin()
        {
            InitializeComponent();
        }

       private void frmLogin_Load(object sender, EventArgs e)
        {
            RadnikService rs = new RadnikService();
            user = rs.GetUsers();
            lkpUser.Properties.DataSource = user;
            lkpUser.EditValue = user.FirstOrDefault().ID;
            textEdit1.SelectAll();
            textEdit1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login();
        }
         private void textEdit1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Login();
            }
        }
      
        private void Login()
        {
            // provjeri User login
            if (user.Find(x => x.ID == (int)lkpUser.EditValue).Lozinka == textEdit1.Text)
            {
                this.Hide();
                frmMain fM = new frmMain();
                fM.Show();

            }
            else
            {
                textEdit1.SelectAll();
                textEdit1.Focus();
            }
        }

    }
}
