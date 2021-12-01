using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DrTaabodi.Data.Models;

namespace DrTaabodi.Services.UserTable;

public interface IUser
{
    public Task<bool> SaveChanges();
    public Task<IEnumerable<UsrTbl>> GetAllUsers();
    public Task<UsrTbl> GetUserById(Guid id);
    public Task<ServiceResponse<UsrTbl>> CreateUsr(UsrTbl WebUser);
    public Task<ServiceResponse<bool>> UpdateUserStatus(Guid id, UsrTbl WebUser);
    public Task<ServiceResponse<bool>> UpdatePassword(Guid id, UsrTbl WebUser);
}