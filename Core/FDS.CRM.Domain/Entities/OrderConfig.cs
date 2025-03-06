namespace FDS.CRM.Domain.Entities
{
    public class OrderConfig : Entity<Guid>, IAggregateRoot
    {
        public Guid ContactId { get; private set; }
        public Contact Contact { get; private set; }
        public string BankName { get; private set; }
        public string AccountName { get; private set; }
        public string AccountNumber { get; private set; }
        public bool AllowPayment { get; private set; }   
        public SendEmailType SendEmailType { get; private set; }
        private readonly List<OrderRelation> _orderRelation = new();
        public IReadOnlyCollection<OrderRelation> OrderRelation => _orderRelation.AsReadOnly();

        #region Constructor

        private OrderConfig(Guid contactId, string bankName, string accountName,
                            string accountNumber, bool allowPayment, SendEmailType sendEmailType)
        {
            Id = Guid.NewGuid();
            ContactId = contactId;
            BankName = bankName;
            AccountName = accountName;
            AccountNumber = accountNumber;
            AllowPayment = allowPayment;
            SendEmailType = sendEmailType;
        }
        #endregion

        #region Business Logic
        public static OrderConfig Create(Guid contactId, string bankName, string accountName,
                                         string accountNumber, bool allowPayment, SendEmailType sendEmailType)
        {
            return new OrderConfig(contactId, bankName, accountName, accountNumber, allowPayment, sendEmailType);
        }
        #endregion
    }
}
