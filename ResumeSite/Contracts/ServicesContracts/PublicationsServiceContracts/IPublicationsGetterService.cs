using ResumeSite.Models.Entities;
using ResumeSite.Models.ViewModels;
using System.Linq.Expressions;

namespace ResumeSite.Contracts.ServicesContracts.PublicationServiceContracts
{
    public interface IPublicationsGetterService
    {
        Task<PublicationResponse> GetPublication(Guid? id);

        Task<List<PublicationResponse>> GetAllPublications();

        Task<List<PublicationResponse>> GetAllPublications(Expression<Func<Publication, bool>> predicate);
    }
}
