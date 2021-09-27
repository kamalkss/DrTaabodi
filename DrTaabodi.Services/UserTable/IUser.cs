using DrTaabodi.Data.Models;
using System;
using System.Collections.Generic;

namespace DrTaabodi.Services.UserTable
{
    public interface IUser
    {
        public bool SaveChanges();
        public List<UsrTbl> GetAllUsers();
        public UsrTbl GetUserById(Guid id);
        public ServiceResponse<UsrTbl> CreateUsr(UsrTbl WebUser);
        public ServiceResponse<bool> UpdateUserStatus(Guid id, UserStatus UsrStatus);
        //AuthenticateResponse Authenticate(AuthenticateRequest model);
        //void Register(RegisterRequest model);
    }
}
