using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FinancasApi.DTOs;
using FinancasApi.Models;
using FinancasApi.Data.Repository;

namespace FinancasApi.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionReadDTO>> GetAllByUserAsync(int userId);
        Task<TransactionReadDTO> GetByIdAsync(int id);
        Task<TransactionReadDTO> CreateAsync(TransactionCreateDTO dto, int userId);
        Task<bool> UpdateAsync(int id, TransactionUpdateDTO dto, int userId);
        Task<bool> DeleteAsync(int id, int userId);
    }

    public class TransactionService : ITransactionService
    {
        private readonly IRepository<Transaction> _transactionRepo;
        private readonly IMapper _mapper;

        public TransactionService(IRepository<Transaction> transactionRepo, IMapper mapper)
        {
            _transactionRepo = transactionRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TransactionReadDTO>> GetAllByUserAsync(int userId)
        {
            var transactions = await _transactionRepo.GetAllAsync(t => t.UserId == userId);
            return _mapper.Map<IEnumerable<TransactionReadDTO>>(transactions);
        }

        public async Task<TransactionReadDTO> GetByIdAsync(int id)
        {
            var transaction = await _transactionRepo.GetByIdAsync(id);
            return _mapper.Map<TransactionReadDTO>(transaction);
        }

        public async Task<TransactionReadDTO> CreateAsync(TransactionCreateDTO dto, int userId)
        {
            var entity = _mapper.Map<Transaction>(dto);

            entity.Date = dto.Date ?? DateTime.UtcNow;
            entity.UserId = userId;

            await _transactionRepo.AddAsync(entity);
            return _mapper.Map<TransactionReadDTO>(entity);
        }

        public async Task<bool> UpdateAsync(int id, TransactionUpdateDTO dto, int userId)
        {
            var existing = await _transactionRepo.GetByIdAsync(id);
            if (existing == null || existing.UserId != userId) return false;

            _mapper.Map(dto, existing);
            await _transactionRepo.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, int userId)
        {
            var transaction = await _transactionRepo.GetByIdAsync(id);
            if (transaction == null || transaction.UserId != userId) return false;

            await _transactionRepo.DeleteAsync(transaction);
            return true;
        }
    }
}
