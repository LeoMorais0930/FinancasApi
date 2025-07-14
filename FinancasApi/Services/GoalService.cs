using FinancasApi.DTOs;
using FinancasApi.Models;
using FinancasApi.Data.Repository;
using AutoMapper;

namespace FinancasApi.Services
{
    public interface IGoalService
    {
        Task<IEnumerable<GoalReadDTO>> GetAllByUserAsync(int userId);
        Task<GoalReadDTO> GetByIdAsync(int id);
        Task<GoalReadDTO> CreateAsync(GoalCreateDTO dto, int userId);
        Task<bool> UpdateAsync(int id, GoalUpdateDTO dto, int userId);
        Task<bool> DeleteAsync(int id, int userId);
    }

    public class GoalService : IGoalService
    {
        private readonly IRepository<Goal> _goalRepo;
        private readonly IMapper _mapper;

        public GoalService(IRepository<Goal> goalRepo, IMapper mapper)
        {
            _goalRepo = goalRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GoalReadDTO>> GetAllByUserAsync(int userId)
        {
            var goals = await _goalRepo.GetAllAsync(g => g.UserId == userId);
            return _mapper.Map<IEnumerable<GoalReadDTO>>(goals);
        }

        public async Task<GoalReadDTO> GetByIdAsync(int id)
        {
            var goal = await _goalRepo.GetByIdAsync(id);
            return _mapper.Map<GoalReadDTO>(goal);
        }

        public async Task<GoalReadDTO> CreateAsync(GoalCreateDTO dto, int userId)
        {
            var entity = _mapper.Map<Goal>(dto);
            entity.UserId = userId;

            await _goalRepo.AddAsync(entity);
            return _mapper.Map<GoalReadDTO>(entity);
        }

        public async Task<bool> UpdateAsync(int id, GoalUpdateDTO dto, int userId)
        {
            var existing = await _goalRepo.GetByIdAsync(id);
            if (existing == null || existing.UserId != userId) return false;

            _mapper.Map(dto, existing);
            await _goalRepo.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, int userId)
        {
            var goal = await _goalRepo.GetByIdAsync(id);
            if (goal == null || goal.UserId != userId) return false;

            await _goalRepo.DeleteAsync(goal);
            return true;
        }
    }
}
