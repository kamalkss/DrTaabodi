using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DrTaabodi.Data.DatabaseContext;
using DrTaabodi.Data.Models;
using DrTaabodi.Services.UserTable;
using DrTaabodi.WebApi.DTO.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BCryptNet = BCrypt.Net.BCrypt;

namespace DrTaabodi.WebApi.Controllers;

[Route("/api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly DrTaabodiDbContext _db;
    private readonly ILogger<UsersController> _logger;
    private readonly IMapper _mapper;
    private readonly IUser _UserService;


    public UsersController(ILogger<UsersController> logger, DrTaabodiDbContext db, IUser user, IMapper mapper)
    {
        _logger = logger;
        _db = db;
        _UserService = user;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ReadUsers>> GetAllUsers()
    {
        _logger.LogInformation("Get All Users");
        var Users = await _UserService.GetAllUsers();
        return Ok(Users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReadUsers>> GetUser(Guid Id)
    {
        var User = await _UserService.GetUserById(Id);
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
    public async Task<ActionResult<Login>> Authenticate([FromBody] Login model)
    {
        var usergot = await _db.UsrTbl.FirstOrDefaultAsync(x => x.UserName == model.UserName);
        if (usergot == null || !BCryptNet.Verify(model.PassCode, usergot.PassCode))
            return Unauthorized("Username or password is incorrect");
        //return Ok($"User {usergot.UsrNickName} {usergot.UsrFamily} User Name : {usergot.UserName} with Id {usergot.UsrId} and Email {usergot.UsrEmail}");
        return Ok(_mapper.Map<ReadUsers>(usergot));
    }

    //Useless comments
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<ActionResult<CreateUsers>> Register([FromBody] CreateUsers model)
    {
        _logger.LogInformation("Create User Log");

        if (_db.UsrTbl.Any(x => x.UserName == model.UserName))
            return Unauthorized("Username '" + model.UserName + "' is already taken");

        // map model to new user object
        var MapUser = _mapper.Map<UsrTbl>(model);

        // hash password
        MapUser.PassCode = BCryptNet.HashPassword(model.PassCode);
        var NewUsr = await _UserService.CreateUsr(MapUser);

        return Ok($"{model.UserName} Has Been Created");
    }

    [HttpPatch]
    public async Task<ActionResult<UpdateUser>> Update_User([FromBody] UpdateUser updateuser)
    {
        _logger.LogInformation("UpdateUserStatus");
        var id = updateuser.UsrId;
        var user = _mapper.Map<UsrTbl>(updateuser);
        var updateduser = await _UserService.UpdateUserStatus(id, user);
        return Ok(updateduser);
    }

    [HttpPatch("UpdatePassword")]
    public async Task<ActionResult<UpdatePassword>> Update_Password([FromBody] UpdatePassword updateuser)
    {
        _logger.LogInformation("UpdateUserStatus");
        var id = updateuser.UsrId;
        var user = _mapper.Map<UsrTbl>(updateuser);
        user.PassCode = BCryptNet.HashPassword(updateuser.PassCode);
        var updateduser = await _UserService.UpdatePassword(id, user);
        return Ok(updateduser);
    }

    // for future MD%
    private static string GetMd5Hash(MD5 md5Hash, string input)
    {
        // Convert the input string to a byte array and compute the hash.
        var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        var sBuilder = new StringBuilder();
        for (var i = 0; i < data.Length; i++) sBuilder.Append(data[i].ToString("x2"));
        return sBuilder.ToString();
    }
}