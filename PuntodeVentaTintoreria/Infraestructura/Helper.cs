using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PuntodeVentaTintoreria.Infraestructura
{
    public static class Helper
    {

        public static async Task<bool> IsConnectedAsync()
        {
            try
            {
                var httpClient = new HttpClient();
                HttpResponseMessage respuesta = (await httpClient.GetAsync("http://www.google.com"));
                return (HttpStatusCode.OK == respuesta.StatusCode);
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
