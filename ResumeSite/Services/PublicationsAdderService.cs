using ResumeSite.Contracts.RepositoriesContracts.PublicationRepositoryContracts;
using ResumeSite.Contracts.ServicesContracts.PublicationServiceContracts;
using ResumeSite.Models.ViewModels;

namespace ResumeSite.Services
{
    public class PublicationsAdderService : IPublicationsAdderService
    {
        private readonly IPublicationsRepository _publicationsRepository;

        public PublicationsAdderService(IPublicationsRepository publicationsRepository)
        {
            _publicationsRepository = publicationsRepository;
        }

        public async Task<Guid> AddPublication(PublicationAddRequest? publicationAddRequest)
        {
            if (publicationAddRequest == null)
            {
                throw new ArgumentNullException("PublicationAddRequest can't be null.");
            }

            return await _publicationsRepository.AddAsync(publicationAddRequest.ToPublication());
        }

    }
}
