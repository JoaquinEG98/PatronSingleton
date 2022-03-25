using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PatronSingleton.Configuration;
using PatronSingleton.Models;
using System.Diagnostics;
using Tools;

namespace PatronSingleton.Controllers
{
    public class HomeController : Controller
    {
        #region Inyección de dependencias de mi Config
        private readonly IOptions<Config> _config;

        public HomeController(IOptions<Config> config)
        {
            _config = config;
        }
        #endregion

        public IActionResult Index()
        {
            Log.GetInstancia(_config.Value.PathLog).Guardar("Entrando a Index...");
            return View();
        }

        public IActionResult Privacy()
        {
            Log.GetInstancia(_config.Value.PathLog).Guardar("Entrando a Privacy...");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}