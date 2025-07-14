using AutoMapper;
using FinancasApi.Models;
using FinancasApi.DTOs;

namespace FinancasApi.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserReadDTO>().ReverseMap();
            CreateMap<UserCreateDTO, User>();
            CreateMap<UserUpdateDTO, User>();

            CreateMap<Transaction, TransactionReadDTO>().ReverseMap();
            CreateMap<TransactionCreateDTO, Transaction>();
            CreateMap<TransactionUpdateDTO, Transaction>();

            CreateMap<Goal, GoalReadDTO>().ReverseMap();
            CreateMap<GoalCreateDTO, Goal>();
            CreateMap<GoalUpdateDTO, Goal>();
        }
    }
}
