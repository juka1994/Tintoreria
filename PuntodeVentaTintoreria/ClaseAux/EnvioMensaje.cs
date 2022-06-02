using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PuntodeVentaTintoreria.ClasesAux
{
    public class EnvioMensaje
    {
        public static string EnviarMensaje(string deviceId, string title, string message,bool opcion)
        {
            try
            {
                var applicationID = "";
                if (opcion)//cliente
                    applicationID = "AAAA_ZBqm2Q:APA91bEEFyIeyck0RA-Z3gC0qhvDYG07GMQYvRCx4rdp5tYrcS0PG7KY8Fnnby0FkRUnPJlGwi9KXFJZsqTxIXMBBq50DsBxu5Uxoch92RWLF-VrCBE8WTSAlcll4V05HtbzK1XtKOyX";
                else//proveedor
                    applicationID = "AAAA7-8qP6o:APA91bHkHDj3eI7BD6TDCBNQDQk5R-ASJecWoKJYBUQ6K5JHKn96LLSsA09f8bQ8zclFTYapZxScS6Lu-oUYMDL_w_1MAIEc7w13j9CgZrjiqbqQ22avZ6uzjeRygAbQjqgfVntqlkNK";

                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");

                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var data = new
                {
                    to = deviceId,
                    notification = new
                    {
                        body = message.ToUpper(),
                        title = title.ToUpper(),
                        sound = "default",
                    }
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                string aux = string.Format("Authorization: key={0}", applicationID);
                tRequest.Headers.Add(string.Format("Authorization:key={0}", applicationID));
                tRequest.ContentLength = byteArray.Length;

                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);

                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                return sResponseFromServer;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
