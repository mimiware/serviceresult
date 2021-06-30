using System;
using System.Collections.Generic;
using System.Linq;
using Example.NetCore31.RestApi.Backend.Models;

namespace Example.NetCore31.RestApi.Backend.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers(string searchString);
    }

    public class UserRepository : IUserRepository
    {
        public List<User> GetUsers(string searchString)
        {
            const string blockedDomain = "@hotmail.com";
            if (searchString != null && searchString.Contains(blockedDomain))
            {
                throw new ArgumentException("Will not search for hotmails");
            }

            var users = new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    Email = "a@b.com"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Email = "c@d.com"
                }
            };

            return users
                .Where(x => x.Email.Contains(searchString))
                .ToList();
        }
    }
}
