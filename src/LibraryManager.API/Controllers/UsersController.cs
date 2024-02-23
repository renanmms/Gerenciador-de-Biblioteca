using LibraryManager.Application.Services.Interfaces;
using LibraryManager.Application.ViewModels;
using LibraryManager.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }

        [HttpPost("create")]
        public IActionResult Post(UserViewModel user)
        {
            try
            {
                var id = _userService.Create(user);
                return Created(nameof(GetById), new {id = id});
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}