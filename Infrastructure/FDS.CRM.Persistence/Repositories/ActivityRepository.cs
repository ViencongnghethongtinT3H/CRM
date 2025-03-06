using FDS.CRM.Persistence;

namespace FDS.CRM.Domain.Repositories
{
    public class ActivityRepository : Repository<Activity, Guid>, IActivityRepository
    {
        public ActivityRepository(CrmDbContext dbContext, IDateTimeProvider dateTimeProvider)
            : base(dbContext, dateTimeProvider)
        {
        }

        public async Task<IQueryable<Activity>> GetByIdAsync(Guid Id, RelationshipType type, ActivityType activityType, CancellationToken cancellationToken = default)
        {
            var query = GetQueryableSet().AsNoTracking();

            var activityIncludes = new Dictionary<ActivityType, Expression<Func<Activity, object>>>
            {
                { ActivityType.Call, p => p.ActivityCalls },
                { ActivityType.Task, p => p.ActivityTasks },
                { ActivityType.SMS, p => p.ActivitySms },
                { ActivityType.Email, p => p.ActivityEmails },
                { ActivityType.Note, p => p.ActivityNotes },
                { ActivityType.Appointment, p => p.ActivityAppointments }
            };

            if (activityIncludes.TryGetValue(activityType, out var includeExpression))
            {
                query = query.Include(includeExpression);
            }
            else
            {
                query = query.Include(p => p.ActivityAppointments)
                             .Include(p => p.ActivityNotes)
                             .Include(p => p.ActivityCalls)
                             .Include(p => p.ActivityTasks)
                             .Include(p => p.ActivityEmails)
                             .Include(p => p.ActivityReminders)
                             .Include(p => p.ActivitySms);
            }


            if (type == RelationshipType.Contact)
            {
                return query.Where(c => c.ContactId == Id);
            }
            else if (type == RelationshipType.Deal)
            {
                return  query.Where(c => c.DealId == Id);
            }
            else if (type == RelationshipType.Ticket)
            {
                return query.Where(c => c.TicketId == Id);
            }
            else if (type == RelationshipType.Company)
            {
                return query.Where(c => c.CompanyId == Id);
            }
            return null;
        }
    }

}
