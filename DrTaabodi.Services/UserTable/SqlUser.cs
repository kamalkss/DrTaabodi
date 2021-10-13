using DrTaabodi.Data.DatabaseContext;
using DrTaabodi.Data.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DrTaabodi.Services.UserTable
{
    public class SqlUser : IUser
    {
        private readonly DrTaabodiDbContext _context;
        private readonly ILogger<SqlUser> _logger;

        public SqlUser(DrTaabodiDbContext _db, ILogger<SqlUser> logger)
        {
            _context = _db;
            _logger = logger;
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public List<UsrTbl> GetAllUsers()
        {
            return _context.UsrTbl.ToList();
        }

        public UsrTbl GetUserById(Guid id)
        {
            return _context.UsrTbl.Find(id);
        }

        public ServiceResponse<UsrTbl> CreateUsr(UsrTbl WebUser)
        {
            _logger.LogInformation("Log For Creating User");
            try
            {
                WebUser.CreatedDate = DateTime.UtcNow;
                WebUser.UpdatedData = DateTime.UtcNow;
                _context.UsrTbl.Add(WebUser);
                SaveChanges();
                return new ServiceResponse<UsrTbl>
                {
                    IsSucceess = true,
                    Data = WebUser,
                    Messege = "New user Added",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<UsrTbl>
                {
                    IsSucceess = false,
                    Data = null,
                    Messege = e.Message,
                    Time = DateTime.UtcNow
                };
            }
        }

        public ServiceResponse<bool> UpdateUserStatus(Guid id, UsrTbl WebUser)
        {

            var UpdatedUser = _context.UsrTbl.Find(id);
            _logger.LogInformation("Log For Update User");
            try
            {
                WebUser.UpdatedData = DateTime.UtcNow;
                _context.UsrTbl.Update(UpdatedUser);
                SaveChanges();
                return new ServiceResponse<bool>
                {
                    IsSucceess = true,
                    Data = true,
                    Messege = " user Updated",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    IsSucceess = false,
                    Data = false,
                    Messege = e.Message,
                    Time = DateTime.UtcNow
                };
            }
        }

    }
}
