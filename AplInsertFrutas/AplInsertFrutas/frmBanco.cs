using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplInsertFrutas
{
    public partial class frmBanco : Form
    {
        public frmBanco()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            string User = txtUser.Text.Trim(), Pass = txtPass.Text.Trim();
            frmInserirFruta form = new frmInserirFruta(User, Pass);
            form.Show();
            Hide();
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                btnConectar_Click(sender, e);
            }
        }
    }
}
