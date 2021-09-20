using AutoMapper;
using DrTaabodi.Data.Models;
using DrTaabodi.WebApi.DTO.QnAs;
using DrTaabodi.WebApi.DTO.Users;

namespace DrTaabodi.WebApi.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<UsrTbl, ReadUsers>();
            CreateMap<CreateUsers, UsrTbl>();
            CreateMap<ReadUsers, UsrTbl>();
        }
    }
}
