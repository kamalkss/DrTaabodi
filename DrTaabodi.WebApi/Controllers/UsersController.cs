﻿using System;
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
    [Route("api/users")]
    [ApiController]
    public class UsersController:ControllerBase
    {
        private readonly IUser _UserService;
        private readonly DrTaabodiDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;

        
        public UsersController(ILogger<UsersController> logger,DrTaabodiDbContext db,IUser user,IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _UserService = user;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<UsrTbl> GetAllUsers()
        {
            _logger.LogInformation("Get All Users");
            var Users = _UserService.GetAllUsers();
            return Ok(_mapper.Map<ReadUsers>(Users));
        }

        [HttpGet("/api/users/{id}")]
        public ActionResult<UsrTbl> GetUser(Guid Id)
        {
            var User = _UserService.GetUserById(Id);
            return Ok(_mapper.Map<ReadUsers>(User));
        }

        [HttpPost("/api/users/")]
        public ActionResult<ServiceResponse<UsrTbl>> CreateUser([FromBody] CreateUsers User)
        {
            _logger.LogInformation("Create User Log");
            User.CreatedDate = DateTime.UtcNow;
            User.UpdatedData = DateTime.UtcNow;
            var MapUser = _mapper.Map<UsrTbl>(User);
            var NewUsr = _UserService.CreateUsr(MapUser);
            
            return Ok(NewUsr);
        }

    }
}
