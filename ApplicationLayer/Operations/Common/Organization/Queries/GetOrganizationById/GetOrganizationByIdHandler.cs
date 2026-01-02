using ApplicationLayer.Infrastructure;
using ApplicationLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Operations.Common.Organization.Queries.GetOrganizationById
{
    internal class GetOrganizationByIdHandler : RequestHandlerBase<GetOrganizationByIdQuery, Domain.Common.Organization>
    {
        public GetOrganizationByIdHandler(IStoneFlowersDbContext context) : base(context)
        { }

        public override async Task<Domain.Common.Organization> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
        {
            var organization = await db.Organizations
                .Include(o => o.Departments)
                .FirstOrDefaultAsync(org => org.Id == request.Id, cancellationToken);

            if (organization is null)
            {
                throw new ArgumentNullException();
            }

            return organization;
        }
    }
}
