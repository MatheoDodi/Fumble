using System.Threading.Tasks;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly IAuthRepository _repo;
    public AuthController(IAuthRepository repo)
    {
      _repo = repo;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(string username, string password)
    {
      // TODO
      // validate the request

      username = username.ToLower();

      if (await _repo.UserExists(username))
        return BadRequest("Username already exists");

      var userToCreate = new User
      {
        Username = username
      };

      var createdUser = _repo.Register(userToCreate, password);

      // TODO
      // implement a "CreatedAtRoute" when I create the route to get an individual user
      return StatusCode(201);
    }
  }
}