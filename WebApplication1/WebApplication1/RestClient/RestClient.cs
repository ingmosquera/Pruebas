using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.RestClient
{
    public class RestClient
    {
        private static string INICIOURL = "http://9b5d5a61.ngrok.io/v1";
        private static readonly string JSONTYPE = "application/json";


        public static async Task<string> ListarRegistros(string complementoUrl) {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(INICIOURL);
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JSONTYPE));
                    var resultado = await httpClient.GetAsync(INICIOURL + complementoUrl);
                    var statusCode = (int)resultado.StatusCode;
                    if (statusCode == 200)
                    {
                        return resultado.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        return "Error al consultar el servicio de listado";
                    }
                }
            }
            catch (Exception )
            {
                return "Error al llamar el servicio";
            }
        }

        public static async Task<string> CrearRegistro(string json, string complementoUrl) {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(INICIOURL);
                    var buffer = Encoding.UTF8.GetBytes(json);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue(JSONTYPE);
                    var resultado = await httpClient.PostAsync(INICIOURL + complementoUrl, byteContent);
                    var statusCode = (int)resultado.StatusCode;
                    if (statusCode == 200)
                    {
                        return resultado.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        return "Error al consultar el servicio de creación";
                    }
                }
            }
            catch (Exception)
            {
                return "Error al crear el proceso de actualizacion";
            }
        }
    }
}
