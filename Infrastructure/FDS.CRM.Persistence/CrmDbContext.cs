using FDS.CRM.Domain.Entities;

namespace FDS.CRM.Persistence;

public class CrmDbContext : DbContext, IUnitOfWork, IDataProtectionKeyContext
{
    private readonly ILogger<CrmDbContext> _logger;

    private IDbContextTransaction _dbContextTransaction;

    public DbSet<DataProtectionKey> DataProtectionKeys {  get; set; }
    public DbSet<Contact> Contacts {  get; set; }
    public DbSet<ContactRelation> ContactRelations { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<OrderConfig> OrderConfigs { get; set; }
    public DbSet<PurchaseTransaction> PurchaseTransactions { get; set; }    
    public DbSet<TicketRelation> TicketRelations { get; set; }    
    public DbSet<CompanyRelation> CompanyRelations { get; set; }    
    public DbSet<DealRelation> DealRelations { get; set; }    
    public DbSet<QuoreRelation> QuoreRelations { get; set; }    
    public DbSet<OrderRelation> OrderRelations { get; set; }    
    public DbSet<Pipeline> Pipelines { get; set; }    
    public DbSet<PipelineStage> PipelineStages { get; set; }    
    public DbSet<Deal> Deals { get; set; }    
    public DbSet<Company> Companies { get; set; }    
    public DbSet<AssociatedInfo> AssociatedInfos { get; set; }    
    public DbSet<Activity> Activities { get; set; }    
    public DbSet<ActivityAppointment> ActivityAppointments { get; set; }    
    public DbSet<ActivityCall> ActivityCalls { get; set; }    
    public DbSet<ActivityEmail> ActivityEmails { get; set; }    
    public DbSet<ActivityNote> ActivityNotes { get; set; }    
    public DbSet<ActivitySms> ActivitySms { get; set; }    
    public DbSet<ActivityReminder> ActivityReminders { get; set; }    
    public DbSet<ActivityTask> ActivityTasks { get; set; }    
    public DbSet<ActivityOwnerRelation> ActivityOwnerRelations { get; set; }    
    public DbSet<QuoteItems> QuoteItems { get; set; }
    public DbSet<Quotes> Quotes { get; set; }   
    public DbSet<Department> Departments { get; set; }   
    public DbSet<Position> Positions { get; set; }   
    public DbSet<User> Users { get; set; }   
    public DbSet<Role> Roles { get; set; }   
    public DbSet<UserRole> UserRoles { get; set; }   
    public DbSet<CommonSetting> CommonSettings { get; set; }   
    public DbSet<Province> Provinces { get; set; }   
    public DbSet<District> Districts { get; set; }   
    public DbSet<Ward> Wards { get; set; }   
    public DbSet<PaymentTerm> PaymentTerms { get; set; }   
    
    
    

    public CrmDbContext(DbContextOptions<CrmDbContext> options, ILogger<CrmDbContext> logger)
        : base(options) 
    {
        _logger = logger;
    }

    public async Task<IDisposable> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default)
    {
        _dbContextTransaction = await Database.BeginTransactionAsync(isolationLevel, cancellationToken);
        return _dbContextTransaction;
    }

    public async Task<IDisposable> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, string lockName = null, CancellationToken cancellationToken = default)
    {
        _dbContextTransaction = await Database.BeginTransactionAsync(isolationLevel, cancellationToken);

        var sqlLock = new SqlDistributedLock(_dbContextTransaction.GetDbTransaction() as SqlTransaction);
        var lockScope = sqlLock.Acquire(lockName);
        if (lockScope == null)
        {
            throw new Exception($"Could not acquire lock: {lockName}");
        }

        return _dbContextTransaction;
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        await _dbContextTransaction.CommitAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new SelectWithoutWhereCommandInterceptor(_logger));
        optionsBuilder.AddInterceptors(new SelectWhereInCommandInterceptor(_logger));
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }
}
