using MediatR;

namespace ApplicationLayer.Infrastructure
{
    public abstract class FacadeBase
    {
        private protected readonly IMediator _mediator;

        public FacadeBase(IMediator mediator)
            => _mediator = mediator;

    }
}
