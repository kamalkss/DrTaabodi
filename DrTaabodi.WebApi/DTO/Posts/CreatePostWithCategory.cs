using System;

namespace DrTaabodi.WebApi.DTO.Posts;

public class CreatePostWithCategory
{
    public Guid User { get; set; }
    public string PstContent { get; set; }
    public string PstTitle { get; set; }
    public string PstDescription { get; set; }

    public Guid PstTbleParent { get; set; }
    public Guid PostCategory { get; set; }


}