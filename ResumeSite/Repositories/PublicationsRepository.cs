using Microsoft.EntityFrameworkCore;
using ResumeSite.Contracts.RepositoriesContracts.PublicationRepositoryContracts;
using ResumeSite.DatabaseContext;
using ResumeSite.Models.Entities;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace ResumeSite.Repositories
{
    public class PublicationsRepository : IPublicationsRepository
    {
        private readonly ApplicationDbContext _db;

        public PublicationsRepository(ApplicationDbContext db) 
        {
            _db = db; 
        }

        public async Task<Guid> AddAsync(Publication publication)
        {
            await _db.Publications.AddAsync(publication);
            await _db.SaveChangesAsync();
            return publication.Id;
        }

        public async Task<Guid> UpdateAsync(Publication publication)
        {
            var publicationToUpdate = await _db.Publications.Include(p => p.Images).FirstOrDefaultAsync(p => p.Id == publication.Id);

            if (publicationToUpdate == null)
            {
                throw new Exception($"Publication with id {publication.Id} not found");
            }

            publicationToUpdate.Title = publication.Title;
            publicationToUpdate.Description = publication.Description;
            publicationToUpdate.Images = publication.Images;

            await _db.SaveChangesAsync();
            return publication.Id;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var publication = await _db.Publications.FindAsync(id);
            if (publication == null)
            {
                return false;
            }

            _db.Publications.Remove(publication);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Publication?> GetAsync(Guid id)
        {
            return await _db.Publications.Include(p => p.Images).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Publication>> GetAllAsync()
        {
            return await _db.Publications.ToListAsync();
        }

        public async Task<List<Publication>> GetAllAsync(Expression<Func<Publication, bool>> predicate)
        {
            return await _db.Publications.Where(predicate).ToListAsync();
        }


        
    }
}
