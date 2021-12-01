using AutoMapper;
using DrTaabodi.Data.Models;
using DrTaabodi.WebApi.DTO.PostType;

namespace DrTaabodi.WebApi.Profiles;

public class PostTypeProfile : Profile
{
    public PostTypeProfile()
    {
        CreateMap<CreatePostType, PostTypeTbl>();
        CreateMap<ReadPostType, PostTypeTbl>();
        CreateMap<PostTypeTbl, CreatePostType>();
        CreateMap<PostTypeTbl, ReadPostType>();

        CreateMap<CreatePostType, PostTypeTbl>().ReverseMap();
        CreateMap<ReadPostType, PostTypeTbl>().ReverseMap();
        CreateMap<PostTypeTbl, CreatePostType>().ReverseMap();
        CreateMap<PostTypeTbl, ReadPostType>().ReverseMap();
    }
}