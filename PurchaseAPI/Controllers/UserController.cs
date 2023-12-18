using AutoMapper;
using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurchaseAPI.Entities;
using PurchaseAPI.Entities.Dto;
using PurchaseAPI.Services.IServices;

namespace PurchaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUser _userService;
        private readonly IJwt _jwtService;
        public UserController(IMapper mapper, IUser user, IJwt jwt)
        {
            _mapper = mapper;
            _userService = user;
            _jwtService = jwt;
        }
        [HttpPost("register")]
        public async Task<ActionResult<string>> RegisterUser(AddUserDto addUserDto)
        {
            var user = _mapper.Map<User>(addUserDto);

            user.Password = BCrypt.Net.BCrypt.HashPassword(addUserDto.Password);
            var checkUser = await _userService.GetUserByEmail(addUserDto.Email);
            if (checkUser != null)
            {
                return BadRequest("Email Already exists");
            }
            var response = await _userService.RegisterUsername(user);
            return Ok(response);


            //password is not encrypted - we need to encrypt
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> LoginUser(LogUserDto user)
        {

            var checkUser = await _userService.GetUserByEmail(user.Email);
            if (checkUser == null)
            {
                return BadRequest("Invalid Credentials");
            }

            //verify password
            var isCorrect = BCrypt.Net.BCrypt.Verify(user.Password, checkUser.Password);
            if (!isCorrect)
            {
                return BadRequest("Invalid Credentials");
            }

            var token = _jwtService.GenerateToken(checkUser);
            return Ok(token);
        }
    }
}
