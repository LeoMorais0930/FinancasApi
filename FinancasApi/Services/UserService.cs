using FinancasApi.DTOs;
using FinancasApi.Models;
using FinancasApi.Data.Repository;
using AutoMapper;

namespace FinancasApi.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserReadDTO>> GetAllAsync();
        Task<UserReadDTO> GetByIdAsync(int id);
        Task<UserReadDTO> CreateAsync(UserCreateDTO dto);
        Task<bool> UpdateAsync(int id, UserUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
    }

    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepo;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserReadDTO>> GetAllAsync()
        {
            var users = await _userRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<UserReadDTO>>(users);
        }

        public async Task<UserReadDTO> GetByIdAsync(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            return _mapper.Map<UserReadDTO>(user);
        }

        public async Task<UserReadDTO> CreateAsync(UserCreateDTO dto)
        {
            var entity = _mapper.Map<User>(dto);
            await _userRepo.AddAsync(entity);
            return _mapper.Map<UserReadDTO>(entity);
        }

        public async Task<bool> UpdateAsync(int id, UserUpdateDTO dto)
        {
            var existing = await _userRepo.GetByIdAsync(id);
            if (existing == null) return false;

            _mapper.Map(dto, existing);
            await _userRepo.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null) return false;

            await _userRepo.DeleteAsync(user);
            return true;
        }
    }
}
