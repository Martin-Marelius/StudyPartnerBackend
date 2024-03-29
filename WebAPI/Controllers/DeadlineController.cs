using BusinessLogic.IBL;
using Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeadlineController : ControllerBase
    {
        private readonly IDeadlineBL deadlineBL;

        public DeadlineController(IDeadlineBL deadlineBL)
        {
            this.deadlineBL = deadlineBL;
        }

        [HttpGet("{deadlineId}")]
        public async Task<IActionResult> GetDeadline(string deadlineId)
        {
            try
            {
                var deadline = await deadlineBL.GetDeadline(deadlineId);
                if (deadline == null)
                    return NotFound();

                return Ok(deadline);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddDeadline([FromBody] Deadline deadline)
        {
            try
            {
                await deadlineBL.AddDeadline(deadline);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{deadlineId}")]
        public async Task<IActionResult> UpdateDeadline(string deadlineId, [FromBody] Deadline deadline)
        {
            try
            {
                await deadlineBL.UpdateDeadline(deadline, deadlineId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{deadlineId}")]
        public async Task<IActionResult> DeleteDeadline(string deadlineId)
        {
            try
            {
                await deadlineBL.DeleteDeadline(deadlineId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
