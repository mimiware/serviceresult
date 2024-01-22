using System.Collections.Generic;
using System.Linq;
using Example.Net8.RestApi.Backend.Models;
using Example.Net8.RestApi.Backend.ViewModels;

namespace Example.Net8.RestApi.Backend.Factories;

public static class UsersViewModelFactory
{
    public static UsersViewModel Create(List<User> users)
    {
        var response = new UsersViewModel
        {
            Users = users.Select(x => new UserViewModel
            {
                Id = x.Id,
                Email = x.Email
            }).ToList()
        };
        return response;
    }
}
