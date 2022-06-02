using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TintoreriaGlobal;
using TintoreriaNegocio;
using System.Data;
using System.Net;
using System.Windows.Forms;
using System.Configuration;
using System.Net.Mime;
using System.Net.Mail;

namespace PuntodeVentaTintoreria.ClasesAux
{
    public class EnvioCorreo
    {
        public static bool EnviarCorreo(string De, string Contraseña, string Para, string Asunto, string Mensaje, bool banArchivo, string Archivo, bool Html, string Host, int Port, bool Ssl, DataTable dt = null)
        {
            try
            {

                //GMAIL
                //Habilitar las siguientes opciones en correo de gmail
                //https://www.google.com/settings/security/lesssecureapps
                //https://accounts.google.com/DisplayUnlockCaptcha
                //HOTMAIL
                //Enviara las primeras veces despues nos llegara un correo para reconocer el inicio de sesion 
                //ya que depende del servidor donde esta alojado y se tiene que reconocer el inicio de sesion   
                //Para = "lackke.141727@gmail.com";
                System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                mailMessage.From = new System.Net.Mail.MailAddress(De);
                mailMessage.To.Add(Para);
                mailMessage.Subject = Asunto;
                if (banArchivo)
                    mailMessage.Attachments.Add(new System.Net.Mail.Attachment(Archivo));
                //mailMessage.Body = Mensaje;
                mailMessage.IsBodyHtml = Html;
                System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient(Host);
                smtpClient.Port = Port;
                smtpClient.EnableSsl = Ssl;
                smtpClient.Credentials = new NetworkCredential(De, Contraseña);

                if(dt != null)
                {
                    AlternateView alternativeView = AlternateView.CreateAlternateViewFromString(Mensaje, null, MediaTypeNames.Text.Html);
                    int i = 0;
                    foreach (DataRow aux in dt.Rows)
                    {
                        
                        Byte[] bitmapData = Convert.FromBase64String(FixBase64ForImage(aux["imagen"].ToString()));
                        System.IO.MemoryStream streamBitmap = new System.IO.MemoryStream(bitmapData);

                        var imageToInline = new LinkedResource(streamBitmap, MediaTypeNames.Image.Jpeg);
                        imageToInline.ContentId = i.ToString();

                        alternativeView.LinkedResources.Add(imageToInline);
                        i++;
                    }
                    mailMessage.AlternateViews.Add(alternativeView);
                }

                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(new Form() { TopMost = true },ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static string FixBase64ForImage(string Image)
        {
            System.Text.StringBuilder sbText = new System.Text.StringBuilder(Image, Image.Length);
            sbText.Replace("\r\n", string.Empty); sbText.Replace(" ", string.Empty);
            return sbText.ToString();
        }

        public static string GenerarHtmlCompras(string razonSocial, string rfc, string direccion, DataTable lstProductos)
        {
            try
            {
                string dominio = ConfigurationManager.AppSettings.Get("ServerTxt");
                string html = "";
                html = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Strict//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"">
   <head>
      <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
      <meta name=""viewport"" content=""width=device-width, initial-scale=1.0""/>
      <title></title>
      <style type=""text/css"">
         /* Client-specific Styles */
         #outlook a {padding:0;} /* Force Outlook to provide a ""view in browser"" menu link. */
         body{width:100% !important; -webkit-text-size-adjust:100%; -ms-text-size-adjust:100%; margin:0; padding:0;}
         /* Prevent Webkit and Windows Mobile platforms from changing default font sizes, while not breaking desktop design. */
         .ExternalClass {width:100%;} /* Force Hotmail to display emails at full width */
         .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div {line-height: 100%;} /* Force Hotmail to display normal line spacing. */
         #backgroundTable {margin:0; padding:0; width:100% !important; line-height: 100% !important;}
         img {outline:none; text-decoration:none;border:none; -ms-interpolation-mode: bicubic;}
         a img {border:none;}
         .image_fix {display:block;}
         p {margin: 0px 0px !important;}
         table td {border-collapse: collapse;}
         table { border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt; }
         a {color: #33b9ff;text-decoration: none;text-decoration:none!important;}
         /*STYLES*/
         table[class=full] { width: 100%; clear: both; }
         /*IPAD STYLES*/
         @media only screen and (max-width: 640px) {
         a[href^=""tel""], a[href^=""sms""] {
         text-decoration: none;
         color: #0a8cce; /* or whatever your want */
         pointer-events: none;
         cursor: default;
         }
         .mobile_link a[href^=""tel""], .mobile_link a[href^=""sms""] {
         text-decoration: default;
         color: #0a8cce !important;
         pointer-events: auto;
         cursor: default;
         }
         table[class=devicewidth] {width: 440px!important;text-align:center!important;}
         table[class=devicewidthmob] {width: 420px!important;text-align:center!important;}
         table[class=devicewidthinner] {width: 420px!important;text-align:center!important;}
         img[class=banner] {width: 440px!important;height:157px!important;}
         img[class=col2img] {width: 440px!important;height:330px!important;}
         table[class=""cols3inner""] {width: 100px!important;}
         table[class=""col3img""] {width: 131px!important;}
         img[class=""col3img""] {width: 131px!important;height: 82px!important;}
         table[class='removeMobile']{width:10px!important;}
         img[class=""blog""] {width: 420px!important;height: 162px!important;}
         }
         /*IPHONE STYLES*/
         @media only screen and (max-width: 480px) {
         a[href^=""tel""], a[href^=""sms""] {
         text-decoration: none;
         color: #0a8cce; /* or whatever your want */
         pointer-events: none;
         cursor: default;
         }
         .mobile_link a[href^=""tel""], .mobile_link a[href^=""sms""] {
         text-decoration: default;
         color: #0a8cce !important; 
         pointer-events: auto;
         cursor: default;
         }
         table[class=devicewidth] {width: 280px!important;text-align:center!important;}
         table[class=devicewidthmob] {width: 260px!important;text-align:center!important;}
         table[class=devicewidthinner] {width: 260px!important;text-align:center!important;}
         img[class=banner] {width: 280px!important;height:100px!important;}
         img[class=col2img] {width: 280px!important;height:210px!important;}
         table[class=""cols3inner""] {width: 260px!important;}
         img[class=""col3img""] {width: 280px!important;height: 175px!important;}
         table[class=""col3img""] {width: 280px!important;}
         img[class=""blog""] {width: 260px!important;height: 100px!important;}
         td[class=""padding-top-right15""]{padding:15px 15px 0 0 !important;}
         td[class=""padding-right15""]{padding-right:15px !important;}
         }
      </style>
   </head>
   <body>
<table width=""100%"" bgcolor=""#d8d8d8"" cellpadding=""0"" cellspacing=""0"" border=""0"" id=""backgroundTable"" st-sortable=""footer"">
   <tbody>
      <tr>
         <td>
            <table width=""560"" cellpadding=""0"" cellspacing=""0"" border=""0"" align=""center"" class=""devicewidth"">
               <tbody>
                  <tr>
                     <td width=""100%"">
                        <table bgcolor=""#303030"" width=""560"" cellpadding=""0"" cellspacing=""0"" border=""0"" align=""center"" class=""devicewidth"">
                           <tbody>
                              <tr>
                                 <td height=""10"" style=""font-size:1px; line-height:1px; mso-line-height-rule: exactly;"">&nbsp;</td>
                              </tr>
                              <tr>
                                 <td>
                                    <table width=""194"" align=""left"" border=""0"" cellpadding=""0"" cellspacing=""0"">
                                       <tbody>
                                          <tr>
                                             <td width=""20""></td>
                                             <td width=""174"" height=""40"" align=""left"">
                                                <div class=""imgpop"">
                                                   <a target=""_blank"" href=""#"">                                                                     
                                                        <h1>" + razonSocial + @"</h1> 
                                                   </a>
                                                </div>
                                             </td>
                                          </tr>
                                       </tbody>
                                    </table>
                                 </td>
                              </tr>
                              <tr>
                                 <td height=""10"" style=""font-size:1px; line-height:1px; mso-line-height-rule: exactly;"">&nbsp;</td>
                              </tr>
                           </tbody>
                        </table>
                     </td>
                  </tr>
               </tbody>
            </table>
         </td>
      </tr>
   </tbody>
</table>
<table width=""100%"" bgcolor=""#d8d8d8"" cellpadding=""0"" cellspacing=""0"" border=""0"" id=""backgroundTable"" st-sortable=""left-image"">
   <tbody>
      <tr>
         <td>
            <table width=""560"" cellpadding=""0"" cellspacing=""0"" border=""0"" align=""center"" class=""devicewidth"">
               <tbody>
                  <tr>
                     <td width=""100%"">
                        <table bgcolor=""#ffffff"" width=""560"" cellpadding=""0"" cellspacing=""0"" border=""0"" align=""center"" class=""devicewidth"">
                           <tbody>
                              <tr>
                                 <td height=""20"" style=""font-size:1px; line-height:1px; mso-line-height-rule: exactly;"">&nbsp;</td>
                              </tr>
                              <tr>
                                 <td>
                                    <table width=""520"" cellpadding=""0"" cellspacing=""0"" border=""0"" align=""center"" class=""devicewidthinner"">
                                       <tbody>
                                          <tr>
                                             <td style=""font-family: Helvetica, arial, sans-serif; font-size: 18px; color: #2d2a26; text-align:left; line-height: 24px;"">
                                                " + rfc + @" 
                                             </td>
                                          </tr>
                                          <tr>
                                             <td width=""100%"" height=""15"" style=""font-size:1px; line-height:1px; mso-line-height-rule: exactly;"">&nbsp;</td>
                                          </tr>
                                          <tr>
                                             <td style=""font-family: Helvetica, arial, sans-serif; font-size: 14px; color: #7a6e67; text-align:left; line-height: 24px;"">
                                               " + direccion + @"
                                             </td>
                                          </tr>
                                       </tbody>
                                    </table>
                                 </td>
                              </tr>
                              <tr>
                                 <td height=""20"" style=""font-size:1px; line-height:1px; mso-line-height-rule: exactly;"">&nbsp;</td>
                              </tr>
                              <tr>
                                 <td height=""5"" bgcolor=""#2d2a26"" style=""font-size:1px; line-height:1px; mso-line-height-rule: exactly;"">&nbsp;</td>
                              </tr>
                           </tbody>
                        </table>
                     </td>
                  </tr>
               </tbody>
            </table>
         </td>
      </tr>
   </tbody>
</table>

<table width=""100%"" bgcolor=""#dbdbdb"" cellpadding=""0"" cellspacing=""0"" border=""0"" id=""backgroundTable"" st-sortable=""preheader"" >
   <tbody>
      <tr>
         <td>
            <table width=""560"" cellpadding=""0"" cellspacing=""0"" border=""0"" align=""center"" class=""devicewidth"">
               <tbody>
                  <tr>
                     <td width=""100%"">
                        <table bgcolor=""#ffffff"" width=""560"" cellpadding=""0"" cellspacing=""0"" border=""0"" align=""center"" class=""devicewidth"">
                           <tbody>
                              <tr>
                                 <td width=""100%"" height=""10""></td>
                              </tr>
                              <tr>
                                 <td align=""center"" valign=""middle"" style=""font-family: Helvetica, arial, sans-serif; font-size: 13px;color: #7a6e67;text-align:center;"" st-content=""viewonline"">
                                    Lista de pedidos:                                     
                                 </td>
                              </tr>
                              <tr>
                                 <td width=""100%"" height=""10""></td>
                              </tr>
                           </tbody>
                        </table>
                     </td>
                  </tr>
               </tbody>
            </table>
         </td>
      </tr>
   </tbody>
</table>";

if (lstProductos != null)
{
    int i = 0;
    foreach (DataRow aux in lstProductos.Rows)
    {
                      
        html = html + @"<table width=""100%"" bgcolor=""#d8d8d8"" cellpadding=""0"" cellspacing=""0"" border=""0"" id=""backgroundTable"" st-sortable=""left-image"">
       <tbody>
          <tr>
             <td>
                <table width=""560"" cellpadding=""0"" cellspacing=""0"" border=""0"" align=""center"" class=""devicewidth"">
                   <tbody>
                      <tr>
                         <td width=""100%"">
                            <table bgcolor=""#ffffff"" width=""560"" cellpadding=""0"" cellspacing=""0"" border=""0"" align=""center"" class=""devicewidth"">
                               <tbody>
                                  <tr>
                                     <td height=""20"" style=""font-size:1px; line-height:1px; mso-line-height-rule: exactly;"">&nbsp;</td>
                                  </tr>
                                  <tr>
                                     <td>
                                        <table width=""520"" cellpadding=""0"" cellspacing=""0"" border=""0"" align=""center"" class=""devicewidth"">
                                           <tbody>
                                              <tr>
                                                 <td>
                                                    <table width=""200"" align=""left"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""devicewidth"">
                                                       <tbody>
                                                          <tr>
                                                             <td width=""200"" height=""150"" align=""center"" class=""devicewidth"">
                                                                <img src=""cid:" + i.ToString() +@""" alt="""" border=""0"" width=""200"" height=""150"" style=""display:block; border:none; outline:none; text-decoration:none;"" class=""col2img"">
                                                             </td>
                                                          </tr>
                                                       </tbody>
                                                    </table>
                                                    <table align=""left"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""mobilespacing"">
                                                       <tbody>
                                                          <tr>
                                                             <td width=""100%"" height=""15"" style=""font-size:1px; line-height:1px; mso-line-height-rule: exactly;"">&nbsp;</td>
                                                          </tr>
                                                       </tbody>
                                                    </table>
                                                    <table width=""300"" align=""right"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""devicewidthmob"">
                                                       <tbody>
                                                          <tr>
                                                             <td style=""font-family: Helvetica, arial, sans-serif; font-size: 18px; color: #2d2a26; text-align:left; line-height: 24px;"" class=""padding-top-right15"">
                                                                <p>" + (aux["nombreProductoFinal"].ToString() != "" ? "Nombre Producto: " + aux["nombreProductoFinal"].ToString(): ""  ) + @"</p>
                                                                <p>" + (aux["cantidadFinal"].ToString() != "" ? "Cantidad: " + aux["cantidadFinal"].ToString() : "") + @"</p>
                                                                <p>" + (aux["txtUnidadMedidaFinal"].ToString() != "" ? "Presentación: " + aux["txtUnidadMedidaFinal"].ToString() : "") + @"</p>
                                                             </td>
                                                          </tr>
                                                          <tr>
                                                             <td width=""100%"" height=""15"" style=""font-size:1px; line-height:1px; mso-line-height-rule: exactly;"">&nbsp;</td>
                                                          </tr>
                                                       </tbody>
                                                    </table>
                                                 </td>
                                              </tr>
                                           </tbody>
                                        </table>
                                     </td>
                                  </tr>
                                  <tr>
                                     <td height=""20"" style=""font-size:1px; line-height:1px; mso-line-height-rule: exactly;"">&nbsp;</td>
                                  </tr>
                                  <tr>
                                     <td height=""5"" bgcolor=""#2d2a26"" style=""font-size:1px; line-height:1px; mso-line-height-rule: exactly;"">&nbsp;</td>
                                  </tr>
                               </tbody>
                            </table>
                         </td>
                      </tr>
                   </tbody>
                </table>
             </td>
          </tr>
       </tbody>
    </table>";
    i++;
  }
}

html = html + @"<table width=""100%"" bgcolor=""#d8d8d8"" cellpadding=""0"" cellspacing=""0"" border=""0"" id=""backgroundTable"" st-sortable=""footer"">
   <tbody>
      <tr>
         <td>
            <table width=""560"" cellpadding=""0"" cellspacing=""0"" border=""0"" align=""center"" class=""devicewidth"">
               <tbody>
                  <tr>
                     <td width=""100%"">
                        <table bgcolor=""#303030"" width=""560"" cellpadding=""0"" cellspacing=""0"" border=""0"" align=""center"" class=""devicewidth"">
                           <tbody>
                              <tr>
                                 <td height=""10"" style=""font-size:1px; line-height:1px; mso-line-height-rule: exactly;"">&nbsp;</td>
                              </tr>
                              <tr>
                                 <td>
                                    <table width=""194"" align=""right"" border=""0"" cellpadding=""0"" cellspacing=""0"">
                                       <tbody>
                                          <tr>
                                             <td width=""20""></td>
                                             <td width=""174"" height=""40"" align=""left"">
                                                <div class=""imgpop"">
                                                   <h2></h2>
                                                </div>
                                             </td>
                                          </tr>
                                       </tbody>
                                    </table>
                                 </td>
                              </tr>
                              <tr>
                                 <td height=""10"" style=""font-size:1px; line-height:1px; mso-line-height-rule: exactly;"">&nbsp;</td>
                              </tr>
                           </tbody>
                        </table>
                     </td>
                  </tr>
               </tbody>
            </table>
         </td>
      </tr>
   </tbody>
</table>
</body>
</html>";
                return html;
            }
            catch (Exception ex)
            {
                return "";
            }
        }        
    }
}
