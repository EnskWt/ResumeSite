using ResumeSite.Contracts.RepositoriesContracts.PublicationRepositoryContracts;
using ResumeSite.Contracts.ServicesContracts.PublicationServiceContracts;
using ResumeSite.Models.ViewModels;

namespace ResumeSite.Services
{
    public class PublicationsUpdaterService : IPublicationsUpdaterService
    {
        private readonly IPublicationsRepository _publicationsRepository;

        public PublicationsUpdaterService(IPublicationsRepository publicationsRepository)
        {
            _publicationsRepository = publicationsRepository;
        }

        public async Task<Guid> UpdatePublication(PublicationUpdateRequest? publicationUpdateRequest)
        {
            if (publicationUpdateRequest == null)
            {
                throw new ArgumentNullException("PublicationUpdateRequest can't be null.");
            }

            return await _publicationsRepository.UpdateAsync(publicationUpdateRequest.ToPublication());
        }
    }
}
