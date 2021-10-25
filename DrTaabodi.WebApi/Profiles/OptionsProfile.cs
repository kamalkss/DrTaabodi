using AutoMapper;
using DrTaabodi.Data.Models;
using DrTaabodi.WebApi.DTO.WebsiteOptions;

namespace DrTaabodi.WebApi.Profiles
{
    public class OptionsProfile: Profile
    {
        public OptionsProfile()
        {
            CreateMap<CreateOption, WebsiteOptionsTbl>();
            CreateMap<WebsiteOptionsTbl, UpdateOption>();
            CreateMap<CreateOption,WebsiteOptionsTbl>().ReverseMap();
            CreateMap<WebsiteOptionsTbl,UpdateOption>().ReverseMap();
        }
    }
}
