using ResumeSite.Models.ViewModels;

namespace ResumeSite.Contracts.ServicesContracts.PublicationServiceContracts
{
    public interface IPublicationsUpdaterService
    {
        Task<Guid> UpdatePublication(PublicationUpdateRequest? publicationUpdateRequest);
    }
}
