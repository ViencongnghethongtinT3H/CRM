
namespace FDS.CRM.Persistence.Repositories
{
    public class DealRepository : Repository<Deal, Guid>, IDealRepository
    {
        public DealRepository(CrmDbContext dbContext, IDateTimeProvider dateTimeProvider)
            : base(dbContext, dateTimeProvider)
        {
        }

        public async Task<List<Deal>> GetDealsAsync(CancellationToken cancellationToken = default)
        {
            var deals = GetQueryableSet()
               .AsNoTracking();

            return await deals.ToListAsync(cancellationToken);
        }
    }

}
