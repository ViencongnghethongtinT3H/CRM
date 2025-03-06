namespace FDS.CRM.Domain.Repositories
{
    public interface ICompanyRepository : IRepository<Company, Guid>
    {
        Task<List<Company>> GetCompanysAsync(CancellationToken cancellationToken = default);
    }
}
