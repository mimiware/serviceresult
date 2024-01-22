using System;
using System.Threading.Tasks;
using Example.Net8.RestApi.Backend.Factories;
using Example.Net8.RestApi.Backend.Repositories;
using Example.Net8.RestApi.Backend.ViewModels;
using Mimiware.ServiceResult;

namespace Example.Net8.RestApi.Backend.Services;

public interface IUserService
{
    Task<IServiceResult<UsersViewModel>> GetUsers(string? searchString);
}

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IServiceResult<UsersViewModel>> GetUsers(string? searchString)
    {
        var result = new ServiceResult<UsersViewModel>();
        var users = await Task.FromResult(_userRepository.GetUsers(searchString));

        try
        {
            var response = UsersViewModelFactory.Create(users);
            return result.Ok(response);
        }
        catch (Exception)
        {
            return result.Error(message: "Failed to get users");
        }
    }
}
