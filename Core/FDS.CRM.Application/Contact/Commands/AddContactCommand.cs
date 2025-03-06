using FDS.CRM.CrossCuttingConcerns.Helper;
using Microsoft.EntityFrameworkCore;

namespace FDS.CRM.Application.Contact.Commands
{
    public class AddContactCommand : ICommand
    {
        public ContactDto ContactDto { get; }

        public AddContactCommand(ContactDto contactDto)
        {
            ContactDto = contactDto ?? throw new ArgumentNullException(nameof(contactDto));
        }
    }

    public class AddContactCommandValidator
    {
        public static void Validate(AddContactCommand request)
        {
            ValidationException.NotNullOrWhiteSpace(request.ContactDto.Name, "Họ Và Tên không được để trống.");
            ValidationException.LengthInRange(request.ContactDto.Name, 0, 100, "Họ Và Tên không được quá 100 ký tự.");

            if (request.ContactDto.AssociatedInfos == null || request.ContactDto.AssociatedInfos.Count == 0)
            {
                throw new ValidationException("Danh sách thông tin liên hệ không được để trống.");
            }

            foreach (var info in request.ContactDto.AssociatedInfos)
            {
                if (info.AssociatedInfoType == AssociatedInfoType.Phone)
                {
                    ValidationException.NotNullOrWhiteSpace(info.Value, "Số điện thoại không được để trống.");
                    if (!ValidationException.ValidPhone(info.Value))
                    {
                        throw new ValidationException($"Số điện thoại '{info.Value}' không đúng định dạng.");
                    }
                }
                else if (info.AssociatedInfoType == AssociatedInfoType.Email)
                {
                    ValidationException.NotNullOrWhiteSpace(info.Value, "Email không được để trống.");
                    ValidationException.ValidEmail(info.Value, $"Email '{info.Value}' không đúng định dạng.");
                }
            }
        }
    }

    internal class AddContactCommandHandler : ICommandHandler<AddContactCommand>
    {
        private readonly ICrudService<Domain.Entities.Contact> _contactService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICrudService<User> _userService;

        public AddContactCommandHandler(
            ICrudService<Domain.Entities.Contact> contactService,
            IUnitOfWork unitOfWork,
            ICrudService<User> userService)
        {
            _contactService = contactService;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task HandleAsync(AddContactCommand command, CancellationToken cancellationToken = default)
        {
            AddContactCommandValidator.Validate(command);

            var userExists = await _userService.GetQueryableSet()
                .FirstOrDefaultAsync(u => u.Id == command.ContactDto.ContactOwnerId, cancellationToken);
            if (userExists == null)
            {
                throw new ValidationException($"ContactOwnerId {command.ContactDto.ContactOwnerId} không tồn tại trong bảng Users.");
            }
            Console.WriteLine($"User found with Id: {userExists.Id}");

            var emailValues = new HashSet<string>(command.ContactDto.AssociatedInfos
                 .Where(a => a.AssociatedInfoType == AssociatedInfoType.Email)
                 .Select(a => a.Value));

            var phoneValues = new HashSet<string>(command.ContactDto.AssociatedInfos
                .Where(a => a.AssociatedInfoType == AssociatedInfoType.Phone)
                .Select(a => a.Value));

            var existingContacts = await _contactService.GetByConditionAsync(
                c => c.AssociatedInfos
                    .Where(info =>
                        (info.AssociatedInfoType == AssociatedInfoType.Email && emailValues.Contains(info.Value)) ||
                        (info.AssociatedInfoType == AssociatedInfoType.Phone && phoneValues.Contains(info.Value)))
                    .Any(),
                cancellationToken
            );

            if (existingContacts.IsAny())
            {
                throw new ValidationException("Khách hàng cá nhân đã tồn tại trên hệ thống.");
            }

            using (await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken))
            {
                int sequenceNumber = await GetNextSequenceNumberAsync();
                string today = DateTime.UtcNow.ToString("ddMMyyyy");
                var Code = $"CN_{today}_{sequenceNumber:D4}";

                var contact = Domain.Entities.Contact.Create(
                    command.ContactDto.Name,
                    Code,
                    userExists.Id,
                    command.ContactDto.PositionId,
                    command.ContactDto.LeadStatus,
                    command.ContactDto.LifecycleStageEnum,
                    command.ContactDto.CustomerSource,
                    command.ContactDto.CompanyId,
                    command.ContactDto.IndustryId,
                    command.ContactDto.LeadScored,
                    CrossCuttingConcerns.Helper.StringHelpers.GetRandomColor()
                );

                if (command.ContactDto.Addresses?.Count > 0)
                {
                    foreach (var address in command.ContactDto.Addresses)
                    {
                        contact.AddAddress(address.AddressName, address.ProvinceId, address.DistrictId,
                            address.WardId, address.Country, address.AddressType);
                    }
                }

                if (command.ContactDto.OrderConfigs?.Count > 0)
                {
                    foreach (var orderConfig in command.ContactDto.OrderConfigs)
                    {
                        contact.AddOrderConfig(orderConfig.BankName, orderConfig.AccountName,
                            orderConfig.AccountNumber, orderConfig.AllowPayment, orderConfig.SendEmailType);
                    }
                }

                if (command.ContactDto.PurchaseTransactions?.Count > 0)
                {
                    foreach (var transaction in command.ContactDto.PurchaseTransactions)
                    {
                        contact.AddPurchaseTransaction(transaction.BuyPaymentMethodId, transaction.BuyPaymentTermId,
                            /*transaction.SalePaymentMethodId, transaction.SalePaymentTermId,*/ transaction.SaleId);
                    }
                }

                if (command.ContactDto.AssociatedInfos?.Count > 0)
                {
                    foreach (var associatedInfo in command.ContactDto.AssociatedInfos)
                    {
                        contact.AddAssociatedInfo(associatedInfo.Value, associatedInfo.AssociatedInfoType);
                    }
                }

                if (command.ContactDto.ContactRelations?.Count > 0)
                {
                    foreach (var contactRelation in command.ContactDto.ContactRelations)
                    {
                        contact.AddContactRelation(contactRelation.RelationId, contactRelation.JobTitle);
                    }
                }

                var filterField = new List<string>
                {
                    contact.Name,
                    string.Join(", ", contact.AssociatedInfos.Select(info => info.Value)),
                };

                contact.SetFilter(StringHelpers.SetFilterField(filterField));

                await _contactService.AddAsync(contact);
                await _unitOfWork.CommitTransactionAsync(cancellationToken);
            }
        }

        private async Task<int> GetNextSequenceNumberAsync()
        {
            var today = DateTime.UtcNow.ToString("ddMMyyyy");

            var existingCodes = await _contactService
                .GetByConditionAsync(c => c.Code.StartsWith($"CN_{today}_"));

            if (!existingCodes.IsAny())
                return 1;

            var maxSequence = existingCodes
                .Select(c => int.TryParse(c.Code.Split('_').Last(), out int num) ? num : 0)
                .Max();

            return maxSequence + 1;
        }

    }
}

