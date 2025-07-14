using FinancasApi.DTOs;
using FinancasApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancasApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoalController : ControllerBase
    {
        private readonly IGoalService _goalService;

        public GoalController(IGoalService goalService)
        {
            _goalService = goalService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<GoalReadDTO>>> GetAll(int userId)
        {
            var goals = await _goalService.GetAllByUserAsync(userId);
            return Ok(goals);
        }

        [HttpGet("{userId}/{id}")]
        public async Task<ActionResult<GoalReadDTO>> GetById(int userId, int id)
        {
            var goal = await _goalService.GetByIdAsync(id);
            if (goal == null) return NotFound();
            return Ok(goal);
        }

        [HttpPost("{userId}")]
        public async Task<ActionResult<GoalReadDTO>> Create(int userId, GoalCreateDTO dto)
        {
            var created = await _goalService.CreateAsync(dto, userId);
            return CreatedAtAction(nameof(GetById), new { userId, id = created.Id }, created);
        }

        [HttpPut("{userId}/{id}")]
        public async Task<IActionResult> Update(int userId, int id, GoalUpdateDTO dto)
        {
            var success = await _goalService.UpdateAsync(id, dto, userId);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{userId}/{id}")]
        public async Task<IActionResult> Delete(int userId, int id)
        {
            var success = await _goalService.DeleteAsync(id, userId);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
