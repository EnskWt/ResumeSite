using ResumeSite.Models.ViewModels;

namespace ResumeSite.Contracts.ServicesContracts.PublicationServiceContracts
{
    public interface IPublicationsAdderService
    {
        Task<Guid> AddPublication(PublicationAddRequest? publicationAddRequest);
    }
}
