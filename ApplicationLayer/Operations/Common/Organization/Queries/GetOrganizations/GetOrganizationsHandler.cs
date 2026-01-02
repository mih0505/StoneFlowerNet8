using ApplicationLayer.Infrastructure;
using ApplicationLayer.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Operations.Common.Organization.Queries.GetOrganizations
{
    internal class GetOrganizationsHandler : RequestHandlerBase<GetOrganizationsQuery, List<OrganizationDTO>>
    {
        public GetOrganizationsHandler(IStoneFlowersDbContext context, IMapper _mapper) : base(context, _mapper)
        {
        }

        public override async Task<List<OrganizationDTO>> Handle(GetOrganizationsQuery request, CancellationToken cancellationToken)
        {
            var organizations = await db.Organizations
                .Where(o => !o.IsDeleted)
                .OrderBy(o => o.Name)
                .ProjectTo<OrganizationDTO>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return organizations;
        }
    }
}
