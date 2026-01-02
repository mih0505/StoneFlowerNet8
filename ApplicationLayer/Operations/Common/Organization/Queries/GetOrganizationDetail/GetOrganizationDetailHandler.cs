using ApplicationLayer.Infrastructure;
using ApplicationLayer.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Operations.Common.Organization.Queries.GetOrganizationDetail
{
    internal class GetOrganizationDetailHandler : RequestHandlerBase<GetOrganizationDetailQuery, OrganizationDetailDTO>
    {
        public GetOrganizationDetailHandler(IStoneFlowersDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<OrganizationDetailDTO> Handle(GetOrganizationDetailQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
                return null;

            var dto = await db.Organizations
                .Where(o => !o.IsDeleted && o.Id == request.Id)
                .ProjectTo<OrganizationDetailDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            return dto;
        }
    }
}