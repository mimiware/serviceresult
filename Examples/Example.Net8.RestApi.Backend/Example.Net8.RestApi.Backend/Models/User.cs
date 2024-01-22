using System;

namespace Example.Net8.RestApi.Backend.Models;

public class User
{
    public Guid Id { get; set; }
    public required string Email { get; set; }
}
