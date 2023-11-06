using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResumeSite.Models.Entities;
using ResumeSite.Models.IdentityEntities;

namespace ResumeSite.DatabaseContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Publication> Publications { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Publication>()
                .HasMany(p => p.Images)
                .WithOne(i => i.Publication)
                .HasForeignKey(i => i.PublicationId);
            
        }
    }
}
