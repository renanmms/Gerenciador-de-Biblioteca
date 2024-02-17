using LibraryManager.API.Repositories.Interfaces;
using LibraryManager.API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userRepository.GetById(id);
            return Ok(user);
        }

        [HttpPost("create")]
        public IActionResult Post(UserViewModel user)
        {
            try
            {
                var id = _userRepository.Create(UserViewModel.ToEntity(user));
                return Created(nameof(GetById), new {id = id});
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}