using ResumeSite.Models.Entities;
using System.Linq.Expressions;

namespace ResumeSite.Contracts.RepositoriesContracts.PublicationRepositoryContracts
{
    public interface IPublicationsRepository
    {
        Task<Guid> AddAsync(Publication publication);

        Task<Guid> UpdateAsync(Publication publication);

        Task<bool> DeleteAsync(Guid id);

        Task<Publication?> GetAsync(Guid id);

        Task<List<Publication>> GetAllAsync();

        Task<List<Publication>> GetAllAsync(Expression<Func<Publication, bool>> predicate);
    }
}
