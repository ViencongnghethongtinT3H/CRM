using FDS.CRM.Application.Common.DTOs;
using FDS.CRM.Application.Position.DTOs;
using Microsoft.EntityFrameworkCore;

namespace FDS.CRM.Application.Position.Queries
{
    public class GetPositionQuery : IQuery<ResultModel<List<PositionDto>>>
    {
        public GetPositionQuery() { }
    }

    public class GetPositionsQueryHandler : IQueryHandler<GetPositionQuery, ResultModel<List<PositionDto>>>
    {
        private readonly IPositionRepository _positionRepository;

        public GetPositionsQueryHandler(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public async Task<ResultModel<List<PositionDto>>> HandleAsync(GetPositionQuery query, CancellationToken cancellationToken)
        {
            //var positions = await _positionRepository.GetGroupedPositionsAsync();

            //var result = positions
            //    .GroupBy(p => p.Department)
            //    .Select(g => new PositionGroupDto
            //    {
            //        DepartmentId = g.Key.Id,
            //        DepartmentName = g.Key.Name,
            //        Positions = g.Select(p => new PositionDto
            //        {
            //            Id = p.Id,
            //            Title = p.Title
            //        }).ToList()
            //    })
            //    .ToList();

            var result = await _positionRepository.GetQueryableSet()
                    .GroupBy(p => p.Title) 
                        .Select(g => new PositionDto
                        {
                            Id = g.Min(p => p.Id),  
                            Title = g.Key  
                        })
                    .ToListAsync();

            return ResultModel<List<PositionDto>>.Create(result);
        }
    }
}
