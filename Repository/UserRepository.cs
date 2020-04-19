using Microsoft.EntityFrameworkCore;
using userService.Repository;
using userService.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using userService.Model;

namespace userService.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _dbContext;

        public UserRepository(UserContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteUser(int userId)
        {
            var user = _dbContext.Users.Find(userId);
            _dbContext.Users.Remove(user);
            Save();
        }

        public User GetUserById(int userId)
        {
            return _dbContext.Users.Find(userId);
        }

        public IEnumerable<User> GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        public void InsertUser(User user)
        {
            _dbContext.Add(user);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateUser(User user, int userId)
        {
            User userToUpdate = _dbContext.Users.Find(userId);

            if (user.username != userToUpdate.username && user.username != null){
                userToUpdate.username = user.username; 
            }

            if (user.passhash != userToUpdate.passhash && user.passhash != null){
                userToUpdate.passhash = user.passhash;
            } 

            if (user.address != userToUpdate.address && user.address != null){
                userToUpdate.address = user.address;
            }

            if (user.cellphone != userToUpdate.cellphone && user.cellphone != 0){
                userToUpdate.cellphone = user.cellphone;
            }

            if (user.email != userToUpdate.email && user.email != null){
                userToUpdate.email = user.email;
            }


            _dbContext.Entry(userToUpdate).State = EntityState.Modified;
            Save();
        }

    }
}