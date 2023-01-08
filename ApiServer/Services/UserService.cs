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
        private readonly ITokenHandlerService _tokenService;

        public UserService(IRepository<User> repository, ITokenHandlerService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
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

        public async Task<LoginResponse> Login(LoginDTO userLogin)
        {
            try
            {
                userLogin.Password = CryptService.Crypt(userLogin.Password);
                var User = (await _repository.GetAll()).FirstOrDefault(u => u.Username == userLogin.Username && u.Password == userLogin.Password);
                if (User == null)
                    return new LoginResponse(null,User,HttpStatusCode.BadRequest, $"User not found");
                var token = _tokenService.GenerateJwtToken(new TokenParameters()
                {
                    Id = User.Id.ToString(),
                    PasswordHash = User.Password,
                    UserName = User.Username,
                });
                return new LoginResponse(token, User, HttpStatusCode.OK, $"Welcome {User.Name}");
            }
            catch (Exception ex)
            {
                return new LoginResponse(null, null, HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
