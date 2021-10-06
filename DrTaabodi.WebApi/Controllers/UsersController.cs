using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using DrTaabodi.Data.DatabaseContext;
using DrTaabodi.Data.Models;
using DrTaabodi.Services;
using DrTaabodi.Services.UserTable;
using DrTaabodi.WebApi.DTO.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Logging;


namespace DrTaabodi.WebApi.Controllers
{
    [Route("/api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _UserService;
        private readonly DrTaabodiDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;


        public UsersController(ILogger<UsersController> logger, DrTaabodiDbContext db, IUser user, IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _UserService = user;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<ReadUsers> GetAllUsers()
        {
            _logger.LogInformation("Get All Users");
            var Users = _UserService.GetAllUsers();
            return Ok(Users);
        }

        [HttpGet("{id}")]
        public ActionResult<ReadUsers> GetUser(Guid Id)
        {
            var User = _UserService.GetUserById(Id);
            return Ok(_mapper.Map<ReadUsers>(User));
        }

        
        //public ActionResult<ServiceResponse<CreateUsers>> CreateUser([FromBody] CreateUsers User)
        //{
        //    _logger.LogInformation("Create User Log");
            
            
        //    using (MD5 md5Hash = MD5.Create())
        //    {
        //        string hash = GetMd5Hash(md5Hash, User.PassCode);
        //        User.PassCode = hash;
        //    }
            
        //    var MapUser = _mapper.Map<UsrTbl>(User);
        //    var NewUsr = _UserService.CreateUsr(MapUser);

        //    return Ok(NewUsr);
        //}
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ActionResult<CreateUsers> Authenticate([FromBody] Login model)
        {
            var usergot = _db.UsrTbl.FirstOrDefault(x => x.UserName == model.UserName);
            if (usergot == null || !BCryptNet.Verify(model.PassCode, usergot.PassCode))
                return Unauthorized("Username or password is incorrect");
            return Ok($"User {usergot.UsrNickName} {usergot.UsrFamily} User Name : {usergot.UserName} with Id {usergot.UsrId} and Email {usergot.UsrEmail}");
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public ActionResult<ReadUsers> Register([FromBody] CreateUsers model)
        {

            _logger.LogInformation("Create User Log");

            if (_db.UsrTbl.Any(x => x.UserName == model.UserName))
                return Unauthorized("Username '" + model.UserName + "' is already taken");

            // map model to new user object
            var MapUser = _mapper.Map<UsrTbl>(model);

            // hash password
            MapUser.PassCode = BCryptNet.HashPassword(model.PassCode);
            var NewUsr = _UserService.CreateUsr(MapUser);

            return Ok(NewUsr.Data.UserName + " Is Created");
        }
        [HttpPatch]
        public ActionResult<ReadUsers> Update_User([FromBody] ReadUsers updateuser)
        {
            _logger.LogInformation("UpdateUserStatus");
            var id = updateuser.UsrId;
            var userStaus = updateuser.UsrStatus;
            var updateduser = _UserService.UpdateUserStatus(id, userStaus);
            return Ok(updateduser);

        }
        // for future MD%
        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
