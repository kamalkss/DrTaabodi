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
            CreateMap<ReadPosts, PstTbl>();
            CreateMap<PstTbl, PostWithUsers>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserTable))
                .ForPath(dest=>dest.UserId,opt=>opt.MapFrom(src=>src.UserTable))
                .ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => src.PstTbleParent.PstId))
                ;
            CreateMap<PostWithUsers, PstTbl>()
                .ForMember(c => c.UserTable, opt => opt.MapFrom(c => c.UserId))
                //.ForPath(dest=>dest.UserTable.Select(c=>c.UsrId),opt=>opt.MapFrom(src=>src.UserId))
                .ForMember(c => c.PstTbleParent, opt => opt.MapFrom(c => c.ParentId))
                .ForPath(dest=>dest.PstTbleParent.PstId,opt=>opt.MapFrom(src=>src.ParentId))
                .ReverseMap();
            //.AfterMap((Src, Dest) =>
            //{
            //    foreach (var VARIABLE in Dest.UserTable)
            //    {
            //        VARIABLE.UsrId = Src.UserId;
            //    }
            //});

        }

    }
}
