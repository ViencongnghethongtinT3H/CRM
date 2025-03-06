namespace FDS.CRM.Domain.Repositories
{
    public interface IPositionRepository : IRepository<Position, Guid>
    {
        Task<List<IGrouping<Guid, Position>>> GetGroupedPositionsAsync(CancellationToken cancellationToken = default);
    }
}
