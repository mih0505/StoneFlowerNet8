using ApplicationLayer.Infrastructure;
using ApplicationLayer.Operations.Common.Department.Commands.Create;
using ApplicationLayer.Operations.Common.Department.Commands.Delete;
using ApplicationLayer.Operations.Common.Department.Commands.Update;
using ApplicationLayer.Operations.Common.Department.Queries.GetDepartmentById;
using ApplicationLayer.Operations.Common.Department.Queries.GetDepartments;
using ApplicationLayer.Operations.Common.Organization.Queries.GetOrganizationById;
using MediatR;

namespace ApplicationLayer.Operations.Common.Department
{
    public class DepartmentFacade : FacadeBase
    {
        public DepartmentFacade(IMediator mediator)
            : base(mediator)
        { }

        /// <summary>
        /// Создание филиала (подразделения) организации
        /// </summary>
        /// <param name="dto">Транспортная модель подразделения</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Идентификатор подразделения</returns>
        public async Task<Guid> CreateAsync(CreateDepartmentCommandDTO dto, CancellationToken cancellationToken)
        {
            var organization = await GetOrganizationAsync(dto.OrganizationId, cancellationToken);

            var command = new CreateDepartmentCommand
            {
                Code = dto.Code,
                Organization = organization,
                Name = dto.Name,
                City = dto.City,
                Street = dto.Street,
                House = dto.House,
                Float = dto.Float,
                PhoneNumber = dto.PhoneNumber,
                AdvancedPhoneNumber = dto.AdvancedPhoneNumber,
                Email = dto.Email,
            };

            var departmentId = await _mediator.Send(command, cancellationToken);
            return departmentId;
        }

        /// <summary>
        /// Редактирование подразделения
        /// </summary>
        /// <param name="dto">Транспортная модель</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateDepartmentDTO dto, CancellationToken cancellationToken)
        {
            var organization = await GetOrganizationAsync(dto.OrganizationId, cancellationToken);

            var command = new UpdateDepartmentCommand
            {
                Id = dto.Id,
                Code = dto.Code,
                Organization = organization,
                Name = dto.Name,
                City = dto.City,
                Street = dto.Street,
                House = dto.House,
                Float = dto.Float,
                PhoneNumber = dto.PhoneNumber,
                AdvancedPhoneNumber = dto.AdvancedPhoneNumber,
                Email = dto.Email,
            };

            await _mediator.Send(command, cancellationToken);
        }

        /// <summary>
        /// Удаление подразделения
        /// </summary>
        /// <param name="id">Идентификатор подразделения</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteDepartmentCommand
            {
                DepartmentId = id,
            };

            await _mediator.Send(command, cancellationToken);
        }

        /// <summary>
        /// Получить подразделение организации
        /// </summary>
        /// <param name="id">Идентификатор подразделения</param>
        /// <returns>Подразделение</returns>
        public async Task<Domain.Common.Department> GetDepartmentAsync(Guid id)
        {
            if (id == Guid.Empty)
                return null;

            return await _mediator.Send(new GetDepartmentByIdQuery
            {
                Id = id,
            });
        }

        /// <summary>
        /// Получить список подразделений организации
        /// </summary>
        /// <returns>Список подразделений</returns>
        public async Task<List<DepartmentDTO>> GetDepartmentsAsync()
        {
            return await _mediator.Send(new GetDepartmentsQuery());
        }

        /// <summary>
        /// Получить организацию
        /// </summary>
        /// <param name="organizationId">Идентификатор организации</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task<Domain.Common.Organization> GetOrganizationAsync(Guid organizationId, CancellationToken cancellationToken)
        {
            var query = new GetOrganizationByIdQuery
            {
                Id = organizationId
            };

            return await _mediator.Send(query, cancellationToken);
        }
    }
}
