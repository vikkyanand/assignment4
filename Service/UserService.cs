using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using UserManagement.Models;

namespace UserManagement.Services
{
    public class UserService
    {
        private readonly IMongoCollection<UserModel> _users;

        public UserService(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            _users = database.GetCollection<UserModel>("Users");
        }

        public List<UserModel> Get()
        {
            try
            {
                return _users.Find(user => true).ToList();
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                throw; // Re-throw the exception
            }
        }

        public UserModel Get(string id)
        {
            try
            {
                return _users.Find<UserModel>(user => user.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                throw; // Re-throw the exception
            }
        }
        public UserModel Create(UserModel user)
        {
            try
            {
                _users.InsertOne(user);
                return user;
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                throw; // Re-throw the exception
            }
        }

        public void Update(string id, UserModel userIn)
        {
            try
            {
                _users.ReplaceOne(user => user.Id == id, userIn);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                throw; // Re-throw the exception
            }
        }

        public void Remove(UserModel userIn)
        {
            try
            {
                _users.DeleteOne(user => user.Id == userIn.Id);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                throw; // Re-throw the exception
            }
        }

        public void Remove(string id)
        {
            try
            {
                _users.DeleteOne(user => user.Id == id);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                throw; // Re-throw the exception
            }
        }
    }
}
