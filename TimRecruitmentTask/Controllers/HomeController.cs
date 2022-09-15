using Microsoft.AspNetCore.Mvc;
using PublicationServiceReference;
using System.Diagnostics;
using TimRecruitmentTask.Models;

namespace TimRecruitmentTask.Controllers
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

        public IActionResult SearchPublication(PublicationSearch publicationSearch)
        {
            TempData["searchedWord"] = publicationSearch.SearchedWord;
            return RedirectToAction("Index", "PublicationService");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}