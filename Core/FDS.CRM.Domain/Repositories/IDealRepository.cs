namespace FDS.CRM.Domain.Repositories
{
    public interface IDealRepository : IRepository<Deal, Guid>
    {
        Task<List<Deal>> GetDealsAsync(CancellationToken cancellationToken = default);
    }
}
