namespace PuntodeVentaTintoreria.ClaseAux
{
    using Microsoft.Reporting.WinForms;
    using System;
    using System.Collections.Generic;
    using System.Drawing.Printing;
    using System.IO;
    using System.Windows.Forms;
    using TintoreriaGlobal;
    using TintoreriaNegocio;

    public class HelperTicketCID
    {
        public static void AbrirCajon()
        {
            try
            {
                PrinterSettings ps = new PrinterSettings();
                ps.PrinterName = string.IsNullOrEmpty(Comun.namePrinter) ? "" : Comun.namePrinter;
                byte[] codigo = new byte[] { 27, 112, 48, 50, 250 };
                if (ps.IsValid)
                    RawPrinterHelper.SendStringToPrinter(ps.PrinterName, System.Text.ASCIIEncoding.ASCII.GetString(codigo));
                else
                    throw new Exception("No se pudo conectar con la impresora.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public static void ImprimirTicket(string idVenta)
        {
            List<TicketDetalle> listaDetalle = new List<TicketDetalle>();
            VentaTintoreriaNegocio oNegocio = new VentaTintoreriaNegocio();
            LocalReport Rtp = new LocalReport();

            //listaDetalle = oNegocio.GetListaTicketDetalles(idVenta);
            TicketDetalle ticket = new TicketDetalle
            {
                Cantidad = 1,
                Descripcion = "Prueba",
                Descuento = 0,
                Impuesto = 1,
                PrecioUnitario = 20,
                Subtotal = 20,
                Total = 21
            };

            for (int i = 0; i < 21; i++)
            {
                listaDetalle.Add(ticket);
            }


            Rtp.EnableExternalImages = true;
            Rtp.DataSources.Clear();
            string path = Path.Combine(Application.StartupPath, @"Formatos\Ticket.rdlc");
            if (System.IO.File.Exists(path))
            {
                Rtp.ReportPath = path;
            }
            else
            {
                new Exception("No se encontro el formato del ticket, contacte a soporte técnico.");
            }

            ReportParameter[] Parametros = new ReportParameter[8];
            Parametros[0] = new ReportParameter("LogoEmpresa", HelperImgCID.IMAGEN_DEFAULT_BASE64);
            Parametros[1] = new ReportParameter("NombreEmpresa", "Empresa S.A de C.V. de S.L.");
            Parametros[2] = new ReportParameter("Direccion", "Palenque 490 col. centenario tuchtlan");
            Parametros[3] = new ReportParameter("RFC", "GAGF900731KFJ");
            Parametros[4] = new ReportParameter("NumTicket", "12320190507000000030");
            Parametros[5] = new ReportParameter("Mensaje1", "Mensaje1");
            Parametros[6] = new ReportParameter("Mensaje2", "Mensaje2");
            Parametros[7] = new ReportParameter("Mensaje3", "Mensaje3");

            Rtp.SetParameters(Parametros);
            Rtp.DataSources.Add(new ReportDataSource("Detalles", listaDetalle));
            Impresor imp = new Impresor();
            imp.Imprime(Rtp);//llamo a la función e creedme imprime de fabula.
        }
    }
}
