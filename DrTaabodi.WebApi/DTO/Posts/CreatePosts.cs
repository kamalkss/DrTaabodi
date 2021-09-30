﻿using System;
using System.ComponentModel.DataAnnotations;
using DrTaabodi.Data.Models;
using DrTaabodi.WebApi.DTO.Users;

namespace DrTaabodi.WebApi.DTO.Posts
{
    public class CreatePosts
    {
         
         public Guid User { get; set; }
         public string PstContent { get; set; }
         public string PstTitle { get; set; }
         public string PstDescription { get; set; }

         public Guid PstTbleParent { get; set; }
    }
}
