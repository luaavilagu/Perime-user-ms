using Microsoft.AspNetCore.Mvc;
using userService.Model;
using userService.Repository;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace userService.Controllers
{
  [Route("perime-user-ms/[Controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {

    private readonly IUserRepository _userRepository;

    public UserController (IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }


    [HttpGet]
    public IActionResult Get()
    {
      try
      {
      var users = _userRepository.GetUsers();
      return new OkObjectResult(users);
      }
      catch(Exception)
      {
        return new StatusCodeResult(500);
      }
    }

    [HttpGet("{id}", Name = "Get")]
    public IActionResult Get(int id)
    {
      try
      {
        var user = _userRepository.GetUserById(id);
        return new OkObjectResult(user);
      }
      catch(Exception)
      {
        return new StatusCodeResult(500);
      }
      
    }

    [HttpPost]
    public IActionResult Post([FromBody] User user)
    {
      try
      {
        using (var scope = new TransactionScope())
        {
          _userRepository.InsertUser(user);
          scope.Complete();
          return CreatedAtAction(nameof(Get), new { id = user.id }, user);
        }
      }
      catch(Exception)
      {
        return new StatusCodeResult(500);
      }
      
    }

    [HttpPut]
    public IActionResult Put([FromBody] User user)
    {
      try
      {
        if (user != null)
        {
          using (var scope = new TransactionScope())
          {
            _userRepository.UpdateUser(user);
            scope.Complete();
            return new OkResult();
          }
        }
        return new NoContentResult();
      }
      catch(Exception)
      {
        return new StatusCodeResult(500);
      }
      
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      try
      {
        _userRepository.DeleteUser(id);
        return new OkResult();
      }
      catch(Exception)
      {
        return new StatusCodeResult(500);
      }

    }
  }
}