using System;
using System.Collections.Generic;
using DrTaabodi.WebApi.DTO.Meta;

namespace DrTaabodi.WebApi.DTO.Posts;

public class CreatePostWithTypeAndCategory
{
    public Guid User { get; set; }
    public string PstContent { get; set; }
    public string PstTitle { get; set; }
    public string PstDescription { get; set; }

    public Guid PstTbleParent { get; set; }
    public ICollection<Guid> PostCategory { get; set; }
    public ICollection<Guid> PostType { get; set; }
    public ICollection<CreateMeta> Meta { get; set; }
}