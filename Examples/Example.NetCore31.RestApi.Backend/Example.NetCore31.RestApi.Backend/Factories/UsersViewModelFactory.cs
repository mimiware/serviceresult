using System.Collections.Generic;
using System.Linq;
using Example.NetCore31.RestApi.Backend.Models;
using Example.NetCore31.RestApi.Backend.ViewModels;

namespace Example.NetCore31.RestApi.Backend.Factories
{
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
}
