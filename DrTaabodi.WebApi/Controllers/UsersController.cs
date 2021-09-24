using System;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using DrTaabodi.Data.DatabaseContext;
using DrTaabodi.Data.Models;
using DrTaabodi.Services;
using DrTaabodi.Services.UserTable;
using DrTaabodi.WebApi.DTO.Users;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(_mapper.Map<ReadUsers>(User));
        }

        [HttpGet("{id}")]
        public ActionResult<ReadUsers> GetUser(Guid Id)
        {
            var User = _UserService.GetUserById(Id);
            return Ok(_mapper.Map<ReadUsers>(User));
        }

        [HttpPost]
        public ActionResult<ServiceResponse<CreateUsers>> CreateUser([FromBody] CreateUsers User)
        {
            _logger.LogInformation("Create User Log");
            User.CreatedDate = DateTime.UtcNow;
            User.UpdatedData = DateTime.UtcNow;
            
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, User.PassCode);
                User.PassCode = hash;
            }
            
            var MapUser = _mapper.Map<UsrTbl>(User);
            var NewUsr = _UserService.CreateUsr(MapUser);

            return Ok(NewUsr);
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
