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

            if (user.username_user != userToUpdate.username_user && user.username_user != null){
                userToUpdate.username_user = user.username_user; 
            }

            if (user.passhash_user != userToUpdate.passhash_user && user.passhash_user != null){
                userToUpdate.passhash_user = user.passhash_user;
            } 

            if (user.address_user != userToUpdate.address_user && user.address_user != null){
                userToUpdate.address_user = user.address_user;
            }

            if (user.cellphone_user != userToUpdate.cellphone_user && user.cellphone_user != null){
                userToUpdate.cellphone_user = user.cellphone_user;
            }

            if (user.email_user != userToUpdate.email_user && user.email_user != null){
                userToUpdate.email_user = user.email_user;
            }


            _dbContext.Entry(userToUpdate).State = EntityState.Modified;
            Save();
        }

    }
}