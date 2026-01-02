using ApplicationLayer.Infrastructure;
using ApplicationLayer.Operations.Common.Organization.Commands.Create;
using ApplicationLayer.Operations.Common.Organization.Commands.Delete;
using ApplicationLayer.Operations.Common.Organization.Commands.Update;
using ApplicationLayer.Operations.Common.Organization.Queries.GetOrganizationById;
using ApplicationLayer.Operations.Common.Organization.Queries.GetOrganizations;
using MediatR;

namespace ApplicationLayer.Operations.Common.Organization
{
    public class OrganizationFacade : FacadeBase
    {
        public OrganizationFacade(IMediator mediator)
               : base(mediator)
        { }

        /// <summary>
        /// Создание организации
        /// </summary>
        /// <param name="dto">Транспортная модель организации</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Идентификатор подразделения</returns>
        public async Task<Guid> CreateAsync(CreateOrganizationCommandDTO dto, CancellationToken cancellationToken)
        {
            var command = new CreateOrganizationCommand
            {                
                Name = dto.Name,                
            };

            var departmentId = await _mediator.Send(command, cancellationToken);
            return departmentId;
        }

        /// <summary>
        /// Редактирование организации
        /// </summary>
        /// <param name="dto">Транспортная модель</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateOrganizationDTO dto, CancellationToken cancellationToken)
        {
            var command = new UpdateOrganizationCommand
            {
                Id = dto.Id,               
                Name = dto.Name,               
            };

            await _mediator.Send(command, cancellationToken);
        }

        /// <summary>
        /// Удаление организации
        /// </summary>
        /// <param name="id">Идентификатор подразделения</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteOrganizationCommand
            {
                OrganizationId = id,
            };

            await _mediator.Send(command, cancellationToken);
        }

        /// <summary>
        /// Получить организацию
        /// </summary>
        /// <param name="id">Идентификатор подразделения</param>
        /// <returns>Подразделение</returns>
        public async Task<Domain.Common.Organization> GetOrganizationAsync(Guid id)
        {
            if (id == Guid.Empty)
                return null;                       

            return await _mediator.Send(new GetOrganizationByIdQuery
            {
                Id = id,
            });
        }

        /// <summary>
        /// Получить список организаций
        /// </summary>
        /// <returns>Список организаций</returns>
        public async Task<List<OrganizationDTO>> GetOrganizationsAsync()
        {            
            return await _mediator.Send(new GetOrganizationsQuery());
        }        
    }
}
