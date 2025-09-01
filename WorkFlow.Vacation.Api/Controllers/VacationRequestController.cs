using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using WorkFlow.Vacation.Application.Models.InputModels;
using WorkFlow.Vacation.Application.Services;
using WorkFlow.Vacation.Core.Enums;

namespace WorkFlow.Vacation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class VacationRequestController : ControllerBase
    {
        private readonly IVacationRequestService _service;

        public VacationRequestController(IVacationRequestService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
           [FromQuery] int? collaboratorId,
           [FromQuery] VacationRequestStatusEnum status,
           [FromQuery] DateOnly? startDate,
           [FromQuery] DateOnly? endDate,
           [FromQuery] int page = 1,
           [FromQuery] int pageSize = 10)
        {
            var vacations = await _service.GetAllAsync(collaboratorId, status, startDate, endDate, page, pageSize);
            return Ok(vacations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vacation = await _service.GetByIdAsync(id);
            if (vacation == null)
                return NotFound(new { Message = "Pedido de férias não encontrado." });

            return Ok(vacation);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VacationRequestInputModel input)
        {
            var result = await _service.CreateAsync(input);
            if(result?.Data?.Id == null)
            {
                return Conflict(new { message = result.Message });

            }
            return CreatedAtAction(nameof(GetById), new { id = result?.Data?.Id }, result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] VacationRequestInputModel input)
        {
            var result = await _service.UpdateAsync(id, input);
            if (result?.Data?.Id == null)
            {
                return Conflict(new { message = result.Message });

            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}
