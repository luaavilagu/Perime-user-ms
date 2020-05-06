using Microsoft.AspNetCore.Mvc;
using userService.Model;
using userService.Repository;
using userService.Controllers;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace userService.Controllers
{
  [Route("perime-user-ms/[controller]")]
  [ApiController]
  public class LoginController : ControllerBase
  {

    private readonly IUserRepository _userRepository;

    public LoginController (IUserRepository userRepository)
    {
      _userRepository = userRepository;
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
                return Ok(userGot);
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