using Entities;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }
        public async Task<ApiResponse> CreateUser(User user)
        {
            try
            {
                user.Password = CryptService.Crypt(user.Password);
                await _repository.Insert(user);
                return new ApiResponse(HttpStatusCode.Created, $"User {user.Name} created successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteUser(int id)
        {
            try
            {
                await _repository.Delete(id);
                return new ApiResponse(HttpStatusCode.OK, $"User deleted successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<ApiResponse> EditUser(int id, User user)
        {
            try
            {
                var userToModify = await _repository.GetAsync(id);
                if (userToModify == null)
                    return new ApiResponse(HttpStatusCode.BadRequest, $"User not found");
                userToModify.Name = user.Name;
                userToModify.Email = user.Email;
                await _repository.Update(user);
                return new ApiResponse(HttpStatusCode.OK, $"User modified");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<ApiResponse> Login(User user)
        {
            try
            {
                user.Password = CryptService.Crypt(user.Password);
                var existUser = (await _repository.GetAll()).Any(u => u.Username == user.Username && u.Password == user.Password);
                if (existUser)
                    return new ApiResponse(HttpStatusCode.OK, $"");
                else
                    return new ApiResponse(HttpStatusCode.BadRequest, $"User not found");

            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
