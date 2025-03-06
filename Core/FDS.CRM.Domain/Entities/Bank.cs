namespace FDS.CRM.Domain.Entities
{
    public class Bank : Entity<Guid>, IAggregateRoot
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string ShortName { get; private set; }
        public string Logo { get; private set; }
        public bool IsActive { get; private set; }
        public string SwiftCode { get; private set; }
        public string Website { get; private set; }
        private readonly List<BankBranch> _branches = new();
        public IReadOnlyCollection<BankBranch> Branches => _branches.AsReadOnly();

        private Bank(string code, string name, string shortName, string logo, string swiftCode, string website)
        {
            Id = Guid.NewGuid();
            Code = code;
            Name = name;
            ShortName = shortName;
            Logo = logo;
            IsActive = true;
            SwiftCode = swiftCode;
            Website = website;
        }

        public static Bank Create(string code, string name, string shortName, string logo, 
                                string swiftCode, string website)
        {
            return new Bank(code, name, shortName, logo, swiftCode, website);
        }

        public void Update(string name, string shortName, string logo, string swiftCode, string website)
        {
            Name = name;
            ShortName = shortName;
            Logo = logo;
            SwiftCode = swiftCode;
            Website = website;
        }

        public void ToggleStatus()
        {
            IsActive = !IsActive;
        }
    }
}
