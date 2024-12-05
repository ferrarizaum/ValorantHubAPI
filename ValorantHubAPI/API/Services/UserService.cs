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
        private readonly IAppStore _appDbContext;
        private readonly AppDbContext _dbContext;
        public UserService(IAppStore appDbContext,
                            AppDbContext appDbContext2)
        {
            _appDbContext = appDbContext;
            _dbContext = appDbContext2;
        }

        public ICollection<UserEntity> GetUsers()
        {
            //var users = _dbContext.Users.ToList();
            //return users;
            throw new NotImplementedException();
        }

        public UserEntity PostUser(UserEntity user)
        {
            //_dbContext.Users.Add(user);
            //_dbContext.SaveChanges();
            //return user;
            throw new NotImplementedException();
        }

        public UserEntity RemoveUser(string displayName)
        {
            throw new NotImplementedException();
        }

        public UserEntity UpdateUser(UserEntity user, string displayName)
        {
            throw new NotImplementedException();
        }
    }
}
