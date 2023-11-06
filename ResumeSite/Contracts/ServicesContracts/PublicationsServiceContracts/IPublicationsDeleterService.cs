namespace ResumeSite.Contracts.ServicesContracts.PublicationServiceContracts
{
    public interface IPublicationsDeleterService
    {
        Task<bool> DeletePublication(Guid? id);
    }
}
