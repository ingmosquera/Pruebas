using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.RestClient;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Usuario() {
            var resultado = EventoJson.Deserializar<Usuario>(await UsuarioService.ListarUsuarios());
            return View(resultado);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Create() {
            return View();
        }


        public async Task<IActionResult> CreateUSuario(Usuario model)
        {
            var resultado = await UsuarioService.CrearUsuario(model.Nombre, model.Codigo);
            return RedirectToAction("Usuario");
        }
    }
}
