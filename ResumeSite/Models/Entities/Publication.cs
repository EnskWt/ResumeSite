using System.ComponentModel.DataAnnotations.Schema;

namespace ResumeSite.Models.Entities
{
    public class Publication
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public virtual List<Image> Images { get; set; } = new List<Image>();
    }
}
