using Microsoft.AspNetCore.Mvc;
using TimRecruitmentTask.Models;
using TimRecruitmentTask.Modules.SearchPublications;

namespace TimRecruitmentTask.Controllers
{
    public class PublicationServiceController : Controller
    {
        private readonly ISearchPublicationsService _searchService;

        public PublicationServiceController(ISearchPublicationsService searchService)
        {
            _searchService = searchService;
        }

        public async Task<IActionResult> Index()
        {
            var loadModel = TempData["searchedWord"];
            if (loadModel == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var word = (string)loadModel;
            var recordsToShow = "25";
            var result = await _searchService.GetSearchResult(word, recordsToShow);

            PublicationSearch publicationSearch = new PublicationSearch()
            {
                SearchedWord = word,
                Result = result,
                Interator = Int32.Parse(recordsToShow)
            };

            return View(publicationSearch);
        }

        public async Task<IActionResult> GetNextPage(string searchedWord, string recordsToShow)
        {
            var result = await _searchService.GetSearchResult(searchedWord, recordsToShow);

            PublicationSearch publicationSearch = new PublicationSearch()
            {
                SearchedWord = searchedWord,
                Result = result,
                Interator = Int32.Parse(recordsToShow)
            };

            return Json(publicationSearch);
        }
    }
}
