using ApplicationLayer.Interfaces;
using AutoMapper;
using MediatR;

namespace ApplicationLayer.Infrastructure
{
    public abstract class RequestHandlerBase<TRequest, TResponse>
        : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private protected readonly IStoneFlowersDbContext db;
        private protected readonly IMapper mapper;

        public RequestHandlerBase(IStoneFlowersDbContext context)
            => db = context;

        public RequestHandlerBase(IStoneFlowersDbContext context, IMapper _mapper)
            => (db, mapper) = (context, _mapper);

        public abstract Task<TResponse> Handle(TRequest request,
                CancellationToken cancellationToken);
    }
}
