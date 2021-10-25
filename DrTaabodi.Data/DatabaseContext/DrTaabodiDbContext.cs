using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrTaabodi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DrTaabodi.Data.DatabaseContext
{
    public class DrTaabodiDbContext: IdentityDbContext
    {
        public DrTaabodiDbContext(){}
        public DrTaabodiDbContext(DbContextOptions opt):base(opt){}

       

       
        public virtual DbSet<PstTbl> PstTbl { get; set; }
        public virtual DbSet<QnATbl> QnATbl { get; set; }
        public virtual DbSet<UsrTbl> UsrTbl { get; set; }
        public virtual DbSet<PostCategoryTbl> PostCategoryTbl { get; set; }
        public virtual DbSet<PostTypeTbl> PostTypeTbl { get; set; }
        public virtual DbSet<WebsiteOptionsTbl> WebsiteOptionsTbls { get; set; }
        //public virtual DbSet<PostTblRelations> PostTblRelations {  get; set; }
        //public virtual DbSet<PostTypeRelations> PostTypeRelations {  get; set; }
       // public virtual DbSet<PostCategoryTblRelation> PostCategoryTblRelations {  get; set; }
    }
}
