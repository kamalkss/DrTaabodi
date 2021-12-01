using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DrTaabodi.Data.Models;

public class UsrTbl
{
    public UsrTbl()
    {
        PostTable = new HashSet<PstTbl>();
        QuestionAndAnswerTable = new HashSet<QnATbl>();
    }

    [Key] [Required] public Guid UsrId { get; set; }
    [Required] public DateTime CreatedDate { get; set; }
    [Required] public DateTime UpdatedData { get; set; }
    [MaxLength(150)] public string UserName { get; set; }
    [MaxLength(150)] public string PassCode { get; set; }
    public string UsrNickName { get; set; }
    public string UsrFamily { get; set; }
    public string UsrEmail { get; set; }
    public UserStatus UsrStatus { get; set; }
    public virtual ICollection<PstTbl> PostTable { get; set; }
    public virtual ICollection<QnATbl> QuestionAndAnswerTable { get; set; }
}

public enum UserStatus
{
    Admin,
    SuperUser,
    User
}