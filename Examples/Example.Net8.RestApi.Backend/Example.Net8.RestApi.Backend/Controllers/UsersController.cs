using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Example.Net8.RestApi.Backend.Services;
using Example.Net8.RestApi.Backend.ViewModels;

namespace Example.Net8.RestApi.Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(ILogger<UsersController> logger, IUserService userService) : ControllerBase
{
    private readonly ILogger<UsersController> _logger = logger;
    private readonly IUserService _userService = userService;

    [HttpGet]
    public async Task<ActionResult<UsersViewModel>> GetUsers(string? searchString)
    {
        _logger.LogInformation("Searching for users");

        var result = await _userService.GetUsers(searchString);

        return result.IsSuccessCode 
            ? Ok(result.Data) 
            : StatusCode(result.Code, result.Data);
    }
}
