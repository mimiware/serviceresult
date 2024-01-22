using System;

namespace Example.Net8.RestApi.Backend.ViewModels;

public class UserViewModel
{
    public Guid Id { get; set; }
    public required string Email { get; set; }
}
