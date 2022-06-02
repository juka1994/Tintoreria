using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TintoreriaGlobal;

namespace PuntodeVentaTintoreria
{
    public class Validaciones
    {
        public void SoloTexto(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == ',')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '´')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == ' ')
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        public void SoloAlfaNumerico(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == ',')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == ' ')
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        public void SoloDecimal(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show( "Este campo solo admite numeros","Sistema punto de venta Tintoreria ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void PermitirSoloNumerosDecimales(KeyPressEventArgs e, string cadena)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    if (e.KeyChar == (char)'.')
                    {
                        if (cadena.IndexOf('.') == -1)
                            e.Handled = false;
                        else
                            e.Handled = true;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
        }
        public void TextoNumerosPuntoGuionTilde(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == ',')
            {
                e.Handled = false;
            }
            else if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '_')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '´')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '@')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '#')
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        public void SoloNumerico(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        public void NumeroTelefono(KeyPressEventArgs e)
        {
            string validar = "-0123456789";

            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (!(validar.IndexOf(e.KeyChar) >= 0))
            {
                e.Handled = true;
            }
        }
        public bool ValidarCorreoElectronico(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        static bool invalid = false;
        public bool IsValidEmails(string strIn)
        {
            invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(strIn, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        public string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();
            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }
        public void Mensaje(string msj, Form fm)
        {
            DialogResult ds;
            ds = MessageBox.Show(fm, msj, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public bool validarCheckGridViewOne(DataGridView Datos, string NameChecked)
        {
            foreach (DataGridViewRow Aux in Datos.Rows)
            {
                if (Convert.ToBoolean(Aux.Cells[NameChecked].Value) == true)
                    return true;
            }
            return false;
        }
        public bool validarCodigoEAN13(string codigo)
        {
            try
            {
                return BarCodeEan13.Ean13.CheckCode(codigo);
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool IsValidMail(string Mail)
        {
            try
            {
                string pattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
            + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
            + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";
                return IsValid(pattern, Mail);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private static bool IsValid(string pattern, string value)
        {
            try
            {
                return Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool IsValidOnlyNumber(string Number)
        {
            try
            {
                string pattern = @"^\d+$";
                return IsValid(pattern, Number);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool ValidarIFE(string cadena)
        {
            try
            {

                return Regex.IsMatch(cadena,
                         @"^\d{13}$",
                        RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool ValidarTarjetaCreditoDebito(string cadena)
        {
            try
            {
                return Regex.IsMatch(cadena,
                         @"^\d{16}$",
                        RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool ValidarCedulaProfesional(string cadena)
        {
            try
            {

                return Regex.IsMatch(cadena,
                       @"^\d{7}$",
                        RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ValidarLicenciaConducir(string cadena)
        {
            try
            {
                return Regex.IsMatch(cadena,
                      @"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9]*$",
                        RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ValidarPasaporte(string cadena)
        {
            try
            {
                return Regex.IsMatch(cadena,
                      @"^[A-Za-z]{1}\d{9}$",
                        RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ValidarTarjetaCliente(string cadena)
        {
            try
            {
                return this.validarCodigoEAN13(cadena);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool validarDireccionMAC(string MAC)
        {
            try
            {
                String expresion;
                expresion = "^([0-9a-fA-F][0-9a-fA-F]:){5}([0-9a-fA-F][0-9a-fA-F])$";
                if (Regex.IsMatch(MAC, expresion))
                {
                    if (Regex.Replace(MAC, expresion, String.Empty).Length == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
