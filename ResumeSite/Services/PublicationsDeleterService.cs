using ResumeSite.Contracts.RepositoriesContracts.PublicationRepositoryContracts;
using ResumeSite.Contracts.ServicesContracts.PublicationServiceContracts;

namespace ResumeSite.Services
{
    public class PublicationsDeleterService : IPublicationsDeleterService
    {
        private readonly IPublicationsRepository _publicationsRepository;

        public PublicationsDeleterService(IPublicationsRepository publicationsRepository)
        {
            _publicationsRepository = publicationsRepository;
        }

        public async Task<bool> DeletePublication(Guid? id)
        {
            if (id == Guid.Empty || id == null)
            {
                throw new ArgumentNullException("Id can't be empty or null.");
            }

            return await _publicationsRepository.DeleteAsync(id.Value);
        }
    }
}
