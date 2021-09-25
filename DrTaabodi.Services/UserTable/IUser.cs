using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrTaabodi.Data.Models;

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
