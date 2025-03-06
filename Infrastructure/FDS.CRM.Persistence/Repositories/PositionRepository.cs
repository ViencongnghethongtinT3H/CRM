namespace FDS.CRM.Persistence.Repositories
{
    public class PositionRepository : Repository<Position, Guid>, IPositionRepository
    {
        public PositionRepository(CrmDbContext dbContext, IDateTimeProvider dateTimeProvider) : base(dbContext, dateTimeProvider)
        {
        }

        public async Task<List<IGrouping<Guid, Position>>> GetGroupedPositionsAsync(CancellationToken cancellationToken = default)
        {
            var positions = await GetQueryableSet()
                .Include(p => p.Department)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return positions
                .GroupBy(p => p.DepartmentID)
                .ToList();
        }

    }
}
