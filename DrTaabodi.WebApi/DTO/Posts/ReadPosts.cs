﻿using System;
using System.Collections.Generic;

namespace DrTaabodi.WebApi.DTO.Posts;

public class ReadPosts
{
    public Guid PstId { get; set; }
    public Guid User { get; set; }
    public string PstContent { get; set; }
    public string PstTitle { get; set; }
    public string PstDescription { get; set; }

    public Guid PstTbleParent { get; set; }
    public ICollection<Guid> PostCategory { get; set; }
    public ICollection<Guid> PostType { get; set; }
    public ICollection<Guid> Meta { get; set; }

    public ICollection<Guid> Categories { get; set; }
}