using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntodeVentaTintoreria
{
    public partial class frmBuscarTicket : Form
    {
        public frmBuscarTicket()
        {
            InitializeComponent();
        }
        
        private void PanelTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(Cursor.Position.X + e.X, Cursor.Position.Y + e.Y);
            }
        }

        protected virtual void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        protected virtual void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void button29_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
