using FDS.CRM.Application.Product.DTOs;

namespace FDS.CRM.Application.ActivityManager.Queries
{
    public class GetActivityQuery : IQuery<ResultModel<Paged<Activity>>>
    {
        public Guid Id { get; set; } // id trang chi tiet (contact, company, deal)
        public RelationshipType RelationshipType { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public ActivityType ActivityType { get; set; }
        public string? Title { get; set; }
    }
    public class GetActivityQueryValidator
    {
        public static void Validate(GetActivityQuery request)
        {
            ValidationException.NotNullOrWhiteSpace(request.Id.ToString(), "Id không được để trống.");
            ValidationException.NotNullOrWhiteSpace(request.RelationshipType.ToString(), "RelationshipType không được để trống.");
        }
    }
    internal class GetActivityQueryHandler : IQueryHandler<GetActivityQuery, ResultModel<Paged<Activity>>>
    {
 
        private readonly IActivityRepository _activityReposiory;
        public GetActivityQueryHandler(IActivityRepository activityReposiory)
        {
            _activityReposiory = activityReposiory;

        }
        public async Task<ResultModel<Paged<Activity>>> HandleAsync(GetActivityQuery query, CancellationToken cancellationToken = default)
        {
            GetActivityQueryValidator.Validate(query);
            var lstActivity = await _activityReposiory.GetByIdAsync(query.Id, query.RelationshipType, query.ActivityType, cancellationToken);
            if(!lstActivity.IsAny())
            {
                return new ResultModel<Paged<Activity>>(null);
            }
            if (!string.IsNullOrEmpty(query.Title))
            {
                lstActivity = lstActivity.Where(p => p.Title == query.Title);
            }
            var result = new Paged<Activity>
            {
                TotalItems = lstActivity.Count(),
            };  
            var activities = lstActivity.OrderByDescending(x => x.IsPinned)
           .Paged(query.Page, query.PageSize);
            result.Items = await _activityReposiory.ToListAsync(lstActivity);
            return new ResultModel<Paged<Activity>>(result);
        }
    }
}
