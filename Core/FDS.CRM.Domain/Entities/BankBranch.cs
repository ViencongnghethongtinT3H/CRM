namespace FDS.CRM.Domain.Entities
{
    public enum BranchType
    {
        MainBranch = 1,
        SubBranch = 2,
        TransactionOffice = 3
    }

    public class BankBranch : Entity<Guid>, IAggregateRoot
    {
        public Guid BankId { get; private set; }
        public Bank Bank { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Province { get; private set; }
        public string District { get; private set; }
        public bool IsActive { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string WorkingHours { get; private set; }
        public BranchType BranchType { get; private set; }
        public string ManagerName { get; private set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }

        private BankBranch(
            Guid bankId, 
            string code, 
            string name, 
            string address, 
            string province, 
            string district,
            string phoneNumber,
            string email,
            string workingHours,
            BranchType branchType,
            string managerName,
            string latitude,
            string longitude)
        {
            Id = Guid.NewGuid();
            BankId = bankId;
            Code = code;
            Name = name;
            Address = address;
            Province = province;
            District = district;
            IsActive = true;
            PhoneNumber = phoneNumber;
            Email = email;
            WorkingHours = workingHours;
            BranchType = branchType;
            ManagerName = managerName;
            Latitude = latitude;
            Longitude = longitude;
        }

        public static BankBranch Create(
            Guid bankId, 
            string code, 
            string name, 
            string address, 
            string province, 
            string district,
            string phoneNumber,
            string email,
            string workingHours,
            BranchType branchType,
            string managerName,
            string latitude,
            string longitude)
        {
            return new BankBranch(bankId, code, name, address, province, district,
                                 phoneNumber, email, workingHours, branchType,
                                 managerName, latitude, longitude);
        }

        public void Update(
            string name, 
            string address, 
            string province, 
            string district,
            string phoneNumber,
            string email,
            string workingHours,
            string managerName,
            string latitude,
            string longitude)
        {
            Name = name;
            Address = address;
            Province = province;
            District = district;
            PhoneNumber = phoneNumber;
            Email = email;
            WorkingHours = workingHours;
            ManagerName = managerName;
            Latitude = latitude;
            Longitude = longitude;
        }

        public void ToggleStatus()
        {
            IsActive = !IsActive;
        }
    }
}
