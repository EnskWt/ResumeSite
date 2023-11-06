namespace ResumeSite.Models.Entities
{
    public class Image
    {
        public Guid Id { get; set; }
        public byte[] Data { get; set; } = null!;
        public Guid PublicationId { get; set; }
        public virtual Publication Publication { get; set; } = null!;
    }
}
