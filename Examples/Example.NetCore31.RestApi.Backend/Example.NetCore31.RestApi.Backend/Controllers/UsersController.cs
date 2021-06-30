using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Example.NetCore31.RestApi.Backend.Services;
using Example.NetCore31.RestApi.Backend.ViewModels;

namespace Example.NetCore31.RestApi.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;

        public UsersController(ILogger<UsersController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<UsersViewModel>> GetUsers(string searchString)
        {
            var result = await _userService.GetUsers(searchString);

            return result.IsSuccessCode 
                ? Ok(result.Data) 
                : StatusCode(result.Code, result.Data);
        }
    }
}
