using AutoMapper;
using DrTaabodi.Data.Models;
using DrTaabodi.WebApi.DTO.PostCategory;

namespace DrTaabodi.WebApi.Profiles;

public class PostCategoryProfile : Profile
{
    public PostCategoryProfile()
    {
        CreateMap<CreatePostCategory, PostCategoryTbl>();
        CreateMap<ReadPostCategory, PostCategoryTbl>();
        CreateMap<PostCategoryTbl, CreatePostCategory>();
        CreateMap<PostCategoryTbl, ReadPostCategory>();

        CreateMap<CreatePostCategory, PostTypeTbl>().ReverseMap();
        CreateMap<ReadPostCategory, PostTypeTbl>().ReverseMap();
        CreateMap<PostCategoryTbl, CreatePostCategory>().ReverseMap();
        CreateMap<PostCategoryTbl, ReadPostCategory>().ReverseMap();
    }
}