using AutoMapper;
using DrTaabodi.Data.Models;
using DrTaabodi.WebApi.DTO.Posts;
using DrTaabodi.WebApi.DTO.QnAs;

namespace DrTaabodi.WebApi.Profiles
{
    public class QnAProfiles:Profile
    {
        public QnAProfiles()
        {
            CreateMap<QnATbl, ReadQnAs>();
            CreateMap<CreateQnAs, QnATbl>();
            CreateMap<ReadQnAs, QnATbl>();
        }
    }
}
