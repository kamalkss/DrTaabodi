using AutoMapper;
using DrTaabodi.Data.Models;
using DrTaabodi.WebApi.DTO.Meta;

namespace DrTaabodi.WebApi.Profiles;

public class MetaProfile : Profile
{
    public MetaProfile()
    {
        CreateMap<CreateMeta, MetaTbl>();
        CreateMap<MetaTbl, ReadMeta>();
        CreateMap<CreateMeta, MetaTbl>().ReverseMap();
        CreateMap<MetaTbl, ReadMeta>().ReverseMap();
    }
}