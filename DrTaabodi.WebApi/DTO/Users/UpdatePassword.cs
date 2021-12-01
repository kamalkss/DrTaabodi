using System;

namespace DrTaabodi.WebApi.DTO.Users;

public class UpdatePassword
{
    public Guid UsrId { get; set; }
    public string PassCode { get; set; }
}