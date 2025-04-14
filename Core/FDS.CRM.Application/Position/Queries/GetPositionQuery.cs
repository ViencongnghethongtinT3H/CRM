using FDS.CRM.Application.Common.DTOs;
using FDS.CRM.Application.Position.DTOs;
using FDS.CRM.CrossCuttingConcerns.Cache.Constants;
using FDS.CRM.CrossCuttingConcerns.Cache.RedisCache;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

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
            var result = new List<PositionDto>();
            var redisKey = RedisKeyConstants.GetPosition;
            if (await RedisConnection.Connection.ExistsAsync(redisKey))
            {
                result = await RedisConnection.Connection.GetAsync<List<PositionDto>>(redisKey);                
            }
            else
            {
                 result = await _positionRepository.GetQueryableSet()
                   .GroupBy(p => p.Title)
                       .Select(g => new PositionDto
                       {
                           Id = g.Min(p => p.Id),
                           Title = g.Key
                       })
                   .ToListAsync();
                await RedisConnection.Connection.AddAsync(redisKey, result);
            }
            return ResultModel<List<PositionDto>>.Create(result);
        }
    }
}
