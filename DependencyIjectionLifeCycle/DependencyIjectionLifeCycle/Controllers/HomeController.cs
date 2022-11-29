using DependencyIjectionLifeCycle.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DependencyIjectionLifeCycle.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IScopedGuidGenerator _scoped;
        private readonly ISingletonGuidGenerator _singleton;
        private readonly ITransientGuidGenerator _transient;
        GuidService _guidService;

        public HomeController(ILogger<HomeController> logger, IScopedGuidGenerator scoped, ISingletonGuidGenerator singleton, ITransientGuidGenerator transient, GuidService guidService)
        {
            _logger = logger;
            _scoped = scoped;
            _singleton = singleton;
            _transient = transient;
            _guidService = guidService;
        }

        public IActionResult Index()
        {
            ViewBag.Transient = _transient.Guid.ToString();
            ViewBag.Scoped = _scoped.Guid.ToString();
            ViewBag.Singleton = _singleton.Guid.ToString();

            ViewBag.ServiceTransient = _guidService._transient.Guid.ToString();
            ViewBag.ServiceScoped = _guidService._scoped.Guid.ToString();
            ViewBag.ServiceSingleton = _guidService._singleton.Guid.ToString();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}