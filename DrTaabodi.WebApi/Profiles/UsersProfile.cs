using AutoMapper;
using DrTaabodi.Data.Models;
using DrTaabodi.WebApi.DTO.Users;

namespace DrTaabodi.WebApi.Profiles;

public class UsersProfile : Profile
{
    public UsersProfile()
    {
        CreateMap<UsrTbl, ReadUsers>();
        CreateMap<CreateUsers, UsrTbl>();
        CreateMap<ReadUsers, UsrTbl>();
        CreateMap<Login, UsrTbl>();
        CreateMap<UsrTbl, Login>();
        CreateMap<UsrTbl, UpdatePassword>();
        CreateMap<UsrTbl, UpdateUser>();
        CreateMap<UpdatePassword, UsrTbl>();
        CreateMap<UpdateUser, UsrTbl>();


        CreateMap<UsrTbl, ReadUsers>().ReverseMap();
        CreateMap<CreateUsers, UsrTbl>().ReverseMap();
        CreateMap<ReadUsers, UsrTbl>().ReverseMap();
        CreateMap<Login, UsrTbl>().ReverseMap();
        CreateMap<UsrTbl, Login>().ReverseMap();
        CreateMap<UsrTbl, UpdatePassword>().ReverseMap();
        CreateMap<UsrTbl, UpdateUser>().ReverseMap();
        CreateMap<UpdatePassword, UsrTbl>().ReverseMap();
        CreateMap<UpdateUser, UsrTbl>().ReverseMap();
    }
}