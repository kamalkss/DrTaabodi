using DrTaabodi.Data.DatabaseContext;
using DrTaabodi.Data.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task<IEnumerable<UsrTbl>> GetAllUsers()
        {
            return await _context.UsrTbl.ToListAsync();
        }

        public async Task<UsrTbl> GetUserById(Guid id)
        {
            return await _context.UsrTbl.FindAsync(id);
        }

        public async Task<ServiceResponse<UsrTbl>> CreateUsr(UsrTbl WebUser)
        {
            _logger.LogInformation("Log For Creating User");
            try
            {
                WebUser.CreatedDate = DateTime.UtcNow;
                WebUser.UpdatedData = DateTime.UtcNow;
                await _context.UsrTbl.AddAsync(WebUser);
                await SaveChanges();
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

        public async Task<ServiceResponse<bool>> UpdateUserStatus(Guid id, UsrTbl WebUser)
        {

            var UpdatedUser = _context.UsrTbl.Find(id);
            _logger.LogInformation("Log For Update User");
            try
            {
                //output = (val % 2 == 1) ? "Number is odd" : "Number is even";


                var to_update = WebUser;
                to_update.UpdatedData = DateTime.UtcNow;
                //bullshir

                to_update.PassCode = (WebUser.PassCode != null) ? WebUser.PassCode : UpdatedUser.PassCode;

                _context.Entry(UpdatedUser).CurrentValues.SetValues(to_update);


                await SaveChanges();





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

        public async Task<ServiceResponse<bool>> UpdatePassword(Guid id, UsrTbl WebUser)
        {
            var UpdatedUser = _context.UsrTbl.Find(id);
            _logger.LogInformation("Log For Update User");
            try
            {
                //output = (val % 2 == 1) ? "Number is odd" : "Number is even";


                var to_update = WebUser;
                UpdatedUser.UpdatedData = DateTime.UtcNow;
                //bullshir

                UpdatedUser.PassCode = (WebUser.PassCode != null) ? WebUser.PassCode : UpdatedUser.PassCode;

                _context.Entry(UpdatedUser).CurrentValues.SetValues(UpdatedUser);


                await SaveChanges();
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
