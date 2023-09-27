using AutoMapper;
using AutoMapper.QueryableExtensions;
using BokCounter.Users.Query.Application.AppUsers.Dtos;
using BokCounter.Users.Query.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BokCounter.Users.Query.Application.AppUsers.Queries;

public static class GetAppUsers
{
    public sealed record Query : IRequest<IEnumerable<AppUserDto>>;
    public sealed class Handler : IRequestHandler<Query, IEnumerable<AppUserDto>>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public Handler(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AppUserDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var appUserDto = await _appDbContext.AppUsers
                .ProjectTo<AppUserDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return appUserDto;
        }
    }
}
