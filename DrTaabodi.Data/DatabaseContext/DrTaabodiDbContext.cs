using System.Linq;
using DrTaabodi.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DrTaabodi.Data.DatabaseContext;

public class DrTaabodiDbContext : IdentityDbContext
{
    public DrTaabodiDbContext()
    {
    }

    public DrTaabodiDbContext(DbContextOptions opt) : base(opt)
    {
    }

    public void DetachAllEntities()
    {
        var changedEntriesCopy = this.ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added ||
                        e.State == EntityState.Modified ||
                        e.State == EntityState.Deleted)
            .ToList();

        foreach (var entry in changedEntriesCopy)
            entry.State = EntityState.Detached;
    }
    public virtual DbSet<PstTbl> PstTbl { get; set; }
    public virtual DbSet<QnATbl> QnATbl { get; set; }
    public virtual DbSet<UsrTbl> UsrTbl { get; set; }
    public virtual DbSet<PostCategoryTbl> PostCategoryTbl { get; set; }
    public virtual DbSet<PostTypeTbl> PostTypeTbl { get; set; }
    public virtual DbSet<WebsiteOptionsTbl> WebsiteOptionsTbls { get; set; }
    public virtual DbSet<FileSystemTbl> FileSystem { get; set; }
    public virtual DbSet<MetaTbl> MetaTbl { get; set; }
    //public virtual DbSet<PostTblRelations> PostTblRelations {  get; set; }
    //public virtual DbSet<PostTypeRelations> PostTypeRelations {  get; set; }
    // public virtual DbSet<PostCategoryTblRelation> PostCategoryTblRelations {  get; set; }
}