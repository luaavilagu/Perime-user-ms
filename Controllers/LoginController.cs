using Microsoft.AspNetCore.Mvc;
using userService.Model;
using userService.Repository;
using userService.Controllers;
using System;
using System.Collections.Generic;
using System.Transactions;

using Microsoft.Extensions.Configuration;
using userService.Service;

namespace userService.Controllers
{
  [Route("perime-user-ms/[controller]")]
  [ApiController]
  public class LoginController : ControllerBase
  {

    private readonly IUserRepository _userRepository;
    private IConfiguration _config;
    public LoginController (IUserRepository userRepository, IConfiguration config)
    {
      _userRepository = userRepository;
      _config = config;
    }


    [HttpPost]
    public IActionResult Post([FromBody] Login login)
    {
      try
      {
          var userGot =_userRepository.GetUserByEmail(login.email);
          if (userGot != null)
          {
          
            if (_userRepository.CheckMatch(userGot.passhash_user, login.password))
            {
              var jwt = new JwtService(_config);
              var token = jwt.GenerateSecurityToken(userGot);
              return Ok(token);
            }
            else
            {
              return Content("Invalid Password");
            }
          }
          else
          {
            return Content("User not found!");
          }   
      }
      catch(Exception)
      {
          return new StatusCodeResult(500);
      } 
    }
  }
}