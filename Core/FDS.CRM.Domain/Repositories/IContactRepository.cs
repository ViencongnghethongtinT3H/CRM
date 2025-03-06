namespace FDS.CRM.Domain.Repositories
{
    public interface IContactRepository : IRepository<Contact, Guid>
    {
        Task<Contact?> GetContactDetailByIdAsync(Guid contactId, CancellationToken cancellationToken = default);
        Task<List<Contact>> GetContactsAsync(CancellationToken cancellationToken = default);
    }
}
