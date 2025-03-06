using FDS.CRM.Application.Common.DTOs;
using FDS.CRM.Application.Common.Queries;
using FDS.CRM.Application.Common.Services;
using FDS.CRM.Application.Contact.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FDS.CRM.Application.Contact.Queries
{
    public class SearchContactQuery : BaseSearchQuery<Domain.Entities.Contact, SearchContactDto>
    {
        public SearchContactQuery(SearchRequestModel searchRequest)
        {
            SearchRequest = searchRequest;
        }

        public override Expression<Func<Domain.Entities.Contact, bool>> GetFilterExpression(SearchCondition condition)
        {
            return condition switch
            {
                { Field: "name", Operator: "contains" } =>
                    x => x.Name.Contains((string)condition.Value),

                //{ Field: "email", Operator: "eq" } =>
                //    x => x.Email == (string)condition.Value,

                //{ Field: "leadStatus", Operator: "eq" } =>
                //    x => x.LeadStatus == (LeadStatusEnum)condition.Value,

                { Field: "companyName", Operator: "contains" } =>
                    x => x.Company.Name.Contains((string)condition.Value),

                _ => null
            };
        }

        public override Expression<Func<Domain.Entities.Contact, SearchContactDto>> GetSelectExpression()
        {
            // This will be overridden in the handler
            return null;
        }

        public override IQueryable<Domain.Entities.Contact> AddIncludes(IQueryable<Domain.Entities.Contact> query)
        {
            return query
                .Include(x => x.Company);
        }

        public override IOrderedQueryable<Domain.Entities.Contact> ApplySort(
            IQueryable<Domain.Entities.Contact> query,
            string sortField,
            bool isDescending)
        {
            return (sortField.ToLower(), isDescending) switch
            {
                ("createddatetime", true) => query.OrderByDescending(x => x.CreatedDateTime),
                ("name", true) => query.OrderByDescending(x => x.Name),
                _ => query.OrderByDescending(x => x.CreatedDateTime)
            };
        }
    }

    public class SearchContactQueryHandler : BaseSearchQueryHandler<Domain.Entities.Contact, SearchContactDto, SearchContactQuery>
    {
        private readonly IRepository<Domain.Entities.AssociatedInfo, Guid> _associatedInfoRepository;
        //private readonly IRepository<Domain.Entities.Deal, Guid> _dealRepository;
        //private readonly IRepository<Domain.Entities.Company, Guid> _companyRepository;

        public SearchContactQueryHandler(
            ICrudService<Domain.Entities.Contact> crudService,
            IRepository<Domain.Entities.AssociatedInfo, Guid> associatedInfoRepository)
            //IRepository<Domain.Entities.Deal, Guid> dealRepository,
            //IRepository<Domain.Entities.Company, Guid> companyRepository)
            : base(crudService)
        {
            _associatedInfoRepository = associatedInfoRepository;

        }

        public override async Task<SearchResponseModel<SearchContactDto>> HandleAsync(
            SearchContactQuery query,
            CancellationToken cancellationToken = default)
        {
            // Get base query with includes and filters applied
            var baseQuery = await PrepareBaseQueryAsync(query, cancellationToken);

            // Apply custom joins and projection
            var result = from contact in baseQuery

                         join ai1 in _associatedInfoRepository.GetQueryableSet()
                             on contact.Id equals ai1.ObjectReferenceId
                             into ai1Join
                         from phoneInfo in ai1Join.Where(ai => ai.AssociatedInfoType == Domain.Enums.AssociatedInfoType.Phone).DefaultIfEmpty()

                         join ai2 in _associatedInfoRepository.GetQueryableSet()
                             on contact.Id equals ai2.ObjectReferenceId
                             into ai2Join
                         from emailInfo in ai2Join.Where(ai => ai.AssociatedInfoType == Domain.Enums.AssociatedInfoType.Email).DefaultIfEmpty()

                         select new SearchContactDto
                         {
                             Id = contact.Id,
                             Email = emailInfo.Value ?? string.Empty,
                             PhoneNumber = phoneInfo.Value ?? string.Empty,
                             Code = contact.Code,
                             LeadScored = contact.LeadScored ?? 0,
                             Name = contact.Name,
                             LeadStatus = contact.LeadStatus,
                         };


            // Get total count
            var totalItems = await result.CountAsync(cancellationToken);

            // Apply paging and final projection
            var items = await result
                .Skip((query.SearchRequest.PageNumber - 1) * query.SearchRequest.PageSize)
                .Take(query.SearchRequest.PageSize)                
                .ToListAsync(cancellationToken);

            return new SearchResponseModel<SearchContactDto>
            {
                Items = items,
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling(totalItems / (double)query.SearchRequest.PageSize),
                CurrentPage = query.SearchRequest.PageNumber
            };
        }

        protected async Task<IQueryable<Domain.Entities.Contact>> PrepareBaseQueryAsync(
            SearchContactQuery query,
            CancellationToken cancellationToken)
        {
            var baseQuery = _crudService.GetQueryableSet();

            // Add includes from base query
            baseQuery = query.AddIncludes(baseQuery);

            // Apply filters from base query
            foreach (var condition in query.SearchRequest.Conditions)
            {
                var filterExpression = query.GetFilterExpression(condition);
                if (filterExpression != null)
                {
                    baseQuery = baseQuery.Where(filterExpression);
                }
            }

            // Apply sorting from base query
            if (!string.IsNullOrEmpty(query.SearchRequest.SortField))
            {
                baseQuery = query.ApplySort(baseQuery, query.SearchRequest.SortField, query.SearchRequest.IsDescending);
            }

            return baseQuery;
        }
    }
}
