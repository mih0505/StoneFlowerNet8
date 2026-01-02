using ApplicationLayer.Operations.Common.Organization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace StoneFlowersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationsController : ControllerBase
    {
        private readonly OrganizationFacade _facade;

        public OrganizationsController(OrganizationFacade facade)
        {
            _facade = facade;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orgs = await _facade.GetOrganizationsAsync();
            return Ok(orgs);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var org = await _facade.GetOrganizationDetailAsync(id);
            if (org == null) return NotFound();

            return Ok(org);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ApplicationLayer.Operations.Common.Organization.Commands.Create.CreateOrganizationCommandDTO dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Name))
                return BadRequest("Invalid organization data");

            var id = await _facade.CreateAsync(dto, CancellationToken.None);
            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ApplicationLayer.Operations.Common.Organization.Commands.Update.UpdateOrganizationDTO dto)
        {
            if (dto == null || id == Guid.Empty || id != dto.Id)
                return BadRequest("Invalid organization data");

            await _facade.UpdateAsync(dto, CancellationToken.None);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            await _facade.DeleteAsync(id, CancellationToken.None);
            return NoContent();
        }
    }
}
