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
        public UsrTbl GetUserById(int id);
        public ServiceResponse<UsrTbl> CreateUsr(UsrTbl WebUser);
        public ServiceResponse<bool> UpdateUserStatus(int id, UserStatus UsrStatus);
    }
}
