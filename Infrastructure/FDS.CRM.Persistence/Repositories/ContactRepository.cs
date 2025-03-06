
namespace FDS.CRM.Persistence.Repositories
{
    public class ContactRepository : Repository<Contact, Guid>, IContactRepository
    {
        public ContactRepository(CrmDbContext dbContext, IDateTimeProvider dateTimeProvider)
            : base(dbContext, dateTimeProvider)
        {
        }

        public async Task<Contact?> GetContactDetailByIdAsync(Guid contactId, CancellationToken cancellationToken = default)
        {
            var query = GetQueryableSet()
                .Include(c => c.AssociatedInfos)
                .Include(c => c.Addresses)
                    .ThenInclude(a => a.Ward)
                .Include(c => c.Addresses)
                    .ThenInclude(a => a.District)
                .Include(c => c.Addresses)
                    .ThenInclude(a => a.Province)
                .Include(c => c.Addresses)
                    .ThenInclude(a => a.Company)
                .Include(c => c.OrderConfigs)
                .Include(c => c.PurchaseTransactions)
                    .ThenInclude(a => a.PaymentMethod)
                .Include(c => c.PurchaseTransactions)
                    .ThenInclude(a => a.PaymentTerm)
                .Include(c => c.PurchaseTransactions)
                    .ThenInclude(a => a.User)
                .Include(c => c.CommonSetting)
                .Include(c => c.User)
                .Include(c => c.Position)
                .Include(c => c.Company)
                .Include(c => c.ContactRelations)
                .AsNoTracking();

            return await query.FirstOrDefaultAsync(c => c.Id == contactId, cancellationToken);
        }

        public async Task<List<Contact>> GetContactsAsync(CancellationToken cancellationToken = default)
        {
            var contacts = GetQueryableSet()
               .AsNoTracking();

            return await contacts.ToListAsync(cancellationToken);
        }
    }

}
