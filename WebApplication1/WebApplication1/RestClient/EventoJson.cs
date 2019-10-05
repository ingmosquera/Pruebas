using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebApplication1.RestClient
{
    public class EventoJson
    {
        public static IEnumerable<T> Deserializar<T>(string Json) where T : class
        {
            var resultado = JsonConvert.DeserializeObject<IEnumerable<T>>(Json);
            return resultado;
        }

    }
}
