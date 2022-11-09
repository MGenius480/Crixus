using CrixusJa.iRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrixusJa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
       

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _unitOfWork.Users.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                Response.WriteAsync("<script>alert('An Error has Occurred #1')</script>");
                return StatusCode(500,ex.Message + "Internal Server Error.");

            }
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUser(string username)
        {
            try
            {
                var user = await _unitOfWork.Users.Get(a => a.username == username);
                return Ok(user);
            }
            catch (Exception ex)
            {
                Response.WriteAsync("<script>alert('An Error has Occurred #1')</script>");
                return StatusCode(500, ex.Message + "Internal Server Error.");
                
            }
        }
    }
}
