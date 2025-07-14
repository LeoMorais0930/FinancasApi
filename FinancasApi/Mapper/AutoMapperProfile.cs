using AutoMapper;
using FinancasApi.Models;
using FinancasApi.DTOs;

namespace FinancasApi.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User
            CreateMap<User, UserReadDTO>();
            CreateMap<UserCreateDTO, User>();
            CreateMap<UserUpdateDTO, User>();

            // Transaction
            CreateMap<Transaction, TransactionReadDTO>();
            CreateMap<TransactionCreateDTO, Transaction>();
            CreateMap<TransactionUpdateDTO, Transaction>();

            // Goal
            CreateMap<Goal, GoalReadDTO>();
            CreateMap<GoalCreateDTO, Goal>();
            CreateMap<GoalUpdateDTO, Goal>();
        }
    }
}
