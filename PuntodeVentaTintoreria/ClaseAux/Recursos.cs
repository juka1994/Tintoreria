using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntodeVentaTintoreria
{
    public static class Recursos
    {
        public static Image ResizeImage2(Image srcImage, int newWidth, int newHeight)
        {
            try
            {
                int Width = srcImage.Width;
                int Heigth = srcImage.Height;
                decimal Porc = (newWidth * 100) / Width;
                newHeight = (int)(Heigth * (Porc / 100));
                Bitmap imagen = new Bitmap(srcImage);
                Bitmap nuevaImagen = new Bitmap(newWidth, newHeight);
                nuevaImagen.SetResolution(srcImage.HorizontalResolution, srcImage.VerticalResolution);
                Graphics gr = Graphics.FromImage(nuevaImagen);
                //DIBUJAMOS LA NUEVA IMAGEN
                gr.DrawImage(imagen, 0, 0, nuevaImagen.Width, nuevaImagen.Height);
                //LIBERAMOS RECURSOS
                gr.Dispose();
                return nuevaImagen;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static Image ResizeImage(Image srcImage, int newWidth, int newHeight, ImageFormat Formato)
        {
            try
            {
                       
                using (Bitmap imagenBitmap =
                   new Bitmap(newWidth, newHeight, PixelFormat.Format32bppRgb))
                {
                    imagenBitmap.SetResolution(
                       Convert.ToInt32(srcImage.HorizontalResolution),
                       Convert.ToInt32(srcImage.HorizontalResolution));

                    using (Graphics imagenGraphics =
                            Graphics.FromImage(imagenBitmap))
                    {
                        imagenGraphics.SmoothingMode =
                           SmoothingMode.AntiAlias;
                        imagenGraphics.InterpolationMode =
                           InterpolationMode.HighQualityBicubic;
                        imagenGraphics.PixelOffsetMode =
                           PixelOffsetMode.HighQuality;
                        imagenGraphics.DrawImage(srcImage,
                           new Rectangle(0, 0, newWidth, newHeight),
                           new Rectangle(0, 0, srcImage.Width, srcImage.Height),
                           GraphicsUnit.Pixel);
                        MemoryStream imagenMemoryStream = new MemoryStream();
                        imagenBitmap.Save(imagenMemoryStream, Formato);
                        srcImage = System.Drawing.Image.FromStream(imagenMemoryStream);
                    }
                }
                return srcImage;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static Image ResizeImageProp(Image srcImage, int newWidth, int newHeight, ImageFormat Formato)
        {
            try
            {
                float newWidth2=0;
                float newHeight2=0;
                if (srcImage.Height > newHeight || srcImage.Width > newWidth)
                {
                   
                    if (srcImage.Height==srcImage.Width)
                    {
                        newWidth2 = newWidth;
                        newHeight2 = newWidth;
                    }
                    else
                    {
                        if (srcImage.Height>srcImage.Width)
                        {
                            newHeight2 = newHeight;
                            int temAlto = srcImage.Height;
                            int temAncho = srcImage.Width;
                            newWidth2 = temAncho / temAlto;
                            newWidth2 = newWidth2 * newHeight;

                        }
                        else
                        {
                            newWidth2 = newWidth;
                            int temAlto = srcImage.Height;
                            int temAncho = srcImage.Width;
                            newHeight2 = (float)temAlto / (float)temAncho;
                            newHeight2 = newHeight2 * newWidth;
                        }
                    }
                }
                else
                {
                    newHeight2 = srcImage.Height;
                    newWidth2 = srcImage.Width;
                }
                int nuevoAncho = (int)newWidth2;
                int nuevoAlto = (int)newHeight2;

                using (Bitmap imagenBitmap =
                   new Bitmap(newWidth, newHeight, PixelFormat.Format32bppRgb))
                {
                    imagenBitmap.SetResolution(
                       Convert.ToInt32(srcImage.HorizontalResolution),
                       Convert.ToInt32(srcImage.HorizontalResolution));

                    using (Graphics imagenGraphics =
                            Graphics.FromImage(imagenBitmap))
                    {
                        imagenGraphics.SmoothingMode =
                           SmoothingMode.AntiAlias;
                        imagenGraphics.InterpolationMode =
                           InterpolationMode.HighQualityBicubic;
                        imagenGraphics.PixelOffsetMode =
                           PixelOffsetMode.HighQuality;
                        imagenGraphics.DrawImage(srcImage,
                           new Rectangle(0, 0, nuevoAncho, nuevoAncho),
                           new Rectangle(0, 0, srcImage.Width, srcImage.Height),
                           GraphicsUnit.Pixel);
                        MemoryStream imagenMemoryStream = new MemoryStream();
                        imagenBitmap.Save(imagenMemoryStream, Formato);
                        srcImage = System.Drawing.Image.FromStream(imagenMemoryStream);
                    }
                }
                return srcImage;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static byte[] StringToBytes(string cadena)
        {
            return Convert.FromBase64String(cadena);
        }
        public static String getString(byte[] text)
        {
            return Convert.ToBase64String(text);
        }
        public class CursorWait : IDisposable
        {
            public CursorWait(bool appStarting = false, bool applicationCursor = false)
            {
                Cursor.Current = appStarting ? Cursors.AppStarting : Cursors.WaitCursor;
                if (applicationCursor) Application.UseWaitCursor = true;
            }

            public void Dispose()
            {
                Cursor.Current = Cursors.Default;
                Application.UseWaitCursor = false;
            }
        }
        public static string ToBase64String(this Bitmap bmp, ImageFormat imageFormat)
        {
            string base64String = string.Empty;

            MemoryStream memoryStream = new MemoryStream();
            bmp.Save(memoryStream, imageFormat);

            memoryStream.Position = 0;
            byte[] byteBuffer = memoryStream.ToArray();

            memoryStream.Close();

            base64String = Convert.ToBase64String(byteBuffer);
            byteBuffer = null;

            return base64String;
        }
        public static string ToBase64ImageTag(this Bitmap bmp, ImageFormat imageFormat)
        {
            string imgTag = string.Empty;
            string base64String = string.Empty;

            base64String = bmp.ToBase64String(imageFormat);

            imgTag = "<img src=\"data:image/" + imageFormat.ToString() + ";base64,";
            imgTag += base64String + "\" ";
            imgTag += "width=\"" + bmp.Width.ToString() + "\" ";
            imgTag += "height=\"" + bmp.Height.ToString() + "\" />";

            return imgTag;
        }
        public static Bitmap Base64StringToBitmap(this string base64String)
        {
            Bitmap bmpReturn = null;

            byte[] byteBuffer = Convert.FromBase64String(base64String);
            MemoryStream memoryStream = new MemoryStream(byteBuffer);

            memoryStream.Position = 0;

            bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);

            memoryStream.Close();
            memoryStream = null;
            byteBuffer = null;

            return bmpReturn;
        }
        public static Image ImageCenter(Image imgWatermark)
        {
            
            //Imagen a la que se le pondrá Marca de agua
            Image imgPhoto = Image.FromFile(Application.StartupPath + @"\Resources\Fondo\fondo.png");
            int phWidth = imgPhoto.Width;
            int phHeight = imgPhoto.Height;

            //Nueva imagen con Marca de agua
            Bitmap bmPhoto = new Bitmap(phWidth, phHeight);
            bmPhoto.SetResolution(72, 72);
            Graphics grPhoto = Graphics.FromImage(bmPhoto);

            //Imagen que será la marca de agua
            int wmWidth = imgWatermark.Width;
            int wmHeight = imgWatermark.Height;

            grPhoto.SmoothingMode = SmoothingMode.AntiAlias;
            grPhoto.DrawImage(
                imgPhoto,
                new Rectangle(0, 0, phWidth, phHeight),
                0,
                0,
                phWidth,
                phHeight,
                GraphicsUnit.Pixel);

            Bitmap bmWatermark = new Bitmap(bmPhoto);
            bmWatermark.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            Graphics grWatermark = Graphics.FromImage(bmWatermark);

            int xPosOfWm = (phWidth / 2) - (wmWidth / 2);
            int yPosOfWm = (phHeight / 2) - (wmHeight / 2);

            grWatermark.DrawImage(imgWatermark,
                new Rectangle(xPosOfWm, yPosOfWm, wmWidth, wmHeight),
                0,
                0,
                wmWidth,
                wmHeight,
                GraphicsUnit.Pixel);

            imgPhoto = bmWatermark;
            grPhoto.Dispose();
            grWatermark.Dispose();

            return imgPhoto;
        }
    }
}
