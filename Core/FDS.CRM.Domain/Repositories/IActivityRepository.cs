namespace FDS.CRM.Domain.Repositories
{
    public interface IActivityRepository : IRepository<Activity, Guid>
    {
        Task<IQueryable<Activity>> GetByIdAsync(Guid Id, RelationshipType type, ActivityType ActivityType, CancellationToken cancellationToken = default);
    }
}
