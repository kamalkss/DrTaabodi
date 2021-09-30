﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DrTaabodi.Data.Models;

namespace DrTaabodi.WebApi.DTO.PostType
{
    public class ReadPostType
    {
        [Required] public Guid PostTypeId { get; set; }
        [Required] public string PostTypeName { get; set; }
        [Required] public DateTime CreatedDate { get; set; }
        [Required] public DateTime UpdatedData { get; set; }
        public virtual ICollection<PostTypeTbl> PostTypeParent { get; set; }
        public virtual ICollection<PstTbl> PostTable { get; set; }
    }
}