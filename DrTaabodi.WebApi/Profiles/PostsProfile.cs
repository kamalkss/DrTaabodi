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
            CreateMap<ReadPosts, PstTbl>();
        }

    }
}
