using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeSite.Contracts.ServicesContracts.PublicationServiceContracts;
using ResumeSite.Models.Entities;
using ResumeSite.Models.ViewModels;

namespace ResumeSite.Controllers
{
    [Route("author")]
    //[Authorize(Roles = "Author")]
    [AllowAnonymous]
    public class AuthorsController : Controller
    {
        private readonly IPublicationsAdderService _publicationsAdderService;
        private readonly IPublicationsGetterService _publicationsGetterService;
        private readonly IPublicationsUpdaterService _publicationsUpdaterService;
        private readonly IPublicationsDeleterService _publicationsDeleterService;


        public AuthorsController(IPublicationsAdderService publicationsAdderService, IPublicationsGetterService publicationsGetterService, IPublicationsUpdaterService publicationsUpdaterService, IPublicationsDeleterService publicationsDeleterService)
        {
            _publicationsAdderService = publicationsAdderService;
            _publicationsGetterService = publicationsGetterService;
            _publicationsUpdaterService = publicationsUpdaterService;
            _publicationsDeleterService = publicationsDeleterService;
        }

        [HttpGet]
        [Route("my-publications")]
        public async Task<IActionResult> Index()
        {
            var publications = await _publicationsGetterService.GetAllPublications();

            return View(publications);
        }

        [HttpGet]
        [Route("new-publication")]
        public IActionResult CreatePublication()
        {
            return View();
        }

        [HttpPost]
        [Route("new-publication")]
        public async Task<IActionResult> CreatePublication(PublicationAddRequest publication)
        {
            if (!ModelState.IsValid)
            {
                return View(publication);
            }

            var newPublicationId = await _publicationsAdderService.AddPublication(publication);

            return RedirectToAction("PublicationDetails", "Publications", new { id = newPublicationId });
        }

        [HttpGet]
        [Route("edit/{id}")]
        public async Task<IActionResult> EditPublication(Guid id)
        {
            var publication = await _publicationsGetterService.GetPublication(id);

            return View(publication.ToPublicationUpdateRequest());
        }

        [HttpPost]
        [Route("edit/{id}")]
        public async Task<IActionResult> EditPublication(PublicationUpdateRequest publication)
        {
            if (!ModelState.IsValid)
            {
                return View(publication);
            }

            await _publicationsUpdaterService.UpdatePublication(publication);

            return RedirectToAction("PublicationDetails", "Publications", new { id = publication.Id });
        }

        [HttpGet]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeletePublication(Guid id)
        {
            await _publicationsDeleterService.DeletePublication(id);

            return RedirectToAction("Index", "Authors");
        }
    }
}
