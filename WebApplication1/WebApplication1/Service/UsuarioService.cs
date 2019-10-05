using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class UsuarioService
    {
        public static async Task<string> ListarUsuarios() {
            try
            {
                var resultado = await RestClient.RestClient.ListarRegistros("/Prueba/GetAll");
                return resultado;
            }
            catch (Exception)
            {
                return "Error al crear el servicio";
            }
        }

        public static async Task<string> CrearUsuario(string nombre,string codigo) {
            try
            {
                var data = new Usuario
                {
                    Codigo = codigo,
                    Nombre = nombre
                };

                string json = JsonConvert.SerializeObject(data);
                var result = await RestClient.RestClient.CrearRegistro(json, "/Prueba/CrearUsuario");
                return result;
            }
            catch (Exception )
            {
                return "Error al crear el servicio";
            }
        }
    }
}
