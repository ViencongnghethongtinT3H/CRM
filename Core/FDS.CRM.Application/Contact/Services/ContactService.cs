using FDS.CRM.Application.Common;
using FDS.CRM.Application.Common.Services;

namespace FDS.CRM.Application.Contact.Services
{
    public class ContactService : CrudService<Domain.Entities.Contact>, IContactService
    {
        public ContactService(IRepository<Domain.Entities.Contact, Guid> repository, Dispatcher dispatcher) : base(repository, dispatcher)
        {
        }
    }
}
