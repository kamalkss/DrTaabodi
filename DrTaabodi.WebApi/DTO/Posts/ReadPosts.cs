using System;
using DrTaabodi.Data.Models;

namespace DrTaabodi.WebApi.DTO.Posts;

public class ReadPosts
{
    public Guid PstId { get; set; }
    public Guid User { get; set; }
    public string PstContent { get; set; }
    public string PstTitle { get; set; }
    public string PstDescription { get; set; }

    public Guid PstTbleParent { get; set; }
    public Guid PostCategory { get; set; }
    public Guid PostType { get; set; }
    public Guid Meta { get; set; }
}