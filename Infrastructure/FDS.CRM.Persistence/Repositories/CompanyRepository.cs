
namespace FDS.CRM.Persistence.Repositories
{
    public class CompanyRepository : Repository<Company, Guid>, ICompanyRepository
    {
        public CompanyRepository(CrmDbContext dbContext, IDateTimeProvider dateTimeProvider)
            : base(dbContext, dateTimeProvider)
        {
        }

        public async Task<List<Company>> GetCompanysAsync(CancellationToken cancellationToken = default)
        {
            var companies = GetQueryableSet()
               .AsNoTracking();

            return await companies.ToListAsync(cancellationToken);
        }
    }

}
