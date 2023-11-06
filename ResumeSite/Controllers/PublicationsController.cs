using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeSite.Contracts.ServicesContracts.PublicationServiceContracts;
using ResumeSite.Models.ViewModels;

namespace ResumeSite.Controllers
{
    [AllowAnonymous]
    public class PublicationsController : Controller
    {
        private readonly IPublicationsGetterService _publicationsGetterService;

        public PublicationsController(IPublicationsGetterService publicationsGetterService)
        {
            _publicationsGetterService = publicationsGetterService;
        }

        [Route("publications")]
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            var publications = await _publicationsGetterService.GetAllPublications();

            return View(publications);
        }

        [Route("publications/{id}")]
        public async Task<IActionResult> PublicationDetails(Guid id)
        {
            var publication = await _publicationsGetterService.GetPublication(id);

            return View(publication);
        }
    }
}
