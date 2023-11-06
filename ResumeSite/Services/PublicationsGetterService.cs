using ResumeSite.Contracts.RepositoriesContracts.PublicationRepositoryContracts;
using ResumeSite.Contracts.ServicesContracts.PublicationServiceContracts;
using ResumeSite.Models.Entities;
using ResumeSite.Models.ViewModels;
using System.Linq.Expressions;

namespace ResumeSite.Services
{
    public class PublicationsGetterService : IPublicationsGetterService
    {
        private readonly IPublicationsRepository _publicationsRepository;

        public PublicationsGetterService(IPublicationsRepository publicationsRepository)
        {
            _publicationsRepository = publicationsRepository;
        }

        public async Task<List<PublicationResponse>> GetAllPublications()
        {
            var publications = await _publicationsRepository.GetAllAsync();
            return publications.Select(x => x.ToPublicationResponse()).ToList();
        }

        // TODO: Add tags to publication model and enum for tags
        public async Task<List<PublicationResponse>> GetAllPublications(Expression<Func<Publication, bool>> predicate)
        {
            var publications = await _publicationsRepository.GetAllAsync(predicate);
            return publications.Select(x => x.ToPublicationResponse()).ToList();
        }

        public async Task<PublicationResponse> GetPublication(Guid? id)
        {
            if (id == Guid.Empty || id == null)
            {
                throw new ArgumentNullException("Id can't be empty or null.");
            }

            var publication = await _publicationsRepository.GetAsync(id.Value);
            if (publication == null)
            {
                throw new Exception($"Publication with id {id} not found");
            }

            return publication.ToPublicationResponseWithImages();
        }
    }
}
