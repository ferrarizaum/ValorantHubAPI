using Microsoft.AspNetCore.Mvc;
using ValorantHubAPI.Data.Context;
using ValorantHubAPI.Data.Entities;
using ValorantHubAPI.Data.Store;

namespace ValorantHubAPI.API.Services
{
    public interface IUserService
    {
        ICollection<UserEntity> GetUsers();
        UserEntity PostUser(UserEntity user);
        UserEntity UpdateUser(UserEntity user, string displayName);
        UserEntity RemoveUser(string displayName);
    }
    public class UserService : IUserService
    {
        private readonly IAppStore _appDbContext;//remove not beign used, was used for testing
        private readonly AppDbContext _dbContext;
        public UserService(IAppStore appDbContext,
                            AppDbContext appDbContext2)
        {
            _appDbContext = appDbContext;
            _dbContext = appDbContext2;
        }

        public ICollection<UserEntity> GetUsers()
        {
            var users = _dbContext.Users.ToList();
            return users;
        }

        public UserEntity PostUser(UserEntity user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public UserEntity RemoveUser(string userName)
        {
            var removedUser = _dbContext.Users.FirstOrDefault(a => a.userName == userName);

            if (removedUser == null)
            {
                return null;
            }

            _dbContext.Users.Remove(removedUser);
            _dbContext.SaveChanges();

            return removedUser;
        }

        public UserEntity UpdateUser(UserEntity user, string displayName)
        {
            throw new NotImplementedException();
        }


    }
}
