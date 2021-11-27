using System.Linq;
using AutoMapper;
using DrTaabodi.Data.Models;
using DrTaabodi.WebApi.DTO.Posts;

namespace DrTaabodi.WebApi.Profiles
{
    public class PostsProfile : Profile
    {
        public PostsProfile()
        {
            CreateMap<PstTbl, ReadPosts>();
            CreateMap<CreatePosts, PstTbl>();
            CreateMap<PstTbl,CreatePosts>();
            CreateMap<ReadPosts, PstTbl>();
            CreateMap<CreatePostWithTypeAndCategory,PstTbl>();
            CreateMap<PstTbl, CreatePostWithTypeAndCategory>();

            CreateMap<PstTbl, ReadPosts>().ReverseMap();
            CreateMap<CreatePosts, PstTbl>().ReverseMap();
            CreateMap<PstTbl, CreatePosts>().ReverseMap();
            CreateMap<ReadPosts, PstTbl>().ReverseMap();
            CreateMap<CreatePostWithTypeAndCategory, PstTbl>().ReverseMap();
            CreateMap<PstTbl, CreatePostWithTypeAndCategory>().ReverseMap();
        }

    }
}
