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
    public partial class frmVentaLavanderia : Form
    {

        int opciontiempo = 1;
        public frmVentaLavanderia()
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

        private void btnTRopa01_Click(object sender, EventArgs e)
        {
            /*
            frmSelSubTipoPrenda frmst = new frmSelSubTipoPrenda();
           if (frmst.ShowDialog() == DialogResult.OK)
            {
                


                

                frmSelDatosPrenda frmdp = new frmSelDatosPrenda();
                frmdp.ShowDialog();
                frmdp.Dispose();

                


            }

            frmst.Dispose();*/
        }

        //private void MostrarOpcion()
        //{
        //    DateTime fecha = DateTime.Now;
        //    DateTime fechaEntrega = fecha;
        //    if (opciontiempo == 1)
        //    {
        //        txtEntrega.Text = "NORMAL";
        //        txtHorasEntrega.Text = "24 hrs";

        //        fechaEntrega=fecha.AddHours(24);
                
        //    }
        //    else
        //    if (opciontiempo == 2)
        //    {
        //        txtEntrega.Text = "URGENTE";
        //        txtHorasEntrega.Text = "12 hrs";
        //        fechaEntrega = fecha.AddHours(12);
        //    }
        //    else
        //    if (opciontiempo == 3)
        //    {
        //        txtEntrega.Text = "EXTRA URGENTE";
        //        txtHorasEntrega.Text = "8 hrs";
        //        fechaEntrega = fecha.AddHours(8);
        //    }

        //    txtFechaEntrega.Text = fechaEntrega.ToShortDateString();
        //    txtHoraEntrega.Text = fechaEntrega.ToShortTimeString();
        //}
        private void button27_Click(object sender, EventArgs e)
        {

            if (opciontiempo > 1) opciontiempo--;
            //MostrarOpcion();

        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (opciontiempo < 3) opciontiempo++;
            //MostrarOpcion();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
       /*     frmSelDatosPrenda frmst = new frmSelDatosPrenda();
            if (frmst.ShowDialog() == DialogResult.OK)
            {


                frmSelDatosPrenda frmdp = new frmSelDatosPrenda();
                frmdp.ShowDialog();
                frmdp.Dispose();


            }

            frmst.Dispose();*/

        }

        private void btnKilos_Click(object sender, EventArgs e)
        {
            try
            {
                frmKilogramos fk = new frmKilogramos();
                fk.ShowDialog();
                fk.Dispose();
            }
            catch (Exception)
            {

                
            }
        }
    }
}
