using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Mvc.BadRequestResult;


namespace DatingApp.API.Controllers

{   [Route("api/[controller]")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {
            _repo=repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password) 
        {
               //validate request
               username=username.ToLower();
               if(await _repo.UserExists(username))

                 return BadRequest("nu");
            var userToCreate=new User {

               Username=username

            };
                var createdUser = await _repo.Register(userToCreate,password);
                return StatusCode(201);
        }


        
    }
}