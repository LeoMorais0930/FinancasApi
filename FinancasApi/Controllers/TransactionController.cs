using FinancasApi.DTOs;
using FinancasApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancasApi.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    [Tags("2 - Transactions")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<TransactionReadDTO>>> GetAll(int userId)
        {
            var transactions = await _transactionService.GetAllByUserAsync(userId);
            return Ok(transactions);
        }

        [HttpGet("{userId}/{id}")]
        public async Task<ActionResult<TransactionReadDTO>> GetById(int userId, int id)
        {
            var transaction = await _transactionService.GetByIdAsync(id);
            if (transaction == null) return NotFound();
            return Ok(transaction);
        }

        [HttpPost("{userId}")]
        public async Task<ActionResult<TransactionReadDTO>> Create(int userId, TransactionCreateDTO dto)
        {
            var created = await _transactionService.CreateAsync(dto, userId);
            return CreatedAtAction(nameof(GetById), new { userId, id = created.Id }, created);
        }

        [HttpPut("{userId}/{id}")]
        public async Task<IActionResult> Update(int userId, int id, TransactionUpdateDTO dto)
        {
            var success = await _transactionService.UpdateAsync(id, dto, userId);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{userId}/{id}")]
        public async Task<IActionResult> Delete(int userId, int id)
        {
            var success = await _transactionService.DeleteAsync(id, userId);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
