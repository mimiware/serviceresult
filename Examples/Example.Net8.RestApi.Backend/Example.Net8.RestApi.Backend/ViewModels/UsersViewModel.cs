using System.Collections.Generic;

namespace Example.Net8.RestApi.Backend.ViewModels;

public class UsersViewModel
{
    public required List<UserViewModel> Users { get; set; }
}
