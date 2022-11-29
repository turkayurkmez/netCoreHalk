using Microsoft.AspNetCore.Mvc;
using RenderHTMLWithRazor.Models;
using System.Diagnostics;

namespace RenderHTMLWithRazor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Response()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Response(ResponseModel responseModel)
        {


            //kurallara ([Required(ErrorMessage = "Lütfen adınızı giriniz")]  [MinLength(3, ErrorMessage = "İsminiz en az üç harften oluşmalı")]) gibi
            //uyuyyor mu?
            if (ModelState.IsValid)
            {
                ThanksViewModel thanksViewModel = new ThanksViewModel();
                //son kişi katılımcı mı?
                thanksViewModel.LastUserIsParticipant = responseModel.IsParticipant;

                if (responseModel.IsParticipant)
                {
                    ResponseService.AddResponse(responseModel);
                }
                //tüm katılımcıları getir
                thanksViewModel.Responses = ResponseService.GetResponses();

                return View("Thanks", thanksViewModel);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}